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
	public class ContentManagerController : Controller
	{
		//ContentManager.aspx?installer_patcher=ENDLESS
		[HttpGet]
		public IActionResult GetPatchingInfo([FromQuery]string installer_patcher)
		{
			//If no valid parameter was provided in the query then return an error code
			//This should only happen if someone is spoofing
			//422 (Unprocessable Entity)
			if (string.IsNullOrWhiteSpace(installer_patcher))
				return StatusCode(422);

			//TODO: What exactly should the backend return? EACentral returns a broken url
			return Content($"{@"http://game1.endlessagesonline./ENDLESSINSTALL.cab"}\n{@"ENDLESSINSTALL.cab"}");
		}

		//ContentManager.aspx?gameapp=1
		[HttpGet]
		public IActionResult GetGameApplicationUrl([FromQuery]int gameapp)
		{
			//If no valid parameter was provided in the query then return an error code
			//This should only happen if someone is spoofing
			//422 (Unprocessable Entity)
			if (gameapp < 0)
				return StatusCode(422);

			//TODO: Implement server and IP mysql tables
			//TODO: It points to an endpoint http://game1.endlessagesonline.com/AXEngineApp.cab but what is it for?
			return Content(@"http://game1.endlessagesonline.com/AXEngineApp.cab");
		}

		//ContentManager.aspx?server_x=1
		[HttpGet]
		public IActionResult GetServerInformation([FromQuery]int server_x)
		{
			//If no valid parameter was provided in the query then return an error code
			//This should only happen if someone is spoofing
			//422 (Unprocessable Entity)
			if (server_x < 0)
				return StatusCode(422);

			//TODO: Implement server and IP mysql tables
			//TODO: I can only guess what is going on here 
			//It appears it sends Aixen IIA, the server IP for some reason and ENDLESS
			//This could be the gameserver IP and the gameserver APP name? A Hello might be required
			//with the app name? I can only guess at this time.
			return Content("Aixen IIA 96.82.227.146 ENDLESS");
		}

		//ContentManager.aspx?contenttype=axengineapp
		[HttpGet]
		public IActionResult GetContentInformation([FromQuery] string contenttype)
		{
			//TODO: Switch or route based on contenttype though maybe not needed
			//If no valid parameter was provided in the query then return an error code
			//This should only happen if someone is spoofing
			//422 (Unprocessable Entity)
			if (string.IsNullOrWhiteSpace(contenttype))
				return StatusCode(422);

			//TODO: Figure out the meaning of the below content
			//This is what eacentral's ASP app returns
			//EndlessAges.exe 0 AXEngineApp.cab \ 1516649222 1 725635732
			//But I'm unsure what it means. EndlessAges.exe is the gameclient executable
			//and AXEngineApp.cab is a compressed archive that contains a new engine app.
			return Content(@"EndlessAges.exe 0 AXEngineApp.cab \ 1516649222 1 725635732");
		}
	}
}
