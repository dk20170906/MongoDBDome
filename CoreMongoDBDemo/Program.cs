using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CoreMongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new MongoClient("mongodb://localhost:27017");
            //// 制定多个地址和端口，让程序自动选择一个进行连接。  
            ////var client = new MongoClient("mongodb://localhost:27017,localhost:27018,localhost:27019");

            //var data = client.GetDatabase("Demo");



            //var collection = data.GetCollection<BsonDocument>("Test1");

            //var doc = new BsonDocument() {
            //    { "name","mongoDB"},
            //    { "user","lixin"},
            //    { "use","demo"},
            //    { "info",new BsonDocument
            //    {
            //        { "test1","Add" },
            //        { "test2","update" },
            //        { "test3","delete" },
            //        { "test4","select" }
            //    }
            //    }
            //};
            //collection.InsertOne(doc);
            ////await collection.InsertOneAsync(doc);

            ////Console.WriteLine(collection);
            //Console.WriteLine();
            ////Console.ReadKey();
            Console.WriteLine(GetDis());
            Console.ReadKey();
        }
        private async Task TaskInsert(IMongoCollection<BsonDocument> client, BsonDocument doc)
        {
            await client.InsertOneAsync(doc);
        }

        private static double GetDis()
        {
            double a = GetDistance(120.32423625806, 30.207319937514, 120.4784335949, 30.255695855487);
            double b = GetDistance(120.4784335949, 30.255695855487, 120.47284997775, 30.227721540309);
            double c = GetDistance(120.47284997775, 30.227721540309, 120.58341789001, 30.169128944673);
            double d = GetDistance(120.58341789001, 30.169128944673, 120.56219919363, 30.182942195818);
            double e = GetDistance(120.56219919363, 30.182942195818, 120.54760601206, 30.170069220548);
            double f = GetDistance(120.54760601206, 30.170069220548, 120.53375126393, 30.175986811542);
            double g = GetDistance(120.53375126393, 30.175986811542, 120.57394427033, 30.183065091992);
            double h = GetDistance(120.57394427033, 30.183065091992, 120.52523942001, 30.16435175241);
            double i = GetDistance(120.52523942001, 30.16435175241, 120.50506098481, 30.18280060022);
            double j = GetDistance(120.50506098481, 30.18280060022, 120.51664729607, 30.211927173485);
            double k = GetDistance(120.51664729607, 30.211927173485, 120.32425518649, 30.207293100805);
            double l = GetDistance(120.32425518649, 30.207293100805, 120.3242054533, 30.207313774493);
            return (a + b + c + d + e + f + g + h + i + j + k + l) / 1000;
        }


        //地球半径，单位米
        private const double EARTH_RADIUS = 6378137;
        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }
    }
}
