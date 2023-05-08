namespace todolist.Models
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public TodoTask()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}
