using TP1.Repositories;
using TP1.DTOs;
using TP1.Models;

namespace TP1.Services;

public interface IParticipantService
{
}

public class ParticipantService : IParticipantService
{

    private readonly IParticipantRepository _ParticipantRepository;

    public ParticipantService(IParticipantRepository ParticipantRepository)
    {
        _ParticipantRepository = ParticipantRepository;
    }
}