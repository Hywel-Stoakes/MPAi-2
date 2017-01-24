@ECHO OFF
cd %APPDATA%
ECHO removed the 
if exist "MPAi" (ECHO "MPAi Folder Found.")
rmdir /s /q "MPAi"
ECHO deleted?
if exist "MPAi" (ECHO "MPAi Folder still Found.")

ECHO old files have been removed.
ECHO **************************************************************************************