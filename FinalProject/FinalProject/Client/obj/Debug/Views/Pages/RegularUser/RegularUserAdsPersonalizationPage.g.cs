#pragma checksum "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B24945FAADC7B441983F0A43A07226E1A5112CE420130BEFD9F6F6DC727118BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client.Views.Pages.RegularUser;
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


namespace Client.Views.Pages.RegularUser {
    
    
    /// <summary>
    /// RegularUserAdsPersonalizationPage
    /// </summary>
    public partial class RegularUserAdsPersonalizationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AdsPersonalization;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox adId;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rating;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox favId;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/views/pages/regularuser/regularuseradspersonalizationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
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
            this.AdsPersonalization = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.adId = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            this.adId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rating = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            this.rating.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.favId = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            this.favId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 19 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_GetAllRatings);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 20 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_RateAd);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 21 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_GetAllFavorites);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 22 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_AddFavorite);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 23 "..\..\..\..\..\Views\Pages\RegularUser\RegularUserAdsPersonalizationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_DeleteFavorite);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

