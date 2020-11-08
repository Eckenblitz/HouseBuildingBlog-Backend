using HouseBuildingBlog.Domain.Documents;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Services
{
	public class TransformDocumentFileService : ITransformDocumentFileService
	{
		public async Task<IFile> TransformAsync(Guid documentId, IFormFile file)
		{
			IFile transformed = null;
			if (file.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					await file.CopyToAsync(ms);
					var fileBytes = ms.ToArray();
					string s = Convert.ToBase64String(fileBytes);
					transformed = new Documents.Models.File(documentId, file.FileName, fileBytes);
				}
				return transformed;
			}
			//ToDo: think about empty file handling
			throw new InvalidOperationException();
		}
	}
}
