﻿#pragma checksum "..\..\..\..\UserControls\UcAccountEditSave.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7EEF96750529D4DE449780EAC4ADCEAE58BF6818"
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


namespace BankProject.UserControls {
    
    
    /// <summary>
    /// UcAccountEditSave
    /// </summary>
    public partial class UcAccountEditSave : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Title;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxAccountId;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxCustomerId;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxAccountType;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxMonthlyFee;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BankProject.UserControls.UcTextBoxRegister myTextBoxInterestRate;
        
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
            System.Uri resourceLocater = new System.Uri("/BankProject;V1.0.0.0;component/usercontrols/ucaccounteditsave.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.14.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.Title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.myTextBoxAccountId = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 3:
            this.myTextBoxCustomerId = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 4:
            this.myTextBoxAccountType = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 5:
            this.myTextBoxMonthlyFee = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 6:
            this.myTextBoxInterestRate = ((BankProject.UserControls.UcTextBoxRegister)(target));
            return;
            case 7:
            
            #line 72 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 73 "..\..\..\..\UserControls\UcAccountEditSave.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

