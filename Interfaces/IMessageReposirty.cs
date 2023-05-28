using API_Application_1.Model;
using MongoDB.GenericRepository.Interfaces;

namespace API_Application_1.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
    }
}
