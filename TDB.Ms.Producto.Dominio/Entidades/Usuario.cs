using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace BK.Usuario.Dominio.Entidades
{
    [CollectionProperty("Usuario")] //check 
    [BsonIgnoreExtraElements]
    public class Usuario : EntityToLower<ObjectId>
    {        
        public int idUsuario { get; set; }
        public string userName { get; set; }
        public int password { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string estado { get; set; }
        public int idRol { get; set; }
    }
}
