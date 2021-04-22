using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization;
using Api.Collections;

namespace Api.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; }
        public MongoDB(IConfiguration configutarion)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configutarion["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configutarion["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possivel conectar ao MongoDB", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);
            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
            {
                BsonClassMap.RegisterClassMap<Infectado>(i =>
                    {
                        i.AutoMap();
                        i.SetIgnoreExtraElements(true);
                    });
            }
        }
    }
}
