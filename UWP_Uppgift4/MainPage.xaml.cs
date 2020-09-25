using Microsoft.Azure.Devices.Client;
using SharedLibraries.Models;
using SharedLibraries.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Uppgift4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {

            this.InitializeComponent();

        }

        private static readonly string _conn = "HostName=EC-iothub.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=Wpp+e1YG/15ffM0XYiK61eeSSVT6ltskDc97X7EktEk=";

        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(_conn, TransportType.Mqtt);

       

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
        }
    }
}
