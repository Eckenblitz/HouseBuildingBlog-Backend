using HouseBuildingBlog.Domain.Files;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Services
{
	public interface ITransformFileService
	{
		Task<IFile> TransformAsync(IFormFile file);
	}
}
