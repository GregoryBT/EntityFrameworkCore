namespace TP1.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public string? Salle { get; set; }

        // Relations
        public int EvenementId { get; set; }
        public Evenement? Evenement { get; set; }
        public List<Participant>? Participants { get; set; } = new List<Participant>();
    }
}
