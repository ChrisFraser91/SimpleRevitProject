using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using Autodesk.Revit.UI;

namespace CloudExportCrash
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DockablePage : System.Windows.Controls.Page, Autodesk.Revit.UI.IDockablePaneProvider
    {
        #region Data
        public RevitPanel ResourcePanel { get; set; }
        WindowsFormsHost _formHost = null;

        public DockablePage()
        {
            InitializeComponent();

            ResourcePanel = new RevitPanel();
            _formHost=  new WindowsFormsHost();
            _formHost.Child = ResourcePanel;
            _formHost.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            
            grid1.Children.Add(_formHost);
            grid1.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        }
        
        public void SetupDockablePane(Autodesk.Revit.UI.DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new Autodesk.Revit.UI.DockablePaneState();

            data.InitialState.DockPosition = DockPosition.Tabbed;
            data.InitialState.TabBehind = Autodesk.Revit.UI.DockablePanes.BuiltInDockablePanes.ProjectBrowser;
            data.InitialState.DockPosition = DockPosition.Left;
        }

        #endregion
    }
}
