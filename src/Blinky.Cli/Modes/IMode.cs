using System.Device.Gpio;

namespace Blinky.Cli.Modes
{
    public interface IMode
    {
        void Start(GpioController controller, int pin);
    }
}