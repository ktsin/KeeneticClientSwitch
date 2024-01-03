using KeeneticClientSwitch.Data.Models;

namespace KeeneticClientSwitch.Data.Services.Persistence
{
    public interface ILoginPersistenceService
    {
        Task<LastLogin?> GetLastLogin();
        Task Initialize();
        Task SaveLastLogin(LastLogin lastLogin);
    }
}