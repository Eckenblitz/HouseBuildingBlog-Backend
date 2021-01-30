using HouseBuildingBlog.Domain.Files;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HouseBuildingBlog.Api.Services
{
	public class FileResponseService : IFileResponseService
	{
		public HttpResponseMessage CreateFileResponse(IFile file)
		{
			HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
			response.Content = new ByteArrayContent(file.Binaries);
			response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
			response.Content.Headers.ContentDisposition.FileName = file.FileName;
			response.Content.Headers.ContentType = new MediaTypeHeaderValue(GetMediaType(file.FileType));
			return response;
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
