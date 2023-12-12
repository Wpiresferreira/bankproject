﻿#pragma checksum "..\..\..\..\Windows\WindowFrame.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C78897DAB097EDE72A519A23504B174800C10178"
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
        
        
        #line 36 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel buttonsList;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock initialsMenu;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nameMenu;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Windows\WindowFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabControl_Frame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.14.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.14.0")]
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
            
            #line 21 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageMinimize_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\..\..\Windows\WindowFrame.xaml"
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
            
            #line 57 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDashboard_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 63 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonWallet_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 99 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCustomerSearch_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 113 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonLogout_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 123 "..\..\..\..\Windows\WindowFrame.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.tabControl_Frame = ((System.Windows.Controls.TabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

