using Intersoft.Crosslight.WinRT;
using MyInventory.WinRT.Infrastructure;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using IntersoftCore = Intersoft.Crosslight.WinRT;

// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace MyInventory.WinRT
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : IntersoftCore.Application
    {
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            // this.RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Light;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Allow Intersoft's WinRT base implementation to take care the application launching
            base.OnLaunched(args);

            // To perform session state restoration, override OnApplicationStarting instead.
            // See OnApplicationStarting method below.
        }

        /// <summary>
        /// Invoked when the application is about to start when it's launched normally by end user.
        /// Override this method to implement state restoration and other application-level initialization.
        /// </summary>
        /// <param name="args"></param>
        protected override async void OnApplicationStarting(LaunchActivatedEventArgs args)
        {
            // By default, RootFrame will automatically instantiate a new Frame object when it's accessed for the first time
            // To specify a custom frame, please override the RootFrame property.

            // Obtains the registered application state service
            IApplicationStateService stateService = this.GetService<IApplicationStateService>();

            // Associate the frame with an ApplicationStateService key  
            stateService.RegisterFrame(this.RootFrame, "AppFrame");

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                // Restore the saved session state only when appropriate
                try
                {
                    await stateService.RestoreAsync();
                }
                catch (ApplicationStateServiceException)
                {
                    //Something went wrong restoring state.
                    //Assume there is no state and continue
                }
            }
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        protected override async void OnSuspending(SuspendingEventArgs args)
        {
            // Obtains the registered application state service
            IApplicationStateService stateService = this.GetService<IApplicationStateService>();

            var deferral = args.SuspendingOperation.GetDeferral();
            await stateService.SaveAsync();
            deferral.Complete();
        }
    }
}
