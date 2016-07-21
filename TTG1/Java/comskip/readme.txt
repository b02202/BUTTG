comskip 0.81.051

Donator version can:
- process h.264
- process wtv files.
- process multi threaded
- Process in lowres for even faster processing speed

This file contains the full changelog, see last part.

WARNING: Comskip can not and will never be able to process copy protected files.

WARNING: Avast will think Comskip is an unsafe program and force it to execute in a sandbox causing Comskip to crash. Tell Avast Comskip is safe.

WARNING: When Comskip crashes at startup you may need to install vcredist_x86.exe from
http://www.microsoft.com/downloads/details.aspx?familyid=32BC1BEE-A3F9-4C13-9C99-220B62A191EE&displaylang=en

WARNING: When processing h.264 you may have to set volume_slip=150 if no or little commercials are found

VISTA WARNING: Comskip has no valid embedded manifest. Please run comskip manually (double click comskip.exe) a first time and and tell vista to always allow it to run.

This, and older versions, can be downloaded from http://www.kaashoek.com/files/
The comskip support forum can be found at http://www.kaashoek.com/comskip/

When you like Comskip do consider to donate! 
I pay for hosting the forum and the download server and spend considerable time to deliver good support.
Donation can be done from the comskip home page at http://www.kaashoek.com/comskip/

If you are not an expert I recomment to use verbose=10 as maximum, any value from 0 to 12 is possible.

Remember that more detection methods (such as 255) is NOT always better.

Installation:


For GBPVR copy comskip.exe, comskip.ini into the gbpvr root directory.
In some situations comskip is not able to find its ini file. Try setting verbose=10 to check if it works. If this fails, copy the ini file in your system32 directory or in the directory containing the mpeg files to be processed

Dirmon2 requires the comskip commandline option for finding the ini file. Otherwise comskip will have terrible performance

SagetTV users may consider using SJQ http://forums.sage.tv/forums/showthread.php?t=25147

HideRun.exe can be used to run Comskip without showing the console window.
Usage: HideRun "path to comskip.exe" "parameters for comskip"
Hiderun requires .net to be installed

For other PVR solutions you may consider using Comskip Monitor (google)

All parameters for comskip can be set in the comskip.ini file. The file comskip.txt lists and describes all possible parameters. If you need a parameter that is currently not in your ini file simply copy the line from comskip.txt and add to comskip.ini

Upgrading
Copy comskip.exe over your old files (you might save the old version ;-)) 
Please start from the included ini file. 
Read manual.htm, tuning.htm and comskip.txt for more information

Use ComskipGUI.exe to see what Comskip is doing when processing a file. Drag and drop the file to be processed on ComskipGUI.exe


Changes on 0.81.051
- Improved the timeline correction to prevent misalignment of detected commercials on long recordings.
Changes on 0.81.050
- Ini parameter added: output_incommercial=0 set to 1 to enable the output of a status file containing a '1' when during live tv processingcomskip detects it is inside a commercial.
- Crash solved: Under certain conditions Comskip crashed when proccessing corrupt recordings.
Changes on 0.81.049
- Bug solved: Sometimes the first logo block is not found when processing the file for the first time.
- Added settings for live tv processing. The default settings should  work for NPVR .ts recording and MCE .wtv recording (see comskip.txt) . You MUST set standoff_size > 0 otherwise the defaults will be used.
	standoff_retries = times to retry if the file has grown during recording while sleeping one second between tries
	standoff_time = time in seconds to wait after last file modification when proceesing during recording
	standoff_size = size in kByte to stay away from the end of the file when processing during recording
	standoff_initial_wait = time in seconds to wait for after file creation time before starting processing
	standoff_initial_size = size of file in kByte to wait for before starting processing
Changes on 0.81.048
- When after_logo=999 or before_logo=999 a cutpoint will forced
Changes on 0.81.047
- Repaired the subtitle PID output for videoredo3
- Increased the standoff time for .ts files so live tv processing has a better chance to work.
Changes on 0.81.046
- Setting verbose=12 will show in the log file why certain candidate cutpoints are removed.
Changes on 0.81.045
- Increased the waiting time for WTV files to 10 minutes for live TV processing to reduce the risk for crashing.
Changes on 0.81.044
- Bug solved: Padding after last commercial was not working.
Changes on 0.81.043
- Comskip will automatically fallback to single thread decoding if the input file is incompatible with multi thread decoding.
- Solved crash: Comskip crashes after finding a logo before a valid audio stream has been detected
Changes on 0.81.042
- Switched off a debug message causing build 041 to be much slower
Changes on 0.81.041
- Solved some very strange behaviour of windows _wstati64, hopefully live TV processing works reliable now
Changes on 0.81.040
- Changed the algorithm for live tv processing, hope it works this time.
Changes on 0.81.039
- A free public version is now available, see top of this file for limitations.
Changes on 0.81.038
- Added unicode filenamesupport
- Observerd so non reproducable crashing that disappears when setting thread_count=1
Changes on 0.81.037
- Updated live TV processing for .wtv. It is confirmed to work.
- Warning; tell Avast comskip is ok otherwise comskip may crash.
Changes on 0.81.036
- Increased the max_analyze_duration to cater for strange recordings with a lot of empty space file at the start
Changes on 0.81.035
- Solved HUGE memory leak when using two_pass_logo=0.
Changes on 0.81.034
- Solved a crash when writing an updated .txt file using comskipGUI
Changes on 0.81.033
- Repaired the broken edlx output format
- Added output_videoredo3 parameter for ini file. Set to 1 to get type 3 videoredo output. Make sure to enable only ONE videoredo output format as they have the same name and one will overwrite the other.
Changes on 0.81.032
- Improved/repaired reviewing video for dvr-ms and wtv files. Still not fully working for bad timeline video's
- Discovered a crash when thread_count>1 and the recording changes video size, This crash can NOT be solved at the moment. If you see comskip crashing set thread_count=1
- Solved crash when video size changes even when thread count was set to 1
- Solved wrong duration and wrong progress indicator for .wtv files
- Solved timing inconsistency between two_pass_logo=1 and two_pass_logo=0
- Solved occasional equal time shifting of all detected commercials
Changes on 0.81.031
- Some improvements in timeline processing
- Solved a bug that causef comskip to hang when decoding mpeg1 video with thread_count>1
Changes on 0.81.029
- Added commandline switch --output=c:\path\to\work\folder to set the folder where all the output and temporary files will be written. 
Changes on 0.81.028
- Corrected a very obscure error in timeline repair.
Changes on 0.81.027
- Repaired the editing of .txt files broken since .024
- Added .mp4 as an extension for video files.
Changes on 0.81.026
- Solved a crash in the mpeg decoding.
Changes on 0.81.025
- Solved a crash in the timeline processing
Changes on 0.81.024
- Added parameter ticker_tape_percentage, default is 0, percentage of height of video from bottom to ignore.
- With the F5 key you can now switch between frame number display and timecode display in the debugwindow.
- Complete rewrite of the internal timeline and timekeeping algorithms to have a structural solution for timeline errors in the recording. This can cause many new bugs to test carefully if this build is ok for you.
- Added a WARNING message in the log file in case of a corrupt timeline in the recording.
- Changed the default of min_show_segment_length=250 to accomodate for HD recordings with very long commercial blocks
Changes on 0.81.023
- Fixed a big memory leak
Changes on 0.81.022
- Added the subtitle PID in the VideoRedo output file.
- Increased the robustness of the mpeg decoder agains stream errors that caused Comskip to crash.
Changes on 0.81.021
- Correctd a logo timeline problem when two_pass_logo=0 and a short non-logo gap in the inital logo segment.
Changes on 0.81.020
- Improved  Heuristics 1 to remove very short show blocks between two commercial blocks.
- Many small internal detection improvements based on huge recording test set.
- Added parameter logo_shrink_tail=0, set to number of seconds the logo should disapear earlier.
- thread_count>1 now also works on h.264
- Default is thread_count=2, best setting on Intel multithreaded CPU's
- Setting lowres > 2 may cause problems.
- Solved some crashes when processing recordings longer the 3 hours. If you think comskip is crashing then check the log file for out of memory warnings.
Changes on 0.81.019
- Solved a bug that cause comskip to crash after finding a logo in a .wtv file when two_pass_logo=1 was set.
Changes on 0.81.018
- Solved a bug that caused wrong logo detection when actually no logo was found
- Greatly improved aspect ratio detection
- Solved a bug that caused comskip to quit after finding a logo on certain recordings.
- Improved Australia specific Commercial detection parameters
Changes on 0.81.017
- Added ini parameter, default is: thread_count=1 , Set to 2 (50% speed increase on HD) or 4 (100% speed increase on HD) to use more threads for decoding.
Changes in 0.81.016
- Solved a bug in single pass logo processing that was causing many crashes.
Changes in 0.81.015
 - Solved a bug in the output of videoredo project file for h.264 video
 - lowres will automatically be disabled for h.264
 - Comskip now running on normal priority for all those multi core CPU users.
Changes in 0.81.014
- Added ini parameter. Default: lowres=0 Setting to 1 will halve the size of th decoded video and speed up. Only usable on mpeg video. Causes h.264 to crash.
- Crash solved when using debugwindow in combination with two_pass_logo=0
Changes in 0.81.013
- This is an experimental release. Do NOT use for production purposes.
- Setting two_pass_logo=0 will enable an experimental multi logo search algorithm that is less accurate but can deal with an infinite number of logo's
- Switched to lower quality decoding to increase decoding speed.
- Disabled the IO playnice to gain speed on multi core Windows 7 machines.
Changes in 0.81.012
- The min_black_frames_for_break setting is working again. Set to the minimum number of black frames needed to have a cutpoint.
- Saving cutscenes will always be done to a .dmp file with the same basename as the recording. The save file dialog is broken. Rename these files if you need more then one.
Changes in 0.81.011
- Complete change of the used codec and demux. Comskip will now process everything ffmpag can decode. Due to the experimental nature certain features have stopped working. Most noticable is NOT LIVE TV SUPPORT!!!!
Changes in 0.80.042
- Repaired a bug that caused build 40 and 41 to fail on dvr-ms. Do NOT use build 40 and 41 on dvr-ms
Changes in 0.80.041
- Added aggressive_logo_detection=4 for detecting logos on very bright backgrounds, could be a future acceptable default once confirmed by testing
Changes in 0.80.040
- Update both before_logo and after_logo processing to seek for the biggest scene change near a silence starting x seconds till 30 seconds after/before the logo (dis)appears. This is usefull when no black frames are present.
Changes in 0.80.039
- Solved a decoder crash caused by a corrupt recording.
Changes in 0.80.038
- Solved a stupid bug that cause the setting of the always_keep_first_seconds to be used to reduce the last commercial block length instead of the parameter always_keep_last_seconds
Changes in 0.80.037
- Improved heuristics rule 1
Changes in 0.80.036
- on request change the way of working of the always_keep_x_seconds to indeed ALWAYS keep the x seconds
Changes in 0.80.035
- Solved a bug in the heuristics for automatically disabling the logo processing.
Changes in 0.80.034
- Added parameter: edl_offset=0 ; The amount of frames subtracted from the edl cut time output, use negative numbers to shift to later.
Changes in 0.80.033
- Added 60fps h.264 video decoding
Changes in 0.80.032
- Added the parameter outout_chapters to create a .chap file listing the framenumbers of the chapters in the recording.
- Increased the robustness of the h.264 positioning while in debug window mode
Changes in 0.80.031
- Added flushing of the .edl and .txt file while processing live tv
Changes in 0.80.030
- Changed the generated .vprj file to include "<MPEG Stream Type>4" in case of h.264 video
Changes in 0.80.029
- Increased the default for volume_slip to 40 to have better black frame detection in long recordings
- Solved a bug in the audio decoding of QAM recording coming from a HDPVR. Could solve many other AC3 related decoding problems.
Changes in 0.80.028
- When cut_on_ar_change is set to any value larger then 2 then all aspect ratio changes will create cutpoints except when the aspect ratio segment is shorter then cut_on_ar_change seconds. Suggested setting for normal use is cut_on_ar_change=20
Changes in 0.80.027
- Changed the sound detection algorithm to prevent sound decoding failure on very high quality digital broadcast.
Changes in 0.80.026
- Extended the H2 heuristics rule to also add short blocks before commercials.
Changes in 0.80.025
- Added parameter: incommercial_frames, default is 1000. When live_tv is set comskip also outputs a file with the extension ".incommercial" that contains a single line with a "0" when outside a commercial and a "1" when the current processed frame is less then incommercial_frames after the last detected commercial.
Changes in 0.80.024
- Bug solved: The delete_show_before_first_commercial did not function as expected
Changes in 0.80.023
- Added parameters always_keep_first_seconds and always_keep_last_seconds, Set them to the number of seconds at start/end you always want to be regarded as show. 
- When live_tv is enable the THREAD_MODE_BACKGROUND_BEGIN is not set to ensure live_tv process can keep up with the recording.
Changes in 0.80.022
- Completely bright frames (such as bright lights or explosions) no longer generate uniform cutpoints.
Changes in 0.80.021
- The public version no longer needs comcodec.dll, I hope this solves the crash on the AMD processors without SSE2
Changes in 0.80.020
- Implemented an additional workaround to prevent a crash
Changes in 0.80.019
- Undid some changes preparing for a new demux as there seem to be some unreproducable stability problems popping up
Changes in 0.80.018
- Bug solved: Comskip sometimes crashes at the start of processing when output_default=0
Changes in 0.80.017
- Set Comskip to THREAD_MODE_BACKGROUND_BEGIN priority to prevent the disk IO from blocking all other processes
- Added the complete list and discription of all tunable parameters in the file comskip.txt
- Implemented a recovery mechanism for when the h.264 decoder (in comcodec.dll) generates an exception. 
Changes in 0.80.016
- To avoid conflicts with ffdshow changed the name of the codec dll to comcodec.dll
Changes in 0.80.015
- Added parameter: delay_logo_search=0 When set to 1 logo seach will start after added_recording*60 seconds, or you can set it to the number of seconds after which to start the logo search
- Improved scene_change detection processing
- Improved the delete before/after commercial processing.
Changes in 0.80.014
- Bug solved: Certain files cause comskip to crash
Changes in 0.80.013
- Bug solved: The before_logo and after_logo with value 999 failed to work under certain conditions.
Changes in 0.80.012
- Changed the .edl output  to UNIX nl line format
- Bug solved: The .smi and .srt files contain duplicated data when a logo is found for the first time.
- Bug solved: Certain AAC streams causes Comskip to crash.
- Comskip now gracefully aborts when reading dvr-ms with sub .sbe files. Comskip can only read a single dvr-ms file.
- Comskip now reports in the log file when the audio is MP3 as Comskip can not decode MP3 audio.
- Bug solved: When cutscene method is enabled the scenechange method is automatically disabled
Changes in 0.80.011
- New parameter: added_recording=14 ; total amount of minutes that are added before and the actual show during the recording.
Changes in 0.80.010
- When before_logo or after_logo are set to 999 then a hard cutpoint will be inserted where the logo (dis)appears
- Improved again the robustness of the h.264 decoder (was lost in build 0.80.009)
Changes in 0.80.009
- Bug solved: Sometime the audio decoding stops
- Added the output format for iPod chapter skipping, enable by setting output_ipodchap=1 this will generate a .chap file with a chapter marker before and after each commercial.
- Removed the very small commercial found at the end of many recordings.
- Bug solved: Sometime Comskip crashes when output_smi or output_srt where enabled
- Bug solved: Comskip crashes on a h.264 recording that changes resolution
Changes in 0.80.008
- Doubled the speed of h.284 decoding. Only available in early access area. YOu MUST copy all the DLL's inside the zip file next you comskip.exe and comskipGUI.exe.
Changes in 0.80.007
- The non h.264 version is now again available outside the donator area. 
- Solved a very generic cause of crashing. You MUST use the new libavcodec.dll that comes with this release.
- Made some experimental improvements in determining the audio type.
Changes in 0.80.006
- Implemented a major robustness improvement in libavcodec.dll. YOu MUST use the libavcodec.dll included in this distribution Zip file.
Changes in 0.80.005
- Dumping a cutscene with the 'C' key is working again, was broken since build 0.79.140
- Improved the demuxing of TS recordings with corrupt PMT info
Changes in 0.80.004
- Changed the video detection for TS files to enable processing of clear QAM  recordings.
- Changed the default detect_method to 43 as the CC decoding sometimes causes Comskip to crash
Changes in 0.80.003
- Increased the robustness of the h.264 decoder
- Increased the robustness of the CC extractor
- Removed the "_1" filename postfix for CC output files.
Changes in 0.80.002
- Removed the embedded manifest as for some reason there is a crash on certain systems
Changes in 0.80.001
- Added h.264/AAC decoding on TS recordings. Not working yet on converted h.264 files. Do set max_volume=0 as the volume level is not normalized yet. AAC decoding still fails on certain recordings. No preview of .h264 yet
Changes in 0.79.144
- Bug solved: Comskip crashes on recordings with mono AC3 sound
Changes in 0.79.143
- Bug solved: When remove_before is set to a positive value and the first commercial starts at the beginning of the recording then the first commercial is missing in the generated list of commercials.
- It is on request again possible to set enable_mencoder_pts=1 in order to use the initial PTS as an offset in the .edl output file to allow mencoder to correctly cut TS recordings.
Changes in 0.79.142
- Made a big change to the sound detection algorithm. This should solve some crashes on certain recordings.
Changes in 0.79.141
- Bug solved: Too short commercials at the beginning or end are not deleted even when shorter then min_commercialbreak
- Substantial changes to the heuristics and to the validation algorithm. Its better on my set of test files, how about yours?
- Switched back to the old compiler
- Bug solved: Can not disable heuristics rule 7.
Changes in 0.79.140
- When the debugwindow is uncovered the windows stayed black untill you hit a key or clicked on the time bar. I tried to show the debuginfo when the window is uncovered but it is not always working.
- Switched to a new compiler, did expect all kind of problems but haven't seen one yet.
- Bug solved: Heuristics rule 7 triggers incorrectly causing loss of show at the beginning of the recording.
Changes in 0.79.139
- Output for Virtualdup shifted with 2 frames
- Added a fflush after writing to stderr
Changes in 0.79.138
- It is now possible to use the .csv file to test changed settings of maxbright
Changes in 0.79.137
- Bug solved: When reviewing the .txt file the bar at the top of the debugwindow is grey instead of black/white
Changes in 0.79.136
- Bugs solved: Comskip crashes when invoked with a .csv file and no .data file is present.
Changes in 0.79.135
- Improved the CC word separation on certain broadcast channels
- (Re)added the "CC" type of CC data.
Changes in 0.79.134
- Change the extension of the XDS dump file to .data
- When comskip is started with a .csv file the .data file containing the XDS dump will also be read when available.
- In ComskipGUI.exe the 'X' key can be used to show XDS data. Currently the Program Name, V_Chips, Program duration and Program position are displayed. Decoding of the XDS data is not yet complete
- A very thin grey vertical line at the very top of the debugbar timeline shows the location of the XDS data changes
Changes in 0.79.133
- Added functionality to decode ATSC Close Captioning data. Will work on any file (mpg, ts, dvr-ms) that contains this information.
- Added the ability to generate a .srt file, Set output_srt=1 to enable. This is done by integrating ccextractorwin. Send me feedback on what other output formats of ccextractor are usefull.
- Added the ability to generate a .smi file, Set output_smi=1 to enable. This is done by integrating ccextractorwin. 
- Added the ability to dump the user data stream from the mpeg recording. Set output_data=1 to enable. this will generate a .dmp file that could be compatible with ccextractor
Changes in 0.79.132
- Bug solved: The dvrmstv xml output file is missing the first commercial when it starts within the first second of the recording
Changes in 0.79.131
- Improved the previewing on dvr-ms recordings.
- It is now possible to disable the combining of blocks for strict or non-strict commercial length checking by setting the combined modifiers to 1.0
- Improved the automatic video PID selection when the stream switches to a new PAT
Changes in 0.79.130
- Audio detection on DVR-MS files still proved to be difficult when skipping frames. Some improvements have been implemented (I hope). Should also improve when not skipping frames.
Changes in 0.79.129
- Bug solved: The XML output file missed the first commercial when it started within 2 seconds from the start
- Improved the detection and decoding of sound in dvr-ms files.
- Improved the aspect ratio detection
- Bug solved: When max_repair_size=0 and skip_b_frames != 0 the amount of position of the identified commercials is completely wrong
Changes in 0.79.128
- It should now be possible to use the preview window on dvr-ms files. Not extensively tested and probably full of bugs. I need your feedback to improve (only for donators)
Changes in 0.79.127
- The previous build(s) generated a huge debug file called camples.csv. Is disabled now
Changes in 0.79.126
- Extra workaround implemented to prevent no sound detection on certain dvr-ms recordings
Changes in 0.79.125
- It is strongly adviced to set max_repair_size=0 for HDHomerun recordings.
- Bug solved: Comskip crashes under certain rare conditions
- Some HDHomerun recordings contain a track without sound, after 50 frames without sound another track is automatically selected
Changes in 0.79.124
- Setting skip_b_frames=2 will have Comskip skip frames on HD but not on SD, only available for donators
Changes in 0.79.123
- Adding output_aspect=1 to you ini file will instruct comskip to generate a .aspects file. This file lists the input resolution and aspect ratio changes. This information can be used for more efficient transcoding or automatic aspect ratio switching during playback.
Changes in 0.79.122
- Comskip can now skip frames to speed up processing, should work on HD streams. Set skip_b_frames=1 in your comskip.ini, only available for donators
Changes in 0.79.121
- New detection method added: RESOLUTION_CHANGE (detect_method 8), replaces the unused FUZZY_LOGIC (which is always on). Resolution_change will insert a hard cutpoint when the resolution of a digital recording changes.
- Improved accuracy during reviewing of cutpoints. Comskip could be up to 15 frames off during preview.
Changes in 0.79.120
- Bug solved: Comskip crashes when the recording changes from 1080i to 480i or 720p. 
Changes in 0.79.119
- Bug solved: Preview failed on certain TS files.
- During preview the 's' and 'f' keys will jump to Start and Finish of the recording
Changes in 0.79.118
- Bug solved: Previewing TS files failed once viewing near the end of the recording 
- Added ini parameter: edge_step=1 Set to 2 when you need extra speed on scanning for logo's on HD files. Will make logo detection slightly worse
Changes in 0.79.117
- Bug solved: On certain MPEG PS recordings no audio was detected leading to much worse detection quality
Changes in 0.79.116
- Fixed a bug that could cause the preview to freeze when reviewing .txt or .csv files
- Improved the demux to better find the audio stream on HD TS recordings, not having audio will make detection quality much worse. 
Changes in 0.79.115
- Changed the Zoomplayer Chapter list using AddChapterBySecond to output integers instead of floats
- Default comskip.ini file has now output_edl=1 to ensure correct skipping in SageTV and GBPVR
Changes in 0.79.114
- Increase input buffer to reduce strain on disks when running multiple comskip in parallel
- Solved the long outstandig "Why does Comskip find a very short commercial at the end of the recording" bug
Changes in 0.79.113
- Added a specific setting for live_tv_retries for dvrms files to avoid dvrms users having to edit the ini file
- Bug solved: Comskip sometimes stops processing before the end of the recording.
- Writes progress to stderr including percentage done
Changes in 0.79.112
- Bug solved: Comskip crashes when the video size changes during logo searching. 
Changes in 0.79.111
- Bug solve: On certain dvr-ms recordings audio decoding fails resulting in a lot of "Audio error" messages.
Changes in 0.79.110
- Added the output file for DVRMS Toolbox, enable with output_dvrmstb=1 in the ini file. A second commandline parameter can be used to specify the directory where the dvrmstb xml file should be written. Setting live_tv=1 will also have this xml file updated during scanning.
Changes in 0.79.109
- Improved the blackframe detection during live_tv processing
Changes in 0.79.108
- Changed the dvrmsstandoff algoritm. For a 8MBit/second recording you should use live_tv_retries=300, The higher the bitrate the lower the retries.
Changes in 0.79.107
- Added the dvrmsstandoff parameter for dvr-ms, default is dvrmsstandoff=120000, set dvrmsstandoff to the amount of kilobytes to stay from the end of the file when processing during recording. Make sure you set live_tv_retries high enough to allow the buffer to fill while waiting.
Changes in 0.79.106
- Increased the waiting time for the writing of dvr-ms files during live tv, set live_tv_retries=4 or higher if needed
Changes in 0.79.105
- Bug solved: Removed the bug that was introduced in build 104
Changes in 0.79.104: Do not use build 104!!!!!!!
- The default comskip.ini file is not very agressive, I changed the settings to be more agressive. If you start to miss parts of the show revert back to the comskip.ini that is in build 103
- Bug solved: Invoking comskipGUI.exe without any arguments could cause Comskip to crash.
- Bug created: Build 104 will ALWAYS display the debugwindow, even when called as a hidden process
Do use build 102 or earlier
Changes in 0.79.103
- Improvements for the for realtime scanning of dvr-ms input, may not work
Changes in 0.79.102
- Experimental implementation of Live_tv for realtime scanning of dvr-ms input
Changes in 0.79.101
- Solved a big bug in the audio decoding a. A lot of content should no longer cause a crash or bad decoding.
Changes in 0.79.100
- Some variable bitrate recordings failed to seek during preview, added variable_bitrate=1 in the ini file as default. Set to 0 if you want to fall back to unreliable byterate seeking
Changes in 0.79.99
- Changed the Zoomplayer chapter file to use seconds instead of frame numbers to solve alignment problem with digital broadcast
- The default ini file now disables the heuristics as results are too broadcast dependend. Enable with care
- Added the .vdr output format defined by the Linux Video Disk Recorder software and used by XBMC to autoskip commercials. Enable by setting output_vdr=1 in the ini file.
Changes in 0.79.98
- Removed the enable_mencoder_pts=1 setting and instead introduced the output_edlp=1 setting enable generating a pts based mencoder file
- Added a parameter logo_filter=0, default is disable. Set to the size of the filter to apply to improve unreliable logo recognition. Setting logo_filter=4 often solves most problems
Changes in 0.79.97
- Improved logo recognition
- When enable_mencoder_pts=1 is set in the ini file the generated .EDL file will use the PTS information for the cutpoints to support mencoder. Does ony work for TS files. Running comskip on the .CSV file will always be done as if enable_mencoder_pts=0
Changes in 0.79.96
- Bug solved: The executable name generated with output_mpeg2schnitt=1 was incorrect and the mpeg2schnitt_options did not work
Changes in 0.79.95
- Build 94 can not preview certain transport stream, do not use build 94
- Bug solved: Certain recordings do not seek correctly in the preview mode.
Changes in 0.79.94
- Bug solved: Some weird encoded transport streams could not be decoded
Changes in 0.79.93
- Bug solved: Sometimes the first commercial in a EDL file starts at 0.03 i.s.o. 0.0
- Bug solved: Certain transport stream recordings with PID's above 256 could not be decoded.
Changes in 0.79.92
- Reduced the minimum acceptable logo_fraction before disabling logo detection to accomodate for huge postpadding in australian recordings. New default is logo_fraction=0.40 i.s.o. 0.50
Changes in 0.79.91
- MAJOR SPEED INCREASE! 20% to 45% faster (depending on your CPU) then the previous builds
Changes in 0.79.90
- Increased the robustness of the TS detector, required for HDHomerun
Changes in 0.79.89
- Change the AR punishment appraoch for small blocks.
- Relaxed criteria for aspect ratio detection.
Changes in 0.79.88
- The new aspect ratio algorithm proved to be flawed when logo's where present during black frames. This is solved now
- Stricter criteria for aspect ratio detection.
Changes in 0.79.87
- Added global heuristics to correct small errors at start of show segment.
- Added ini parameter min_commercial_break_at_start_or_end=39, any commercials shorter than that size in seconds at start of end of recording will not be remove.
- Large retest of many small parts resulting in improved commercial recognition.
Changes in 0.79.86
- Added ini parameter videoredo_offset=3 where 3 is the default, will cause all videoredo output to be advanced with 3 frames.
Changes in 0.79.85
- Bug solved: Also MPEG PS files did have inconsistent frame numbers before and after logo discovery
Changes in 0.79.84
- A completely new aspect ratio detection algorith that also is able to detect letterboxed 4/3 inside 16/9 ATSC. Some parts are experimentel so Comskip may crash.
Changes in 0.79.83
- Created a workaround for previewing recordings with corrupted timelines. Positioning accuracy is not perfect, could be up to 50 frames off.
Changes in 0.79.82
- Bug solved: Comskip crashes when cutscene files are defined in the ini file.
Changes in 0.79.81
- Cutpoints caused by cutsceneframes no longer need silence to be accepted as cutpoints
Changes in 0.79.80
- Changed the processing of silence cutpoints to accomodate for a broader set of broadcasting variants
- Bug solved: It is not possible to disable global heuristic 6
Changes in 0.79.79
- Add the disable_heuristics as a binary mask setting for selective disabling of heuristics, Add the selected rules, Rule 1 -> 1, Rule 2 -> 2, Rule 3 -> 4, Rule 4 -> 8, etc... 
- It is no longer possible to disable all global heuristics by disabling the FUZZY_LOGIC in the detect_methods , use disable_heuristics instead. set disable_heuristic=511 to disable all current heuristics
Changes in 0.79.78
- Bug solved: Sometimes when autoselecting the video PID, no audio is found
- Bug solved: Some recordings with logo did have up to 15 frames too much at the start causing all cutpoints to be upto 15 frames too late. 
Changes in 0.79.77
- Changed some of the heuristics to accomodate for long show blocks without logo
- Changed the names of the generated .bat files to include a postfix marking the used cutter so you can generate multiple .bat files. WARNING: Incompatible with previous version
- Added option: Set non_uniformity=0 to disable checking for uniform frames
- Added cutpoint option: cut_on_ar_change=2 forcing AR change cuts even when no logo has been found. Use with care!!!!
Changes in 0.79.76
- Bug solved: Since build 73 the results of processing the mpeg and the corresponding csv give inconsistent results.
Changes in 0.79.75
- Bug solved: Sometimes audio and video run out of sync during processing.
Changes in 0.79.74
- Bug fixed: Inconsistent frame numbers between normal processing and previewing on certain files.
Changes in 0.79.73
- Added a separate executable for using the DebugWindow ComskipGUI.exe, no longer needed to edit the shortcut for activating the debugwindow, simply drag and drop onto ComskipGUI.exe
- New cutpoint detection method: CutScenes, method number 128
First record one or more frames to be used as cutscene by running ComskipGUI on the MPEG, move to the frame you want to use as cutscene and hit 'C'. Select where you want the frame to be saved.
Then use up to 8 cutsceneframes in your ini file
cutscenefile1="C:\\Work\\cutscene1.dmp"
cutscenefile2="C:\\Work\\cutscene2.dmp"
Set the cutscene threshold higher if you have low quality video. 
cutscene_threshold=20
Using more cutscenes will slowdown Comskip, when cutscenes are enabled the Debugwindow will show in the pink line cutscene information instead of scene change information
Changes in 0.79.72
- Again many small improvements in timeline repairing. Hope this is fixing most of the problems.
- Bug solved: Comskip crashes on certain recordings.
- Preview in the Debugwindow should work again except on some very bad timelines
Changes in 0.79.71
- Preview in the Debugwindow is broken!!!!!!
- An extensive check has been performed on the timeline repairing and many small improvements where made. This should improve consistency between Comskip output and Videoredo consistency. Set max_repair_size=200 to enable or max_repair_size=0 to disable
- Added a noise filter in the mpeg decoder
- There is a higher chance of bugs in this release due to the larger amount of changes. Please test before using in a production environment.
- Bug solved: When a .csv file contains scene_change cuts they are not discarded when the detect_method does not use scene_change
Changes in 0.79.70
- It is now possible to disable all global heuristics by disabling the FUZZY_LOGIC in the detect_methods (method 8), possibly usefull in a strongly regulated USA environment.	
- Did some finetuning on the detection of strict durations.
- Bug solved: The last couple of seconds of a recording are sometimes incorrectly classified as show
- The fixed part of the AVS output files is now configurable in comskip.ini
Changes in 0.79.69
- New output format: Avisynth, set output_avisynth=1
Changes in 0.79.68
- Improved auto PID selection.
- Bug solved: A certain audio stream causes Comskip to crash
Changes in 0.79.67
- Bug solved: Incorrect processing of Australian 50fps HD recordings 
Changes in 0.79.66
- Bug solved: no preview available when editing a .TXT coming from a .dvr-ms recording
Changes in 0.79.65
- Bug solved: Comskip crashes on certain ASTC recordings.
Changes in 0.79.64: do not use due to ATSC bug
- Bug solved: Incorrect Aspect Ratio used on certain segments causing big mistakes.
- Bug solved: The delete_show_after_last_commercial did not work under certain conditions
Changes in 0.79.63: do not use due to ATSC bug
- Changed the alignment of the frame numbers in the .mls bookMark file as used by the latest version of MPEG Video Wizard
- Added the option to set the title of the debugwindow to allow remote control. Default is windowtitle="Comskip - %s" where %s will get substituted by the filename
Changes in 0.79.62
- Bug solved: BTV versions starting with 4.3 break Comskip on Live TV viewing. Set live_tv_retries=16 and standoff=8000000 (or any amount above 4MByte) in the comskip.ini file 
Changes in 0.79.61
- Added parameter for ignoring gray side bars, set ignore_side=number of pixels to ignore, check visual in debugwindow
- Bug solved: Long commercials are not recognized on 60fps HD recordings
Changes in 0.79.60
- Added visual feedback while tuning certain parameters (F2,F3,F4 in debugwindow mode)
- Bug solved: Panic: Unknown audio format when switching between MPEG and AC3 audio in one recording.
- Bug solved: Videoredo requires the comment field in the BTV xml file to be filled with the right time code 
Changes in 0.79.59
- Changed the logo recognition to allow for logo's outside the aspect ratio
Changes in 0.79.58
- Bug solved: When logo_present_modifier=1 the excessive_length_modifier should always be used
- Added parameter delete_block_after_commercial, set to the maximum size in seconds of a block to be deleted after a commercial, set to 0 to disable
Changes in 0.79.57
- The extension of the cuttermaran video output file is now set to .m2v
- Added the output format for BSPlayer, to enable set output_bsplayer=1, this will generate a .bcf file
Changes in 0.79.56
- Bug solved: As of build 55 the <\cutlist> is missing on the btv output for some recordings
- Added comment=\"00:00:00.0000000\" to the btv output to facilitate importing the cutlist in womble
Changes in 0.79.55
- Bug solved: After pressing the 'W' key when editing the cut list sometimes the first commercial disappears for certain output formats
- Bug solved; In certain output formats sometimes the first commercial is missing.
Changes in 0.79.54
- Bug solved: Hangup on certain Transport Streams
Changes in 0.79.53
- Added the SceneMarker info to the videoredo output file to aid manual touchup
Changes in 0.79.52
- Live TV detection now also will create .edl file when output_edl is enabled
- Setting verbose to 10 will show in the log file the values of all configurable parameters
Changes in 0.79.51
- Improved detection of logo when letterboxed video
- Bug solved: SaveTV still gets into a loop when a commercial shorter the 10 seconds at the start is detected.
Changes in 0.79.50
- Parameter added: Set logo_at_bottom=1 to search only for logo in the bottom part of the video
- Bug solved: SaveTV still gets into a loop when a very short commercial at the start is detected.
Changes in 0.79.49
- Bug solved: SageTV needs tabs instead of spaces in the .edl file
- Bug solved: SaveTV gets into a loop when a very short commercial at the start is detected.
Changes in 0.79.48
- Bug solved: remove_after does not have any effect, all commercials shortened with fps frames.
Changes in 0.79.47
- Bug solved: Certain DVR-MS files cause a buffer overrun in sound decoding
- Parameter added: BTV requires a longer time to check for end of recording during live_tv. Set live_tv_retries=8 in the ini file.
Changes in 0.79.46
- Added two ini file parameters, remove_before and remove_after, will remove the given amount of seconds of show before or after ALL commercials
- Increase amount of memory available during live_tv processing to prevent out_of_memory crash when processing very long recordings.
Changes in 0.79.45
- Bug solved: A TS file with MANY PID's causes Comskip to crash
- Improved algorithm to deal with LiveTV in BTV 4.3 
Changes in 0.79.44
- Added in the debugwindow the option to toggle blocks between commercial and show. Is available after processing an mpeg or a .csv file. Output files are rewritten after each toggle. The refference bar stays at the original detection results. Use the 'T' key to toggle
Changes in 0.79.43
- Changed output for ProjectX from mode 4 to mode 2 to solve ProjectX problem
- Added the PID info for VideoRedo processing of Transport Streams
Changes in 0.79.42
- When for a TS file a non existent PID is specified on the commandline a list of available video PID's will be shown in the log file.
Changes in 0.79.41
- It is again possible to select the video pid in a TS file with --pid=xx where xx is pid of the video stream, all input and reporting on pid's is done in hexadecimal format. The Audio pid will be autoselected
- Bug solved: When a video stream has two audio streams (such as stereo and 5.1) the audio decoding will fail with all kind of error messages.
Changes in 0.79.40
- Added parameter: punish_no_logo, default is 1, if set to punish_no_logo=0 then the absence of logo is not punished towards commercial.
- Added parameters: validate_xxx, default is 1, if set to validate_xxx=0 then the validity of cut points coming from volume, scenechange and uniform will not be assessed
- Bug solved: Certain AC3 formats not recognized leading to many "Audio PTS jumped" messages
Changes in 0.79.39
- Added MPeg Video Wizard bookmark file output, set output_mls=1
- Corrected an error in the dvrcut_options parameter
- Bug solved: Sometimes a 0:0:0 0:0:0 show segment is generated causing DVRCut to crash
- Certain AC3 formats are NOT recognized, this is indicated by many many "Audio PTS jumped" messages in the log file.
- Bug solved: sage_minute_bug solution always rounds down instead of up or down.
Changes in 0.79.38
- Added parameter: Setting sage_minute_bug=1 in the ini file will correct the frame numbers in the .txt file in a sage specific way.
Changes in 0.79.37
- Added parameter: drvcut_options to set the way the dvrcut .bat file is being generated. The default allows for direct execution without any parameters
- Bug solved: No audio decoded with AC3 in MPEG PS files.
- Bug solved: AC3 audio decoding unreliable
Changes in 0.79.36
- Added ini parameter, setting output_dvrcut=1 will enable the generation of the bat file that can run the commandline dvr-ms cutter to generate a clean dvr-ms file. You need dvrcut.zip for this
Changes in 0.79.35
- Bug solved: Commercial frame numbers found on dvr-ms files with logo where completely wrong.
- Bug solved: There is a difference in results when processing an mpeg or the corresponding .csv
Changes in 0.79.34
- Added the proposed cutlistformat for TVersity, enable with output_edlx=1. Warning: This output only is available correctly when scanning the video file, not when editing the cutpoints or processing the .csv file.
- Added ini parameter sage_framenumber_bug=1 to halve the .txt file frame numbers when 720p/60fps content is detected.
- Changed logic when enabling both SILENCE and other detection methods to become more robust against input variations over broadcasting styles.
- Warning: Some changes did have the risk of slightly less quality in detection. Notify me when you detect this.
Changes in 0.79.33
- Added ini parameter max_repair_size=40 controls the maximum jump in frames of the PTS still to be repaired
- Bug solved: Restarting after logo found does not restart the demux output.
Changes in 0.79.32
- Added the BTV Smartskip output format, set output_btv=1 in the comskip.ini file to enable
- Bug solved: AC3 sound volume is too high causing missing of black frames
- Bug solved: Recording with 3/2 pull down has wrong frame numbers leading to incorrect cut points
- Bug solved: The volume_slip default value is too low
- Added parameter in ini file: ms_audio_delay=5 set to the number of frames audio lags video in dvr-ms files. Default value of 5 should be OK for most recordings.
Changes in 0.79.31
- Comskip will detect missing/faulty frames in recordings and try to correct for this to ensure correct frame numbers
- Comskip will analyze the timeline of the recording and warn if and how the timeline is broken when verbose is at least 1
- Bug solved: -m and --demux switch did not work
- New output format: ProjectX cutlist, setting output_projectx=1 will cause Comskip to generate a ProjectX cutlist file.
Changes in 0.79.30
- New output switch: output_demux=1 or "-m" switch will demux the input file into elementary video and audio streams during scanning.
- Bug solved: Audio timeline in DVR-MS was inconsistent with video
- Bug solved: Reviewing and cutpoint editing works for dvr-ms files
- Bug solved: The .cvf file contained a negative start frame number for a show segment starting at the start of the recording.
Changes in 0.79.29 dvr beta2
- DVR-MS input should work, no reviewing or editing but preview during scanning works, always use .dvr-ms as extension for dvr-ms files
- Known bug: After finishing the scan Comskip can crash on DVR-MS files in preview mode.
Changes in 0.79.29 beta
- Extensive testing has brough substantial improvements to the TS decoder, it now works on all submitted streams
- AC3 decoding for TS works.
- Tested both ATSC and DVB-T streams and everything seems to work but remember, this is a beta release, if something fails, notify me on the forum, see above.
Changes in 0.79.28
- Added output for mpeg2schnit, set output_mpeg2schnitt=1 and mpeg2schnitt_options in ini file
Changes in 0.79.27
- Bug solved: First commercial missing in videoredo project file
Changes in 0.79.26
- Added scoring modifiers based on comparing to average value of Brightness, Non-Uniformity, Volume, Non Silence and Scene change rate.
- Added parameters to controll this scoring: punish, punish_threshold and punish_modifier, see ini file for details.
- Added graphs in Debugwindow to show where parameters are above threshold for scoring, indicated by red lines.
- Warning: Do not blindly enable these because you assume commercials are louder, brighter, etc... Do check your assumptions. I have not yet found a foolproof approach to have them always enabled.
- No longer required to have Black Frame detection enabled. Certain recordings work better without this.
Changes in 0.79.25
- New detection method: SILENCE, creates candidate cutpoints if volume below deep silence, duration set by min_silence
- new parameter: min_silence=20 Number of frames required for deep silence detection.
- Bug solved: Last commercial in Videoredo outputfile missing
Changes in 0.79.24
- Made a big change to improve finding weak logo's (like on NZ's channel ONE)
- Some heuristics improvements for very short segments
- Comskip will check you logo_threshold setting and suggest a value in the log file. Can work only on recordings of at least 45 minutes.
- Fixed a buf that could cause the wrong ini file to be used
Changes in 0.79.23
- Added the -t commandline switch to enable Transport Stream input. TS files can have .ts or .mpg as an extension
- Files with a .ts extension are assumed to be a Transport Stream
- The debugwindow can show graphs of all measured parameters, use 'G' key to toggle
- It is now possible to zoom into the timeline fo accurate positioning of cutpoints, 'Z' to zoom, 'U' to unzoom
Changes in 0.79.22
- Fixed a bug in the .vcf output format
Changes in 0.79.21
- Corrected a bug causing comskip to crash when no EDL output was created.
Changes in 0.79.20
- Cutlist changes will be immidiately shown on the timeline
- New outputfile format .vcf for Virtualdub. Enable with output_vcf=1 in the ini file.
Changes in 0.79.19
- Improved identification of commercials
- Added a play_nice_sleep parameter to the ini file to allow configuration of the processor load
- Fixed a bug causing play_nice_start and play_nice_end in the ini file not to work .
Changes in 0.79.18
- Solved a crash when AR was disabled in detect_method
- Improved the heuristics for before_logo and after_logo
Changes in 0.79.17
- Any two logo segments with a gap less then min_commercial_size will be joined to one logo segment
- Any logo segment less then min_commercial_size will be deleted
- Added a delete_show_before_first_commercial ini parameter with default value of 0, usefull if you have a lot of prepadding.
- Improved the after_logo behaviour to set cutpoint at silence and maximum scene change in a 30 seconds windows after the after_logo, this solves the problem of a commercial break without starting black frame.
Changes in 0.79.16
- Extensive recheck of all the scoring and heuristics rules resulting in many small corrections
Changes in 0.79.15
- Fix a bug causing wrong aspect ratio processing for recordings with a low amount of horizontal pixels
- Added the posibility to always force cutting on aspect ratio by setting cut_on_ar_change=2
Changes in 0.79.13
- Fixed the overlapping of the last two last commercial segments when the last commercial found ended at the end of the recording. 
- Fixed a wrong configuration causing the generation of a very large timing.csv file
Changes in 0.79.12
- Change the debugwindow title to Comskip so it can be found by other programs
- Increased the size of the commercial bar when using a .txt file as input to avoid overscan problems
- Introduced a possible fix for a bug that caused Comskip to exit when invoked with an empty or incorrect .txt file.
Changes in 0.79.11
- Fixed a bug causing deletion of of the EDL file when using a txt file to inspect the found commercials
- Fixed a bug causing incorrect handling of the final 1 frame commercial.
Changes in 0.79.10
- Remember to us a 4 times higher non_uniformity setting when recording HD!
- Both the edl file and the txt file have as last entry a one frame size commercial at the end of the recording
- Now you can set the cuttermaran command options in cuttermaran_options in the ini file
- The ini file is first searched for in the directory where the mpg file resides so you can automatically have multiple ini files.
- The current block is highlighted in the timeline in the debugwindow
- The csvout command ine switch is working again
Changes in 0.79.8
- Changed the numbering in the womble clip list to work around a womble bug
Changes in 0.79.7
- Improved the delete_show_before_or_after_current processing to deal with commercials up to min_commercial_size seperating the current and the previous/next show
- Solved a bug that was causing Comskip to crash on certain recordings
- Improved the display of found logo in the display bar. No more false positives
Changes in 0.79.06
- Fixex a hangup in debug window when the timeline of the mpg is corrupt
Changes in 0.79.05
- Fixed a bug causing a crash with 60 fps material.
Changes in 0.79.04
- Improvements in the heuristics
Changes in 0.79.01
- Can process mpeg video with size up to 2000 by 1200
- Moved the info bar in the debug window to above the video
- Enabled the scaling of video in debugwindow, anything above 800x600 will be halved in size 
Changes in 0.78.02
- Solved a bug where setting a new 'b'eginning of a commercial the written cutpoint was 10 frames earlier
- Solved a bug where after editing the cutpoints all output formats that where in time instead of frames could be wrong. 
- Change the format of the TXT file to include the framerate to solve the bug above.
- Solved a bug where the output files where cleared if no 'w' was used when reviewing the .txt file.
Changes in 0.78.01
- Writing a new cutlist writes all selected output files instead of only the txt file
- Substantial changes to heuristics.
Changes in 0.77.77
- Added the output_edl parameter to generate the edit decision list for mencoder so you can cut and convert at the same time.
Changes in 0.77.76
- Solved a bug that might cause a crash when live_tv is on on a very long recording
- Solved a bug that might cause a crash when the timeline of the input mpeg is severily corrupt
- Improved the heuristics related to Aspect Ratio mismatch
- Improved the heuristics related to logo changes
Changes in 0.77.68
- Fixed a bug in the support for cuttermaran
- Added the information required to run cuttermaran from the commandline
Changes in 0.77.66
- Added support for output for cuttermaran
Changes in 0.77.65
- Added the ticker_tape option to ignore a certain amount of pixels at the bottom. Nice if you have a continues ticker tape or fixed logo at the bottom and still want to detect black frames for the rest of the screen.
Changes in 0.77.61
- Solved a bug in sound processing causing too many black frames to be detected.
Changes in 0.77.59
- Its is now possible to review the .txt file by running comskip on it such as: comskip filename.txt
- Now it is possible to edit the begin, end and number of commercials in the debugwindow and write out an updated .txt file, also for output of older Comskip versions.
- Added the shrink_logo parameter to reduce the duration of the logo if it extends into the commercial
- The ESCAPE key can be used to exit comskip in debugwindow mode
- Corrected a bug that prevented the reviewing of .txt files of long recordings 
- Corrected a bug in the CSV file causing problems with NTSC
- Corrected a bug in shrink_logo processing which could cause a crash
Changes in 0.77.52
- Fixed a buf in the application of padding
- Corrected a bug that prevented the after_logo cutpoints to be shown in the debugwindow
- Added a debug window showing in graphical way the processing and results of Comskip, enable with -w. 
- Added intelligence for situations with logo only on commercials, logo everywhere and different logo's on commercials and show.
- Added intelligence for detecting the end of the previous show and the beginning of the next show
- Fps is now read from the mpg file, no need to adjust it anymore.
- If a .ref file with the same name and structure as the .txt file is present in the directory of the mpg file then it is used for comparison
- When verbose=10 a histogram of the volume is written to the log to help determin the max_volume
- Added cut_on_ar_change parameter in ini file
- live_tv=1 works again
- Added delete_show_after_last_commercial to do what is says.
- Added a commandline option to set the logo file so a learned logo can be re-used. --logo=filename.logo.txt
- Multiple ini files can be used with the --ini=filename.ini commandline switch. Use --ini=comskip%2.ini in postprocessing.bat to have a per channel ini file.
- Added the possibility to review the output of comskip in the debugwindow. When finished positioning the mpeg is possible with cursor keys and mouse.

Changes in 0.74
- Corrected a bug that prevented the use of the minimum commercial size
- Improved the comparison with the reference file

Changes in 0.73
- Added sound processing
- Improved blackframe and logo processing which makes tuning less important.
- Speed has not improved due to the added processing.
- Framerate is now automatically read from the mpeg file, no need to set in the ini.
- Did a lot on the block algorithm which may not have improved the performance for you ;-)
- 

Changes in 0.72
- Fixed a bug causing noisy black frames not to be recognized, this can improve performance considerable!
- Changed the CSV file to use ';' as separator so you can load it into excel without conversion.

Changes in 0.71
- Many changes in the log file, most specific in the final block list, hope you like it!

Changes in 0.70
- Any frame with a non_uniformity below the threshold will be used as a cut point. So pur blue or pure white will work. Default is 100.
- A show_percentile below about 0.2 will be added to the logo_percentile to get the real show_percentile. Usefulle for shows that take some time before the logo appears
- Determining show/commercials for a recording without logo with many very darks scenes is not working, but then I don't know how this will ever work. 
- Some improvements in the log file (mostly for myself).

Changes 0.69
- About 25% faster then comskip 0.64
- Logo learning is substantial more robust leading to much better logo recognition
- The written framearray now also shows the (aspect_ratio-1)*100
- Corrected some stupid errors that where leading to a bad performance.
- The show_percentile is automatically calculated from the logo_percentage when sufficient logo is found.
- experimental code for settings generating cutpoints before and after a logo, value is in seconds, should be 10 or bigger, 0 disables
- have installed automatic regression testing on a test set of 10 shows to prevent future stupid errors 

Changes 0.68
- The written framearray can not be read back!!! You can import it in a spreadsheet to do extensive evaluation of blackframe detection, logo detection and aspect ratio detection
- The written framearray now includes the variable "uniform" that shows the quality of the black frames.
- The saved logo file combines horizontal and vertical edges in one presentation. Should be easier to read
- Ascpect Ratio changes do generate candidate cutpoints
- Logo processing shows time before logo appears and time after logo disappearing.
- Scene Change detection seems to be based on wrong assumptions, please do not use it.
- Debug level above 2 shows the Long/Short block ratio per long block to support blackframe detection tuning. The ratio should be above 50 percent.

Changes 0.67
- Fixed the bug that prevented the scene change rate to be used in the calculation
- Now logo's at the right side of the screen are also detected
- A new parameter for the ini files is added ar_split, it sets the ration above which it is assumed to be widescreen
  If you see too many AR segments increase the minimum commercial length

No dictonary is included, please use your old one.
The comskip.ini included is mine, please adapt it to your settings!!!!!!

