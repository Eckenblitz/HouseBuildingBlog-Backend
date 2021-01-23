using System;

namespace HouseBuildingBlog.Domain.Tests.Extensions
{
	public static class TestDataCreator
	{
		public static byte[] CreateRandomBytes()
		{
			var data = new Byte[1024];
			new Random().NextBytes(data);
			return data;
		}
	}
}
