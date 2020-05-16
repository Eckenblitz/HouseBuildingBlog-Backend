﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetSingleEventHandler : IRequestHandler<GetSingleEventQuery, IActionResult>
	{
		public Task<IActionResult> Handle(GetSingleEventQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
