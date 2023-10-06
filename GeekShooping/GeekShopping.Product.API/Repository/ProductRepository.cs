using AutoMapper;
using GeekShopping.Product.API.DTO;
using GeekShopping.Product.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> FindAllAsync()
        {
            List<Model.Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindByIdAsync(long id)
        {
            Model.Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO productDTO)
        {
            Model.Product product = _mapper.Map<Model.Product>(productDTO);

            _context.Products?.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
        {
            Model.Product product = _mapper.Map<Model.Product>(productDTO);

            _context.Products?.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                Model.Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (product == null)
                {
                    return false;
                }
                else
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
