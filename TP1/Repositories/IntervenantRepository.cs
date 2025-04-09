public interface IIntervenantRepository : IRepository<Intervenant>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Intervenant> GetIntervenantsByCategory(int categoryId);
}
public class IntervenantRepository : Repository<Intervenant>, IIntervenantRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public IntervenantRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Intervenant> GetIntervenantsByCategory(int categoryId) {
    //     return AppDbContext.Intervenants
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}