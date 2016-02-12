using Intersoft.Crosslight;
using MyInventory.ViewModels;

namespace MyInventory
{
    public class CategoryListBindingProvider : BindingProvider
    {
        #region Constructors

        public CategoryListBindingProvider()
        {
            IApplicationContext context = this.GetService<IApplicationService>().GetContext();
            bool isTablet = context.Device.Kind == DeviceKind.Tablet;
            ItemBindingDescription itemBinding = new ItemBindingDescription()
            {
                DisplayMemberPath = "Name"
            };

            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);

            if (isTablet)
                this.AddBinding("TableView", BindableProperties.DetailNavigationTargetProperty, new NavigationTarget(typeof(ItemListViewModel), "CategoryItemList", NavigationTargetKind.Self), true);
            else
                this.AddBinding("TableView", BindableProperties.DetailNavigationTargetProperty, new NavigationTarget(typeof(ItemListViewModel), "CategoryItemList"), true);
        }

        #endregion
    }
}