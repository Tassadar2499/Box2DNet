//using Box2DNet.CollisionCopy.Shapes.Entities;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

using Box2DNet.Common;
using Transform = Box2DNet.Common.Transform;
using Box2DNet.Collision;

namespace Box2DNet.CollisionCopy.Shapes
{
	/// <summary>
	/// The various collision shape types supported by Box2D.
	/// </summary>
	public enum ShapeType
	{
		UnknownShape = -1,
		CircleShape,
		PolygonShape,
		EdgeShape,
		ShapeTypeCount,
	}

	/// <summary>
	/// Returns code from TestSegment
	/// </summary>
	public enum SegmentCollide
	{
		StartInsideCollide = -1,
		MissCollide = 0,
		HitCollide = 1
	}

	/// <summary>
	/// A shape is used for collision detection. You can create a shape however you like.
	/// Shapes used for simulation in World are created automatically when a Fixture is created.
	/// </summary>
	public interface IShape : IDisposable
	{
		#region Fields

		//protected ShapeType _type = ShapeType.UnknownShape;
		//internal float _radius;

		#endregion Fields

		/// <summary>
		/// Test a point for containment in this shape. This only works for convex shapes.
		/// </summary>
		/// <param name="xf">The shape world Transform.</param>
		/// <param name="p">A point in world coordinates.</param>
		/// <returns></returns>
		public bool TestPoint(Transform xf, Vector2f p);

		/// <summary>
		/// Perform a ray cast against this shape.
		/// </summary>
		/// <param name="xf">The shape world Transform.</param>
		/// <param name="lambda">Returns the hit fraction. You can use this to compute the contact point
		/// p = (1 - lambda) * segment.P1 + lambda * segment.P2.</param>
		/// <param name="normal"> Returns the normal at the contact point. If there is no intersection, 
		/// the normal is not set.</param>
		/// <param name="segment">Defines the begin and end point of the ray cast.</param>
		/// <param name="maxLambda">A number typically in the range [0,1].</param>
		public SegmentCollide TestSegment(Transform xf, out float lambda, out Vector2f normal, Segment segment, float maxLambda);

		/// <summary>
		/// Given a Transform, compute the associated axis aligned bounding box for this shape.
		/// </summary>
		/// <param name="aabb">Returns the axis aligned box.</param>
		/// <param name="xf">The world Transform of the shape.</param>
		public void ComputeAABB(out AABB aabb, Transform xf);

		/// <summary>
		/// Compute the mass properties of this shape using its dimensions and density.
		/// The inertia tensor is computed about the local origin, not the centroid.
		/// </summary>
		/// <param name="massData">Returns the mass data for this shape</param>
		public Box2DNet.CollisionCopy.Shapes.Entities.MassData ComputeMass(float density);

		/// <summary>
		/// Compute the volume and centroid of this shape intersected with a half plane.
		/// </summary>
		/// <param name="normal">Normal the surface normal.</param>
		/// <param name="offset">Offset the surface offset along normal.</param>
		/// <param name="xf">The shape Transform.</param>
		/// <param name="c">Returns the centroid.</param>
		/// <returns>The total volume less than offset along normal.</returns>
		public float ComputeSubmergedArea(Vector2f normal, float offset, Transform xf, out Vector2f c);

		/// <summary>
		/// Compute the sweep radius. This is used for conservative advancement (continuous collision detection).
		/// </summary>
		/// <param name="pivot">Pivot is the pivot point for rotation.</param>
		/// <returns>The distance of the furthest point from the pivot.</returns>
		public float ComputeSweepRadius(Vector2f pivot);

		public Vector2f GetVertex(int index);

		public int GetSupport(Vector2f d);

		public Vector2f GetSupportVertex(Vector2f d);
	}
}
