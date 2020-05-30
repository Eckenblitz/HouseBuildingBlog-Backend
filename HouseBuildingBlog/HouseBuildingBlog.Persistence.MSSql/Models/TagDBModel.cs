using HouseBuildingBlog.Domain;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class TagDBModel : ITag
	{
		public Guid TagId { get; private set; }

		public string Title { get; private set; }

		public Tag ConvertToDomain()
		{
			return new Tag(TagId, Title);
		}
	}
}