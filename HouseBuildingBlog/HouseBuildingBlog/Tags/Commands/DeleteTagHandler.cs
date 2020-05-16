using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, IActionResult>
	{
		private readonly IWriteRepository<Tag> _writeRepo;
		private readonly IReadRepository<Tag> _readRepo;

		public DeleteTagHandler(IWriteRepository<Tag> writeRepo, IReadRepository<Tag> readRepo)
		{
			_writeRepo = writeRepo;
			_readRepo = readRepo;
		}

		public async Task<IActionResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
		{
			var tag = await _readRepo.GetById(request.TagId);

			if (tag == null)
				return new NotFoundResult();

			await _writeRepo.Delete(tag.TagId);

			return new OkResult();
		}
	}
}
