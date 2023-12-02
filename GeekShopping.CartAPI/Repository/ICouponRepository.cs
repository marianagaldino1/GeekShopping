using GeekShopping.CartAPI.Data.ValueObjects;
using System.Threading.Tasks;

namespace GeekShopping.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode, string token); 
    }
}
