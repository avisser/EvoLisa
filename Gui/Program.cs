﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenArt.Core;

namespace GenArt
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      AutomapperConfig.Setup();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}