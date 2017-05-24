# EndlessAges.LauncherService

EndlessAges.LauncherService is a crossplatform ASP.NET Core web API service that emulates the functionality of the service that the Endless Ages launcher communicates with for patching and etc.

## Endpoints

**Launcher.html**: Returns raw HTML that redirects to the login.aspx

**ContentManager.aspx?installer_patcher=ENDLESS**: Provides the content name for the .cab archive containing the launcher to use. Points to *domain*./ENDLESSINSTALL.cab ENDLESSINSTALL.cab which is broken and causes the launcher to hang.

**domain/ENDLESSINSTALL.cab**: Downloads compressed archive that contains the launcher executable. Assumably this is a patching mechansim for the launcher.

**ContentManager.aspx?gameapp=1**: Returns the location of the AXEngineApp.cab file. For example *domain*/AXEngineApp.cab.

**domain/AXEngineApp.cab**: Downloads compressed archive that contains the game client executable. Assumably this is a patching mechansim for the game client.

**ContentManager.aspx?server_x=1**: Unknown meaning or use. ASP.NET app returns "Aixen IIA *ip* ENDLESS".

**ContentManager.aspx?contenttype=axengineapp**: Unknown meaning or use. ASP.NET app returns "EndlessAges.exe 0 AXEngineApp.cab \ 1516649222 1 725635732" the significance of the numbers is not known. The EndlessAges.exe is the game client and the AXEngineApp.cab is the archive containing the game client.

## Setup

* Visual Studio 2017 (you need this version for netcore1.1)

## License

MIT
