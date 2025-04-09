using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;

public interface IIntervenantRepository : IRepository<Intervenant>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Intervenant> GetIntervenantsByCategory(int categoryId);
}
public class IntervenantRepository : Repository<Intervenant>, IIntervenantRepository
{
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public IntervenantRepository(AppDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Intervenant> GetIntervenantsByCategory(int categoryId) {
    //     return AppDbContext.Intervenants
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}