using GeekShopping.ProductAPI.Data.DTO;

namespace GeekShopping.ProductAPI.Repository
{
	public interface IProductRepository
	{
		Task<IEnumerable<ProductDTO>> FindAll();

		Task<ProductDTO> FindById(long id);

		Task<ProductDTO> Create(ProductDTO productDto);
		Task<ProductDTO> Update(ProductDTO productDto);

		Task<bool> Delete(long id);
	}
}
