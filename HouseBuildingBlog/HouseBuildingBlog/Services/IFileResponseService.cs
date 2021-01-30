using HouseBuildingBlog.Domain.Files;
using System.Net.Http;

namespace HouseBuildingBlog.Api.Services
{
	public interface IFileResponseService
	{
		HttpResponseMessage CreateFileResponse(IFile file);
	}
}
