using SQLite.Net.Attributes;

namespace FreshQuiz.Models
{
    [Table(nameof(Examine))]
    public class Examine
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [NotNull, MaxLength(250)]
        public string Name { get; set; }
        [Indexed]
        public int QuestionId { get; set; }

    }
}
