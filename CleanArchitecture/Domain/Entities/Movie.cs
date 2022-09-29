namespace Domain.Entities
{
    public class Movie : BaseEntity<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}