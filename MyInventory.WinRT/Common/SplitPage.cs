using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intersoft.Crosslight;
using Intersoft.Crosslight.WinRT;
using Intersoft.Crosslight.WinRT.Services;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace MyInventory.WinRT.Common
{
    public class SplitPage : LayoutAwarePage, ISupportLogicalPageNavigation
    {
        #region Logical page navigation

        // Visual state management typically reflects the four application view states directly
        // (full screen landscape and portrait plus snapped and filled views.)  The split page is
        // designed so that the snapped and portrait view states each have two distinct sub-states:
        // either the item list or the details are displayed, but not both at the same time.
        //
        // This is all implemented with a single physical page that can represent two logical
        // pages.  The code below achieves this goal without making the user aware of the
        // distinction.

        #region Methods

        /// <summary>
        /// Invoked to determine the name of the visual state that corresponds to an application
        /// view state.
        /// </summary>
        /// <param name="viewState">The view state for which the question is being posed.</param>
        /// <returns>The name of the desired visual state.  This is the same as the name of the
        /// view state except when there is a selected item in portrait and snapped views where
        /// this additional logical page is represented by adding a suffix of _Detail.</returns>
        public override string GetLayoutVisualState(ApplicationViewState viewState)
        {
            // Determine visual states for landscape layouts based not on the view state, but
            // on the width of the window.  This page has one layout that is appropriate for
            // 1366 virtual pixels or wider, and another for narrower displays or when a snapped
            // application reduces the horizontal space available to less than 1366.
            if (viewState == ApplicationViewState.Filled || viewState == ApplicationViewState.FullScreenLandscape)
            {
                var windowWidth = Window.Current.Bounds.Width;

                if (windowWidth >= 1366)
                    return "FullScreenLandscapeOrWide";

                return "FilledOrNarrow";
            }

            // When in portrait or snapped start with the default visual state name, then add a
            // suffix when viewing details instead of the list
            var logicalPageBack = this.IsLogicalPageNavigation() && this.LogicalNavigationItem != null;
            var defaultStateName = base.GetLayoutVisualState(viewState);

            return logicalPageBack ? defaultStateName + "_Detail" : defaultStateName;
        }

        public override void InvalidateLayoutVisualState()
        {
            base.InvalidateLayoutVisualState();

            // Update the back button's enabled state when the view state changes
            INavigable navigable = this.ViewModel as INavigable;

            if (navigable != null)
                ((NavigationService)navigable.NavigationService).GoBackCommand.RaiseCanExecuteChanged();
        }

        #endregion

        /// <summary>
        /// Invoked to determine whether the page should act as one logical page or two.
        /// </summary>
        /// <returns>True when the view state in question is portrait or snapped, false
        /// otherwise.</returns>
        public bool IsLogicalPageNavigation()
        {
            return ApplicationView.Value == ApplicationViewState.FullScreenPortrait ||
                   ApplicationView.Value == ApplicationViewState.Snapped;
        }

        /// <summary>
        /// Gets or sets the item that represent the current logical navigation.
        /// </summary>
        public object LogicalNavigationItem
        {
            get { return NavigationService.GetLogicalNavigationItem(this); }
            set { NavigationService.SetLogicalNavigationItem(this, value); }
        }

        #endregion
    }
}
