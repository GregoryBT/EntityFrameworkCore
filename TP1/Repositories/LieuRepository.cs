using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;

public interface ILieuRepository : IRepository<Lieu>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Lieu> GetLieuxByCategory(int categoryId);
}
public class LieuRepository : Repository<Lieu>, ILieuRepository
{
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public LieuRepository(AppDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Lieu> GetLieuxByCategory(int categoryId) {
    //     return AppDbContext.Lieux
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}