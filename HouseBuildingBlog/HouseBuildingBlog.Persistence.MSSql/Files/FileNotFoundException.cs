using HouseBuildingBlog.Domain.Files;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Files
{
	public class FileNotFoundException<TFile> : Exception where TFile : IFile
	{
		public TFile File { get; }

		public Exception SystemException { get; }

		public FileNotFoundException(TFile file, Exception ex)
		{
			File = file;
			SystemException = ex;
		}
	}
}
