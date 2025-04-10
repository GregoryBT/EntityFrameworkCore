using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ISalleService
{
}

public class SalleService : ISalleService
{

    private readonly ISalleRepository _SalleRepository;

    public SalleService(ISalleRepository SalleRepository)
    {
        _SalleRepository = SalleRepository;
    }
}