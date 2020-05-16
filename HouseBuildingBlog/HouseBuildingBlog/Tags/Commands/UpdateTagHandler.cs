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
		private readonly IWriteRepository<Tag> _writeRepo;
		private readonly IReadRepository<Tag> _readRepo;

		public UpdateTagHandler(IWriteRepository<Tag> writeRepo, IReadRepository<Tag> readRepo)
		{
			_writeRepo = writeRepo;
			_readRepo = readRepo;
		}

		public async Task<IActionResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
		{
			var tag = await _readRepo.GetById(request.TagId);

			if (tag == null)
				return new NotFoundResult();

			tag.UpdateTitle(request.Title);
			await _writeRepo.Save(tag);

			return new OkResult();
		}
	}
}
