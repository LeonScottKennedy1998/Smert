﻿#pragma checksum "..\..\StorageWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "162439CF8973F4CD78BB3F3113F0C047636F9696C5A674325A6EE3E9EEAD85B4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// StorageWindow
    /// </summary>
    public partial class StorageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TypeAnimalButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AnimalButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProductTypeButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProductButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Smert;component/storagewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StorageWindow.xaml"
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
            
            #line 8 "..\..\StorageWindow.xaml"
            ((Smert.StorageWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.TypeAnimalButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\StorageWindow.xaml"
            this.TypeAnimalButton.Click += new System.Windows.RoutedEventHandler(this.TypeAnimalButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AnimalButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\StorageWindow.xaml"
            this.AnimalButton.Click += new System.Windows.RoutedEventHandler(this.AnimalButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProductTypeButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\StorageWindow.xaml"
            this.ProductTypeButton.Click += new System.Windows.RoutedEventHandler(this.ProductTypeButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\StorageWindow.xaml"
            this.ProductButton.Click += new System.Windows.RoutedEventHandler(this.ProductButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
