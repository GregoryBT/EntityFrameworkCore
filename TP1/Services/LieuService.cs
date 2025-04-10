using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ILieuService
{
    Task<IEnumerable<LieuDTO>> GetAllLieux();
    Task<LieuDTO> GetLieuById(int id);
    Task<LieuDTO> CreateLieu(LieuDTO lieuDto);
    Task<LieuDTO> UpdateLieu(int id, LieuDTO lieuDto);
    Task DeleteLieu(int id);
}

public class LieuService : ILieuService
{

    private readonly ILieuRepository _LieuRepository;

    public LieuService(ILieuRepository LieuRepository)
    {
        _LieuRepository = LieuRepository;
    }

    public Task<IEnumerable<LieuDTO>> GetAllLieux()
    {
        var lieux = _LieuRepository.GetAll();
        var dtos = lieux.Select(l => new LieuDTO
        {
            Id = l.Id,
            Nom = l.Nom,
            Adresse = l.Adresse,
            Ville = l.Ville,
            Pays = l.Pays,
            Capacite = l.Capacite
        });

        return Task.FromResult(dtos);
    }

    public Task<LieuDTO> GetLieuById(int id)
    {
        var lieu = _LieuRepository.GetById(id);
        if (lieu == null)
        {
            throw new KeyNotFoundException($"Lieu with id {id} not found.");
        }

        var dto = new LieuDTO
        {
            Id = lieu.Id,
            Nom = lieu.Nom,
            Adresse = lieu.Adresse,
            Ville = lieu.Ville,
            Pays = lieu.Pays,
            Capacite = lieu.Capacite
        };

        return Task.FromResult(dto);
    }

    public Task<LieuDTO> CreateLieu(LieuDTO lieuDto)
    {
        var lieu = new Lieu
        {
            Nom = lieuDto.Nom,
            Adresse = lieuDto.Adresse,
            Ville = lieuDto.Ville,
            Pays = lieuDto.Pays,
            Capacite = lieuDto.Capacite
        };

        _LieuRepository.Add(lieu);
        return Task.FromResult(lieuDto);
    }

    public Task<LieuDTO> UpdateLieu(int id, LieuDTO lieuDto)
    {
        var existingLieu = _LieuRepository.GetById(id);
        if (existingLieu == null)
        {
            throw new KeyNotFoundException($"Lieu with id {id} not found.");
        }

        existingLieu.Nom = lieuDto.Nom;
        existingLieu.Adresse = lieuDto.Adresse;
        existingLieu.Ville = lieuDto.Ville;
        existingLieu.Pays = lieuDto.Pays;
        existingLieu.Capacite = lieuDto.Capacite;

        _LieuRepository.Update(existingLieu);
        return Task.FromResult(lieuDto);
    }

    public Task DeleteLieu(int id)
    {
        var existingLieu = _LieuRepository.GetById(id);
        if (existingLieu == null)
        {
            throw new KeyNotFoundException($"Lieu with id {id} not found.");
        }

        _LieuRepository.Remove(existingLieu);
        return Task.CompletedTask;
    }
}