using TP1.Models;
using TP1.Data;

namespace TP1.Repositories;

public interface IParticipantRepository : IRepository<Participant>
{
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple : IEnumerable<Participant> GetParticipantsByCategory(int categoryId);
}
public class ParticipantRepository : Repository<Participant>, IParticipantRepository
{
    // Référence typée au contexte
    private AppDbContext AppDbContext => (AppDbContext)_context;
    // Constructeur
    public ParticipantRepository(AppDbContext context) : base(context) { }
    /// Ajouter les méthodes spécifiques au produit ici
    /// Exemple :
    // public IEnumerable<Participant> GetParticipantsByCategory(int categoryId) {
    //     return AppDbContext.Participants
    //         .Where(p => p.CategoryId == categoryId)
    //         .ToList();
    // }
}