using Refit;

namespace DeskBook.EndPoint.UpdateProfile
{
    public class UpdateProfileEndPoint : IUpdateProfileEndPoint, IEndPoint
    {
        public IpdateProfileDataModel UpdateDataModel { get; set; }
        public int Id { get; set; }

        public ProfileRequestModel ProfileRequestModel { get; set; }
        public async Task<HttpResponseMessage> Execute()
        {
            return await
                RestService.For<IDeskBookApi>("https://dummy.restapiexample.com/api/v1").UpdateProfile(ProfileRequestModel, Id);
        }
    }
}
