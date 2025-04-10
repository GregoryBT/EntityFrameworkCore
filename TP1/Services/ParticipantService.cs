using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface IParticipantService
{
    Task<IEnumerable<ParticipantDTO>> GetAllParticipants();
    Task<ParticipantDTO> GetParticipantById(int id);
    Task<ParticipantDTO> CreateParticipant(ParticipantDTO participantDto);
    Task<ParticipantDTO> UpdateParticipant(int id, ParticipantDTO participantDto);
    Task DeleteParticipant(int id);
}

public class ParticipantService : IParticipantService
{

    private readonly IParticipantRepository _ParticipantRepository;

    public ParticipantService(IParticipantRepository ParticipantRepository)
    {
        _ParticipantRepository = ParticipantRepository;
    }

    public Task<IEnumerable<ParticipantDTO>> GetAllParticipants()
    {
        var participants = _ParticipantRepository.GetAll();
        var dtos = participants.Select(p => new ParticipantDTO
        {
            Id = p.Id,
            Nom = p.Nom,
            Prenom = p.Prenom,
            Email = p.Email,
            Entreprise = p.Entreprise,
            Poste = p.Poste
        });

        return Task.FromResult(dtos);
    }

    public Task<ParticipantDTO> GetParticipantById(int id)
    {
        var participant = _ParticipantRepository.GetById(id);
        if (participant == null)
        {
            throw new KeyNotFoundException($"Participant with id {id} not found.");
        }

        var dto = new ParticipantDTO
        {
            Id = participant.Id,
            Nom = participant.Nom,
            Prenom = participant.Prenom,
            Email = participant.Email,
            Entreprise = participant.Entreprise,
            Poste = participant.Poste
        };

        return Task.FromResult(dto);
    }

    public Task<ParticipantDTO> CreateParticipant(ParticipantDTO participantDto)
    {
        var participant = new Participant
        {
            Nom = participantDto.Nom,
            Prenom = participantDto.Prenom,
            Email = participantDto.Email,
            Entreprise = participantDto.Entreprise,
            Poste = participantDto.Poste
        };

        _ParticipantRepository.Add(participant);
        return Task.FromResult(participantDto);
    }

    public Task<ParticipantDTO> UpdateParticipant(int id, ParticipantDTO participantDto)
    {
        var participant = _ParticipantRepository.GetById(id);
        if (participant == null)
        {
            throw new KeyNotFoundException($"Participant with id {id} not found.");
        }

        participant.Nom = participantDto.Nom;
        participant.Prenom = participantDto.Prenom;
        participant.Email = participantDto.Email;
        participant.Entreprise = participantDto.Entreprise;
        participant.Poste = participantDto.Poste;

        _ParticipantRepository.Update(participant);
        return Task.FromResult(participantDto);
    }

    public Task DeleteParticipant(int id)
    {
        var participant = _ParticipantRepository.GetById(id);
        if (participant == null)
        {
            throw new KeyNotFoundException($"Participant with id {id} not found.");
        }

        _ParticipantRepository.Remove(participant);
        return Task.CompletedTask;
    }
}