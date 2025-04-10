using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ISessionService
{
}

public class SessionService : ISessionService
{

    private readonly ISessionRepository _SessionRepository;

    public SessionService(ISessionRepository SessionRepository)
    {
        _SessionRepository = SessionRepository;
    }
}