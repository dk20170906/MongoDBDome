using MongoDB.Driver;
using MongoDBDemo.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDemo
{
    class Program
    {
        static MongodbHost host = new MongodbHost()
        {
            Connection= "mongodb://localhost:27017",
            DataBase="Dome",
            Table= "Phone"
        };
        static void Main(string[] args)
        {
            Mothed();
        }

        private static void Mothed()
        {
            //1.批量修改,修改的条件
            var time = DateTime.Now;
            var list = new List<FilterDefinition<PhoneEntity>>();
            list.Add(Builders<PhoneEntity>.Filter.Lt("AddTime", time.AddDays(5)));
            list.Add(Builders<PhoneEntity>.Filter.Gt("AddTime", time));
            var filter = Builders<PhoneEntity>.Filter.And(list);

            //2.要修改的字段内容
            var dic = new Dictionary<string, string>();
            dic.Add("UseAge", "168");
            dic.Add("Name", "朝阳");
            //3.批量修改
            var kk = TMongodbHelper<PhoneEntity>.UpdateManay(host, dic, filter);
        }
        private static void Mothed1()
        {
            //根据条件查询集合
            var time = DateTime.Now;
            var list = new List<FilterDefinition<PhoneEntity>>();
            list.Add(Builders<PhoneEntity>.Filter.Lt("AddTime", time.AddDays(20)));
            list.Add(Builders<PhoneEntity>.Filter.Gt("AddTime", time));
            var filter = Builders<PhoneEntity>.Filter.And(list);
            //2.查询字段
            var field = new[] { "Name", "Price", "AddTime" };
            //3.排序字段
            var sort = Builders<PhoneEntity>.Sort.Descending("AddTime");
            var res = TMongodbHelper<PhoneEntity>.FindList(host, filter, field, sort);
        }
        private static void Mothed2()
        {
            //分页查询，查询条件
            var time = DateTime.Now;
            var list = new List<FilterDefinition<PhoneEntity>>();
            list.Add(Builders<PhoneEntity>.Filter.Lt("AddTime", time.AddDays(400)));
            list.Add(Builders<PhoneEntity>.Filter.Gt("AddTime", time));
            var filter = Builders<PhoneEntity>.Filter.And(list);
            long count = 0;
            //排序条件
            var sort = Builders<PhoneEntity>.Sort.Descending("AddTime");
            var res = TMongodbHelper<PhoneEntity>.FindListByPage(host, filter, 2, 10, out count, null, sort);
        }


        public class PhoneEntity
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public DateTime AddTime { get; set; }
        }
    }
}
