REM Open the Dojo folder and Programs and Features
start c:\dojo
start appwiz.cpl

REM Install the MSI
msiexec /i "C:\dojo\v0.9\ep4.msi" /l*v C:\dojo\dojo-ep4-install.txt
start c:\dojo\dojo-ep4-install.txt
explorer.exe "C:\Program Files (x86)"
