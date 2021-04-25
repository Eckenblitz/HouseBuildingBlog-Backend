using HouseBuildingBlog.Api.Images.Queries.Contracts;
using MediatR;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Images.Commands
{
	public class CreateGalleryCommand : IRequest<GalleryQueryDto>
	{
		public string Title { get; }

		public IList<Guid> TagIds { get; }

		public CreateGalleryCommand(string title, IList<Guid> tagIds)
		{
			Title = title;
			TagIds = tagIds;
		}
	}
}
