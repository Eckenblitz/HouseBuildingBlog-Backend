using HouseBuildingBlog.Domain.Files;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Files
{
	public interface IWriteFileRepository<TFile> where TFile : IFile
	{
		Task WriteFileBinariesAsync(TFile file);

		Task DeleteFileBinariesAsync(TFile file);
	}
}
