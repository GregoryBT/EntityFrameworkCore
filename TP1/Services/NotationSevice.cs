using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface INotationService
{
}

public class NotationService : INotationService
{

    private readonly INotationRepository _NotationRepository;

    public NotationService(INotationRepository NotationRepository)
    {
        _NotationRepository = NotationRepository;
    }
}