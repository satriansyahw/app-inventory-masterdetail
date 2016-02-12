using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Intersoft.Crosslight.WinRT;
using MyInventory.WinRT.Common;
using MyInventory.ViewModels;

namespace MyInventory.WinRT.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    [MasterDetailViewModelType(typeof(SettingsViewModel))]
    public sealed partial class SettingMasterDetailPage : MasterDetailPage, IMasterDetail 
    {
        public SettingMasterDetailPage()
        {
            this.InitializeComponent();
        }
    }
}
