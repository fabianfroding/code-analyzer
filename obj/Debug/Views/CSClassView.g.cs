﻿#pragma checksum "..\..\..\Views\CSClassView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D97CF4A5A0B0623A6374B116186F7FB7862601A668C9037E7717403F1FD65A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CodeAnalyzer;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CodeAnalyzer {
    
    
    /// <summary>
    /// CSClassView
    /// </summary>
    public partial class CSClassView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Views\CSClassView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridLayout;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\CSClassView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\CSClassView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxLOC;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Views\CSClassView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxAssociations;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\CSClassView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AssociationsList;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\CSClassView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser webBrowser;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CodeAnalyzer;component/views/csclassview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CSClassView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridLayout = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TextBoxName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TextBoxLOC = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TextBoxAssociations = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.AssociationsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.webBrowser = ((System.Windows.Controls.WebBrowser)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

