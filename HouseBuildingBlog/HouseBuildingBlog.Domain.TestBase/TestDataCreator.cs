using System;

namespace HouseBuildingBlog.Domain.TestBase
{
	public static class TestDataCreator
	{
		public static byte[] CreateRandomBytes()
		{
			var data = new byte[1024];
			new Random().NextBytes(data);
			return data;
		}
	}
}
