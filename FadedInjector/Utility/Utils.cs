// Decompiled with JetBrains decompiler
// Type: FadedInjector.Utility.Utils
// Assembly: FadedInjector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BC737EBC-507F-4EF8-AD74-E9059D311E61
// Assembly location: C:\Users\tcool\Downloads\FadedInjector.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FadedInjector.Utility
{
  public class Utils
  {
    private const int PROCESS_CREATE_THREAD = 2;
    private const int PROCESS_QUERY_INFORMATION = 1024;
    private const int PROCESS_VM_OPERATION = 8;
    private const int PROCESS_VM_WRITE = 32;
    private const int PROCESS_VM_READ = 16;
    private const uint MEM_COMMIT = 4096;
    private const uint MEM_RESERVE = 8192;
    private const uint PAGE_READWRITE = 4;

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(
      int dwDesiredAccess,
      bool bInheritHandle,
      int dwProcessId);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr VirtualAllocEx(
      IntPtr hProcess,
      IntPtr lpAddress,
      uint dwSize,
      uint flAllocationType,
      uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool WriteProcessMemory(
      IntPtr hProcess,
      IntPtr lpBaseAddress,
      byte[] lpBuffer,
      uint nSize,
      out UIntPtr lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    private static extern IntPtr CreateRemoteThread(
      IntPtr hProcess,
      IntPtr lpThreadAttributes,
      uint dwStackSize,
      IntPtr lpStartAddress,
      IntPtr lpParameter,
      uint dwCreationFlags,
      IntPtr lpThreadId);

    public void InjectDLL(string DLLPath)
    {
      if (Process.GetProcessesByName("Minecraft.Windows").Length != 0)
      {
        Utils.applyAppPackages(DLLPath);
        IntPtr hProcess = Utils.OpenProcess(1082, false, Process.GetProcessesByName("Minecraft.Windows")[0].Id);
        IntPtr procAddress = Utils.GetProcAddress(Utils.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
        IntPtr num = Utils.VirtualAllocEx(hProcess, IntPtr.Zero, (uint) ((DLLPath.Length + 1) * Marshal.SizeOf(typeof (char))), 12288U, 4U);
        Utils.WriteProcessMemory(hProcess, num, Encoding.Default.GetBytes(DLLPath), (uint) ((DLLPath.Length + 1) * Marshal.SizeOf(typeof (char))), out UIntPtr _);
        Utils.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, num, 0U, IntPtr.Zero);
      }
      else
      {
        int num1 = (int) MessageBox.Show("Minecraft is not open, launching now...");
        Process.Start("minecraft://");
        Thread.Sleep(2000);
        this.InjectDLL(DLLPath);
        int num2 = (int) MessageBox.Show("You appear to not have Minecraft installed!");
      }
    }

    public static void applyAppPackages(string DLLPath)
    {
      FileInfo fileInfo = new FileInfo(DLLPath);
      FileSecurity accessControl = fileInfo.GetAccessControl();
      accessControl.AddAccessRule(new FileSystemAccessRule((IdentityReference) new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
      fileInfo.SetAccessControl(accessControl);
    }

    private void FileCompleted(object sender, AsyncCompletedEventArgs e)
    {
    }

    public void DownloadFile(string file, string location) => new Thread((ThreadStart) (() =>
    {
      WebClient webClient = new WebClient();
      webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.FileCompleted);
      webClient.DownloadFileAsync(new Uri(file), location);
    })).Start();

    public void CheckForDirectory()
    {
      if (Directory.Exists(MainForm.AssetDirectory))
        return;
      Directory.CreateDirectory(MainForm.AssetDirectory);
    }

    public void InjectClient()
    {
      switch (((ListControl) ((MainForm) Application.OpenForms["MainForm"]).ClientList).SelectedIndex)
      {
        case 0:
          this.InjectDLL(MainForm.AssetDirectory + "Horion.dll");
          break;
        case 1:
          this.InjectDLL(MainForm.AssetDirectory + "Packet.dll");
          break;
        case 2:
          this.InjectDLL(MainForm.AssetDirectory + "Onix.dll");
          break;
        case 3:
          this.InjectDLL(MainForm.AssetDirectory + "NG.dll");
          break;
        case 4:
          this.InjectDLL(MainForm.AssetDirectory + "Fadeaway1.16.201.dll");
          break;
        case 5:
          this.InjectDLL(MainForm.AssetDirectory + "Fadeaway1.17.11.1.dll");
          break;
        case 6:
          this.InjectDLL(MainForm.AssetDirectory + "Zephyr.dll");
          break;
        case 7:
          this.InjectDLL(MainForm.AssetDirectory + "Kek.dll");
          break;
        case 8:
          this.InjectDLL(MainForm.AssetDirectory + "Bom.dll");
          break;
      }
    }
  }
}
