using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, IActionResult>
	{
		private readonly ITagRepository _repo;

		public DeleteTagHandler(ITagRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
		{
			await _repo.Delete(request.TagId);
			return new OkResult();
		}
	}
}
