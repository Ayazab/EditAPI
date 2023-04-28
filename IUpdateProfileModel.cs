using DeskBook.DataModel;

namespace DeskBook
{
    public interface IUpdateProfileModel
    {
        UpdateProfileDataModel UpdateProfileDataModel { get; set; }
        Task<ActionResultEventArgs> PerfromActionAsync();
    }
}
