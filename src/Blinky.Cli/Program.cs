using System;
using System.Device.Gpio;
using System.Threading;
using Blinky.Cli.Utils;

const int pin = 18;

int lightTime = Input.ReadInt("Enter light time (in ms): ", 100, 10000);
int dimTime = Input.ReadInt("Enter dim time (in ms): ", 100, 10000);

using GpioController controller = new();
controller.OpenPin(pin, PinMode.Output);
Console.WriteLine($"GPIO pin enabled: {pin}");

while (true)
{
    Console.WriteLine($"Light for {lightTime}ms");
    controller.Write(pin, PinValue.High);
    Thread.Sleep(TimeSpan.FromMilliseconds(lightTime));

    Console.WriteLine($"Dim for {dimTime}ms");
    controller.Write(pin, PinValue.Low);
    Thread.Sleep(TimeSpan.FromMilliseconds(dimTime));
}
