using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ISessionIntervenantService
{
}

public class SessionIntervenantService : ISessionIntervenantService
{

    private readonly ISessionIntervenantRepository _ISessionIntervenantRepository;

    public SessionIntervenantService(ISessionIntervenantRepository ISessionIntervenantRepository)
    {
        _ISessionIntervenantRepository = ISessionIntervenantRepository;
    }
}