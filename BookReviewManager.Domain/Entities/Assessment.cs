namespace BookReviewManager.Domain.Entities
{
    public class Assessment : Base
    {
        public Assessment(int nota, string description, int userId, int bookId)
        {
            Nota = nota;
            Description = description;
            UserId = userId;
            BookId = bookId;
        }

        public int Nota { get; private set; }
        public string Description { get; set; }
        public int UserId { get; private set; }
        public virtual User? User { get; private set; }
        public int BookId { get; private set; }
        public virtual Book? Book { get; private set; }
        public DateTime AssessmentDate { get; private set; } = DateTime.Now;

    }
}