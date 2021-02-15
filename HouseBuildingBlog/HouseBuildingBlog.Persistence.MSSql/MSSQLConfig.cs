namespace HouseBuildingBlog.Persistence.MSSql
{
	public class MSSQLConfig
	{
		public string Server { get; set; }

		public string DatabaseName { get; set; }

		public string UserId { get; set; }

		public string UserPw { get; set; }

		public bool TrustedConnection { get; set; }

		public string FileStorageLocation { get; set; }
	}
}
