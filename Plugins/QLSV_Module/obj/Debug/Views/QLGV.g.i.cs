#pragma checksum "..\..\..\Views\QLGV.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57AA0406741000E86FB645DA9E9093819129C872"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI.ModuleInjection;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
using QLGV_Module.ViewModels;
using QLGV_Module.Views;
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


namespace QLSV_Module.Views
{


    /// <summary>
    /// QLGV
    /// </summary>
    public partial class QLSV : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 37 "..\..\..\Views\QLGV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMaGV;

#line default
#line hidden


#line 38 "..\..\..\Views\QLGV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTenGV;

#line default
#line hidden


#line 39 "..\..\..\Views\QLGV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbLop;

#line default
#line hidden


#line 41 "..\..\..\Views\QLGV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;

#line default
#line hidden


#line 42 "..\..\..\Views\QLGV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;

#line default
#line hidden


#line 47 "..\..\..\Views\QLGV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QLGV_Module;component/views/qlgv.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\QLGV.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.txtMaGV = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.txtTenGV = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.cbbLop = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 4:
                    this.btnAdd = ((System.Windows.Controls.Button)(target));

#line 41 "..\..\..\Views\QLGV.xaml"
                    this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.btnUpdate = ((System.Windows.Controls.Button)(target));

#line 42 "..\..\..\Views\QLGV.xaml"
                    this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.datagrid = ((System.Windows.Controls.DataGrid)(target));

#line 47 "..\..\..\Views\QLGV.xaml"
                    this.datagrid.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.datagrid_SelectedCellsChanged);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

