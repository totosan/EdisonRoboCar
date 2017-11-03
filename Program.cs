using System;
using System.Threading;
using MraaSharp;

namespace RoboCar
{
	class Program
	{
		static void Main(string[] args)
		{
			Mraa.Initialize();
			Console.WriteLine("Version: {0}", Mraa.Version);
			Console.WriteLine("PlatformName: {0}", Mraa.PlatformName);

			Motor engine = new Motor(3, 12, 9);
			Motor gear = new Motor(11, 13, 8);

			engine.StartEngine(0.5f);
			Console.WriteLine("Stared engine!");
			//gear.StartEngine(0.3f);
			//Thread.Sleep(100);
			//gear.Brake();

			Console.ReadLine();
			//while (true)
			//{
			//	Thread.Sleep(1000);
			//	Console.WriteLine(a0.Read());
			//}

			engine.StopEngine();
		}
	}
}
