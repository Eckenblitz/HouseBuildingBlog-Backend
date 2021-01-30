using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Files;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class ReadDocumentFileRepository : DocumentFileRepositoryBase, IReadFileRepository<IDocumentFile>
	{
		public ReadDocumentFileRepository(MSSQLConfig config) : base(config)
		{ }

		public async Task<byte[]> ReadFileBinariesAsync(IDocumentFile file)
		{
			try
			{
				return await File.ReadAllBytesAsync(Path.Combine(_fileDirectory, GetFileName(file)));
			}
			catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
			{
				throw new FileNotFoundException<IDocumentFile>(file, ex);
			}
		}
	}
}
