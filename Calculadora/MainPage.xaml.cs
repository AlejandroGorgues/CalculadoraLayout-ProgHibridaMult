using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Calculadora
{

    public sealed partial class MainPage : Page
    {
        private SimpleOrientationSensor sensor;

        public MainPage()
        {
            this.InitializeComponent();

            sensor = SimpleOrientationSensor.GetDefault();
            sensor.OrientationChanged += Sensor_OrientationChanged;
        }

        private async void Sensor_OrientationChanged(SimpleOrientationSensor sender, SimpleOrientationSensorOrientationChangedEventArgs args)
        {
            SimpleOrientation orientation = args.Orientation;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Switch the placement of the buttons based on an orientation change.
                if (SimpleOrientation.NotRotated == orientation)
                {
                    Panel1.Visibility = Visibility.Collapsed;
                    Panel2.Visibility = Visibility.Collapsed;
                    Panel3.Visibility = Visibility.Collapsed;
                }
                // If not in portrait, move buttonList content to visible row and column.
                else
                {
                    Panel1.Visibility = Visibility.Visible;
                    Panel2.Visibility = Visibility.Visible;
                    Panel3.Visibility = Visibility.Visible;
                }
            });
        }

    }
}
