copy "..\bin\Debug\ArchiGungeon.dll" "..\_DLLRepack\"
powershell -Command "..\packages\ILRepack*\tools\ILRepack.exe /out:'..\_DLLRepack\ArchipelaGun.dll' '..\_DLLRepack\ArchiGungeon.dll' '..\_DLLRepack\Archipelago.MultiClient.Net.dll' '..\_DLLRepack\websocket-sharp.dll' /lib:'..\bin\Debug'"
copy "..\_DllRepack\ArchipelaGun.dll" "[HARD CODED LOCATION HERE]"