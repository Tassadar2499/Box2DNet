using Box2DNet.CommonCopy.ExtensionMethods;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Box2DNet.CommonCopy
{
	/// <summary>
	/// A Transform contains translation and rotation.
	/// It is used to represent the position and orientation of rigid frames.
	/// </summary>
	public struct Transform
	{
		public Vector2f Position;
		public Quaternion Rotation;
		public static readonly Transform Identity = new Transform(new Vector2f(0, 0), Quaternion.Identity);

		/// <summary>
		/// Initialize using a position vector and a rotation matrix.
		/// </summary>
		public Transform(Vector2f position, Quaternion rotation)
		{
			Position = position;
			Rotation = rotation;
		}

		#region By Inverse
		public Vector2f InverseTransformPoint(Vector2f vector)
			=> InverseTransform(vector - Position);

		public Vector2f InverseTransformDirection(Vector2f vector)
			=> InverseTransform(vector);

		private Vector2f InverseTransform(Vector2f vector)
			=> GetInverseTransformVector().Multiply(vector);

		private Vector2f GetInverseTransformVector()
			=> Quaternion.Inverse(Rotation).GetVector3f().ToVector2f();
		#endregion

		#region By Default
		public Vector2f TransformPoint(Vector2f vector)
			=> Position + GetTransformVector(vector);

		public Vector2f TransformDirection(Vector2f vector)
			=> GetTransformVector(vector);

		private Vector2f GetTransformVector(Vector2f vector)
			=> (Rotation.GetVector3f().Multiply(vector.ToVector3f())).ToVector2f();
		#endregion
	}
}
