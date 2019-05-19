using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TcpClient
{
    class Model
    {
        public bool Pump1State { get; set; }
        public bool Pump2State { get; set; }
        public bool Pump3State { get; set; }
        public bool Pump4State { get; set; }
        public bool WaterLevelSensor1State { get; set; }
        public bool WaterLevelSensor2State { get; set; }
        public bool WaterLevelSensor3State { get; set; }
        public bool WaterLevelSensor4State { get; set; }
    }
    class Program
    {
        private const string Url = "https://localhost:5001/api/data";

        
        
        static void Main(string[] args)
        {
            int i = 0;
           
            while (true)
            {
                Model obj = new Model
                {
                    Pump1State = i%2==0?true:false,
                    Pump2State = false,
                    Pump3State = false,
                    Pump4State = false,
                    WaterLevelSensor1State = true,
                    WaterLevelSensor2State = true,
                    WaterLevelSensor3State = false,
                    WaterLevelSensor4State = false
                };
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                JsonSerializer serializer = new JsonSerializer();

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(writer, obj);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result.ToString());
                }
                Thread.Sleep(2000);
                i++;
            }
            
        }
    }
}