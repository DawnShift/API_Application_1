using API_Application_1.Model;
using MongoDB.GenericRepository.Interfaces; 
namespace MongoDB.GenericRepository.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }
    }
}
