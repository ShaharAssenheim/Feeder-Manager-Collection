﻿#pragma checksum "..\..\AddNewFeeder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "09F602A547B5554CAB8603216582B1DEA031E39056564A8085BF38D799B22DF4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Feeder_Manager;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Feeder_Manager {
    
    
    /// <summary>
    /// AddNewFeeder
    /// </summary>
    public partial class AddNewFeeder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Feeder_ID;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox User_ID;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Feeder_Type;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Feeder_Sensor;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Fedder_Status;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Calibration_Date;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OKBtn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AddNewFeeder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Feeder Manager;component/addnewfeeder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddNewFeeder.xaml"
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
            this.Feeder_ID = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\AddNewFeeder.xaml"
            this.Feeder_ID.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Feeder_ID_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.User_ID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Feeder_Type = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Feeder_Sensor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Fedder_Status = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Calibration_Date = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.OKBtn = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\AddNewFeeder.xaml"
            this.OKBtn.Click += new System.Windows.RoutedEventHandler(this.Ok_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

