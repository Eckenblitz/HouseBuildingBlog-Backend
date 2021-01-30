using HouseBuildingBlog.Domain.Documents;
using System.IO;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public abstract class DocumentFileRepositoryBase
	{
		protected readonly string _fileDirectory;

		protected DocumentFileRepositoryBase(MSSQLConfig config)
		{
			_fileDirectory = Path.Combine(config.FileStorageLocation, "Resources", "Documents");
		}

		protected string GetFileName(IDocumentFile documentFile)
		{
			return $"{documentFile.DocumentId}.{documentFile.FileType.ToString().ToLower()}";
		}

		protected void CheckAndCreateDirectory()
		{
			if (!Directory.Exists(_fileDirectory))
			{
				Directory.CreateDirectory(_fileDirectory);
			}
		}

	}
}
