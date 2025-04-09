public interface ISessionRepository : IRepository<Session>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Session> GetSessionsByCategory(int categoryId);
}
public class SessionRepository : Repository<Session>, ISessionRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public SessionRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Session> GetSessionsByCategory(int categoryId) {
    //     return AppDbContext.Sessions
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}