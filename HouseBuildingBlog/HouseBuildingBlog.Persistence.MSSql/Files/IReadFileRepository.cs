using HouseBuildingBlog.Domain.Files;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Files
{
	public interface IReadFileRepository<TFile> where TFile : IFile
	{
		Task<byte[]> ReadFileBinariesAsync(TFile file);
	}
}
