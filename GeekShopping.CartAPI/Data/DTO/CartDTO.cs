using System.Collections.Generic;

namespace GeekShopping.CartAPI.Data.DTO

{
    public class CartDTO
    {
        public CartHeaderDTO CartHeader { get; set; }

        public IEnumerable<CartDetailsDTO> CardDetails { get; set; }

    }
}
