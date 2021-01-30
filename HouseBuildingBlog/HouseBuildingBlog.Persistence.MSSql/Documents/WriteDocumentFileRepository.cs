using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Files;
using System.IO;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class WriteDocumentFileRepository : DocumentFileRepositoryBase, IWriteFileRepository<IDocumentFile>
	{
		public WriteDocumentFileRepository(MSSQLConfig config) : base(config)
		{ }

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
	}
}
