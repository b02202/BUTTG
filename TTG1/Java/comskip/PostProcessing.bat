@echo off
Rem PostProcessing.bat
Rem This script will be run automatically by GBPVR when found after a recording is finished
Rem To enable it put this file inside your GBPVR default program directory (C:\Program Files\devnz\gbpvr\)
Rem together with Comskip.exe, Comskip.ini and Comskip.dictionary
Rem The script is called with two parameters
Rem %1 is the fully qualified name of the recorded mpeg file.
Rem %2 is the channel number of the recording
echo Postprocessing.bat invoked on %1 recorded from channel %2 >>postprocessing.log

Rem The part below can be used to not run Comskip on certain channels, please modify for your conveniance.
Rem The channel numbers that should be skipped are the numbers between the double quotes ("").
Rem You can add "if" lines as much as you want
Rem To disable this behaviour use channel numbers outside the normal range, put a "rem" before the "if" or delete the "if" lines

Rem list of channels to not run comskip on
if "%2" == "27" goto eof
if "%2" == "36" goto eof

Rem this trick also makes it possible to have dedicated comskip.ini file for certain channels.
if "%2" == "79" goto channel79
if "%2" == "72" goto channel72
if "%2" == "65" goto channel65
Rem use the default comskip.ini for all other channels
goto generic

:channel79
comskip --ini=channel79.ini %1
goto continue
:channel72
comskip --ini=channel72.ini %1
goto continue
:channel65
rem This is an example of how to reuse a previously learned logo to prevent Comskip from learning the wrong logo
comskip --ini=channel65.ini --logo=channel65.logo.txt %1
goto continue

:generic
Rem The actual run of Comskip. Only one parameter, the name of the mpeg file to process.
Rem Comskip will read its settings from the Comskip.ini found in the same directory as Comskip.exe
Rem Both are supposed to be in the GBPVR default program directory. (C:\Program Files\devnz\gbpvr\)
comskip %1
:continue

Rem Once the commercials have been identified you can run comclean to delete the commercials from the recording.
Rem Do this only when you are not using the Skip function in the GBPVR viewer.
Rem To enable comclean remove the word "Rem" from the following line.
rem call comclean %1
:eof
