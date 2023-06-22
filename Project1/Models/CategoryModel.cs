using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class CategoryModel
    {
        public static int DEFAULT_CATEGORY_ID = 7;

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public CategoryModel() { }

        public CategoryModel(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public CategoryModel(string name)
        {
            Name = name;
        }
    }
}
