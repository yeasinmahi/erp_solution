@echo off
:: variables
set drive=C:\Backup
set folder=%date:~10,4%-%date:~7,2%-%date:~4,2%_%TIME:~0,2%-%TIME:~3,2%-%TIME:~6,2%
set backupcmd=xcopy /s /c /d /e /h /i /r /k /y

echo ### Backing up directory...
%backupcmd% "C:\ERP" "%drive%\%folder%"

echo Backup Complete!
exit