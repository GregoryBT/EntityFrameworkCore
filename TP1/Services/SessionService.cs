using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ISessionService
{
    Task<IEnumerable<SessionDTO>> GetAllSessions();
    Task<SessionDTO> GetSessionById(int id);
    Task<SessionDTO> CreateSession(SessionDTO sessionDto);
    Task<SessionDTO> UpdateSession(int id, SessionDTO sessionDto);
    Task DeleteSession(int id);
}

public class SessionService : ISessionService
{

    private readonly ISessionRepository _SessionRepository;

    public SessionService(ISessionRepository SessionRepository)
    {
        _SessionRepository = SessionRepository;
    }

    public Task<IEnumerable<SessionDTO>> GetAllSessions()
    {
        var sessions = _SessionRepository.GetAll();
        var dtos = sessions.Select(s => new SessionDTO
        {
            Id = s.Id,
            Titre = s.Titre,
            Description = s.Description,
            HeureDebut = s.HeureDebut,
            HeureFin = s.HeureFin,
            EvenementId = s.EvenementId,
            SalleId = s.SalleId,
        });

        return Task.FromResult(dtos);
    }

    public Task<SessionDTO> GetSessionById(int id)
    {
        var session = _SessionRepository.GetById(id);
        if (session == null)
        {
            throw new KeyNotFoundException($"Session with id {id} not found.");
        }

        var dto = new SessionDTO
        {
            Id = session.Id,
            Titre = session.Titre,
            Description = session.Description,
            HeureDebut = session.HeureDebut,
            HeureFin = session.HeureFin,
            EvenementId = session.EvenementId,
            SalleId = session.SalleId,
        };

        return Task.FromResult(dto);
    }

    public Task<SessionDTO> CreateSession(SessionDTO sessionDto)
    {
        var session = new Session
        {
            Titre = sessionDto.Titre,
            Description = sessionDto.Description,
            HeureDebut = sessionDto.HeureDebut,
            HeureFin = sessionDto.HeureFin,
            EvenementId = sessionDto.EvenementId,
            SalleId = sessionDto.SalleId,
        };

        _SessionRepository.Add(session);
        _SessionRepository.SaveChanges();

        return Task.FromResult(sessionDto);
    }

    public Task<SessionDTO> UpdateSession(int id, SessionDTO sessionDto)
    {
        var session = _SessionRepository.GetById(id);
        if (session == null)
        {
            throw new KeyNotFoundException($"Session with id {id} not found.");
        }

        session.Titre = sessionDto.Titre;
        session.Description = sessionDto.Description;
        session.HeureDebut = sessionDto.HeureDebut;
        session.HeureFin = sessionDto.HeureFin;
        session.EvenementId = sessionDto.EvenementId;
        session.SalleId = sessionDto.SalleId;

        _SessionRepository.Update(session);
        _SessionRepository.SaveChanges();

        return Task.FromResult(sessionDto);
    }

    public Task DeleteSession(int id)
    {
        var session = _SessionRepository.GetById(id);
        if (session == null)
        {
            throw new KeyNotFoundException($"Session with id {id} not found.");
        }

        _SessionRepository.Remove(session);
        _SessionRepository.SaveChanges();
        return Task.CompletedTask;
    }

}