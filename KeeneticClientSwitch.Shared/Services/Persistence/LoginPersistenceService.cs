using KeeneticClientSwitch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KeeneticClientSwitch.Data.Services.Persistence;

public class LoginPersistenceService : ILoginPersistenceService
{
    private readonly LocalContext _localContext;

    public LoginPersistenceService(LocalContext localContext)
    {
        _localContext = localContext;
    }

    public async Task Initialize()
    {
        await _localContext.Initialize();
    }

    public async Task SaveLastLogin(LastLogin lastLogin)
    {
        await Initialize();
        lastLogin.RecordedAt = DateTimeOffset.Now;
        lastLogin = _localContext.LastLogins.Add(lastLogin).Entity;
        await _localContext.SaveChangesAsync();
        var insertedId = lastLogin.Id;
        _localContext.LastLogins.Where(e => e.Id != insertedId).ExecuteDelete();
        await _localContext.SaveChangesAsync();
    }

    public async Task<LastLogin?> GetLastLogin()
    {
        await Initialize();
        return _localContext.LastLogins.OrderByDescending(x => x.RecordedAt).FirstOrDefault();
    }
}
