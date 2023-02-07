using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK.Usuario.Infraestructura
{
    public interface IMongoDbContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoCollection<TDocument> GetCollection<TDocument>(string partitioKey = null);
        void DropCollection<TDocument>(string partitionKey = null);
        void SetGuidRepresentation(GuidRepresentation guidRepresentation);
        void Dispose();
    }
}
