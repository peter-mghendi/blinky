using System.Threading;
using System;
using System.Device.Gpio;

namespace Blinky.Cli.Modes
{
    public class ToggleMode : IMode
    {
        private bool _isOn = false;

        public void Start(GpioController controller, int pin)
        {
            controller.Write(pin, PinValue.Low);

            while (true)
            {
                Console.WriteLine("Press enter to toggle the light");
                var keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter) 
                {
                    Console.WriteLine("Toggling light...");
                    _isOn = !_isOn;
                    controller.Write(pin, _isOn ? PinValue.High : PinValue.Low);
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                }
            }
        }
    }
}