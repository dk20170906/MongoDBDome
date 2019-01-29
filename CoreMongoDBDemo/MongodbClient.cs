using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMongoDBDemo
{
    public class MongodbClient
    {
        public void Test()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            // 制定多个地址和端口，让程序自动选择一个进行连接。  
            //var client = new MongoClient("mongodb://localhost:27017,localhost:27018,localhost:27019");

            var data = client.GetDatabase("local");



            var collection = data.GetCollection<BsonDocument>("startup_log");

        }
    }
}
