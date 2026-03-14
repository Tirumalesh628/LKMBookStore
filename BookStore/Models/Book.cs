using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {

        public int BookID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public string? ImagePath { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public IFormFile? imagefile { get; set; }
        public int QuantityAvailable { get; set; }

        public int categoryId { get; set; }

        public Category category { get; set; }



    }
}
