using API_Application_1.Interfaces;
using API_Application_1.Model;
using MongoDB.GenericRepository.Interfaces;
using MongoDB.GenericRepository.Repository;

namespace API_Application_1.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    { 
        public MessageRepository(IMongoContext context) : base(context)
        { 
        }
    }
}
