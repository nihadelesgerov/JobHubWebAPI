using JobHubWebAPI.APPLICATIONLAYER.EFCoreService;
using JobHubWebAPI.DATALAYER.DataTransferObjects;
using JobHubWebAPI.DATALAYER.Repositores.ServicesR;

namespace JobHubWebAPI.APPLICATIONLAYER.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo accountRepo;

        public AccountService(IAccountRepo accountRepo)
        {
            this.accountRepo = accountRepo;
        }
        public AccountDTO UploadUsersInformation(string id)
        {
            return accountRepo.GetUserAccount().MapAccount(id);
        }
        public AccountDTO UploadUserInformationForEdit(string id)
        {
            return accountRepo.GetUserAccount().MapAccountForEdit(id);
        }
    }
}
