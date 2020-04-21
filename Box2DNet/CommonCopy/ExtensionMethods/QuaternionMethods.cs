using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Box2DNet.CommonCopy.ExtensionMethods
{
	public static class QuaternionMethods
	{
		public static Vector3f GetVector3f(this Quaternion quaternion)
			=> new Vector3f(quaternion.X, quaternion.Y, quaternion.Z);

		public static Quaternion FromAngle2D(float radians)
			=> Quaternion.CreateFromAxisAngle(new Vector3(0, 0, 1), radians * (float)(360.0 / (Math.PI * 2)));
	}
}
