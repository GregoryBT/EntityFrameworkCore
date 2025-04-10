using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface IEvenementParticipantService
{
    Task<IEnumerable<EvenementParticipantDTO>> GetAllEvenementParticipants();
    Task<IEnumerable<EvenementParticipantDTO>> GetEvenementsParticipantByParticipantId(int id);
    Task<IEnumerable<EvenementParticipantDTO>> GetEvenementParticipantByEvenementId(int id);
    Task<EvenementParticipantDTO> CreateEvenementParticipant(EvenementParticipantDTO evenement);
    Task<EvenementParticipantDTO> UpdateEvenementParticipant(int id, EvenementParticipantDTO evenement);
    Task DeleteEvenementParticipant(int id);
}

public class EvenementParticipantService : IEvenementParticipantService
{

    private readonly IEvenementParticipantRepository _EvenementParticipantRepository;

    public EvenementParticipantService(IEvenementParticipantRepository EvenementParticipantRepository)
    {
        _EvenementParticipantRepository = EvenementParticipantRepository;
    }

    public Task<IEnumerable<EvenementParticipantDTO>> GetAllEvenementParticipants()
    {
        var ep = _EvenementParticipantRepository.GetAll();
        var dtos = ep.Select(e => new EvenementParticipantDTO
        {
            DateInscription = e.DateInscription,
            StatutPresence = e.StatutPresence,
            EvenementId = e.EvenementId,
            ParticipantId = e.ParticipantId,
        });
        return Task.FromResult(dtos);
    }

    public Task<IEnumerable<EvenementParticipantDTO>> GetEvenementsParticipantByParticipantId(int id)
    {
        var ep = _EvenementParticipantRepository.GetEvenementsParticipantByParticipantId(id);
        var dtos = ep.Select(e => new EvenementParticipantDTO
        {
            DateInscription = e.DateInscription,
            StatutPresence = e.StatutPresence,
            EvenementId = e.EvenementId,
            ParticipantId = e.ParticipantId,
        });
        return Task.FromResult(dtos);
    }

    public Task<IEnumerable<EvenementParticipantDTO>> GetEvenementParticipantByEvenementId(int id)
    {
        var ep = _EvenementParticipantRepository.GetEvenementsParticipantByEvenementId(id);
        var dtos = ep.Select(e => new EvenementParticipantDTO
        {
            DateInscription = e.DateInscription,
            StatutPresence = e.StatutPresence,
            EvenementId = e.EvenementId,
            ParticipantId = e.ParticipantId,
        });
        return Task.FromResult(dtos);
    }

    public Task<EvenementParticipantDTO> CreateEvenementParticipant(EvenementParticipantDTO evenement)
    {
        var ep = new EvenementParticipant
        {
            DateInscription = evenement.DateInscription,
            StatutPresence = evenement.StatutPresence,
            EvenementId = evenement.EvenementId,
            ParticipantId = evenement.ParticipantId,
        };
        _EvenementParticipantRepository.Add(ep);
        return Task.FromResult(evenement);
    }

    public Task<EvenementParticipantDTO> UpdateEvenementParticipant(int id, EvenementParticipantDTO evenementDto)
    {
        var ep = _EvenementParticipantRepository.GetById(id);
        if (ep == null)
        {
            throw new KeyNotFoundException($"EvenementParticipant with id {id} not found.");
        }

        ep.DateInscription = evenementDto.DateInscription;
        ep.StatutPresence = evenementDto.StatutPresence;
        ep.EvenementId = evenementDto.EvenementId;
        ep.ParticipantId = evenementDto.ParticipantId;

        _EvenementParticipantRepository.Update(ep);
        return Task.FromResult(evenementDto);
    }

    public Task DeleteEvenementParticipant(int id)
    {
        var _event = _EvenementParticipantRepository.GetById(id);
        if (_event == null)
        {
            throw new KeyNotFoundException($"EvenementParticipant with id {id} not found.");
        }

        _EvenementParticipantRepository.Remove(_event);
        return Task.FromResult(true);
    }
}