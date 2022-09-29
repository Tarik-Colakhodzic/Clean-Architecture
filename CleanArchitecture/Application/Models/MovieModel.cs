namespace Application.Models
{
    public class MovieModel : BaseModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}