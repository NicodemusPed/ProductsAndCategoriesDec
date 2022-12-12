#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategoriesDec.Models;

public class Categories
{

    [Key] // Primary Key

    public int CategoryId { get; set; }

    [Required (ErrorMessage = "Name is required.")]
    [Display (Name = "Name:")]
    public string Name { get; set; }

    public List<Association> AssociatedProducts { get; set; } = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public class Association
    {
        [Key]
        public int AssociationId {get;set;}
        public int ProductId {get;set;}
        public int CategoryId {get;set;}
        public Product Product {get;set;}
        public Categories Category {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

}

