using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace PiGpioSamples {
	class Program {
		static void Main(string[] args) {
			Pi.Init<BootstrapWiringPi>();
		}
	}
}