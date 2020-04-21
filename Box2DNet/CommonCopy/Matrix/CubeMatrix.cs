using Box2DNet.CommonCopy.ExtensionMethods;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Box2DNet.CommonCopy
{
	public class CubeMatrix
	{
		public (Vector3f First, Vector3f Second, Vector3f Third) Columns;
		public Vector3f FirstColumn => Columns.First;
		public Vector3f SecondColumn => Columns.Second;
		public Vector3f ThirdColumn => Columns.Third;
		/// <summary>
		/// Определитель матрицы
		/// </summary>
		public float Determinant => CalculateDeterminant(FirstColumn, SecondColumn, ThirdColumn);

		public float InverseDeterminant
		{
			get
			{
				if (Determinant == 0.0f)
					throw new Exception("Невозможно получить обратный определитель, так как определитель равен 0");

				return 1.0f / Determinant;
			}
		}

		/// <summary>
		/// Construct this matrix using columns.
		/// </summary>
		public CubeMatrix(Vector3f first, Vector3f second, Vector3f third)
		{
			Columns.First = first;
			Columns.Second = second;
			Columns.Third = third;
		}

		/// <summary>
		/// Set this matrix to all zeros.
		/// </summary>
		public void SetZero()
		{
			Columns.First = new Vector3f(0, 0, 0);
			Columns.Second = new Vector3f(0, 0, 0);
			Columns.Third = new Vector3f(0, 0, 0);
		}

		///// <summary>
		///// Solve A * x = b, where b is a column vector. This is more efficient
		///// than computing the inverse in one-shot cases.
		///// </summary>
		public Vector3f Solve33(Vector3f b)
			=> new Vector3f
			(
				InverseDeterminant * CalculateDeterminant(b, SecondColumn, ThirdColumn),
				InverseDeterminant * CalculateDeterminant(FirstColumn, b, ThirdColumn),
				InverseDeterminant * CalculateDeterminant(FirstColumn, SecondColumn, b)
			);

		/// <summary>
		/// Solve A * x = b, where b is a column vector. This is more efficient
		/// than computing the inverse in one-shot cases. Solve only the upper
		/// 2-by-2 matrix equation.
		/// </summary>
		public Vector2f Solve22(Vector2f b)
			=> new SquareMatrix((FirstColumn.ToVector2f(), SecondColumn.ToVector2f())).Solve(b);

		private static float CalculateDeterminant(Vector3f first, Vector3f second, Vector3f third)
			=> Vector3fMethods.Dot(first, Vector3fMethods.Cross(second, third));
	}
}
