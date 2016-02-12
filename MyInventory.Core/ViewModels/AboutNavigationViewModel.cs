using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;

namespace MyInventory.ViewModels
{
    public class AboutNavigationViewModel : ViewModelBase
    {
        #region Constructors

        public AboutNavigationViewModel()
        {
            this.Title = "About";
            this.IntroductionText = "Intersoft Crosslight makes native enterprise cross-platform mobile development truly a breeze, thanks to the rock-solid frameworks and comprehensive data components.";
            this.AboutText = "Crosslight includes over more than 12,000 APIs and built-in services to make enterprise apps development easier than ever. This template represents a typical business app which leverages many of the services available in Crosslight such as local storage service, user management services, data access services, single sign-on with social services, push notification services, and much more.";
            this.LearnMoreCommand = new DelegateCommand(ExecuteLearnMore);
        }

        #endregion

        #region Fields

        private string _aboutText;
        private string _introductionText;

        #endregion

        #region Properties

        public string AboutText
        {
            get { return _aboutText; }
            set
            {
                if (_aboutText != value)
                {
                    _aboutText = value;
                    OnPropertyChanged("AboutText");
                }
            }
        }

        public string IntroductionText
        {
            get { return _introductionText; }
            set
            {
                if (_introductionText != value)
                {
                    _introductionText = value;
                    OnPropertyChanged("IntroductionText");
                }
            }
        }

        public DelegateCommand LearnMoreCommand { get; set; }

        #endregion

        #region Methods

        private void ExecuteLearnMore(object parameter)
        {
            this.MobileService.Browser.Navigate("http://www.intersoftpt.com/crosslight");
        }

        #endregion
    }
}