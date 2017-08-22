using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshQuiz.Models
{
    [Table(nameof(Question))]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [NotNull, MaxLength(250)]
        public string Contents{ get; set; }

        [NotNull, MaxLength(250)]
        public string Answe_1 { get; set; }

        [NotNull, MaxLength(250)]
        public string Answe_2 { get; set; }

        [NotNull, MaxLength(250)]
        public string Answe_3 { get; set; }

        public bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(Contents));
        }
    }
}
