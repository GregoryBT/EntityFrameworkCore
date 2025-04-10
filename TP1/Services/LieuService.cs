using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface ILieuService
{
}

public class LieuService : ILieuService
{

    private readonly ILieuRepository _LieuRepository;

    public LieuService(ILieuRepository LieuRepository)
    {
        _LieuRepository = LieuRepository;
    }
}