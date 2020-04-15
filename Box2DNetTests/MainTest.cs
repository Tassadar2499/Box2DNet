using System;
using Xunit;
using Box2DNet;
using Box2DNet.Dynamics;

namespace Box2DNetTests
{
	public class MainTest
	{
		[Fact]
		public void Test1()
		{
			var rofl = new World(default, default, default);
			Assert.Equal(null, null);
		}
	}
}
