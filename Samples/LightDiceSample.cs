using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace PiGpioSamples.Samples {
	public static class LightDiceSample {
		static int _currentValue = -1;

		public static void Run() {
			var random = new Random();
			var ledPins = new[] {
				Pi.Gpio[BcmPin.Gpio17],
				Pi.Gpio[BcmPin.Gpio27],
				Pi.Gpio[BcmPin.Gpio22],
				Pi.Gpio[BcmPin.Gpio05],
				Pi.Gpio[BcmPin.Gpio06],
				Pi.Gpio[BcmPin.Gpio26],
			};
			var controlPin = Pi.Gpio[BcmPin.Gpio23];
			var resetPin = Pi.Gpio[BcmPin.Gpio24];
			SetLightCount(ledPins, 0);
			var oldControlValue = false;
			while ( true ) {
				var value = controlPin.Read();
				if ( value && !oldControlValue ) {
					int randomValue;
					do {
						randomValue = random.Next(1, ledPins.Length + 1);
					} while ( randomValue == _currentValue );
					_currentValue = randomValue;
					SetLightCount(ledPins, randomValue);
				}
				oldControlValue = value;
				var reset = resetPin.Read();
				if ( reset ) {
					break;
				}
				Thread.Sleep(100);
			}
			SetLightCount(ledPins, 0);
		}

		static void SetLightCount(IGpioPin[] pins, int count) {
			Console.WriteLine($"SetLightCount({count})");
			for ( var i = 0; i < pins.Length; i++ ) {
				var pin = pins[i];
				pin.PinMode = GpioPinDriveMode.Output;
				var isOn = (i < count);
				pin.Write(isOn);
			}
		}
	}
}