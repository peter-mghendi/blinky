using System;
using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;
using Blinky.Cli.Utils;

namespace Blinky.Cli.Modes
{

    public class PulseMode : IMode
    {
        public void Start(GpioController controller, int pin)
        {
            int lightTime = Input.ReadInt("Enter light time (in ms): ", 100, 10000);
            int dimTime = Input.ReadInt("Enter dim time (in ms): ", 100, 10000);

            while (true)
            {
                Console.WriteLine($"Light for {lightTime}ms");
                controller.Write(pin, PinValue.High);
                Thread.Sleep(TimeSpan.FromMilliseconds(lightTime));

                Console.WriteLine($"Dim for {dimTime}ms");
                controller.Write(pin, PinValue.Low);
                Thread.Sleep(TimeSpan.FromMilliseconds(dimTime));
            }
        }
    }
}