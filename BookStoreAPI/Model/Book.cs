using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Model
{
    public class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo título deve ser preenchido.")]
        public string? Title { get; set; }
        public string? Author { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Price { get; set; }

    }
}
