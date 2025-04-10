using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface IIntervenantService
{
}

public class IntervenantService : IIntervenantService
{

    private readonly IIntervenantRepository _IntervenantRepository;

    public IntervenantService(IIntervenantRepository IntervenantRepository)
    {
        _IntervenantRepository = IntervenantRepository;
    }
}