using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface IIntervenantService
{
    Task<IEnumerable<IntervenantDTO>> GetAllIntervenants();
    Task<IntervenantDTO> GetIntervenantById(int id);
    Task<IntervenantDTO> CreateIntervenant(IntervenantDTO intervenantDto);
    Task<IntervenantDTO> UpdateIntervenant(int id, IntervenantDTO intervenantDto);
    Task DeleteIntervenant(int id);
}

public class IntervenantService : IIntervenantService
{

    private readonly IIntervenantRepository _IntervenantRepository;

    public IntervenantService(IIntervenantRepository IntervenantRepository)
    {
        _IntervenantRepository = IntervenantRepository;
    }

    public Task<IEnumerable<IntervenantDTO>> GetAllIntervenants()
    {
        var intervenants = _IntervenantRepository.GetAll();
        var dtos = intervenants.Select(i => new IntervenantDTO
        {
            Nom = i.Nom,
            Prenom = i.Prenom,
            Email = i.Email,
            Entreprise = i.Entreprise,
        });
        return Task.FromResult(dtos);
    }

    public Task<IntervenantDTO> GetIntervenantById(int id)
    {
        var intervenant = _IntervenantRepository.GetById(id);
        if (intervenant == null)
        {
            throw new KeyNotFoundException($"Intervenant with id {id} not found.");
        }
        var dto = new IntervenantDTO
        {
            Nom = intervenant.Nom,
            Prenom = intervenant.Prenom,
            Email = intervenant.Email,
            Entreprise = intervenant.Entreprise,
        };
        return Task.FromResult(dto);
    }

    public Task<IntervenantDTO> CreateIntervenant(IntervenantDTO intervenantDto)
    {
        var intervenant = new Intervenant
        {
            Nom = intervenantDto.Nom,
            Prenom = intervenantDto.Prenom,
            Email = intervenantDto.Email,
            Entreprise = intervenantDto.Entreprise,
        };
        _IntervenantRepository.Add(intervenant);
        return Task.FromResult(intervenantDto);
    }

    public Task<IntervenantDTO> UpdateIntervenant(int id, IntervenantDTO intervenantDto)
    {
        var intervenant = _IntervenantRepository.GetById(id);
        if (intervenant == null)
        {
            throw new KeyNotFoundException($"Intervenant with id {id} not found.");
        }
        intervenant.Nom = intervenantDto.Nom;
        intervenant.Prenom = intervenantDto.Prenom;
        intervenant.Email = intervenantDto.Email;
        intervenant.Entreprise = intervenantDto.Entreprise;

        _IntervenantRepository.Update(intervenant);
        return Task.FromResult(intervenantDto);
    }

    public Task DeleteIntervenant(int id)
    {
        var intervenant = _IntervenantRepository.GetById(id);
        if (intervenant == null)
        {
            throw new KeyNotFoundException($"Intervenant with id {id} not found.");
        }

        _IntervenantRepository.Remove(intervenant);
        return Task.CompletedTask;
    }
}