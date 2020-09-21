using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedLibraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Uppgift4.Services
{
    public static class DeviceService
    {


        private static readonly Random rnd = new Random();



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

