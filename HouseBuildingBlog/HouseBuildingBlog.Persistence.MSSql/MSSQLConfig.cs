using System.Text;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public class MSSQLConfig
	{
		public string Server { get; set; }

		public int? Port { get; set; }

		public string DatabaseName { get; set; }

		public string UserId { get; set; }

		public string UserPw { get; set; }

		public bool TrustedConnection { get; set; }

		public string FileStorageLocation { get; set; }

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(nameof(MSSQLConfig));
			builder.Append($"\r\n--{nameof(Server)}:'{Server}'");
			builder.Append($"\r\n--{nameof(DatabaseName)}:'{DatabaseName}'");
			builder.Append($"\r\n--{nameof(Port)}:'{Port}'");
			builder.Append($"\r\n--{nameof(UserId)}:'{UserId}'");
			builder.Append($"\r\n--{nameof(UserPw)}:'{UserPw}'");
			builder.Append($"\r\n--{nameof(TrustedConnection)}:'{TrustedConnection}'");
			builder.Append($"\r\n--{nameof(FileStorageLocation)}:'{FileStorageLocation}'");
			return builder.ToString();
		}
	}
}
