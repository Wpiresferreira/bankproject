﻿#pragma checksum "..\..\..\..\Windows\WindowRegister.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26DC7E51A725B8867980FAA570E9E5F7127531D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BankProject.UserControls;
using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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
    /// WindowRegister
    /// </summary>
    public partial class WindowRegister : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 68 "..\..\..\..\Windows\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxFirstName;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Windows\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxLastName;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Windows\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxDataOfBirth;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Windows\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxPhone;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Windows\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxEmail;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Windows\WindowRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox myTextBoxPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/BankProject;component/windows/windowregister.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\WindowRegister.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 19 "..\..\..\..\Windows\WindowRegister.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageMinimize_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\..\Windows\WindowRegister.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageClose_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 31 "..\..\..\..\Windows\WindowRegister.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBack_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 40 "..\..\..\..\Windows\WindowRegister.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.myTextBoxFirstName = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 6:
            this.myTextBoxLastName = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 7:
            this.myTextBoxDataOfBirth = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 8:
            this.myTextBoxPhone = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 9:
            this.myTextBoxEmail = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 10:
            this.myTextBoxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 11:
            
            #line 82 "..\..\..\..\Windows\WindowRegister.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 83 "..\..\..\..\Windows\WindowRegister.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

