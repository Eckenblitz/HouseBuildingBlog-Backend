using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseBuildingBlog.Domain.Documents;

namespace HouseBuildingBlog.Api.Documents.Models
{
	public class Document : IDocument
	{
		public Guid DocumentId { get; private set; }

		public string Title { get; private set; }

		public string Comment { get; private set; }

		public string FileAdress { get; private set; }

		public Document() { }

		public Document(IDocument doc) {
			this.DocumentId = doc.DocumentId;
			this.Title = doc.Title;
			this.Comment = doc.Comment;
			this.FileAdress = doc.FileAdress;
		}
	}
}
