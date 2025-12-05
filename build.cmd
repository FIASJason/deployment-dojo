@echo off

pushd

echo Initializing dev environment

for /f "usebackq delims=" %%i in (`"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -version [17.0^,18.0^) -property installationPath`) do (
  call "%%i\Common7\Tools\vsdevcmd.bat" -no_logo
)

echo Build
echo Current Directory: %CD%

msbuild -nologo -m .\BeltTest.sln -p:BuildVersion=0.34.2 -bl