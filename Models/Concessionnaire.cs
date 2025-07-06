namespace ConcessionnaireAPI.Models
{
    public class Concessionnaire
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public DateTime  DateOuverture { get; set; }

    }
}
