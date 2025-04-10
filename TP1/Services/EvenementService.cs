using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface IEvenementService
{
    Task<IEnumerable<EvenementDTO>> GetAllEvenements();
    Task<EvenementDTO> GetEvenementById(int id);
    Task<EvenementDTO> CreateEvenement(EvenementDTO evenementDto);
    Task<EvenementDTO> UpdateEvenement(int id, EvenementDTO evenementDto);
    Task DeleteEvenement(int id);
}

public class EvenementService : IEvenementService
{

    private readonly IEvenementRepository _EvenementRepository;

    public EvenementService(IEvenementRepository EvenementRepository)
    {
        _EvenementRepository = EvenementRepository;
    }

    public Task<IEnumerable<EvenementDTO>> GetAllEvenements()
    {
        var events = _EvenementRepository.GetAll();
        var dtos = events.Select(e => new EvenementDTO
        {
            Id = e.Id,
            Titre = e.Titre,
            Description = e.Description,
            DateDebut = e.DateDebut,
            DateFin = e.DateFin,
            Statut = e.Statut,
            Categorie = e.Categorie,
            LieuId = e.LieuId
        });

        return Task.FromResult(dtos);
    }

    public Task<EvenementDTO> GetEvenementById(int id)
    {
        var _event = _EvenementRepository.GetById(id);
        if (_event == null)
        {
            throw new KeyNotFoundException($"Evenement with id {id} not found.");
        }

        var dtos = new EvenementDTO
        {
            Id = _event.Id,
            Titre = _event.Titre,
            Description = _event.Description,
            DateDebut = _event.DateDebut,
            DateFin = _event.DateFin,
            Statut = _event.Statut,
            Categorie = _event.Categorie,
            LieuId = _event.LieuId
        };

        return Task.FromResult(dtos);
    }

    public Task<EvenementDTO> CreateEvenement(EvenementDTO evenementDto)
    {
        var _event = new Evenement
        {
            Titre = evenementDto.Titre,
            Description = evenementDto.Description,
            DateDebut = evenementDto.DateDebut,
            DateFin = evenementDto.DateFin,
            Statut = evenementDto.Statut,
            Categorie = evenementDto.Categorie,
            LieuId = evenementDto.LieuId
        };

        _EvenementRepository.Add(_event);
        return Task.FromResult(evenementDto);
    }

    public Task<EvenementDTO> UpdateEvenement(int id, EvenementDTO evenementDto)
    {
        var _event = _EvenementRepository.GetById(id);
        if (_event == null)
        {
            throw new KeyNotFoundException($"Evenement with id {id} not found.");
        }

        _event.Titre = evenementDto.Titre;
        _event.Description = evenementDto.Description;
        _event.DateDebut = evenementDto.DateDebut;
        _event.DateFin = evenementDto.DateFin;
        _event.Statut = evenementDto.Statut;
        _event.Categorie = evenementDto.Categorie;
        _event.LieuId = evenementDto.LieuId;

        _EvenementRepository.Update(_event);
        return Task.FromResult(evenementDto);
    }

    public Task DeleteEvenement(int id)
    {
        var _event = _EvenementRepository.GetById(id);
        if (_event == null)
        {
            throw new KeyNotFoundException($"Evenement with id {id} not found.");
        }

        _EvenementRepository.Remove(_event);
        return Task.FromResult(true);
    }
}