﻿#pragma checksum "..\..\ProductPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EACD3AAAF78ACAF060CA32E97F2730D0153A34664123E946D64A241A2FBC35AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Smert;
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


namespace Smert {
    
    
    /// <summary>
    /// ProductPage
    /// </summary>
    public partial class ProductPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductGrid;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Import;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTb;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescrTB;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTB;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AmountTb;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox IdcatCB;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProduct;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveProduct;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteProduct;
        
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
            System.Uri resourceLocater = new System.Uri("/Smert;component/productpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProductPage.xaml"
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
            this.ProductGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 23 "..\..\ProductPage.xaml"
            this.ProductGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProductGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Import = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ProductPage.xaml"
            this.Import.Click += new System.Windows.RoutedEventHandler(this.Import_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NameTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DescrTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PriceTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AmountTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.IdcatCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 53 "..\..\ProductPage.xaml"
            this.IdcatCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.IdcatCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddProduct = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\ProductPage.xaml"
            this.AddProduct.Click += new System.Windows.RoutedEventHandler(this.AddProduct_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SaveProduct = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\ProductPage.xaml"
            this.SaveProduct.Click += new System.Windows.RoutedEventHandler(this.SaveProduct_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DeleteProduct = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\ProductPage.xaml"
            this.DeleteProduct.Click += new System.Windows.RoutedEventHandler(this.DeleteProduct_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

