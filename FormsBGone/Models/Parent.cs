namespace FormsBGone.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        // Relationships
        public ICollection<Student> Students { get; set; }
    }
}
