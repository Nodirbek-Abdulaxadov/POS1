﻿#pragma checksum "..\..\..\..\Components\MaterialMessageBox.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DDC19AE1DB52DE7BB8E4AE106FF1160C273A9762"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Seller.App.Components {
    
    
    /// <summary>
    /// MaterialMessageBox
    /// </summary>
    public partial class MaterialMessageBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card cardHeader;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitle;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMessage;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnYes;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNo;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Components\MaterialMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRetry;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Seller.App;component/components/materialmessagebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Components\MaterialMessageBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cardHeader = ((MaterialDesignThemes.Wpf.Card)(target));
            return;
            case 2:
            this.txtTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Components\MaterialMessageBox.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtMessage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\Components\MaterialMessageBox.xaml"
            this.btnOk.Click += new System.Windows.RoutedEventHandler(this.btnOk_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\Components\MaterialMessageBox.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnYes = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\Components\MaterialMessageBox.xaml"
            this.btnYes.Click += new System.Windows.RoutedEventHandler(this.btnYes_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnNo = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\Components\MaterialMessageBox.xaml"
            this.btnNo.Click += new System.Windows.RoutedEventHandler(this.btnNo_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnRetry = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\Components\MaterialMessageBox.xaml"
            this.btnRetry.Click += new System.Windows.RoutedEventHandler(this.btnRetry_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
