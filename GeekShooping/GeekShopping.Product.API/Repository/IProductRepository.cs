using GeekShopping.Product.API.DTO;

namespace GeekShopping.Product.API.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> FindAllAsync();
        Task<ProductDTO> FindByIdAsync(long id);
        Task<ProductDTO> CreateAsync(ProductDTO productDTO);
        Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
        Task<bool> DeleteAsync(long id);
    }
}
