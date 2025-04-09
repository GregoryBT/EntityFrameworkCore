using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;

public interface INotationRepository : IRepository<Notation>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Notation> GetNotationsByCategory(int categoryId);
}
public class NotationRepository : Repository<Notation>, INotationRepository
{
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public NotationRepository(AppDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Notation> GetNotationsByCategory(int categoryId) {
    //     return AppDbContext.Notations
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}