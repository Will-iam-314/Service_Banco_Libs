using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace BK.Usuario.Dominio.Entidades
{
    [CollectionProperty("Rol")]
    [BsonIgnoreExtraElements]
    public class Rol : EntityToLower<ObjectId>
    {
        public int idRol { get; set; }
        public string descripcion { get; set; }
    }
}
