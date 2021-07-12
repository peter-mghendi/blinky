using System;
using System.Device.Gpio;
using Blinky.Cli.Modes;

const int pin = 18;

using GpioController controller = new();
controller.OpenPin(pin, PinMode.Output);
Console.WriteLine($"GPIO pin enabled: {pin}");

IMode pulseMode = new PulseMode();
pulseMode.Start(controller, pin);
