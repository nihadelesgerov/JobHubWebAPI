using JobHubWebAPI.DATALAYER.DataTransferObjects;

namespace JobHubWebAPI.APPLICATIONLAYER.AccountService
{
    public interface IAccountService
    {
        public AccountDTO UploadUsersInformation(string id);
        public AccountDTO UploadUserInformationForEdit(string id);
    }
}
