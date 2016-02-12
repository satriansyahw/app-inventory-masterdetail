using System.Linq;
using Intersoft.Crosslight;
using Intersoft.Crosslight.WinRT;
using System;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyInventory.WinRT.Common
{
    /// <summary>
    /// Represents page for master detail capabilities.
    /// </summary>
    public class MasterDetailPage : SplitPage, ISplitPage
    {
        #region Properties
        internal IViewModel MasterViewModel { get; set; }
        internal IViewModel DetailViewModel { get; set; }
        private Frame MasterFrame { get; set; }
        private Frame DetailFrame { get; set; }
        #endregion

        #region Dependency Properties

        /// <summary>
        /// Identifies the MasterFrameName dependency property.
        /// </summary>
        public static readonly DependencyProperty MasterFrameNameProperty =
            DependencyProperty.Register("MasterFrameName", typeof(string), typeof(MasterDetailPage), new PropertyMetadata("MasterFrame"));

        /// <summary>
        /// Identifies the DetailFrameName dependency property.
        /// </summary>
        public static readonly DependencyProperty DetailFrameNameProperty =
            DependencyProperty.Register("DetailFrameName", typeof(string), typeof(MasterDetailPage), new PropertyMetadata("DetailFrame"));

        /// <summary>
        /// Gets or sets the name of the detail frame.
        /// </summary>
        /// <value>
        /// The name of the detail frame.
        /// </value>
        public string DetailFrameName
        {
            get { return (string)GetValue(DetailFrameNameProperty); }
            set { SetValue(DetailFrameNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the master frame.
        /// </summary>
        /// <value>
        /// The name of the master frame.
        /// </value>
        public string MasterFrameName
        {
            get { return (string)GetValue(MasterFrameNameProperty); }
            set { SetValue(MasterFrameNameProperty, value); }
        }

        #endregion

        #region Constructor
        public MasterDetailPage()
        {
        }
        #endregion

        #region Methods

        protected override void OnViewInitialized()
        {
            base.OnViewInitialized();

        }

        /// <summary>
        /// Called when the view is created.
        /// </summary>
        protected override void OnViewCreated()
        {
            base.OnViewCreated();

            if (this.ViewModel != null)
            {
                if (ViewModel is IListViewModel)
                {
                    MasterViewModel = ViewModel as IListViewModel;
                }
            }
            else
            {
                MasterDetailViewModelTypeAttribute attr = this.GetObjectTypeInfo().GetCustomAttribute<MasterDetailViewModelTypeAttribute>();
                if (attr != null)
                {
                    MasterViewModel = Activator.CreateInstance(attr.MasterViewModelType) as IViewModel;
                    if (attr.DetailViewModelType != null)
                        DetailViewModel = Activator.CreateInstance(attr.DetailViewModelType) as IViewModel;
                }
            }

            MasterFrame = this.Content.FindName<Frame>(MasterFrameName);
            if (MasterViewModel != null)
            {
                Type viewContextType = Utility.GetViewContext(MasterViewModel, typeof(IMasterDetail));
                if (viewContextType != null)
                {
                    NavigationService.PerformNavigation(viewContextType, MasterFrame, this.MasterViewModel);
                    
                    INavigable targetnavigable = MasterViewModel as INavigable;
                    if (targetnavigable != null)
                        targetnavigable.Navigated(new NavigatedParameter());
                }
            }
        }

        #endregion

        public override bool IsNavigable
        {
            get
            {
                return false;
            }
        }
    }
}
