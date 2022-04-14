// Decompiled with JetBrains decompiler
// Type: FadedInjector.Program
// Assembly: FadedInjector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BC737EBC-507F-4EF8-AD74-E9059D311E61
// Assembly location: C:\Users\tcool\Downloads\FadedInjector.exe

using System;
using System.Windows.Forms;

namespace FadedInjector
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new MainForm());
    }
  }
}
