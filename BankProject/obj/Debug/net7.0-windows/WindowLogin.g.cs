﻿#pragma checksum "..\..\..\WindowLogin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C0984AD8B04AF1BB02288660E11D26BEE107CB49"
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
    /// WindowLogin
    /// </summary>
    public partial class WindowLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 2 "..\..\..\WindowLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.WindowLogin LoginScreen;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\WindowLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockEmail;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\WindowLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxEmail;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\WindowLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockPassword;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\WindowLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox textBoxPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/BankProject;component/windowlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowLogin.xaml"
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
            this.LoginScreen = ((BankProject.WindowLogin)(target));
            return;
            case 2:
            
            #line 16 "..\..\..\WindowLogin.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 42 "..\..\..\WindowLogin.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBlockEmail = ((System.Windows.Controls.TextBlock)(target));
            
            #line 66 "..\..\..\WindowLogin.xaml"
            this.textBlockEmail.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textEmail_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textBoxEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\WindowLogin.xaml"
            this.textBoxEmail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtEmail_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBlockPassword = ((System.Windows.Controls.TextBlock)(target));
            
            #line 78 "..\..\..\WindowLogin.xaml"
            this.textBlockPassword.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textPassword_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBoxPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 79 "..\..\..\WindowLogin.xaml"
            this.textBoxPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.txtPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 83 "..\..\..\WindowLogin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
