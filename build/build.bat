@ECHO OFF

::Adjust the value of MaxDir to match your local 3dsmax installation directory.
SET MaxDir=C:\Program Files\Autodesk\3ds Max 2010\

::dir "%MaxDir%ManagedServices.dll" > nul || CALL :PathError "Could not find ManagedServices. Be sure to correctly set MaxDir value."


CALL :GetMSBuild MSBuild_3_5 3.5

dir "%MSBuild_3_5%" > nul || CALL :PathError "Could not find MSBuild.exe for .NET 3.5."

ECHO Building ScriptCenter.Max...
%MSBuild_3_5% ..\ScriptCenter\ScriptCenter.Max.csproj /nologo /ToolsVersion:3.5 /verbosity:quiet /flp:Logfile=build_scriptcenter.max.log;verbosity=normal /p:ReferencePath="%MaxDir%;" || goto :buildError
ECHO Build succeeded.

ECHO.
ECHO Building ScriptCenter...
%MSBuild_3_5% ..\ScriptCenter\ScriptCenter.csproj /nologo /ToolsVersion:3.5 /verbosity:quiet /flp:Logfile=build_scriptcenter.log;verbosity=normal /p:ReferencePath="%MaxDir%;" || goto :buildError
ECHO Build succeeded.


CALL deploy.bat


ECHO.
ECHO Done.
goto :eof


:: Usage: CALL :GetMSBuild variable_to_set dot_net_version
:GetMSBuild
SET KEY_NAME=HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\
SET KEY_VALUE=MSBuildToolsPath

FOR /F "tokens=1-3" %%A IN ('REG QUERY "%KEY_NAME%%2" /v %KEY_VALUE% 2^>nul') DO (
   set %~1=%%CMSBuild.exe
)
goto :eof


:buildError
ECHO Build failed. See build_x.log for details.
goto :error

:PathError
ECHO %~1
goto :error

:error
PAUSE
EXIT /B %ERRORLEVEL%