﻿#pragma checksum "..\..\WindowTaikhoan.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A773C4AF20C0DA04D4F3CA9FA4D735A65DBE80A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using QuanLyNhanSu;
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


namespace QuanLyNhanSu {
    
    
    /// <summary>
    /// WindowTaikhoans
    /// </summary>
    public partial class WindowTaikhoans : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTendangnhap;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxMatkhau;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTenhienthi;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tbxLoaitk;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTimkiem;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThem;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnXoa;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSua;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\WindowTaikhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewTaikhoan;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyNhanSu;component/windowtaikhoan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowTaikhoan.xaml"
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
            this.tbxTendangnhap = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbxMatkhau = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbxTenhienthi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbxLoaitk = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.tbxTimkiem = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\WindowTaikhoan.xaml"
            this.tbxTimkiem.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbxTimkiem_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnThem = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\WindowTaikhoan.xaml"
            this.btnThem.Click += new System.Windows.RoutedEventHandler(this.btnThem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnXoa = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\WindowTaikhoan.xaml"
            this.btnXoa.Click += new System.Windows.RoutedEventHandler(this.btnXoa_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSua = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\WindowTaikhoan.xaml"
            this.btnSua.Click += new System.Windows.RoutedEventHandler(this.btnSua_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ListViewTaikhoan = ((System.Windows.Controls.ListView)(target));
            
            #line 88 "..\..\WindowTaikhoan.xaml"
            this.ListViewTaikhoan.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewTaikhoan_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

