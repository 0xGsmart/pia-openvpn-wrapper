# pia-openvpn-wrapper
PIA's `openvpn.log` file can become hundreds of GB large with continual usage. This issue was reported to PIA on their [forums](https://www.privateinternetaccess.com/forum/discussion/18461/large-log-files) but no patch has been released yet.
This project aims to provide that fix.


## Installation
* Stop PIA
* Find your `pia_manager` folder. This should be located at `C:\Program Files\pia_manager` or `C:\Program Files (x86)\pia_manager`
* Rename the `openvpn.exe` file in the pia_manager folder to `openvpn-orig.exe` (the file will still be used and it must be exactly that filename)
* Download the latest [Release](https://github.com/jbob182/pia-openvpn-wrapper/releases/download/v1.0.0/openvpn.exe)
* Place the downloaded `openvpn.exe` into your `pia_manager` folder
* Start PIA

An `openvpn.log` file will still exist, but will be minimal in size, and be cleared out every time you restart PIA / your computer.

## How it works
PIA keeps openvpn in standard verbose mode. This means a great detail of information is logged. This application acts as a wrapper, putting openvpn into silent mode and deleting any old logs.

You can examine the [source code](https://github.com/jbob182/pia-openvpn-wrapper/blob/master/Program.cs) for further information.
