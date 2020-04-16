using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Box2DNet.CommonCopy.ExtensionMethods
{
	public static class QuaternionExtensions
	{
		public static Vector3f GetVector3f(this Quaternion quaternion)
			=> new Vector3f(quaternion.X, quaternion.Y, quaternion.Z);
	}
}
