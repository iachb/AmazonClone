using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain
{
    public class OrderItem : BaseDomainModel
    {
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string? Quantity { get; set; }
        public string? Order {  get; set; }
        public int OrderId { get; set; }
        public int ProductItemId { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
