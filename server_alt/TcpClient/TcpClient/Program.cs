using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;

namespace TcpClient
{
    public class Model
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
        public static System.Timers.Timer timy = new System.Timers.Timer(1800); 
        static byte[] buffers;
        private static System.Net.Sockets.TcpClient client;
        static IAsyncResult result;
        
        private const string Url = "https://localhost:5001/api/data";
        public static int index = 0;
        public static bool[] pumpStates = new bool[] {false, false, false, false};
        public static byte[] command = new byte[16];

        private static System.Timers.Timer aTimer = new System.Timers.Timer();

        static Model state = new Model
        {
            Pump1State = false,
            Pump2State = false,
            Pump3State = false,
            Pump4State = false,
            WaterLevelSensor1State = false,
            WaterLevelSensor2State = false,
            WaterLevelSensor3State = false,
            WaterLevelSensor4State = false
        };


        static void Main(string[] args)
        {
            tcp_listener();
            
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            client.Close();
        }

        public static void tcp_listener()
        {
            try
            {
                Int32 port = 2000;
                IPAddress localAddr = IPAddress.Parse("192.168.0.142");

                TcpListener server = new TcpListener(localAddr, port);

                
                server.Start();

                Byte[] bytes = new Byte[16];
                String data = null;

                Boolean inaltime = false;
                
                
                aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval=1000;
                aTimer.Enabled=true;
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    System.Net.Sockets.TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    //timy.Enabled = true;
                    data = null;

                    NetworkStream stream = client.GetStream();

                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        Restart:
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);       
                        Console.WriteLine(String.Format("Received: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",bytes[0],
                        bytes[1],bytes[2],bytes[3],bytes[4],bytes[5],bytes[6],bytes[7],bytes[8],bytes[9]));
                        byte[] msg = new byte[16];
                        msg[0] = bytes[0];
                        msg[1] = bytes[8];

                        byte sensorStateB1 = (byte) (msg[0] & 01000000);
                        byte sensorStateB2 = (byte) (msg[0] & 10000000);
                        byte sensorStateB3 = (byte) (msg[1] & 00000001);
                        byte sensorStateB4 = (byte) (msg[1] & 00000010);

                        /*Console.WriteLine("B1" + sensorStateB1.ToString());
                        Console.WriteLine("B2" + sensorStateB2.ToString());
                        Console.WriteLine("B3" + sensorStateB3.ToString());
                        Console.WriteLine("B4" + sensorStateB4.ToString());*/
                        

                        state.WaterLevelSensor1State = sensorStateB1 > 0;
                        state.WaterLevelSensor2State = sensorStateB2 > 0;
                        state.WaterLevelSensor3State = sensorStateB3 > 0;
                        state.WaterLevelSensor4State = sensorStateB4 > 0;
                        
                        stream.Write(command, 0, msg.Length);                       
                    
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }          

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        } 
        
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            SendHttpPost(state, Url);
            updateCommand();
        }


          public static void updateCommand()
          {
              if (state.WaterLevelSensor3State == true)
              {
                  command[0] &= 0;
              }
              else
              {
                  if (state.WaterLevelSensor1State == true)
                  {
                      command[0] |= 32;
                  }
                  if (index > 3) index = 3;
                  if (index < 0) index = 0;

                  if (state.WaterLevelSensor2State == false)
                  {
                      if (index > 3) index = 3;
                      pumpStates[index] = true;
                      index++;
                  }
                  if (state.WaterLevelSensor2State == true)
                  {
                      if (index < 0) index = 0;
                      pumpStates[index] = false;
                      index--;
                  }
              
              

                  if (pumpStates[0] == true)
                  {
                      state.Pump1State = true;
                      command[0] |= 1;
                  }
                  else
                  {
                      state.Pump1State = false;
                      command[0] &= 254;
                  }
              
              
                  if (pumpStates[1] == true)
                  {
                      state.Pump2State = true;
                      command[0] |= 2;
                  }
                  else
                  {
                      state.Pump2State = false;
                      command[0] &= 253;
                  }
              
              
                  if (pumpStates[2] == true)
                  {
                      state.Pump3State = true;
                      command[0] |= 4;
                  }
                  else
                  {
                      state.Pump3State = false;
                      command[0] &= 251;
                  }
              
              
                  if (pumpStates[3] == true)
                  {
                      state.Pump4State = true;
                      command[0] |= 8;
                  }
                  else
                  {
                      state.Pump4State = false;
                      command[0] &= 247;
                  }
              }
          }
        
          
        private static void SendHttpPost(Model model, string Url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            JsonSerializer serializer = new JsonSerializer();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, model);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result.ToString());
            }
        }
    }
}