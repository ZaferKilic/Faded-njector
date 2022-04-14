// Decompiled with JetBrains decompiler
// Type: FadedInjector.Properties.Resources
// Assembly: FadedInjector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BC737EBC-507F-4EF8-AD74-E9059D311E61
// Assembly location: C:\Users\tcool\Downloads\FadedInjector.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace FadedInjector.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (FadedInjector.Properties.Resources.resourceMan == null)
          FadedInjector.Properties.Resources.resourceMan = new ResourceManager("FadedInjector.Properties.Resources", typeof (FadedInjector.Properties.Resources).Assembly);
        return FadedInjector.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => FadedInjector.Properties.Resources.resourceCulture;
      set => FadedInjector.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap discord => (Bitmap) FadedInjector.Properties.Resources.ResourceManager.GetObject(nameof (discord), FadedInjector.Properties.Resources.resourceCulture);
  }
}
