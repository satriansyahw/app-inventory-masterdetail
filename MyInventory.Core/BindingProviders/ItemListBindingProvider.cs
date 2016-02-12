using Intersoft.Crosslight;
using MyInventory.ViewModels;

namespace MyInventory
{
    public class ItemListBindingProvider : BindingProvider
    {
        #region Constructors

        public ItemListBindingProvider()
        {
            IApplicationContext context = this.GetService<IApplicationService>().GetContext();
            bool isTablet = context.Device.Kind == DeviceKind.Tablet;
            bool isAndroid = context.Platform.OperatingSystem == OSKind.Android;

            ItemBindingDescription itemBinding = new ItemBindingDescription()
            {
                DisplayMemberPath = "Name",
                DetailMemberPath = "Location",
                ImageMemberPath = "ThumbnailImage",
                ImagePlaceholder = "item_placeholder.png"
            };

            itemBinding.AddBinding("TextLabel", BindableProperties.StyleAttributesProperty, new BindingDescription("IsSold")
            {
                Converter = new TextLabelStyleConverter()
            });

            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.IsBatchUpdatingProperty, "IsBatchUpdating");
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.SelectedItemsProperty, "SelectedItems", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.IsEditingProperty, "IsEditing", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.AddItemCommandProperty, "AddCommand", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.DeleteItemCommandProperty, "DeleteCommand", BindingMode.TwoWay);

            // Specifically for Android tablet, navigate to detail instead of editor
            if (isTablet || isAndroid)
                this.AddBinding("TableView", BindableProperties.DetailNavigationTargetProperty, new NavigationTarget(typeof(ItemDetailViewModel)), true);
            else
                this.AddBinding("TableView", BindableProperties.DetailNavigationTargetProperty, new NavigationTarget(typeof(ItemEditorViewModel)), true);

            this.AddBinding("AddButton", BindableProperties.CommandProperty, "AddCommand");

            this.AddBinding("DeleteButton", BindableProperties.TextProperty, "DeleteText");
            this.AddBinding("DeleteButton", BindableProperties.CommandProperty, "DeleteCommand");

            if (isTablet)
                this.AddBinding("DeleteButton", BindableProperties.CommandParameterProperty, "SelectedItem");
            else
                this.AddBinding("DeleteButton", BindableProperties.CommandParameterProperty, "SelectedItems");

            this.AddBinding("MarkSoldButton", BindableProperties.TextProperty, "MarkSoldText");
            this.AddBinding("MarkSoldButton", BindableProperties.CommandProperty, "MarkSoldCommand");
            this.AddBinding("MarkSoldButton", BindableProperties.CommandParameterProperty, "SelectedItems");

            this.AddBinding("FooterLabel", BindableProperties.TextProperty, "TotalItemsText");
        }

        #endregion
    }
}