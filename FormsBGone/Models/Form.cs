namespace FormsBGone.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime SubmissionDate { get; set; }

        // Relationships
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
