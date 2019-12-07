using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace PiGpioSamples {
	class Program {
		static void Main(string[] args) {
			Pi.Init<BootstrapWiringPi>();
			// GPIO26 -> LED <- RESISTOR <- GND
			var ledPin = Pi.Gpio[BcmPin.Gpio26];
			ledPin.PinMode = GpioPinDriveMode.Output;
			// GPIO17 -> BUTTON <- 3V3
			var controlPin = Pi.Gpio[BcmPin.Gpio17];
			while ( true ) {
				var isOn = controlPin.Read();
				ledPin.Write(isOn);
				Thread.Sleep(100);
			}
		}
	}
}