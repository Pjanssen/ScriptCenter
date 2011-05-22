(
	function checkDotNetVersion =
	(
		--Returns true if the .NET Framework 3.5 key could be opened.
		local rKey;
		local success = registry.openkey HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5" key:&rKey accessright:#readonly;
		if (success) do
			registry.closeKey rKey;
		
		if (not success) do
		(
			success = registry.openkey HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4" key:&rKey accessright:#readonly;
			if (success) do
				registry.closeKey rKey;
		)
		
		success;
	)

	if (not checkDotNetVersion()) then
		messagebox "This installer requires .NET 3.5 or higher." title:".NET required";
	else
	(
		try
		(
			local tempDir = (GetDir #temp) + "/{id}";
			dotnet.loadassembly (tempDir + "/scriptcenter.dll");
			local installer = dotNetObject "ScriptCenter.Installer.Installer" tempDir (tempDir + "/script.scmanifest") (tempDir + "/script.scinstaller");
			local uiConfig = (dotNetClass "ScriptCenter.Installer.UI.InstallerUIConfiguration").FromFile (tempDir + "/script.scinstallerui");
			local installerDialog = dotNetObject "ScriptCenter.Installer.InstallerDialog" installer uiConfig;
			installerDialog.ShowDialog();
		)
		catch
		(
			messagebox "Error starting installer." title:"Installer error";
		)
	)
)