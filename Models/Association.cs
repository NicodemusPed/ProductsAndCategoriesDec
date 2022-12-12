#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategoriesDec.Models;

public class Association
{

    [Key] // Primary Key

    public int AssociationId { get; set; }

    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public Product Product  {get;set;}
    public Categories Category  {get;set;}
}
