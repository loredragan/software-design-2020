﻿#pragma checksum "..\..\..\..\Views\Pages\AdminsMenuPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "961C2A1AACFD4824B5BA0C0C17A54ED8B97AA5EC1AA4C43BEFEC7D81B76C174E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assignment_2.View.Pages;
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


namespace Assignment_2.View.Pages {
    
    
    /// <summary>
    /// AdminsMenuPage
    /// </summary>
    public partial class AdminsMenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManageUsersButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManageUsersAds;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGenerateReports;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
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
            System.Uri resourceLocater = new System.Uri("/Assignment_2;component/views/pages/adminsmenupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
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
            this.btnManageUsersButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
            this.btnManageUsersButton.Click += new System.Windows.RoutedEventHandler(this.BtnManageUsers_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnManageUsersAds = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
            this.btnManageUsersAds.Click += new System.Windows.RoutedEventHandler(this.BtnManageUsersAds_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnGenerateReports = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
            this.btnGenerateReports.Click += new System.Windows.RoutedEventHandler(this.BtnGenerateReports_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Views\Pages\AdminsMenuPage.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.BtnLogout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

