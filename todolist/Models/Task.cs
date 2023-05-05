namespace todolist.Models
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime CompletionDate { get; private set; }
    }
}
