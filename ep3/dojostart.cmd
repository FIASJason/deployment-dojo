REM Open the Dojo folder and Programs and Features
start c:\dojo
start appwiz.cpl

REM Install the MSI
msiexec /i "C:\dojo\dojo-ep2.msi" /l*v C:\dojo\dojo-ep2-install.txt
start c:\dojo\dojo-ep2-install.txt
explorer.exe "C:\Program Files (x86)"
