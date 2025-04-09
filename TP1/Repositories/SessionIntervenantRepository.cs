using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;

public interface ISessionIntervenantRepository : IRepository<SessionIntervenant>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<SessionIntervenant> GetSessionIntervenantsByCategory(int categoryId);
}
public class SessionIntervenantRepository : Repository<SessionIntervenant>, ISessionIntervenantRepository
{
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public SessionIntervenantRepository(AppDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<SessionIntervenant> GetSessionIntervenantsByCategory(int categoryId) {
    //     return AppDbContext.SessionIntervenants
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}