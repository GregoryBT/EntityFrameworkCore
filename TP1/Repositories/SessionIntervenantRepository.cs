using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;

public interface ISessionIntervenantRepository : IRepository<SessionIntervenant>
{
    IEnumerable<SessionIntervenant> GetSessionIntervenantsBySessionId(int sessionId);
    IEnumerable<SessionIntervenant> GetSessionIntervenantsByIntervenantId(int intervenantId);
}
public class SessionIntervenantRepository : Repository<SessionIntervenant>, ISessionIntervenantRepository
{
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public SessionIntervenantRepository(AppDbContext context) : base(context) { }

    public IEnumerable<SessionIntervenant> GetSessionIntervenantsBySessionId(int sessionId)
    {
        return AppDbContext.SessionIntervenants
            .Where(si => si.SessionId == sessionId)
            .ToList();
    }
    public IEnumerable<SessionIntervenant> GetSessionIntervenantsByIntervenantId(int intervenantId)
    {
        return AppDbContext.SessionIntervenants
            .Where(si => si.IntervenantId == intervenantId)
            .ToList();
    }
}