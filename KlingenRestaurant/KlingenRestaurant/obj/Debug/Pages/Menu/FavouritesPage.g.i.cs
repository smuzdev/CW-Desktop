﻿#pragma checksum "..\..\..\..\Pages\Menu\FavouritesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FCDA7740DECD9E881F8B6B50E7E8C70F9F3F02ACEE429080718C0E837468B9D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KlingenRestaurant;
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


namespace KlingenRestaurant {
    
    
    /// <summary>
    /// FavouritesPage
    /// </summary>
    public partial class FavouritesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Pages\Menu\FavouritesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TransitioningContentSlide;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\Menu\FavouritesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListViewMenuDish;
        
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
            System.Uri resourceLocater = new System.Uri("/KlingenRestaurant;component/pages/menu/favouritespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Menu\FavouritesPage.xaml"
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
            this.TransitioningContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 2:
            
            #line 29 "..\..\..\..\Pages\Menu\FavouritesPage.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ScrollViewer_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListViewMenuDish = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

