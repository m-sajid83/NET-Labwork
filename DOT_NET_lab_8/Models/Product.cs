using System.ComponentModel.DataAnnotations;

namespace InventoryManagementNet6.Models;

public class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Enter product name.")]
    [StringLength(100)]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; } = "";

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be zero or more.")]
    public int Quantity { get; set; }

    [Range(typeof(decimal), "0", "99999999.99", ErrorMessage = "Enter a valid price.")]
    public decimal Price { get; set; }
}
