﻿#pragma checksum "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BB3C94AB97B77E4B149181AC8D2DAB73B2E160C9934CFF3E0445F3A539DD1219"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assignment_2.Views.Pages;
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


namespace Assignment_2.Views.Pages {
    
    
    /// <summary>
    /// RegularUserManagePersonalAdsPage
    /// </summary>
    public partial class RegularUserManagePersonalAdsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UserManagePersonalAds;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox id;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox location;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox size;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price;
        
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
            System.Uri resourceLocater = new System.Uri("/Assignment_2;component/views/pages/regularuser/regularusermanagepersonaladspage." +
                    "xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
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
            this.UserManagePersonalAds = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.id = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
            this.id.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.location = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.size = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 21 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_AddNewModel);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 22 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ListModels);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 23 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_UpdateModel);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 24 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_FindByIdModel);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 25 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserManagePersonalAdsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_DeleteByIdModel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

