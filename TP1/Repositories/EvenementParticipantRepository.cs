using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;
public interface IEvenementParticipantRepository : IRepository<EvenementParticipant>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<EvenementParticipant> GetEvenementParticipantsByCategory(int categoryId);
}
public class EvenementParticipantRepository : Repository<EvenementParticipant>, IEvenementParticipantRepository
{
    // Référence typée au contexte
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public EvenementParticipantRepository(AppDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<EvenementParticipant> GetEvenementParticipantsByCategory(int categoryId) {
    //     return AppDbContext.EvenementParticipants
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}
