using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Intersoft.Crosslight;
using Intersoft.Crosslight.WinRT;
using MyInventory.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MyInventory.WinRT.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    [ViewModelType(typeof(SettingsViewModel))]
    public sealed partial class SettingPage : MyInventory.WinRT.Common.LayoutAwarePage, IListPage
    {
        public SettingPage()
        {
            this.InitializeComponent();
        }
    }
}
