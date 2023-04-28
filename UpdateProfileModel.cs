
using DeskBook.EndPoint.UpdateProfile;
using Newtonsoft.Json;


namespace DeskBook.Model.EditProfileModeOfWork
{
    public class UpdateProfileModel 
    {
        private readonly IUpdateProfileEndPoint _endPoint;
        private readonly IEndPointProvider _endPointProvider;

        public IpdateProfileDataModel UpdateDataModel { get; set; }

        public UpdateProfileModel(IUpdateProfileEndPoint endPoint, IEndPointProvider endPointProvider)
        {
            _endPoint = endPoint;
            _endPointProvider = endPointProvider;
        }


        public async Task<ActionResultEventArgs> PerfromActionAsync()
        {
            try
            {
                #region Step 1: API call

                _endPoint.UpdateDataModel = UpdateDataModel;
                var data = await _endPointProvider.ExecuteAsync(_endPoint);
                #endregion

                #region Step 2: Return Response
                if (!data.IsResultSuccess)
                {
                    return ActionResultEventArgs.Response(data);
                }
                #endregion

                #region Step 3: UI operations
                // operation
                var content = JsonConvert.DeserializeObject<ProfileResponseModel>(data.Content);

                return ActionResultEventArgs.Response(data);
                #endregion
            }
            catch (Exception ex)
            {
                #region Exception Handling
                // Return the response
                return ActionResultEventArgs.Exception(ex.Message);
                #endregion
            }

        }
    }
}
