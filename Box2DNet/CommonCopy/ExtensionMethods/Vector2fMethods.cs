using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using _Consts = Box2DNet.CommonCopy.Consts.Consts;

namespace Box2DNet.CommonCopy.ExtensionMethods
{
	public static class Vector2fMethods
	{
		public static Vector3f ToVector3f(this Vector2f vector)
			=> new Vector3f(vector.X, vector.Y, 0.0f);

		public static Vector2f Multiply(this Vector2f first, Vector2f second)
			=> new Vector2f(first.X * second.X, first.Y * second.Y);

		/// <summary>
		/// Установка новых координат для вектора
		/// </summary>
		public static void Set(this Vector2f vector, float x, float y)
		{
			vector.X = x;
			vector.Y = y;
		}

		/// <summary>
		///  Get the length of this vector (the norm).
		/// </summary>
		public static float GetLength(this Vector2f vector)
			=> (float)System.Math.Sqrt(GetLengthSquared(vector));

		/// <summary>
		/// Get the length squared. For performance, use this instead of
		/// Length (if possible).
		/// </summary>
		public static float GetLengthSquared(this Vector2f vector)
			=> vector.X * vector.X + vector.Y * vector.Y;

		/// <summary>
		/// Конвертация вектора в единичный вектор
		/// </summary>
		public static Vector2f GetNormalizedVector(this Vector2f vector)
		{
			float length = GetLength(vector);

			return length < _Consts.FLT_EPSILON ? new Vector2f(0.0f, 0.0f) : vector / length;
		}

		/// <summary>
		/// Скалярное произведение векторов
		/// </summary>
		public static float Dot(this Vector2f first, Vector2f second)
			=> first.X * second.X + first.Y * second.Y;

		/// <summary>
		/// Векторное произведение векторов в 2D это скаляр
		/// </summary>
		public static float Cross(this Vector2f first, Vector2f second)
			=> first.X * second.Y - first.Y * second.X;

		/// <summary>
		/// Векторное произведение вектора и скаляра
		/// в 2D это вектор
		/// </summary>
		public static Vector2f Cross(this Vector2f vector, float number)
			=> new Vector2f(number * vector.Y, -number * vector.X);

		public static Vector2f CrossScalarPreMultiply(this Vector2f vector, float number)
			=> Cross(vector, -number);

		public static float Distance(this Vector2f first, Vector2f second)
			=> (first - second).GetLength();

		public static float DistanceSquared(this Vector2f first, Vector2f second)
		{
			var difVector = first - second;
			return difVector.Dot(difVector);
		}

		public static Vector2f Abs(this Vector2f vector)
			=> new Vector2f(System.Math.Abs(vector.X), System.Math.Abs(vector.Y));

		public static Vector2f Min(Vector2f first, Vector2f second)
			=> new Vector2f(System.Math.Min(first.X, second.X), System.Math.Min(first.Y, second.Y));

		public static Vector2f Max(Vector2f first, Vector2f second)
			=> new Vector2f(System.Math.Max(first.X, second.X), System.Math.Max(first.Y, second.Y));
	}
}
