using System;
using System.Device.Gpio;
using System.Threading;

const int pin = 18;

const int lightTime = 1000;
const int dimTime = 200;

using GpioController controller = new();
controller.OpenPin(pin, PinMode.Output);
Console.WriteLine($"GPIO pin enabled: {pin}");

while (true)
{
    Console.WriteLine($"Light for {lightTime}ms");
    controller.Write(pin, PinValue.High);
    Thread.Sleep(lightTime);

    Console.WriteLine($"Dim for {dimTime}ms");
    controller.Write(pin, PinValue.Low);
    Thread.Sleep(dimTime);
}
