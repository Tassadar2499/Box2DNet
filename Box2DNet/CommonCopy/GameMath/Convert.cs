using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Box2DNet.CommonCopy.Math
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Convert
	{
		[FieldOffset(0)]
		public float x;

		[FieldOffset(0)]
		public int i;
	}
}
