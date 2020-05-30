using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, IActionResult>
	{
		private readonly IWriteRepository<ITag> _writeRepo;
		private readonly IReadRepository<ITag> _readRepo;

		public UpdateTagHandler(IWriteRepository<ITag> writeRepo, IReadRepository<ITag> readRepo)
		{
			_writeRepo = writeRepo;
			_readRepo = readRepo;
		}

		public async Task<IActionResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
		{
			var tag = await _readRepo.GetById(request.TagId);

			if (tag == null)
				return new NotFoundResult();

			var toUpdate = new Tag(tag);

			toUpdate.UpdateTitle(request.Title);
			await _writeRepo.Save(toUpdate);

			return new OkResult();
		}
	}
}
