using HouseBuildingBlog.Domain.Documents;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Services
{
	public interface ITransformDocumentFileService
	{
		Task<IFile> TransformAsync(Guid documentId, IFormFile file);
	}
}
