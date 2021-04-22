using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Collections
{
    public class Infectado
    {
        public Infectado(DateTime dataNascimento,int idade, string sexo, double latitute, double longitude) 
        {
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Localizacao = new GeoJson2DGeographicCoordinates(latitute, longitude);
            Idade = idade;
        }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}
