using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ISessionIntervenantService
{
    Task<IEnumerable<SessionIntervenantDTO>> GetAllSessionIntervenants();
    Task<IEnumerable<SessionIntervenantDTO>> GetSessionIntervenantBySessionId(int id);
    Task<IEnumerable<SessionIntervenantDTO>> GetSessionIntervenantByIntervenantId(int id);
    Task<SessionIntervenantDTO> CreateSessionIntervenant(SessionIntervenantDTO sessionIntervenantDto);
    Task<SessionIntervenantDTO> UpdateSessionIntervenant(int id, SessionIntervenantDTO sessionIntervenantDto);
    Task DeleteSessionIntervenant(int id);
}

public class SessionIntervenantService : ISessionIntervenantService
{

    private readonly ISessionIntervenantRepository _ISessionIntervenantRepository;

    public SessionIntervenantService(ISessionIntervenantRepository ISessionIntervenantRepository)
    {
        _ISessionIntervenantRepository = ISessionIntervenantRepository;
    }

    public Task<IEnumerable<SessionIntervenantDTO>> GetAllSessionIntervenants()
    {
        var sessionIntervenants = _ISessionIntervenantRepository.GetAll();
        var dtos = sessionIntervenants.Select(s => new SessionIntervenantDTO
        {
            Role = s.Role,
            SessionId = s.SessionId,
            IntervenantId = s.IntervenantId
        });

        return Task.FromResult(dtos);
    }

    public Task<IEnumerable<SessionIntervenantDTO>> GetSessionIntervenantBySessionId(int id)
    {
        var sessionIntervenant = _ISessionIntervenantRepository.GetSessionIntervenantsBySessionId(id);
        if (sessionIntervenant == null)
        {
            throw new KeyNotFoundException($"SessionIntervenant with id {id} not found.");
        }

        var dtos = sessionIntervenant.Select(s => new SessionIntervenantDTO
        {
            Role = s.Role,
            SessionId = s.SessionId,
            IntervenantId = s.IntervenantId
        });

        return Task.FromResult(dtos);
    }

    public Task<IEnumerable<SessionIntervenantDTO>> GetSessionIntervenantByIntervenantId(int id)
    {
        var sessionIntervenant = _ISessionIntervenantRepository.GetSessionIntervenantsByIntervenantId(id);
        if (sessionIntervenant == null)
        {
            throw new KeyNotFoundException($"SessionIntervenant with id {id} not found.");
        }

        var dtos = sessionIntervenant.Select(s => new SessionIntervenantDTO
        {
            Role = s.Role,
            SessionId = s.SessionId,
            IntervenantId = s.IntervenantId
        });

        return Task.FromResult(dtos);
    }

    public Task<SessionIntervenantDTO> CreateSessionIntervenant(SessionIntervenantDTO sessionIntervenantDto)
    {
        var sessionIntervenant = new SessionIntervenant
        {
            Role = sessionIntervenantDto.Role,
            SessionId = sessionIntervenantDto.SessionId,
            IntervenantId = sessionIntervenantDto.IntervenantId
        };

        _ISessionIntervenantRepository.Add(sessionIntervenant);
        return Task.FromResult(sessionIntervenantDto);
    }

    public Task<SessionIntervenantDTO> UpdateSessionIntervenant(int id, SessionIntervenantDTO sessionIntervenantDto)
    {
        var sessionIntervenant = _ISessionIntervenantRepository.GetById(id);
        if (sessionIntervenant == null)
        {
            throw new KeyNotFoundException($"SessionIntervenant with id {id} not found.");
        }

        sessionIntervenant.Role = sessionIntervenantDto.Role;
        sessionIntervenant.SessionId = sessionIntervenantDto.SessionId;
        sessionIntervenant.IntervenantId = sessionIntervenantDto.IntervenantId;

        _ISessionIntervenantRepository.Update(sessionIntervenant);

        return Task.FromResult(sessionIntervenantDto);
    }

    public Task DeleteSessionIntervenant(int id)
    {
        var sessionIntervenant = _ISessionIntervenantRepository.GetById(id);
        if (sessionIntervenant == null)
        {
            throw new KeyNotFoundException($"SessionIntervenant with id {id} not found.");
        }

        _ISessionIntervenantRepository.Remove(sessionIntervenant);
        return Task.CompletedTask;
    }
}