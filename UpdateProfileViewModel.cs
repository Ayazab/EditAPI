using CommunityToolkit.Mvvm.Input;
using DeskBook.DataModel;
using DeskBook.Model.EditProfileModeOfWork;

namespace DeskBook.ViewModel
{
    public partial class UpdateProfileViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly IUpdateProfileModel _model;
        #endregion

        #region Properties
        private UpdateProfileDataModel _updateProfileDataModel;
        public UpdateProfileDataModel UpdateProfileDataModel
        {
            get { return _updateProfileDataModel; }
            set
            {
                _updateProfileDataModel = value;
                OnPropertyChanged();
            }
        }
        public IpdateProfileDataModel DataModel { get; set; }

        #endregion

        public UpdateProfileViewModel()
        {
            DataModel = AutoFactory.Resolve<IpdateProfileDataModel>();
            _model = AutoFactory.Resolve<IUpdateProfileModel>();
        }

        
        public async void PerformUpdateProfileAction()
        {
            try
            {
                var result = await _model.PerfromActionAsync();
                UpdateProfileDataModel = _model.UpdateProfileDataModel;
                var response = await _model.PerfromActionAsync();

                RaiseEvent(response);
            }
            catch (Exception ex)
            {
                RaiseExceptionEvent(ex);
            }
        }

    }
    /*public class UpdateProfileViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly IUpdateProfileModel _model;
        #endregion

        #region Properties
        private UpdateProfileDataModel _updateProfileDataModel;
        public UpdateProfileDataModel UpdateProfileDataModel
        {
            get { return _updateProfileDataModel; }
            set 
            { 
                _updateProfileDataModel = value;
                OnPropertyChanged();
            }
        }
        public ProfileDataModel DataModel { get; set; }

        #endregion

        public UpdateProfileViewModel()
        {
            DataModel = AutoFactory.Resolve<ProfileDataModel>();
            _model = AutoFactory.Resolve<IUpdateProfileModel>();
        }

        [RelayCommand]
        public async void PerformUpdateProfileAction()
        {
            try
            {
                var validationResult = DataModel.ValidateAll;

                if (!validationResult)
                {
                    return;
                }

                _model.UpdateDataModel = DataModel;

                var response = await _model.PerfromActionAsync();

                RaiseEvent(response);
            }
            catch (Exception ex)
            {
                RaiseExceptionEvent(ex);
            }
        }

    }*/
}
