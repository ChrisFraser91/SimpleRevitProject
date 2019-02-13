using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using CefSharp;
using CefSharp.WinForms;

namespace CloudExportCrash
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]     //allows for the use of window.external
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]    //allows for the use of window.external
    public partial class RevitPanel : UserControl
    {
        public RevitPanel()
        {
            InitializeComponent();

            var window = new ChromiumWebBrowser("");
            window.Dock = DockStyle.Fill;
            window.Load("https://www.nationalbimlibrary.com");

            this.Controls.Add(window);
        }
    }
}
