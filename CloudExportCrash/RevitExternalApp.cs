using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using CefSharp;

namespace CloudExportCrash
{
    public class RevitExternalApp : IExternalApplication
    {
        private readonly DockablePaneId _dockPanelId;

        public RevitExternalApp()
        {
            _dockPanelId = new DockablePaneId(new Guid("5B9B82AC-7659-4F7A-9330-0165A57D0F3A"));
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var assetLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var settings = new CefSettings
            {
                BrowserSubprocessPath = string.Format("{0}\\CefSharp.BrowserSubprocess.exe", assetLocation),
                LocalesDirPath = string.Format("{0}\\locales", assetLocation)
            };

            settings.CefCommandLineArgs.Add("disable-gpu", "1");


            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings, true, null);
            }


            var revitDockPanel = new DockablePage();
            application.RegisterDockablePane(_dockPanelId, "Docked panel", revitDockPanel);


            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
