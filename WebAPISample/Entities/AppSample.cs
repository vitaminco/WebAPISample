namespace WebAPISample.Entities
{
    public class AppSample
    {
        public AppSample()
        {
            appExamples = new HashSet<AppExample>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //1 Sample có nhiều Example
        public ICollection<AppExample> appExamples { get; set; }
    }
}
