/*
 * MIT License
 *
 * Copyright (c) 2022 Aptivi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */

#if NET
using System.Runtime.Versioning;
#endif

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace UnameNET
{
#if NET
	[UnsupportedOSPlatform("windows")]
#endif
	public static class UnameManager
    {
        /// <summary>
        /// Gets details from the uname process
        /// </summary>
        /// <param name="unameTypes">All the uname types the high-level APIs passed</param>
        /// <returns>Uname string output</returns>
        public static string GetUname(UnameTypes unameTypes)
        {
			// Check the platform
			if (Environment.OSVersion.Platform != PlatformID.Unix)
				throw new PlatformNotSupportedException("This library is only supported on Unix.");

			// Check the uname executable paths
			string UnameExecutable = File.Exists("/usr/bin/uname")     ? "/usr/bin/uname"     : "/bin/uname";
		    UnameExecutable        = File.Exists("/system/xbin/uname") ? "/system/xbin/uname" : UnameExecutable;

			// Select arguments according to the types
			StringBuilder argsBuilder = new();
			if (unameTypes.HasFlag(UnameTypes.KernelName))
				argsBuilder.Append("-s ");
			if (unameTypes.HasFlag(UnameTypes.KernelRelease))
				argsBuilder.Append("-r ");
			if (unameTypes.HasFlag(UnameTypes.KernelVersion))
				argsBuilder.Append("-v ");
			if (unameTypes.HasFlag(UnameTypes.NetworkNode))
				argsBuilder.Append("-n ");
			if (unameTypes.HasFlag(UnameTypes.Machine))
				argsBuilder.Append("-m ");
			if (unameTypes.HasFlag(UnameTypes.OperatingSystem))
				argsBuilder.Append("-o ");
			string Args = argsBuilder.ToString().Trim();

			// Make a new instance of process
			Process UnameS = new();
			ProcessStartInfo UnameSInfo = new()
			{
				FileName = UnameExecutable,
				Arguments = Args,
				CreateNoWindow = true,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden,
				RedirectStandardOutput = true
			};
			UnameS.StartInfo = UnameSInfo;

			// Start the process and wait for the output to flow
			UnameS.Start();
			UnameS.WaitForExit();

			// Return the output
			return UnameS.StandardOutput.ReadToEnd().Trim(new char[] { '\n' });
		}
    }
}