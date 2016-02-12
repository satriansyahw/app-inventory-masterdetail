using Intersoft.Crosslight;
using Intersoft.Crosslight.WinRT;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using IntersoftCore = Intersoft.Crosslight.WinRT;

namespace MyInventory.WinRT.Common
{
    /// <summary>
    /// Typical implementation of Page that provides several important conveniences:
    /// <list type="bullet">
    /// <item>
    /// <description>Application view state to visual state mapping</description>
    /// </item>
    /// <item>
    /// <description>GoBack, GoForward, and GoHome event handlers</description>
    /// </item>
    /// <item>
    /// <description>Mouse and keyboard shortcuts for navigation</description>
    /// </item>
    /// <item>
    /// <description>State management for navigation and process lifetime management</description>
    /// </item>
    /// <item>
    /// <description>A default view model</description>
    /// </item>
    /// </list>
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public class LayoutAwarePage : IntersoftCore.Page, ILayoutAware
    {
        private List<Control> _layoutAwareControls;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutAwarePage"/> class.
        /// </summary>
        public LayoutAwarePage()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                return;

            // When this page is part of the visual tree make two changes:
            // 1) Map application view state to visual state for the page
            // 2) Handle keyboard and mouse navigation requests
            this.Loaded += (sender, e) =>
            {
                this.StartLayoutUpdates(sender, e);

                var inputPane = InputPane.GetForCurrentView();
                inputPane.Showing += OnInputPaneShowing;
                inputPane.Hiding += OnInputPaneHiding;

                VisualStateManager.GoToState(this, "LayoutInitialize", false);
                this.GetService<IViewService>().RunOnUIThread(() => VisualStateManager.GoToState(this, "LayoutReady", true));
            };

            // Undo the same changes when the page is no longer visible
            this.Unloaded += (sender, e) =>
            {
                this.StopLayoutUpdates(sender, e);

                var inputPane = InputPane.GetForCurrentView();
                inputPane.Showing -= OnInputPaneShowing;
                inputPane.Hiding -= OnInputPaneHiding;
            };
        }

        protected virtual void OnInputPaneHiding(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            VisualStateManager.GoToState(this, "InputPaneHidden", false);
        }

        protected virtual void OnInputPaneShowing(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            VisualStateManager.GoToState(this, "InputPaneShown", false);
        }

        #region Visual state switching

        /// <summary>
        /// Invoked as an event handler, typically on the <see cref="FrameworkElement.Loaded"/>
        /// event of a <see cref="Control"/> within the page, to indicate that the sender should
        /// start receiving visual state management changes that correspond to application view
        /// state changes.
        /// </summary>
        /// <param name="sender">Instance of <see cref="Control"/> that supports visual state
        /// management corresponding to view states.</param>
        /// <param name="e">Event data that describes how the request was made.</param>
        /// <remarks>The current view state will immediately be used to set the corresponding
        /// visual state when layout updates are requested.  A corresponding
        /// <see cref="FrameworkElement.Unloaded"/> event handler connected to
        /// <see cref="StopLayoutUpdates"/> is strongly encouraged.  Instances of
        /// <see cref="LayoutAwarePage"/> automatically invoke these handlers in their Loaded and
        /// Unloaded events.</remarks>
        /// <seealso cref="GetLayoutVisualState"/>
        /// <seealso cref="InvalidateLayoutVisualState"/>
        public void StartLayoutUpdates(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;
            if (this._layoutAwareControls == null)
            {
                // Start listening to view state changes when there are controls interested in updates
                Window.Current.SizeChanged += this.WindowSizeChanged;
                this._layoutAwareControls = new List<Control>();
            }
            this._layoutAwareControls.Add(control);

            // Set the initial visual state of the control
            // VisualStateManager.GoToState(control, this.GetLayoutVisualState(ApplicationView.Value), false);
            this.InvalidateLayoutVisualState();
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            this.InvalidateLayoutVisualState();
        }

        /// <summary>
        /// Invoked as an event handler, typically on the <see cref="FrameworkElement.Unloaded"/>
        /// event of a <see cref="Control"/>, to indicate that the sender should start receiving
        /// visual state management changes that correspond to application view state changes.
        /// </summary>
        /// <param name="sender">Instance of <see cref="Control"/> that supports visual state
        /// management corresponding to view states.</param>
        /// <param name="e">Event data that describes how the request was made.</param>
        /// <remarks>The current view state will immediately be used to set the corresponding
        /// visual state when layout updates are requested.</remarks>
        /// <seealso cref="StartLayoutUpdates"/>
        public void StopLayoutUpdates(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            if (control == null || this._layoutAwareControls == null) return;
            this._layoutAwareControls.Remove(control);
            if (this._layoutAwareControls.Count == 0)
            {
                // Stop listening to view state changes when no controls are interested in updates
                this._layoutAwareControls = null;
                Window.Current.SizeChanged -= this.WindowSizeChanged;
            }
        }

        /// <summary>
        /// Translates <see cref="ApplicationViewState"/> values into strings for visual state
        /// management within the page.  The default implementation uses the names of enum values.
        /// Subclasses may override this method to control the mapping scheme used.
        /// </summary>
        /// <param name="viewState">View state for which a visual state is desired.</param>
        /// <returns>Visual state name used to drive the
        /// <see cref="VisualStateManager"/></returns>
        /// <seealso cref="InvalidateLayoutVisualState"/>
        public virtual string GetLayoutVisualState(ApplicationViewState viewState)
        {
            return viewState.ToString();
        }

        /// <summary>
        /// Updates all controls that are listening for visual state changes with the correct
        /// visual state.
        /// </summary>
        /// <remarks>
        /// Typically used in conjunction with overriding <see cref="GetLayoutVisualState"/> to
        /// signal that a different value may be returned even though the view state has not
        /// changed.
        /// </remarks>
        public virtual void InvalidateLayoutVisualState()
        {
            if (this._layoutAwareControls != null)
            {
                string visualState = this.GetLayoutVisualState(ApplicationView.Value);

                foreach (var layoutAwareControl in this._layoutAwareControls)
                    VisualStateManager.GoToState(layoutAwareControl, visualState, false);
            }
        }

        #endregion

    }
}
