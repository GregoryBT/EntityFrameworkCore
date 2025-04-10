using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ISalleService
{
    Task<IEnumerable<SalleDTO>> GetAllSalles();
    Task<SalleDTO> GetSalleById(int id);
    Task<SalleDTO> CreateSalle(SalleDTO salleDto);
    Task<SalleDTO> UpdateSalle(int id, SalleDTO salleDto);
    Task DeleteSalle(int id);
}

public class SalleService : ISalleService
{

    private readonly ISalleRepository _SalleRepository;

    public SalleService(ISalleRepository SalleRepository)
    {
        _SalleRepository = SalleRepository;
    }

    public Task<IEnumerable<SalleDTO>> GetAllSalles()
    {
        var salles = _SalleRepository.GetAll();
        var dtos = salles.Select(s => new SalleDTO
        {
            Id = s.Id,
            Nom = s.Nom,
            Capacite = s.Capacite,
            LieuId = s.LieuId
        });

        return Task.FromResult(dtos);
    }

    public Task<SalleDTO> GetSalleById(int id)
    {
        var salle = _SalleRepository.GetById(id);
        if (salle == null)
        {
            throw new KeyNotFoundException($"Salle with id {id} not found.");
        }

        var dto = new SalleDTO
        {
            Id = salle.Id,
            Nom = salle.Nom,
            Capacite = salle.Capacite,
            LieuId = salle.LieuId
        };

        return Task.FromResult(dto);
    }

    public Task<SalleDTO> CreateSalle(SalleDTO salleDto)
    {
        var salle = new Salle
        {
            Nom = salleDto.Nom,
            Capacite = salleDto.Capacite,
            LieuId = salleDto.LieuId
        };

        _SalleRepository.Add(salle);
        salleDto.Id = salle.Id;

        return Task.FromResult(salleDto);
    }

    public Task<SalleDTO> UpdateSalle(int id, SalleDTO salleDto)
    {
        var salle = _SalleRepository.GetById(id);
        if (salle == null)
        {
            throw new KeyNotFoundException($"Salle with id {id} not found.");
        }

        salle.Nom = salleDto.Nom;
        salle.Capacite = salleDto.Capacite;
        salle.LieuId = salleDto.LieuId;

        _SalleRepository.Update(salle);

        return Task.FromResult(salleDto);
    }

    public Task DeleteSalle(int id)
    {
        var salle = _SalleRepository.GetById(id);
        if (salle == null)
        {
            throw new KeyNotFoundException($"Salle with id {id} not found.");
        }

        _SalleRepository.Remove(salle);
        return Task.CompletedTask;
    }
}