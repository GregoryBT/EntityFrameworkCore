public interface IEvenementParticipantParticipantRepository : IRepository<EvenementParticipant>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<EvenementParticipant> GetEvenementParticipantsByCategory(int categoryId);
}
public class EvenementParticipantRepository : Repository<EvenementParticipant>, IEvenementParticipantParticipantRepository {
    // Référence typée au contexte
    private ApplicationDbContext AppDbContext => (ApplicationDbContext) _context;
    // Constructeur
    public EvenementParticipantRepository(ApplicationDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<EvenementParticipant> GetEvenementParticipantsByCategory(int categoryId) {
    //     return AppDbContext.EvenementParticipants
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}