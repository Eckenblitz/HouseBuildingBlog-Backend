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
		private readonly ITagRepository _repo;

		public CreateTagHandler(ITagRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(CreateTagCommand request, CancellationToken cancellationToken)
		{
			await _repo.Save(new Domain.Tag(Guid.NewGuid(), request.Data.Title));
			return new OkResult();
		}
	}
}
