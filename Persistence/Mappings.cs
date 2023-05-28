using API_Application_1.Model;
using MongoDB.Bson.Serialization; 

namespace MongoDB.GenericRepository.Persistence
{
    public class ProductMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Description).SetIsRequired(true);
            });
        }
    }

    public class MessageMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Message>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Text).SetIsRequired(true);
            });
        }
    }
}