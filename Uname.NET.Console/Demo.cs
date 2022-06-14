/*
 * MIT License
 *
 * Copyright (c) 2022 EoflaOE and its companies
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

#if NETCOREAPP
using System.Runtime.Versioning;
#endif

namespace UnameNET.Console
{
#if NETCOREAPP
    [UnsupportedOSPlatform("windows")]
#endif
    internal class Demo
    {
        static void Main()
        {
            System.Console.WriteLine("Kernel name:      {0}", UnameManager.GetUname(UnameTypes.KernelName));
            System.Console.WriteLine("Kernel release:   {0}", UnameManager.GetUname(UnameTypes.KernelRelease));
            System.Console.WriteLine("Kernel version:   {0}", UnameManager.GetUname(UnameTypes.KernelVersion));
            System.Console.WriteLine("Network node:     {0}", UnameManager.GetUname(UnameTypes.NetworkNode));
            System.Console.WriteLine("Machine:          {0}", UnameManager.GetUname(UnameTypes.Machine));
            System.Console.WriteLine("Operating system: {0}", UnameManager.GetUname(UnameTypes.OperatingSystem));
        }
    }
}