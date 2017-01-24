@ECHO OFF

SET installdir= %cd%

CALL deleteData.bat
cd %installdir%

cd %appdata%

if exist "MPAi" (del /s /q "MPAi")

ECHO Creating MPAi directory in %appdata%
if not exist "MPAi" ( mkdir "MPAi" )

cd MPAi


if exist MPAiDB.mdf ( del MPAiDB.mdf)
if exist MPAiDB_log.ldf ( del MPAiDB_log.ldf)

ECHO Creating Database directory in %appdata%/MPAi
if not exist "Database" (mkdir "DataBase")

cd Database

if exist MPAiDB.mdf ( del MPAiDB.mdf)
if exist MPAiDB_log.ldf ( del MPAiDB_log.ldf)

cd %installdir%

ECHO Creating new Database in %appdata%/MPAi

MPAi.exe initDB

cd ../../..

ECHO Starting Installation.
start setup.exe

pause