using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, IActionResult>
	{
		private readonly ITagRepository _repo;

		public UpdateTagHandler(ITagRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
		{
			var tag = await _repo.Get(request.TagId);
			tag.UpdateTitle(request.Data.Title);
			await _repo.Save(tag);
			return new OkResult();
		}
	}
}
