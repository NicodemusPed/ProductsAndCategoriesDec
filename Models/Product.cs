#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategoriesDec.Models;

public class Product
{

    [Key]

    public int ProductId { get; set; }

    [Required (ErrorMessage = "Name is required.")]
    [Display (Name = "Name:")]
    public string Name { get; set; }

    [Required (ErrorMessage = "Description is required.")]
    [Display (Name = "Description:")]
    public string Description { get; set; }

    [Required (ErrorMessage = "Price is required.")]
    [DataType (DataType.Currency)]
    [Display (Name = "Price:")]
    public Decimal Price { get; set; }

    public List<Association> AssociatedCategories { get; set; } = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

