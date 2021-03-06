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
			local tempDir = (GetDir #temp) + "/{id}/";
			local installerDir = tempDir + "installer/";
			dotnet.loadassembly (installerDir + "scriptcenter.dll");
			local installer = dotNetObject "ScriptCenter.Package.Installer" tempDir (installerDir + "script.scmanifest") (installerDir + "script.scinstaller");
			--local uiConfig = (dotNetClass "ScriptCenter.Package.InstallerUI.InstallerUIConfiguration").FromFile (tempDir + "/script.scinstallerui");
			--local installerDialog = dotNetObject "ScriptCenter.Package.InstallerUI.InstallerDialog" installer uiConfig;
			--installerDialog.ShowDialog();
			installer.Install();
		)
		catch
		(
			print (getCurrentException());
			messagebox "Error starting installer." title:"Installer error";
		)
	)
)