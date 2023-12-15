﻿#pragma checksum "..\..\..\..\Windows\WindowFrame.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B9EBBEC7F603F825176A8B03E9205EC2EFE64465"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BankProject;
using BankProject.UserControls;
using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using LiveCharts.Wpf;
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


namespace BankProject {
    
    
    /// <summary>
    /// WindowFrame
    /// </summary>
    public partial class WindowFrame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel buttonsList;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock initialsMenu;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nameMenu;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lowerTextMenu;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabControl_Frame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BankProject;component/windows/windowframe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\WindowFrame.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\Windows\WindowFrame.xaml"
            ((BankProject.WindowFrame)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 22 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageMinimize_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 23 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageClose_MouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonsList = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.initialsMenu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.nameMenu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.lowerTextMenu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 58 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDashboard_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 64 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonWallet_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 70 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCustomerSearch_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 76 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCreateNewBranch_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 82 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonListBranches_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 88 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonListCustomersFromMyBranch_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 94 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonManageAccounts_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 100 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMakeDeposit_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 106 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMakeWithdraw_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 112 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMakeTransfer_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 127 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonLogout_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 137 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 20:
            this.tabControl_Frame = ((System.Windows.Controls.TabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

