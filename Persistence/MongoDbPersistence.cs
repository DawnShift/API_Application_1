﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.GenericRepository.Persistence
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            ProductMap.Configure();
            MessageMap.Configure();
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            // BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
