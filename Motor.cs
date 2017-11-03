using System;
using MraaSharp;

namespace RoboCar
{
	public class Motor
	{
		Pwm speed;
		Gpio direction;
		Gpio brake;

		public enum Direction
		{
			Forward=1,
			Backward=0
		}

		public Motor(int pwmPin, int directionPin, int brakePin)
		{
			speed = new Pwm(pwmPin);
			direction = new Gpio(directionPin, MraaGpioDir.Out);
			brake = new Gpio(brakePin, MraaGpioDir.Out);

			InitializeMotor();
		}

		private void InitializeMotor()
		{
			direction.Write(MraaGpioValue.High);
			brake.Write(MraaGpioValue.Low);
		}

		public void SetDirection(Direction dir)
		{
			if (dir == Direction.Forward)
				direction.Write(MraaGpioValue.High);
			else
				direction.Write(MraaGpioValue.Low);
		}

		public void Brake()
		{
			brake.Write(MraaGpioValue.High);
		}

		public void Release()
		{
			brake.Write(MraaGpioValue.Low);
		}

		public void StartEngine(float velocity = 0.0f)
		{
			speed.Enable = true;
			speed.Write(velocity);
			Release();
		}

		public void StopEngine()
		{
			Brake();
			speed.Write(0.0f);
			speed.Enable = false;
		}
	}
}
