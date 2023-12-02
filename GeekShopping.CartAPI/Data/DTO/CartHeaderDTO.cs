using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Data.DTO
{
    public class CartHeaderDTO : BaseEntity
    {
        public string UserId { get; set; }

        public string CuoponCode { get;set; }
    }
}
