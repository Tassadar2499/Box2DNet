using Box2DNet.CommonCopy.ExtensionMethods;
using SFML.System;
using System.Numerics;

namespace Box2DNet.CommonCopy
{
	/// <summary>
	/// Трансформация - содержит перевод и вращение.
	/// Используется для представления положения и ориентации жестких фреймов.
	/// </summary>
	public readonly struct Transform
	{
		/// <summary>
		/// Текущая поиция
		/// </summary>
		public readonly Vector2f Position;
		/// <summary>
		/// Матрица вращения
		/// </summary>
		public readonly Quaternion Rotation;
		public static readonly Transform Identity = new Transform(new Vector2f(0, 0), Quaternion.Identity);

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
