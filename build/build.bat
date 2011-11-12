@ECHO OFF

::Adjust the value of MaxDir to match your local 3dsmax installation directory.
SET MaxDir=C:\Program Files\Autodesk\3ds Max 2010\

CALL :GetMSBuild MSBuild_3_5 3.5

IF NOT EXIST %MSBuild_3_5% ( 
   ECHO Could not find MSBuild.exe for .NET v3.5
   goto :error
)


ECHO Building ScriptCenter...
SET Configuration=Release
%MSBuild_3_5% ..\ScriptCenter\ScriptCenter.csproj /nologo /ToolsVersion:3.5 /verbosity:quiet /flp:Logfile=build.log;verbosity=normal /p:ReferencePath="%MaxDir%;" || goto :buildError
ECHO Build successful.

CALL deploy.bat ..\ScriptCenter\bin\%Configuration%\


ECHO.
ECHO Done.
goto :eof


:: Usage: CALL :GetMSBuild variable_to_set dot_net_version
:GetMSBuild
SETLOCAL
SET KEY_NAME=HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\
SET KEY_VALUE=MSBuildToolsPath
ENDLOCAL
FOR /F "tokens=1-3" %%A IN ('REG QUERY "%KEY_NAME%%~2" /v %KEY_VALUE% 2^>nul') DO (
   set %~1=%%CMSBuild.exe
)
goto :eof


:buildError
ECHO Build failed. See build.log for details.
goto :error

:error
PAUSE
EXIT /B %ERRORLEVEL%