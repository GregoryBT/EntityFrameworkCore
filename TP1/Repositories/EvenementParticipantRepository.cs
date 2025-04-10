using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;
public interface IEvenementParticipantRepository : IRepository<EvenementParticipant>
{
    IEnumerable<EvenementParticipant> GetEvenementsParticipantByParticipantId(int participantId);
    IEnumerable<EvenementParticipant> GetEvenementsParticipantByEvenementId(int evenementId);
}
public class EvenementParticipantRepository : Repository<EvenementParticipant>, IEvenementParticipantRepository
{
    // Référence typée au contexte
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public EvenementParticipantRepository(AppDbContext context) : base(context) { }

    public IEnumerable<EvenementParticipant> GetEvenementsParticipantByParticipantId(int participantId)
    {
        return AppDbContext.EvenementParticipants
            .Where(ep => ep.ParticipantId == participantId)
            .ToList();
    }
    public IEnumerable<EvenementParticipant> GetEvenementsParticipantByEvenementId(int evenementId)
    {
        return AppDbContext.EvenementParticipants
            .Where(ep => ep.EvenementId == evenementId)
            .ToList();
    }
}
