<!-- default file list -->
*Files to look at*:

* [MainWindowController.cs](./CS/WinWebSolution.Module/MainWindowController.cs) (VB: [MainWindowController.vb](./VB/WinWebSolution.Module/MainWindowController.vb))
<!-- default file list end -->
# How to determine the View, from which another view is shown


<p>This Controller below demonstrates how to handle the <a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppXafApplication_ViewShowingtopic">ViewShowing</a>  and <a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppXafApplication_ViewShowntopic">ViewShown</a> events of the XafApplication class, to provide interaction between views.<br />Use the SourceFrame and TargetFrame properties of the event arguments for additional context information.<br /><br /></p>


```cs
using System;
using DevExpress.ExpressApp;

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
            if(e.SourceFrame != null && e.SourceFrame.View != null && e.SourceFrame.View.Id == "Party_PhoneNumbers_ListView") {
                DetailView targetView = (DetailView)e.View;
                ListView sourceView = (ListView)e.SourceFrame.View;
                //...
            }
        }
        //OR
        void Application_ViewShown(object sender, ViewShownEventArgs e) {
            if(e.SourceFrame != null && e.SourceFrame.View != null && e.SourceFrame.View.Id == "Party_PhoneNumbers_ListView") {
                DetailView targetView = (DetailView)e.TargetFrame.View;
                ListView sourceView = (ListView)e.SourceFrame.View;
                //...
            }
        }
        protected override void OnDeactivated() {
            Application.ViewShown -= new EventHandler<ViewShownEventArgs>(Application_ViewShown);
            base.OnDeactivated();
        }
    }
}
```


<p> </p>


```vb
Imports DevExpress.ExpressApp

Namespace WinWebSolution.Module
    Public Class MainWindowController
        Inherits WindowController
        Public Sub New()
            TargetWindowType = WindowType.Main
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler Application.ViewShowing, AddressOf Application_ViewShowing
            AddHandler Application.ViewShown, AddressOf Application_ViewShown
        End Sub
        Private Sub Application_ViewShowing(ByVal sender As Object, ByVal e As ViewShowingEventArgs)
            If e.SourceFrame IsNot Nothing AndAlso e.SourceFrame.View IsNot Nothing AndAlso e.SourceFrame.View.Id = "Party_PhoneNumbers_ListView" Then
                Dim targetView As DetailView = CType(e.View, DetailView)
                Dim sourceView As ListView = CType(e.SourceFrame.View, ListView)
                '...
            End If
        End Sub
        'OR
        Private Sub Application_ViewShown(ByVal sender As Object, ByVal e As ViewShownEventArgs)
            If e.SourceFrame IsNot Nothing AndAlso e.SourceFrame.View IsNot Nothing AndAlso e.SourceFrame.View.Id = "Party_PhoneNumbers_ListView" Then
                Dim targetView As DetailView = CType(e.TargetFrame.View, DetailView)
                Dim sourceView As ListView = CType(e.SourceFrame.View, ListView)
                '...
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            RemoveHandler Application.ViewShown, AddressOf Application_ViewShown
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
```



<br/>


