using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public class SyncService<T> : ISyncService<T> where T : MongoDocument
    {
        public HttpResponseMessage Delete(T record)
        {
            
        }

        public HttpResponseMessage Upsert(T record)
        {
            
        }
    }
}
