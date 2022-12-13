#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategoriesDec.Models;

public class Category
{

    [Key] // Primary Key

    public int CategoryId { get; set; }

    [Required (ErrorMessage = "Name is required.")]
    [Display (Name = "Name:")]
    public string Name { get; set; }

    public List<Association> AssociatedProducts { get; set; } = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



}

