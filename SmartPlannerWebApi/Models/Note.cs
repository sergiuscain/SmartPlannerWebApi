namespace SmartPlannerWebApi.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate
        {
            get; set;
        }
    }
}
