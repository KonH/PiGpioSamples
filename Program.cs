using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace PiGpioSamples {
	class Program {
		static void Main(string[] args) {
			Pi.Init<BootstrapWiringPi>();
			var pin = Pi.Gpio[BcmPin.Gpio17];
			pin.PinMode = GpioPinDriveMode.Output;
			var isOn = false;
			for ( var i = 0; i < 10; i++ ) {
				isOn = !isOn;
				pin.Write(isOn);
				System.Threading.Thread.Sleep(500);
			}
		}
	}
}