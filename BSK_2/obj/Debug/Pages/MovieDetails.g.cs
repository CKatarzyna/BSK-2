﻿#pragma checksum "..\..\..\Pages\MovieDetails.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A522ECCB231438BFE8D896F0CDC19777C980B3A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BSK_2.Pages;
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


namespace BSK_2.Pages {
    
    
    /// <summary>
    /// MovieDetails
    /// </summary>
    public partial class MovieDetails : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Pages\MovieDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label infoLabel2;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\MovieDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label infoLabel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\MovieDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\MovieDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button returnButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\MovieDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logOffButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\MovieDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewDirectors;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\MovieDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewActors;
        
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
            System.Uri resourceLocater = new System.Uri("/BSK_2;component/pages/moviedetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MovieDetails.xaml"
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
            this.infoLabel2 = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.infoLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\MovieDetails.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.returnButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Pages\MovieDetails.xaml"
            this.returnButton.Click += new System.Windows.RoutedEventHandler(this.returnButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.logOffButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Pages\MovieDetails.xaml"
            this.logOffButton.Click += new System.Windows.RoutedEventHandler(this.logOffButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.listViewDirectors = ((System.Windows.Controls.ListView)(target));
            
            #line 29 "..\..\..\Pages\MovieDetails.xaml"
            this.listViewDirectors.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listViewDirectors_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listViewActors = ((System.Windows.Controls.ListView)(target));
            
            #line 40 "..\..\..\Pages\MovieDetails.xaml"
            this.listViewActors.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listViewActors_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

