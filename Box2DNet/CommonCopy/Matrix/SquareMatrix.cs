using SFML.System;
using System;
using System.Numerics;

namespace Box2DNet.CommonCopy
{
	/// <summary>
	/// Квадратная матрица немного ебанутого вида:
	/// x : | a c |
	/// y : | b d |
	/// Вектора - (a, b) и (c, d) где a - x1, b - y1, c - x2, d - y2
	/// БУДЬ ВНИМАТЕЛЕН БОЕЦ
	/// Примечание - обычно матрица представляется в виде - 
	/// |a b|
	/// |c d|
	/// </summary>
	public struct SquareMatrix
	{
		public (Vector2f First, Vector2f Second) Columns;
		public Vector2f FirstColumn => Columns.First;
		public Vector2f SecondColumn => Columns.Second;
		/// <summary>
		/// Определитель матрицы
		/// </summary>
		public float Determinant => FirstColumn.X * SecondColumn.Y - SecondColumn.X * FirstColumn.Y;

		public float InverseDeterminant
		{
			get
			{
				if (Determinant == 0.0f)
					throw new Exception("Невозможно получить обратный определитель, так как определитель равен 0");

				return 1.0f / Determinant;
			}
		}

		public static SquareMatrix Identity = new SquareMatrix(1, 0, 0, 1);

		public SquareMatrix((Vector2f First, Vector2f Second) columns)
		{
			Columns = columns;
		}

		//TO DO: Тут нужно внимательно все проверить, чтобы не было обсеров
		public SquareMatrix(float a, float b, float c, float d)
		{
			Columns.First.X = a;
			Columns.First.Y = b;
			Columns.Second.X = c;
			Columns.Second.Y = d;
		}

		public SquareMatrix(float angle)
		{
			float cos = (float)Math.Cos(angle);
			float sin = (float)Math.Sin(angle);
			Columns.First.X = cos;
			Columns.First.Y = sin;
			Columns.Second.X = -sin;
			Columns.Second.Y = cos;
		}

		public static SquareMatrix operator +(SquareMatrix A, SquareMatrix B)
		{
			SquareMatrix C = new SquareMatrix();
			C.Set((A.FirstColumn + B.FirstColumn, A.SecondColumn + B.SecondColumn));
			return C;
		}

		/// <summary>
		/// Initialize this matrix using columns.
		/// </summary>
		public void Set((Vector2f First, Vector2f Second) columns)
		{
			Columns = columns;
		}

		/// <summary>
		/// Initialize this matrix using an angle.
		/// This matrix becomes an orthonormal rotation matrix.
		/// </summary>
		public void Set(float angle)
		{
			float cos = (float)Math.Cos(angle);
			float sin = (float)Math.Sin(angle);
			Columns.First.X = cos;
			Columns.First.Y = sin;
			Columns.Second.X = -sin;
			Columns.Second.Y = cos;
		}

		/// <summary>
		/// Extract the angle from this matrix (assumed to be a rotation matrix).
		/// </summary>
		public float GetAngle()
			=> (float)Math.Atan2(FirstColumn.Y, FirstColumn.X);

		public Vector2f Multiply(Vector2f vector)
			=> new Vector2f(FirstColumn.X * vector.Y + SecondColumn.X * vector.Y, FirstColumn.Y * vector.X + SecondColumn.Y * vector.Y);

		/// <summary>
		/// Compute the inverse of this matrix, such that inv(A) * A = identity.
		/// </summary>
		public SquareMatrix GetInverse()
		{
			var firstColumn = new Vector2f(InverseDeterminant * SecondColumn.Y, -InverseDeterminant * FirstColumn.Y);
			var secondColumn = new Vector2f(-InverseDeterminant * SecondColumn.X, InverseDeterminant * FirstColumn.X);
			
			return new SquareMatrix((firstColumn, secondColumn));
		}

		/// <summary>
		/// Solve A * x = b, where b is a column vector. This is more efficient
		/// than computing the inverse in one-shot cases.
		/// </summary>
		public Vector2f Solve(Vector2f b)
			=> new Vector2f
			(
				InverseDeterminant * (SecondColumn.Y * b.X - SecondColumn.X * b.Y),
				InverseDeterminant * (FirstColumn.X * b.Y - FirstColumn.Y * b.X)
			);
	}
}
