@echo off

del /Q Stugo.Glue.Wcf\bin\Release\*.nupkg
call .\build.cmd
.\tools\NuGet\NuGet.exe push Stugo.Glue.Wcf\bin\Release\*.nupkg -Source https://www.nuget.org/api/v2/package