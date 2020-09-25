using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MAD = Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedLibraries.Models;

namespace SharedLibraries.Services
{
    public static class DeviceService
    {

        private static readonly Random rnd = new Random();


        // Device Client = IoT Device
        public static async Task ReceiveMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {
                var payload = await deviceClient.ReceiveAsync();

                if (payload == null)
                    continue;

                Console.WriteLine($"Message Received: {Encoding.UTF8.GetString(payload.GetBytes())}");

                await deviceClient.CompleteAsync(payload);
            }
        }

        // Device Client = IoT Service
        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            
                var data = new TemperatureModel
                {
                    Temperature = rnd.Next(20, 30),
                    Humidity = rnd.Next(40, 50)
                };



                //JSON = {"temperature": 20, "humidity": 44}
                var json = JsonConvert.SerializeObject(data);

                var payload = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(json));
                await deviceClient.SendEventAsync(payload);

                
            }
        }
}




