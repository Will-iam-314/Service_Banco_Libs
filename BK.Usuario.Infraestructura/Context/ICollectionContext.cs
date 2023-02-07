using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK.Usuario.Infraestructura
{
    public interface ICollectionContext
    {
        IMongoCollection<BsonDocument> Context(string collectionName);
    }
}
