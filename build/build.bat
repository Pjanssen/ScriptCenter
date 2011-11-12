@ECHO OFF

::Adjust the value of MaxDir to match your local 3dsmax installation directory.
SET MaxDir=C:\Program Files\Autodesk\3ds Max 2010\

SET MSBuild=%SystemRoot%\Microsoft.NET\Framework\v3.5\MSBuild.exe


ECHO Building ScriptCenter...
SET Configuration=Release
%MSBuild% ..\ScriptCenter\ScriptCenter.csproj /nologo /p:ReferencePath="%MaxDir%;" || goto :error


ECHO.
ECHO Deploying compiled files...
IF EXIST deploy ( rmdir deploy /S /Q || goto :error )
mkdir deploy || goto :error
copy ..\ScriptCenter\bin\%Configuration%\*.dll deploy\ || goto :error


ECHO.
ECHO Done.
goto :eof


:error
PAUSE
EXIT /B %ERRORLEVEL%
