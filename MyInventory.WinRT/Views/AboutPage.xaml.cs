using Intersoft.Crosslight;
using MyInventory.ViewModels;

namespace MyInventory.WinRT
{
    [ViewModelType(typeof(AboutNavigationViewModel))]
    public sealed partial class AboutPage
    {
        public AboutPage()
        {
            this.InitializeComponent();
        }
    }
}
