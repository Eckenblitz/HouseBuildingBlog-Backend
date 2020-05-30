using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class CreateTagHandler : IRequestHandler<CreateTagCommand, IActionResult>
	{
		private readonly IWriteRepository<ITag> _repo;

		public CreateTagHandler(IWriteRepository<ITag> repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(CreateTagCommand request, CancellationToken cancellationToken)
		{
			var tag = new Tag(Guid.NewGuid(), request.Title);

			await _repo.Save(tag);

			return new CreatedResult(string.Empty, new { tag.TagId });
		}
	}
}
