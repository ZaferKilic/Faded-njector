// Decompiled with JetBrains decompiler
// Type: FadedInjector.MainForm
// Assembly: FadedInjector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BC737EBC-507F-4EF8-AD74-E9059D311E61
// Assembly location: C:\Users\tcool\Downloads\FadedInjector.exe

using DiscordRPC;
using FadedInjector.Properties;
using FadedInjector.Utility;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FadedInjector
{
  public class MainForm : Form
  {
    public string FileToInjectDir;
    public DiscordRpcClient client;
    public readonly string InjectorDirectory = AppDomain.CurrentDomain.BaseDirectory;
    public static readonly string AssetDirectory = Directory.GetCurrentDirectory() + "\\Assets\\";
    public readonly string AssetGitClient = "https://github.com/FadedKow/Assets/raw/main/MCBE%20Clients/";
    public string McVersion;
    private Utils Util = new Utils();
    private IContainer components;
    private Guna2Elipse Elipse;
    private Guna2ControlBox Exit;
    private Guna2DragControl DragPanel;
    private Guna2ShadowForm Shadow;
    private Guna2ControlBox Minimize;
    private Guna2Panel Titlebar;
    private Label InjectorLabel;
    private Guna2Button Inject;
    private Guna2CustomCheckBox AutoInject;
    private Guna2Button SelectDLL;
    private Guna2ShadowPanel SettingsPanel;
    private Label AutoInjectLabel;
    private Guna2ShadowPanel InjectPanel;
    private Label RpcLabel;
    private Guna2CustomCheckBox DiscordRpc;
    private Guna2ShadowPanel ClientsPanel;
    private Guna2CircleButton Help;
    public Guna2ComboBox ClientList;
    private Guna2DragControl DragTitle;
    private Guna2CircleButton Discord;
    private Guna2CircleButton Animation;
    private Label FreezeGifLabel;
    private Guna2CustomCheckBox FreezeGif;
    private Guna2ShadowPanel SpooferPanel;
    public Guna2ComboBox VersionList;
    private Guna2Button Spoof;

    public MainForm() => this.InitializeComponent();

    private void Help_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Injector - Founder\nInjection Functionality - EchoHackCMD", "Credits");
    }

    private void Discord_Click(object sender, EventArgs e) => Process.Start("https://discord.gg/KGGX69sXqf");

    private void SelectDLL_Click(object sender, EventArgs e)
    {
      this.Util.CheckForDirectory();
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      if (openFileDialog.SafeFileName.ToLower().EndsWith(".dll"))
      {
        if (this.AutoInject.Checked)
          this.Util.InjectDLL(openFileDialog.FileName);
        else
          this.FileToInjectDir = openFileDialog.FileName;
      }
      else
      {
        int num = (int) MessageBox.Show("You did not specify a DLL!");
      }
    }

    private void Inject_Click(object sender, EventArgs e)
    {
      this.Util.CheckForDirectory();
      if (!this.AutoInject.Checked)
      {
        if (this.FileToInjectDir == "" || this.FileToInjectDir == null)
        {
          int num1 = (int) MessageBox.Show("Select a DLL", "Error");
        }
        else
          this.Util.InjectDLL(this.FileToInjectDir);
      }
      else if (((ListControl) this.ClientList).SelectedIndex == -1)
      {
        int num2 = (int) MessageBox.Show("Select a Client", "Error");
      }
      else
        this.Util.InjectClient();
    }

    private void ClientList_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (((ListControl) this.ClientList).SelectedIndex)
      {
        case 0:
          this.Util.DownloadFile("https://horion.download/bin/Horion.dll", MainForm.AssetDirectory + "Horion.dll");
          break;
        case 1:
          this.Util.DownloadFile("https://github.com/PacketDeveloper/PacketClient/raw/main/PacketClientFree.dll", MainForm.AssetDirectory + "Packet.dll");
          break;
        case 2:
          this.Util.DownloadFile("https://github.com/bernarddesfosse/onixclientautoupdate/raw/main/OnixClient.dll", MainForm.AssetDirectory + "Onix.dll");
          break;
        case 3:
          this.Util.DownloadFile(this.AssetGitClient + "NG.dll", MainForm.AssetDirectory + "NG.dll");
          break;
        case 4:
          this.Util.DownloadFile(this.AssetGitClient + "Fadeaway_1.16.201.dll", MainForm.AssetDirectory + "Fadeaway1.16.201.dll");
          break;
        case 5:
          this.Util.DownloadFile(this.AssetGitClient + "Fadeaway_1.17.11.1.dll", MainForm.AssetDirectory + "Fadeaway1.17.11.1.dll");
          break;
        case 6:
          this.Util.DownloadFile(this.AssetGitClient + "Zephyr.dll", MainForm.AssetDirectory + "Zephyr.dll");
          break;
        case 7:
          this.Util.DownloadFile(this.AssetGitClient + "KekClub.dll", MainForm.AssetDirectory + "Kek.dll");
          break;
        case 8:
          this.Util.DownloadFile(this.AssetGitClient + "Bom.dll", MainForm.AssetDirectory + "Bom.dll");
          break;
      }
    }

    private void AutoInject_Click(object sender, EventArgs e)
    {
      if (this.AutoInject.Checked)
        ((Control) this.Inject).Text = "Inject Client";
      else
        ((Control) this.Inject).Text = "Inject DLL";
    }

    private void DiscordRpc_Click(object sender, EventArgs e)
    {
      if (this.DiscordRpc.Checked)
      {
        this.client = new DiscordRpcClient("961004803843031040");
        DiscordRpcClient client = this.client;
        RichPresence richPresence = new RichPresence();
        ((BaseRichPresence) richPresence).Details = "Injecting Gamer Fluid";
        ((BaseRichPresence) richPresence).State = "Committing Large Amounts Of Trolling";
        ((BaseRichPresence) richPresence).Assets = new Assets()
        {
          LargeImageKey = "https://i.imgur.com/ufZN3k3.png",
          LargeImageText = "FadedInjector - Founder#8300",
          SmallImageKey = "https://i.imgur.com/vOkR3H5.png"
        };
        client.SetPresence(richPresence);
        this.client.Initialize();
      }
      else
        this.client.Dispose();
    }

    private void FreezeGif_Click(object sender, EventArgs e)
    {
      if (this.FreezeGif.Checked)
      {
        this.Animation.AnimatedGIF = false;
        this.Animation.Animated = false;
      }
      else
      {
        this.Animation.AnimatedGIF = true;
        this.Animation.Animated = true;
      }
    }

    private void Animation_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp)";
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        this.Animation.Image = Image.FromFile(openFileDialog.FileName);
        this.Refresh();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Uh oh, a fucky wucky has occured:\n" + ex.Message, "Error");
      }
    }

    private void Spoof_Click(object sender, EventArgs e)
    {
      if (((ListControl) this.VersionList).SelectedIndex == -1)
      {
        int num = (int) MessageBox.Show("Version not selected", "Error");
      }
      else
        Process.Start(MainForm.AssetDirectory + "Spoofer.exe", "Spoof -v " + this.McVersion);
    }

    private void VersionList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Util.DownloadFile("https://github.com/fadeaway-client/FadedToolCLI/releases/latest/download/fadedtoolcli.exe", MainForm.AssetDirectory + "Spoofer.exe");
      switch (((ListControl) this.VersionList).SelectedIndex)
      {
        case 0:
          this.McVersion = "1.16.40";
          break;
        case 1:
          this.McVersion = "1.16.100";
          break;
        case 2:
          this.McVersion = "1.16.201";
          break;
        case 3:
          this.McVersion = "1.16.210";
          break;
        case 4:
          this.McVersion = "1.16.221";
          break;
        case 5:
          this.McVersion = "1.17.0";
          break;
        case 6:
          this.McVersion = "1.17.10";
          break;
        case 7:
          this.McVersion = "1.17.11";
          break;
        case 8:
          this.McVersion = "1.17.40";
          break;
        case 9:
          this.McVersion = "1.17.41";
          break;
        case 10:
          this.McVersion = "1.18.0";
          break;
        case 11:
          this.McVersion = "1.18.2";
          break;
        case 12:
          this.McVersion = "1.18.10.4";
          break;
        case 13:
          this.McVersion = "1.18.12.1";
          break;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.Elipse = new Guna2Elipse(this.components);
      this.DragPanel = new Guna2DragControl(this.components);
      this.Shadow = new Guna2ShadowForm(this.components);
      this.Exit = new Guna2ControlBox();
      this.Minimize = new Guna2ControlBox();
      this.Inject = new Guna2Button();
      this.Titlebar = new Guna2Panel();
      this.Discord = new Guna2CircleButton();
      this.Help = new Guna2CircleButton();
      this.InjectorLabel = new Label();
      this.ClientList = new Guna2ComboBox();
      this.SelectDLL = new Guna2Button();
      this.AutoInject = new Guna2CustomCheckBox();
      this.SettingsPanel = new Guna2ShadowPanel();
      this.FreezeGifLabel = new Label();
      this.FreezeGif = new Guna2CustomCheckBox();
      this.RpcLabel = new Label();
      this.DiscordRpc = new Guna2CustomCheckBox();
      this.AutoInjectLabel = new Label();
      this.InjectPanel = new Guna2ShadowPanel();
      this.ClientsPanel = new Guna2ShadowPanel();
      this.DragTitle = new Guna2DragControl(this.components);
      this.Animation = new Guna2CircleButton();
      this.SpooferPanel = new Guna2ShadowPanel();
      this.VersionList = new Guna2ComboBox();
      this.Spoof = new Guna2Button();
      ((Control) this.Titlebar).SuspendLayout();
      ((Control) this.SettingsPanel).SuspendLayout();
      ((Control) this.InjectPanel).SuspendLayout();
      ((Control) this.ClientsPanel).SuspendLayout();
      ((Control) this.SpooferPanel).SuspendLayout();
      this.SuspendLayout();
      this.Elipse.BorderRadius = 16;
      this.Elipse.TargetControl = (Control) this;
      this.DragPanel.DockIndicatorTransparencyValue = 0.6;
      this.DragPanel.TargetControl = (Control) this;
      this.DragPanel.UseTransparentDrag = true;
      this.Shadow.BorderRadius = 16;
      this.Shadow.TargetForm = (Form) this;
      ((Control) this.Exit).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Exit.BorderRadius = 16;
      this.Exit.FillColor = Color.FromArgb(16, 16, 16);
      this.Exit.IconColor = Color.White;
      ((Control) this.Exit).Location = new Point(799, 3);
      ((Control) this.Exit).Name = "Exit";
      ((Control) this.Exit).Size = new Size(28, 28);
      ((Control) this.Exit).TabIndex = 0;
      ((Control) this.Minimize).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Minimize.BorderRadius = 16;
      this.Minimize.ControlBoxType = (ControlBoxType) 0;
      this.Minimize.FillColor = Color.FromArgb(16, 16, 16);
      this.Minimize.IconColor = Color.White;
      ((Control) this.Minimize).Location = new Point(765, 3);
      ((Control) this.Minimize).Name = "Minimize";
      ((Control) this.Minimize).Size = new Size(28, 28);
      ((Control) this.Minimize).TabIndex = 1;
      this.Inject.Animated = true;
      this.Inject.AutoRoundedCorners = true;
      this.Inject.BorderColor = Color.Fuchsia;
      this.Inject.BorderRadius = 17;
      this.Inject.DisabledState.BorderColor = Color.DarkGray;
      this.Inject.DisabledState.CustomBorderColor = Color.DarkGray;
      this.Inject.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
      this.Inject.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
      this.Inject.FillColor = Color.FromArgb(192, 0, 192);
      ((Control) this.Inject).Font = new Font("Arial Rounded MT Bold", 14.25f);
      ((Control) this.Inject).ForeColor = Color.White;
      ((Control) this.Inject).Location = new Point(163, 25);
      ((Control) this.Inject).Name = "Inject";
      ((Control) this.Inject).Size = new Size(140, 37);
      ((Control) this.Inject).TabIndex = 2;
      ((Control) this.Inject).Text = "Inject Client";
      ((Control) this.Inject).Click += new EventHandler(this.Inject_Click);
      this.Titlebar.BorderColor = Color.Black;
      this.Titlebar.BorderThickness = 1;
      ((Control) this.Titlebar).Controls.Add((Control) this.Discord);
      ((Control) this.Titlebar).Controls.Add((Control) this.Help);
      ((Control) this.Titlebar).Controls.Add((Control) this.InjectorLabel);
      ((Control) this.Titlebar).Controls.Add((Control) this.Minimize);
      ((Control) this.Titlebar).Controls.Add((Control) this.Exit);
      ((Control) this.Titlebar).Dock = DockStyle.Top;
      ((Control) this.Titlebar).Location = new Point(0, 0);
      ((Control) this.Titlebar).Name = "Titlebar";
      ((Control) this.Titlebar).Size = new Size(830, 37);
      ((Control) this.Titlebar).TabIndex = 3;
      ((Control) this.Discord).BackgroundImageLayout = ImageLayout.Zoom;
      this.Discord.DisabledState.BorderColor = Color.DarkGray;
      this.Discord.DisabledState.CustomBorderColor = Color.DarkGray;
      this.Discord.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
      this.Discord.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
      this.Discord.FillColor = Color.FromArgb(15, 15, 15);
      ((Control) this.Discord).Font = new Font("Microsoft Sans Serif", 9f);
      ((Control) this.Discord).ForeColor = Color.White;
      this.Discord.Image = (Image) Resources.discord;
      ((Control) this.Discord).Location = new Point(697, 3);
      ((Control) this.Discord).Name = "Discord";
      this.Discord.ShadowDecoration.Mode = (ShadowMode) 1;
      ((Control) this.Discord).Size = new Size(28, 28);
      ((Control) this.Discord).TabIndex = 11;
      ((Control) this.Discord).Click += new EventHandler(this.Discord_Click);
      this.Help.DisabledState.BorderColor = Color.DarkGray;
      this.Help.DisabledState.CustomBorderColor = Color.DarkGray;
      this.Help.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
      this.Help.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
      this.Help.FillColor = Color.FromArgb(15, 15, 15);
      ((Control) this.Help).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.Help).ForeColor = Color.White;
      ((Control) this.Help).Location = new Point(731, 3);
      ((Control) this.Help).Name = "Help";
      this.Help.ShadowDecoration.Mode = (ShadowMode) 1;
      ((Control) this.Help).Size = new Size(28, 28);
      ((Control) this.Help).TabIndex = 10;
      ((Control) this.Help).Text = "?";
      ((Control) this.Help).Click += new EventHandler(this.Help_Click);
      this.InjectorLabel.Font = new Font("Arial Rounded MT Bold", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.InjectorLabel.ForeColor = Color.White;
      this.InjectorLabel.Location = new Point(3, 3);
      this.InjectorLabel.Name = "InjectorLabel";
      this.InjectorLabel.Size = new Size(168, 33);
      this.InjectorLabel.TabIndex = 2;
      this.InjectorLabel.Text = "Faded Injector";
      this.InjectorLabel.TextAlign = ContentAlignment.MiddleLeft;
      ((Control) this.ClientList).BackColor = Color.Transparent;
      this.ClientList.BorderColor = Color.Fuchsia;
      this.ClientList.BorderRadius = 6;
      this.ClientList.DrawMode = DrawMode.OwnerDrawFixed;
      this.ClientList.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ClientList.FillColor = Color.FromArgb(20, 20, 20);
      this.ClientList.FocusedColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      this.ClientList.FocusedState.BorderColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      ((Control) this.ClientList).Font = new Font("Arial Rounded MT Bold", 12f);
      ((Control) this.ClientList).ForeColor = Color.White;
      ((ComboBox) this.ClientList).ItemHeight = 30;
      ((ComboBox) this.ClientList).Items.AddRange(new object[9]
      {
        (object) "Horion",
        (object) "Packet",
        (object) "Onix",
        (object) "NG",
        (object) "Fadeaway (1.16.201)",
        (object) "Fadeaway (1.17.11)",
        (object) "Zephyr",
        (object) "Kek",
        (object) "Bom"
      });
      ((Control) this.ClientList).Location = new Point(16, 26);
      ((Control) this.ClientList).Name = "ClientList";
      ((Control) this.ClientList).Size = new Size(220, 36);
      this.ClientList.Style = (TextBoxStyle) 1;
      ((Control) this.ClientList).TabIndex = 4;
      ((ComboBox) this.ClientList).SelectedIndexChanged += new EventHandler(this.ClientList_SelectedIndexChanged);
      this.SelectDLL.Animated = true;
      this.SelectDLL.AutoRoundedCorners = true;
      this.SelectDLL.BorderColor = Color.Fuchsia;
      this.SelectDLL.BorderRadius = 17;
      this.SelectDLL.DisabledState.BorderColor = Color.DarkGray;
      this.SelectDLL.DisabledState.CustomBorderColor = Color.DarkGray;
      this.SelectDLL.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
      this.SelectDLL.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
      this.SelectDLL.FillColor = Color.FromArgb(192, 0, 192);
      ((Control) this.SelectDLL).Font = new Font("Arial Rounded MT Bold", 14.25f);
      ((Control) this.SelectDLL).ForeColor = Color.White;
      ((Control) this.SelectDLL).Location = new Point(20, 25);
      ((Control) this.SelectDLL).Name = "SelectDLL";
      ((Control) this.SelectDLL).Size = new Size(140, 37);
      ((Control) this.SelectDLL).TabIndex = 5;
      ((Control) this.SelectDLL).Text = "Select DLL";
      ((Control) this.SelectDLL).Click += new EventHandler(this.SelectDLL_Click);
      ((Control) this.AutoInject).BackColor = Color.Transparent;
      this.AutoInject.Checked = true;
      this.AutoInject.CheckedState.BorderColor = Color.Fuchsia;
      this.AutoInject.CheckedState.BorderRadius = 2;
      this.AutoInject.CheckedState.BorderThickness = 0;
      this.AutoInject.CheckedState.FillColor = Color.Fuchsia;
      ((Control) this.AutoInject).ForeColor = Color.White;
      ((Control) this.AutoInject).Location = new Point(12, 16);
      ((Control) this.AutoInject).Name = "AutoInject";
      ((Control) this.AutoInject).Size = new Size(20, 20);
      ((Control) this.AutoInject).TabIndex = 6;
      ((Control) this.AutoInject).Text = "Auto Inject";
      this.AutoInject.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
      this.AutoInject.UncheckedState.BorderRadius = 2;
      this.AutoInject.UncheckedState.BorderThickness = 0;
      this.AutoInject.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
      ((Control) this.AutoInject).Click += new EventHandler(this.AutoInject_Click);
      ((Control) this.SettingsPanel).BackColor = Color.Transparent;
      ((Control) this.SettingsPanel).Controls.Add((Control) this.FreezeGifLabel);
      ((Control) this.SettingsPanel).Controls.Add((Control) this.FreezeGif);
      ((Control) this.SettingsPanel).Controls.Add((Control) this.RpcLabel);
      ((Control) this.SettingsPanel).Controls.Add((Control) this.DiscordRpc);
      ((Control) this.SettingsPanel).Controls.Add((Control) this.AutoInjectLabel);
      ((Control) this.SettingsPanel).Controls.Add((Control) this.AutoInject);
      this.SettingsPanel.FillColor = Color.FromArgb(20, 20, 20);
      ((Control) this.SettingsPanel).ForeColor = Color.White;
      ((Control) this.SettingsPanel).Location = new Point(512, 43);
      ((Control) this.SettingsPanel).Name = "SettingsPanel";
      this.SettingsPanel.ShadowColor = Color.Black;
      ((Control) this.SettingsPanel).Size = new Size(306, 106);
      ((Control) this.SettingsPanel).TabIndex = 7;
      this.FreezeGifLabel.Font = new Font("Arial Narrow", 12.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.FreezeGifLabel.ForeColor = Color.White;
      this.FreezeGifLabel.Location = new Point(38, 68);
      this.FreezeGifLabel.Name = "FreezeGifLabel";
      this.FreezeGifLabel.Size = new Size(130, 20);
      this.FreezeGifLabel.TabIndex = 11;
      this.FreezeGifLabel.Text = "Freeze Gif";
      this.FreezeGifLabel.TextAlign = ContentAlignment.MiddleLeft;
      ((Control) this.FreezeGif).BackColor = Color.Transparent;
      this.FreezeGif.CheckedState.BorderColor = Color.Fuchsia;
      this.FreezeGif.CheckedState.BorderRadius = 2;
      this.FreezeGif.CheckedState.BorderThickness = 0;
      this.FreezeGif.CheckedState.FillColor = Color.Fuchsia;
      ((Control) this.FreezeGif).ForeColor = Color.White;
      ((Control) this.FreezeGif).Location = new Point(12, 68);
      ((Control) this.FreezeGif).Name = "FreezeGif";
      ((Control) this.FreezeGif).Size = new Size(20, 20);
      ((Control) this.FreezeGif).TabIndex = 10;
      ((Control) this.FreezeGif).Text = "Auto Inject";
      this.FreezeGif.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
      this.FreezeGif.UncheckedState.BorderRadius = 2;
      this.FreezeGif.UncheckedState.BorderThickness = 0;
      this.FreezeGif.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
      ((Control) this.FreezeGif).Click += new EventHandler(this.FreezeGif_Click);
      this.RpcLabel.Font = new Font("Arial Narrow", 12.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.RpcLabel.ForeColor = Color.White;
      this.RpcLabel.Location = new Point(38, 42);
      this.RpcLabel.Name = "RpcLabel";
      this.RpcLabel.Size = new Size(130, 20);
      this.RpcLabel.TabIndex = 9;
      this.RpcLabel.Text = "Discord RPC";
      this.RpcLabel.TextAlign = ContentAlignment.MiddleLeft;
      ((Control) this.DiscordRpc).BackColor = Color.Transparent;
      this.DiscordRpc.CheckedState.BorderColor = Color.Fuchsia;
      this.DiscordRpc.CheckedState.BorderRadius = 2;
      this.DiscordRpc.CheckedState.BorderThickness = 0;
      this.DiscordRpc.CheckedState.FillColor = Color.Fuchsia;
      ((Control) this.DiscordRpc).ForeColor = Color.White;
      ((Control) this.DiscordRpc).Location = new Point(12, 42);
      ((Control) this.DiscordRpc).Name = "DiscordRpc";
      ((Control) this.DiscordRpc).Size = new Size(20, 20);
      ((Control) this.DiscordRpc).TabIndex = 8;
      ((Control) this.DiscordRpc).Text = "Auto Inject";
      this.DiscordRpc.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
      this.DiscordRpc.UncheckedState.BorderRadius = 2;
      this.DiscordRpc.UncheckedState.BorderThickness = 0;
      this.DiscordRpc.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
      ((Control) this.DiscordRpc).Click += new EventHandler(this.DiscordRpc_Click);
      this.AutoInjectLabel.Font = new Font("Arial Narrow", 12.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.AutoInjectLabel.ForeColor = Color.White;
      this.AutoInjectLabel.Location = new Point(38, 16);
      this.AutoInjectLabel.Name = "AutoInjectLabel";
      this.AutoInjectLabel.Size = new Size(130, 20);
      this.AutoInjectLabel.TabIndex = 7;
      this.AutoInjectLabel.Text = "Auto Inject DLL";
      this.AutoInjectLabel.TextAlign = ContentAlignment.MiddleLeft;
      ((Control) this.InjectPanel).BackColor = Color.Transparent;
      ((Control) this.InjectPanel).Controls.Add((Control) this.SelectDLL);
      ((Control) this.InjectPanel).Controls.Add((Control) this.Inject);
      this.InjectPanel.FillColor = Color.FromArgb(20, 20, 20);
      ((Control) this.InjectPanel).ForeColor = Color.White;
      ((Control) this.InjectPanel).Location = new Point(492, 365);
      ((Control) this.InjectPanel).Name = "InjectPanel";
      this.InjectPanel.ShadowColor = Color.Black;
      ((Control) this.InjectPanel).Size = new Size(326, 88);
      ((Control) this.InjectPanel).TabIndex = 8;
      ((Control) this.ClientsPanel).BackColor = Color.Transparent;
      ((Control) this.ClientsPanel).Controls.Add((Control) this.ClientList);
      this.ClientsPanel.FillColor = Color.FromArgb(20, 20, 20);
      ((Control) this.ClientsPanel).ForeColor = Color.White;
      ((Control) this.ClientsPanel).Location = new Point(7, 43);
      ((Control) this.ClientsPanel).Name = "ClientsPanel";
      this.ClientsPanel.ShadowColor = Color.Black;
      ((Control) this.ClientsPanel).Size = new Size(262, 88);
      ((Control) this.ClientsPanel).TabIndex = 9;
      this.DragTitle.DockIndicatorTransparencyValue = 0.6;
      this.DragTitle.TargetControl = (Control) this.Titlebar;
      this.DragTitle.UseTransparentDrag = true;
      ((Control) this.Animation).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Animation.Animated = true;
      this.Animation.AnimatedGIF = true;
      this.Animation.DisabledState.BorderColor = Color.DarkGray;
      this.Animation.DisabledState.CustomBorderColor = Color.DarkGray;
      this.Animation.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
      this.Animation.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
      this.Animation.FillColor = Color.FromArgb(20, 20, 20);
      ((Control) this.Animation).Font = new Font("Segoe UI", 9f);
      ((Control) this.Animation).ForeColor = Color.White;
      this.Animation.Image = (Image) componentResourceManager.GetObject("Animation.Image");
      this.Animation.ImageSize = new Size(150, 150);
      ((Control) this.Animation).Location = new Point(329, 166);
      ((Control) this.Animation).Name = "Animation";
      this.Animation.ShadowDecoration.Mode = (ShadowMode) 1;
      ((Control) this.Animation).Size = new Size(148, 148);
      ((Control) this.Animation).TabIndex = 10;
      ((Control) this.Animation).Click += new EventHandler(this.Animation_Click);
      ((Control) this.SpooferPanel).BackColor = Color.Transparent;
      ((Control) this.SpooferPanel).Controls.Add((Control) this.Spoof);
      ((Control) this.SpooferPanel).Controls.Add((Control) this.VersionList);
      this.SpooferPanel.FillColor = Color.FromArgb(20, 20, 20);
      ((Control) this.SpooferPanel).ForeColor = Color.White;
      ((Control) this.SpooferPanel).Location = new Point(7, 365);
      ((Control) this.SpooferPanel).Name = "SpooferPanel";
      this.SpooferPanel.ShadowColor = Color.Black;
      ((Control) this.SpooferPanel).Size = new Size(262, 88);
      ((Control) this.SpooferPanel).TabIndex = 10;
      ((Control) this.VersionList).BackColor = Color.Transparent;
      this.VersionList.BorderColor = Color.Fuchsia;
      this.VersionList.BorderRadius = 6;
      this.VersionList.DrawMode = DrawMode.OwnerDrawFixed;
      this.VersionList.DropDownStyle = ComboBoxStyle.DropDownList;
      this.VersionList.FillColor = Color.FromArgb(20, 20, 20);
      this.VersionList.FocusedColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      this.VersionList.FocusedState.BorderColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      ((Control) this.VersionList).Font = new Font("Arial Rounded MT Bold", 12f);
      ((Control) this.VersionList).ForeColor = Color.White;
      ((ComboBox) this.VersionList).ItemHeight = 30;
      ((ComboBox) this.VersionList).Items.AddRange(new object[15]
      {
        (object) "1.16.40",
        (object) "1.16.100",
        (object) "1.16.201",
        (object) "1.16.210",
        (object) "1.16.221",
        (object) "1.17.0",
        (object) "1.17.2",
        (object) "1.17.10",
        (object) "1.17.11",
        (object) "1.17.40",
        (object) "1.17.41",
        (object) "1.18.0",
        (object) "1.18.2",
        (object) "1.18.10.4",
        (object) "1.18.12.1"
      });
      ((Control) this.VersionList).Location = new Point(16, 26);
      ((Control) this.VersionList).Name = "VersionList";
      ((Control) this.VersionList).Size = new Size(160, 36);
      this.VersionList.Style = (TextBoxStyle) 1;
      ((Control) this.VersionList).TabIndex = 4;
      ((ComboBox) this.VersionList).SelectedIndexChanged += new EventHandler(this.VersionList_SelectedIndexChanged);
      this.Spoof.Animated = true;
      this.Spoof.AutoRoundedCorners = true;
      this.Spoof.BorderColor = Color.Fuchsia;
      this.Spoof.BorderRadius = 17;
      this.Spoof.DisabledState.BorderColor = Color.DarkGray;
      this.Spoof.DisabledState.CustomBorderColor = Color.DarkGray;
      this.Spoof.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
      this.Spoof.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
      this.Spoof.FillColor = Color.FromArgb(192, 0, 192);
      ((Control) this.Spoof).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.Spoof).ForeColor = Color.White;
      ((Control) this.Spoof).Location = new Point(182, 26);
      ((Control) this.Spoof).Name = "Spoof";
      ((Control) this.Spoof).Size = new Size(64, 37);
      ((Control) this.Spoof).TabIndex = 6;
      ((Control) this.Spoof).Text = "Spoof";
      ((Control) this.Spoof).Click += new EventHandler(this.Spoof_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(15, 15, 15);
      this.ClientSize = new Size(830, 465);
      this.Controls.Add((Control) this.SpooferPanel);
      this.Controls.Add((Control) this.Animation);
      this.Controls.Add((Control) this.ClientsPanel);
      this.Controls.Add((Control) this.InjectPanel);
      this.Controls.Add((Control) this.SettingsPanel);
      this.Controls.Add((Control) this.Titlebar);
      this.ForeColor = Color.White;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (MainForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Faded Injector";
      ((Control) this.Titlebar).ResumeLayout(false);
      ((Control) this.SettingsPanel).ResumeLayout(false);
      ((Control) this.InjectPanel).ResumeLayout(false);
      ((Control) this.ClientsPanel).ResumeLayout(false);
      ((Control) this.SpooferPanel).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
