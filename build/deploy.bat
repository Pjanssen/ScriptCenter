ECHO.
ECHO Deploying compiled files...

SET deployDir=%1..\..\..\build\deploy

IF EXIST %deployDir% ( rmdir %deployDir% /S /Q || goto :error )
mkdir %deployDir% || goto :error

copy %1*.dll %deployDir%\ || goto :error

goto :eof

:error
ECHO Deploy failed.
PAUSE
EXIT /B %ERRORLEVEL%