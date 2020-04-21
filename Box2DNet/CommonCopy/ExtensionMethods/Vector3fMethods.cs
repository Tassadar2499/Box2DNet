using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Box2DNet.CommonCopy.ExtensionMethods
{
	public static class Vector3fMethods
	{
		public static Vector2f ToVector2f(this Vector3f vector)
			=> new Vector2f(vector.X, vector.Y);

		public static Vector3f Multiply(this Vector3f first, Vector3f second)
			=> new Vector3f(first.X * second.X, first.Y * second.Y, first.Z * second.Z);

		/// <summary>
		/// Установка новых координат для вектора
		/// </summary>
		public static void Set(this Vector3f vector, float x, float y, float z)
		{ 
			vector.X = x;
			vector.Y = y;
			vector.Z = z; 
		}

		/// <summary>
		/// Скалярное произведение векторов
		/// </summary>
		public static float Dot(this Vector3f first, Vector3f second)
			=> first.X * second.X + first.Y * second.Y + first.Z * second.Z;

		/// <summary>
		/// Векторное произведение векторов
		/// </summary>
		public static Vector3f Cross(this Vector3f a, Vector3f b)
			=> new Vector3f(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
	}
}
