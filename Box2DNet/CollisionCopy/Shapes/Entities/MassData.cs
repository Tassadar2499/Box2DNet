using SFML.System;

namespace Box2DNet.CollisionCopy.Shapes.Entities
{
	/// <summary>
	/// This holds the mass data computed for a shape.
	/// </summary>
	public struct MassData
	{
		/// <summary>
		/// The mass of the shape, usually in kilograms.
		/// </summary>
		public float Mass;

		/// <summary>
		/// The position of the shape's centroid relative to the shape's origin.
		/// </summary>
		public Vector2f Center;

		/// <summary>
		/// The rotational inertia of the shape.
		/// </summary>
		public float Inertia;
	}
}
