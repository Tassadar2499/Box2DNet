using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Box2DNet.CommonCopy
{
	/// <summary>
	/// A transform contains translation and rotation.
	/// It is used to represent the position and orientation of rigid frames.
	/// </summary>
	public readonly struct XForm
	{
		public readonly Vector2f Position;
		public readonly SquareMatrix Rotation;

		public static readonly XForm Identity = new XForm(new Vector2f(0, 0), SquareMatrix.Identity);

		/// <summary>
		/// Initialize using a position vector and a rotation matrix.
		/// </summary>
		public XForm(Vector2f position, SquareMatrix rotation)
		{
			Position = position;
			Rotation = rotation;
		}

		///// Calculate the angle that the rotation matrix represents.
		/// <summary>
		/// Calculate the angle that the rotation matrix represents.
		/// </summary>
		public float GetAngle()
			=> (float) Math.Atan2(Rotation.FirstColumn.Y, Rotation.FirstColumn.X);

		///// Calculate the angle that the rotation matrix represents.
		//public float GetAngle()
		//{
		//	return Math.Atan2(R.Col1.Y, R.Col1.X);
		//}

		//public Vector2 TransformDirection(Vector2 vector)
		//{
		//	return Math.Mul(R, vector);
		//}

		//public Vector2 InverseTransformDirection(Vector2 vector)
		//{
		//	return Math.MulT(R, vector);
		//}

		//public Vector2 TransformPoint(Vector2 vector)
		//{
		//	return position + Math.Mul(R, vector);
		//}

		//public Vector2 InverseTransformPoint(Vector2 vector)
		//{
		//	return Math.MulT(R, vector - position);
		//}


	}
}
