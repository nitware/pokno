﻿#pragma checksum "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "96B303D982339EB82C867269098FF43E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Pokno.People.ViewModel;
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
using System.Windows.Interactivity;
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


namespace Pokno.People.Views.Popups {
    
    
    /// <summary>
    /// ChangePasswordPopUpView
    /// </summary>
    public partial class ChangePasswordPopUpView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Pokno.People.Views.Popups.ChangePasswordPopUpView childWindow;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbNewPassKey;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbConfirmPassKey;
        
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
            System.Uri resourceLocater = new System.Uri("/Pokno.People;component/views/popups/changepasswordpopupview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml"
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
            this.childWindow = ((Pokno.People.Views.Popups.ChangePasswordPopUpView)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.pbNewPassKey = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 66 "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml"
            this.pbNewPassKey.PasswordChanged += new System.Windows.RoutedEventHandler(this.pbNewPassKey_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pbConfirmPassKey = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 69 "..\..\..\..\Views\Popups\ChangePasswordPopUpView.xaml"
            this.pbConfirmPassKey.PasswordChanged += new System.Windows.RoutedEventHandler(this.pbConfirmPassKey_PasswordChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

