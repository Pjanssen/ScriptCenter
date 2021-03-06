ScriptCenter
============

Requirements
------------
* 3dsmax 2010 or above
* .NET Framework v3.5 (v4.0 to run the unit tests)
* Visual Studio 2010 SP1 (optional, to open projects and run unit tests)

Building using build.bat
------------------------
1. Fork the project, or download the source from 
    `https://github.com/Pjanssen/ScriptCenter/zipball/master`
2. Adjust MaxDir in build/build.bat to reflect the correct path to ManagedServices.dll
3. Run build.bat
4. The compiled files are located in the directory /deploy.

Building using Visual Studio
----------------------------
1. Fork the project, or download the source from 
    `https://github.com/Pjanssen/ScriptCenter/zipball/master`
2. Open ScriptCenter.sln in Visual Studio.
3. Select the ScriptCenter project and go to its properties.
4. In the Reference Paths tab, add your 3dsmax folder as a reference path.
5. Build Solution.

Contributors
------------
Pier Janssen, www.threesixty.nl  
Jonathan de Blok, www.jdbgraphics.nl

License
-------
This project is licensed under the BSD license. For the complete license, see LICENSE.txt