using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Files;
using System.IO;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class WriteDocumentFileRepository : IWriteFileRepository<IDocumentFile>
	{
		private readonly string _fileDirectory;

		public WriteDocumentFileRepository(MSSQLConfig config)
		{
			_fileDirectory = Path.Combine(config.FileStorageLocation, "Resources", "Documents");
		}

		public async Task WriteFileBinariesAsync(IDocumentFile documentFile)
		{
			await DeleteFileBinariesAsync(documentFile); //Delete old files because old file could have another extention
			CheckAndCreateDirectory();

			await File.WriteAllBytesAsync(Path.Combine(_fileDirectory, GetFileName(documentFile)), documentFile.Binaries);
		}

		public Task DeleteFileBinariesAsync(IDocumentFile documentFile)
		{
			if (!Directory.Exists(_fileDirectory))
				return Task.CompletedTask;

			var files = Directory.GetFiles(_fileDirectory, $"{documentFile.DocumentId}.*");
			foreach (var file in files)
			{
				var fileInfo = new FileInfo(file);
				File.Delete(fileInfo.FullName);
			}

			return Task.CompletedTask;
		}

		private void CheckAndCreateDirectory()
		{
			if (!Directory.Exists(_fileDirectory))
			{
				Directory.CreateDirectory(_fileDirectory);
			}
		}

		private string GetFileName(IDocumentFile documentFile)
		{
			return $"{documentFile.DocumentId}.{documentFile.FileType.ToString().ToLower()}";
		}
	}
}
