using HouseBuildingBlog.Domain.Files;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Services
{
	public class FileResponseService : IFileResponseService
	{
		public FileContentResult CreateFileContentResult(IFile file)
		{
			return new FileContentResult(file.Binaries, GetMediaType(file.FileType));
		}

		private string GetMediaType(FileType fileType)
		{
			switch (fileType)
			{
				case FileType.PDF:
					return "application/pdf";
				case FileType.JPG:
					return "image/jpeg";
				case FileType.PNG:
					return "image/png";
				case FileType.TXT:
					return "text/plain";
				default:
					throw new NotSupportedException();
			}
		}
	}
}
