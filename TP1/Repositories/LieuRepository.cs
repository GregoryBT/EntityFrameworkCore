public interface ILieuRepository : IRepository<Lieu>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Lieu> GetLieuxByCategory(int categoryId);
}
public class LieuRepository : Repository<Lieu>, ILieuRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public LieuRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Lieu> GetLieuxByCategory(int categoryId) {
    //     return AppDbContext.Lieux
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}