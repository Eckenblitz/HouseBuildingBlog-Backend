using HouseBuildingBlog.Domain.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, IActionResult>
	{
		private readonly IWriteTagsAggregate _writeTagsAggregate;

		public DeleteTagHandler(IWriteTagsAggregate writeTagsAggregate)
		{
			_writeTagsAggregate = writeTagsAggregate;
		}

		public async Task<IActionResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
		{
			var tag = await _writeTagsAggregate.DeleteTagAsync(request.TagId);

			if (tag == null)
				return new NotFoundResult();

			return new OkResult();
		}
	}
}
