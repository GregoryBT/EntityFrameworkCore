namespace TP1.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telephone { get; set; }

        // Relations
        public List<Session>? Sessions { get; set; } = new List<Session>();
    }
}
