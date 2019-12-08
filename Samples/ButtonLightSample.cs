using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace PiGpioSamples.Samples {
	public static class ButtonLightSample {
		public static void Run() {
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