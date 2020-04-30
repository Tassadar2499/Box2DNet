using SFML.System;
using System;

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
		public readonly Vector2f FirstColumnRotation => Rotation.FirstColumn;
		public readonly Vector2f SecondColumnRotation => Rotation.SecondColumn;

		public static readonly XForm Identity = new XForm(new Vector2f(0, 0), SquareMatrix.Identity);

		/// <summary>
		/// Initialize using a position vector and a rotation matrix.
		/// </summary>
		public XForm(Vector2f position, SquareMatrix rotation)
		{
			Position = position;
			Rotation = rotation;
		}

		/// <summary>
		/// Calculate the angle that the rotation matrix represents.
		/// </summary>
		public float GetAngle()
			=> (float) Math.Atan2(FirstColumnRotation.Y, FirstColumnRotation.X);

		public Vector2f TransformPoint(Vector2f vector)
			=> Position + TransformDirection(vector);

		public Vector2f TransformDirection(Vector2f vector)
			=> Rotation * vector;

		public Vector2f InverseTransformPoint(Vector2f vector)
			=> InverseTransformDirection(vector - Position);

		public Vector2f InverseTransformDirection(Vector2f vector)
			=> Rotation.InverseMultiply(vector);
	}
}
