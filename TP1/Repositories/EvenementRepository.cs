public interface IEvenementRepository : IRepository<Evenement>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Evenement> GetEvenementsByCategory(int categoryId);
}
public class EvenementRepository : Repository<Evenement>, IEvenementRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public EvenementRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Evenement> GetEvenementsByCategory(int categoryId) {
    //     return AppDbContext.Evenements
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}