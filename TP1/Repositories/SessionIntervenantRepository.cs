public interface ISessionIntervenantRepository : IRepository<SessionIntervenant>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<SessionIntervenant> GetSessionIntervenantsByCategory(int categoryId);
}
public class SessionIntervenantRepository : Repository<SessionIntervenant>, ISessionIntervenantRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public SessionIntervenantRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<SessionIntervenant> GetSessionIntervenantsByCategory(int categoryId) {
    //     return AppDbContext.SessionIntervenants
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}