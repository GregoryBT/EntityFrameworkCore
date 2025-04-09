public interface ISalleRepository : IRepository<Salle>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Salle> GetSallesByCategory(int categoryId);
}
public class SalleRepository : Repository<Salle>, ISalleRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public SalleRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Salle> GetSallesByCategory(int categoryId) {
    //     return AppDbContext.Salles
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}