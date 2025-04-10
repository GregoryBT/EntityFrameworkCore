using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface INotationService
{
    Task<IEnumerable<NotationDTO>> GetAllNotations();
    Task<NotationDTO> GetNotationById(int id);
    Task<NotationDTO> CreateNotation(NotationDTO notationDto);
    Task<NotationDTO> UpdateNotation(int id, NotationDTO notationDto);
    Task DeleteNotation(int id);
}

public class NotationService : INotationService
{

    private readonly INotationRepository _NotationRepository;

    public NotationService(INotationRepository NotationRepository)
    {
        _NotationRepository = NotationRepository;
    }

    public Task<IEnumerable<NotationDTO>> GetAllNotations()
    {
        var notations = _NotationRepository.GetAll();
        var dtos = notations.Select(n => new NotationDTO
        {
            Id = n.Id,
            Note = n.Note,
            Commentaire = n.Commentaire,
            SessionId = n.SessionId,
            ParticipantId = n.ParticipantId
        });

        return Task.FromResult(dtos);
    }

    public Task<NotationDTO> GetNotationById(int id)
    {
        var notation = _NotationRepository.GetById(id);
        if (notation == null)
        {
            throw new KeyNotFoundException($"Notation with id {id} not found.");
        }

        var dto = new NotationDTO
        {
            Id = notation.Id,
            Note = notation.Note,
            Commentaire = notation.Commentaire,
            SessionId = notation.SessionId,
            ParticipantId = notation.ParticipantId
        };

        return Task.FromResult(dto);
    }

    public Task<NotationDTO> CreateNotation(NotationDTO notationDto)
    {
        var notation = new Notation
        {
            Note = notationDto.Note,
            Commentaire = notationDto.Commentaire,
            SessionId = notationDto.SessionId,
            ParticipantId = notationDto.ParticipantId
        };

        _NotationRepository.Add(notation);
        return Task.FromResult(notationDto);
    }

    public Task<NotationDTO> UpdateNotation(int id, NotationDTO notationDto)
    {
        var existingNotation = _NotationRepository.GetById(id);
        if (existingNotation == null)
        {
            throw new KeyNotFoundException($"Notation with id {id} not found.");
        }

        existingNotation.Note = notationDto.Note;
        existingNotation.Commentaire = notationDto.Commentaire;
        existingNotation.SessionId = notationDto.SessionId;
        existingNotation.ParticipantId = notationDto.ParticipantId;

        _NotationRepository.Update(existingNotation);
        return Task.FromResult(notationDto);
    }

    public Task DeleteNotation(int id)
    {
        var existingNotation = _NotationRepository.GetById(id);
        if (existingNotation == null)
        {
            throw new KeyNotFoundException($"Notation with id {id} not found.");
        }

        _NotationRepository.Remove(existingNotation);
        return Task.CompletedTask;
    }
}