using Box2DNet.CommonCopy.ExtensionMethods;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Box2DNet.CommonCopy.Math
{
	public static class GameMath
	{
		public static float Rad2Deg = 57.29578f;
		public static float Epsilon = 1.401298E-45f;

		//Какая-то магия с небезопасным кодом, нид протестировать
		/// <summary>
		/// This is a approximate yet fast inverse square-root.
		/// </summary>
		public static float InvSqrt(float x)
		{
			Convert convert = new Convert
			{
				x = x
			};

			convert.i = 0x5f3759df - (convert.i >> 1);
			x = convert.x;

			return x * (1.5f - 0.5f * x * x * x);
		}

		public static float Clamp(float f, float min, float max)
		{
			if (f < min)
				return min;

			if (f > max)
				return max;

			return f;
		}

		/// <summary>
		/// "Next Largest Power of 2
		/// Given a binary integer value x, the next largest power of 2 can be computed by a SWAR algorithm
		/// that recursively "folds" the upper bits into the lower bits. This process yields a bit vector with
		/// the same most significant 1 as x, but all 1's below it. Adding 1 to that value yields the next
		/// largest power of 2. For a 32-bit value:"
		/// </summary>
		public static uint NextPowerOfTwo(uint x)
		{
			x |= (x >> 1);
			x |= (x >> 2);
			x |= (x >> 4);
			x |= (x >> 8);
			x |= (x >> 16);

			return x + 1;
		}

		public static bool IsPowerOfTwo(uint x)
			=> x > 0 && (x & (x - 1)) == 0;

		public static Vector2f Abs(Vector2f vector)
			=> new Vector2f(System.Math.Abs(vector.X), System.Math.Abs(vector.Y));

		public static SquareMatrix Abs(SquareMatrix A)
			=> new SquareMatrix((Abs(A.FirstColumn), Abs(A.SecondColumn)));

		public static Vector2f Clamp(Vector2f a, Vector2f low, Vector2f high)
			=> Vector2fMethods.Max(low, Vector2fMethods.Min(a, high));

		public static void Swap<T>(ref T a, ref T b)
		{
			T tmp = a;
			a = b;
			b = tmp;
		}
	}
}
