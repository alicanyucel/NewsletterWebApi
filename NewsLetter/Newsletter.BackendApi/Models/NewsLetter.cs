namespace Newsletter.BackendApi.Models
{
    public class NewsLetter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
