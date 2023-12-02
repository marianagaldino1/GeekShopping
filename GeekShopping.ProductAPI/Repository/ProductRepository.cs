﻿using AutoMapper;
using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly MySqlContext _context;

		private IMapper _mapper;

		public ProductRepository( MySqlContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ProductDTO> FindById(long id)
		{
			Product product = 
				await _context.Products.Where(p => p.Id == id)
				.FirstOrDefaultAsync();
			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<ProductDTO> Update(ProductDTO productDto)
		{
			Product product = _mapper.Map<Product>(productDto);
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<ProductDTO> Create(ProductDTO productDto)
		{
			Product product = _mapper.Map<Product>(productDto);
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<bool> Delete(long id)
		{
			try
			{
				Product product =
				await _context.Products.Where(p => p.Id == id)
				.FirstOrDefaultAsync();

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
				throw new Exception();
			}
		}

		public async Task<IEnumerable<ProductDTO>> FindAll()
		{
			List<Product> products = await _context.Products.ToListAsync();

			return _mapper.Map<List<ProductDTO>>(products);
		}


	}
}
