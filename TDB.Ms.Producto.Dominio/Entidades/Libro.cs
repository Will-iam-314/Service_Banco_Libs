using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOFL.Libro.Dominio.Entidades
{
    [BsonIgnoreExtraElements]
    public class Libro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int idLibro { get; set; }

        public int isbn { get; set; }

        public int lib_volumen { get; set; }

        public int lib_stock { get; set; }

        public string lib_titulo { get; set; }

        public int idEditorial { get; set; }
        
        public int idAutor { get; set; }
    }
}
