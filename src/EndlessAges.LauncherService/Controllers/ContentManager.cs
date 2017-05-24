﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndlessAges.LauncherService.Controllers
{
	/// <summary>
	/// Emulated controller ContentManager.aspx from the Endless Ages backend.
	/// </summary>
	[Route("ContentManager.aspx")]
	public class ContentManager : Controller
	{
		//ContentManager.aspx?installer_patcher=ENDLESS
		[HttpGet]
		public IActionResult Get([FromQuery]string installer_patcher)
		{
			//If no valid parameter was provided in the query then return an error code
			//This should only happen if someone is spoofing
			//422 (Unprocessable Entity)
			if (string.IsNullOrWhiteSpace(installer_patcher))
				return StatusCode(422);

			//TODO: What exactly should the backend return? EACentral returns a broken url
			return Content($"{@"http://game1.endlessagesonline./ENDLESSINSTALL.cab"}\n{@"ENDLESSINSTALL.cab"}");
		}
	}
}
