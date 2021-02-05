using HouseBuildingBlog.Domain.Files;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Services
{
	public interface IFileResponseService
	{
		FileContentResult CreateFileContentResult(IFile file);
	}
}
