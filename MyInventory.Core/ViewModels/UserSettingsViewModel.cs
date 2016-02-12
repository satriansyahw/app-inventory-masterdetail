using System;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.EntityModel;
using Intersoft.Crosslight.ViewModels;
using MyInventory.Models;

namespace MyInventory.ViewModels
{
    public class UserSettingsViewModel : EditorViewModelBase<UserSettings>
    {
        #region Constructors

        public UserSettingsViewModel()
        {
            this.Item = new UserSettings();
            this.EntityContainer = new EntityContainer();
            this.EntityContainer.AddEntity(this.Item);

            this.Item.BeginEdit();
        }

        #endregion

        #region Properties

        private EntityContainer EntityContainer { get; set; }

        public override Type FormMetadataType
        {
            get { return typeof(UserSettingsFormMetadata); }
        }

        #endregion

        #region Methods

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);

            if (isDisposing)
            {
                this.EntityContainer.RemoveEntity(this.Item);
                this.EntityContainer = null;
            }
        }

        protected override void ExecuteCancel(object parameter)
        {
            this.Item.CancelEdit();

            base.ExecuteCancel(parameter);
        }

        protected override void ExecuteSave(object parameter)
        {
            this.Validate();

            if (!this.HasErrors)
            {
                this.Item.EndEdit();

                // await this.GetService<IUserSettingsService>().Save(this.Item);
                IApplicationContext context = this.GetService<IApplicationService>().GetContext();
                if (context.Device.Kind == DeviceKind.Phone)
                    this.NavigationService.Close();
            }
            else
                this.MessagePresenter.Show(this.ErrorMessage);
        }

        #endregion
    }
}