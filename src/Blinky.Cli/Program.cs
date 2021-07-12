using System;
using System.Device.Gpio;
using Blinky.Cli.Modes;
using Blinky.Cli.Utils;

const int pin = 18;

using GpioController controller = new();
controller.OpenPin(pin, PinMode.Output);
Console.WriteLine($"GPIO pin enabled: {pin}");

var prompt = "Choose a mode: \n1: Pulse \n2: Toggle \n> ";
IMode pulseMode = Input.ReadInt(prompt, 1, 2) switch
{
    1 => new PulseMode(),
    2 => new ToggleMode(),
    _ => throw new Exception("Unrecognized mode.")
};

pulseMode.Start(controller, pin);
