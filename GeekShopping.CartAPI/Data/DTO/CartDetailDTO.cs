using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Data.DTO
{
    public class CartDetailsDTO
    {
        public long Id { get; set; }

        public long CartHeaderId { get; set; }

        public CartHeaderDTO CartHeader { get; set; }

        public long ProductId { get; set; }

        public ProductDTO Product { get; set; }

        public int Count { get; set; }
    }
}
