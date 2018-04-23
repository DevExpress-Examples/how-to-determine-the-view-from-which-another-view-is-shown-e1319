using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;

namespace WinWebSolution.Module {
    public class MainWindowController : WindowController {
        public MainWindowController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            Application.ViewShowing += new EventHandler<ViewShowingEventArgs>(Application_ViewShowing);
            Application.ViewShown += new EventHandler<ViewShownEventArgs>(Application_ViewShown);
        }
        void Application_ViewShowing(object sender, ViewShowingEventArgs e) {
            if (e.SourceFrame != null && e.SourceFrame.View != null && e.SourceFrame.View.Id == "Party_PhoneNumbers_ListView") {
                Frame phoneNumberFrame = e.TargetFrame;
                DetailView phoneNumberDetailView = (DetailView)e.View;
                //...
            }
        }
        //OR
        void Application_ViewShown(object sender, ViewShownEventArgs e) {
            if (e.SourceFrame != null && e.SourceFrame.View != null && e.SourceFrame.View.Id == "Party_PhoneNumbers_ListView") {
                Frame phoneNumberFrame = e.Frame;
                DetailView phoneNumberDetailView = (DetailView)phoneNumberFrame.View;
                //...
            }
        }
        protected override void OnDeactivating() {
            Application.ViewShown -= new EventHandler<ViewShownEventArgs>(Application_ViewShown);
            base.OnDeactivating();
        }
    }
}