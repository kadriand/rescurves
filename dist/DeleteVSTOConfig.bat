@echo off
REM --------------------------
set BatchVersion=1.4
REM --------------------------
set Elevated=%1
echo This will Delete VSTOInstaller.exe.Config [batch Version %BatchVersion%]
echo .

set BadConfigFile="%ProgramFiles%\Common Files\Microsoft Shared\VSTO\10.0\VSTOInstaller.exe.config"
call :Delete

REM - we have also an second location - test it
if DEFINED ProgramFiles(x86) (
	set BadConfigFile="%ProgramFiles(x86)%\Common Files\Microsoft Shared\VSTO\10.0\VSTOInstaller.exe.config"
	call :Delete
	)

:end
pause
goto :eof

:Delete
if exist %BadConfigFile% (
	REM - The file exist - we have to delete it
	REM del /Q /F %BadConfigFile%
	del /Q %BadConfigFile%
	if exist %BadConfigFile% (
		echo .
		echo Deleting the file was not successful. 
		echo Please verify you have admin rights and UAC is enabled.
		echo .
		echo Right click on the batch file and select 'Run as administrator'
		call :TryToElevate
	) else (
		echo File %BadConfigFile% was successful deleted.
		echo Please try to reinstall the plugin.
	)
) else (
    REM - The file doesn't exist
	echo The file %BadConfigFile% was not found.
)
echo .
echo Closing .bat
goto :eof

:TryToElevate
if NOT [%ELEVATED%]==[] (
	echo Match
	goto :eof
	)
echo -----------------------
echo Try to start as administrator
echo -----------------------
set Elevated=TRYED
echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
echo UAC.ShellExecute "%~s0", "ELEVATED", "", "runas", 1 >> "%temp%\getadmin.vbs"
"%temp%\getadmin.vbs"
goto :eof

