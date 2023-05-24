using Midway.Gleybe.Domain.Entities;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midway.Gleybe.Infrastructure.Mapping
{
    public static class ClassMapping
    {
        public static void Map()
        {
            if(!BsonClassMap.IsClassMapRegistered(typeof(Contact)))
            {
                BsonClassMap.RegisterClassMap<Contact>(q =>
                {
                    q.AutoMap();
                    q.MapIdMember(q => q._Id);
                    q.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
