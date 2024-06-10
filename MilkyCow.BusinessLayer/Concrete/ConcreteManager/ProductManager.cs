using AutoMapper;
using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.BusinessLayer.Abstract.IServiceManager;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        //private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly Lazy<IServiceManager> _serviceManager;

        public ProductManager(IProductDal productDal, IMapper mapper, Lazy<IServiceManager> serviceManager)
        {
            _productDal = productDal;

            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        #region Create Product
        public string CreateProduct(CreateProductDto createProductDto)
        {
            var categories = _serviceManager.Value.CategoryService.GetAll();
            var category = categories.FirstOrDefault(c => c.CategoryId.Equals(createProductDto.CategoryId));

            if (category == null)
            {
                return "Invalid Category.";
            }

            var product = _mapper.Map<Product>(createProductDto);
            product.CategoryId = category.CategoryId;

            Add(product);

            return "Product added.";
        }
        #endregion

        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public int GetProductCount()
        {
            return _productDal.GetProductCount();
        }

        public List<Product> GetProductWithCategory()
        {
            return _productDal.GetProductWithCategory();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}