/**
*Copyright (c) <2015> <copyright jbob182>
*Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
*The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/


using System;
using System.Diagnostics;
using System.IO;

namespace openvpn
{
    static class Program
    {
        static int Main(string[] args)
        {
            var dir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            CleanLog(dir);
            var argString = "--verb 0 " + Environment.CommandLine;

            var exePath = Path.Combine(dir, "openvpn-orig.exe");

            var proc = new Process
            {
                StartInfo =
                {
                    FileName = exePath,
                    Arguments = argString,
                    CreateNoWindow = true,
                    WindowStyle =  ProcessWindowStyle.Hidden,
                    UseShellExecute = false
                }
            };

            proc.Start();
            proc.WaitForExit();

            return proc.ExitCode;
        }

        private static void CleanLog(string dir)
        {
            var logFile = Path.Combine(dir, "log", "openvpn.log");

            try
            {
                if (File.Exists(logFile))
                {
                    File.Delete(logFile);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
