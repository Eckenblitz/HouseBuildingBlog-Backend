using HouseBuildingBlog.Domain.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Services
{
	public class TransformFileService : ITransformFileService
	{
		public async Task<IFile> TransformAsync(IFormFile file)
		{
			IFile transformed = null;
			if (file.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					await file.CopyToAsync(ms);
					var fileBytes = ms.ToArray();
					string s = Convert.ToBase64String(fileBytes);
					transformed = new Domain.Files.File(file.FileName, GetTypeFromExtension(file), fileBytes);
				}
				return transformed;
			}
			//ToDo: think about empty file handling
			throw new InvalidOperationException("File is empty");
		}

		private FileType GetTypeFromExtension(IFormFile file)
		{
			var extension = Path.GetExtension(file.FileName).ToLower();
			switch (extension)
			{
				case ".jpg":
					return FileType.JPG;
				case ".png":
					return FileType.PNG;
				case ".pdf":
					return FileType.PDF;
				case ".txt":
					return FileType.TXT;
			}

			throw new NotSupportedException($"Extension {extension} is not supported");
		}
	}
}
