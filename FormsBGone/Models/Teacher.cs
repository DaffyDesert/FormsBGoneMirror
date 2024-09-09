namespace FormsBGone.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        // Relationships
        public ICollection<Form> Forms { get; set; }
    }
}
