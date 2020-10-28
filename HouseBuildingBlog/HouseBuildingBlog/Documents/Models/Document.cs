﻿using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Documents.Models
{
	public class Document : IDocument
	{
		public Guid DocumentId { get; private set; }

		public string Title { get; private set; }

		public string Comment { get; private set; }

		public string FileAdress { get; private set; }

		public float Price { get; private set; }

		public Guid EventId { get; private set; }

		public Document() { }

		public Document(IDocument doc)
		{
			this.DocumentId = doc.DocumentId;
			this.Title = doc.Title;
			this.Comment = doc.Comment;
			this.FileAdress = doc.FileAdress;
			this.Price = doc.Price;
			this.EventId = doc.EventId;
		}

		public Document(CreateDocumentCommand command)
		{
			this.DocumentId = Guid.NewGuid();
			this.Title = command.Data.Title;
			this.Comment = command.Data.Comment;
			this.FileAdress = command.Data.FileAdress;
			this.Price = command.Data.Price;
			this.EventId = command.Data.EventId;
		}

		public Document(UpdateDocumentCommand command)
		{
			this.DocumentId = command.Id;
			this.Title = command.Data.Title;
			this.Comment = command.Data.Comment;
			this.FileAdress = command.Data.FileAdress;
			this.Price = command.Data.Price;
			this.EventId = command.Data.EventId;
		}
	}
}
