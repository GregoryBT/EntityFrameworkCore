public interface INotationRepository : IRepository<Notation>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Notation> GetNotationsByCategory(int categoryId);
}
public class NotationRepository : Repository<Notation>, INotationRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public NotationRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Notation> GetNotationsByCategory(int categoryId) {
    //     return AppDbContext.Notations
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}