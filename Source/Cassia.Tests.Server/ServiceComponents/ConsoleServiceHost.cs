using System;

namespace Cassia.Tests.Server.ServiceComponents
{
    public class ConsoleServiceHost : IServiceHost
    {
        #region IServiceHost Members

        public void Run(IHostedService service)
        {
            service.Attach(this);
            Console.WriteLine("Starting service {0}...", service.Name);
            service.Start();
            Console.WriteLine("Service started.");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.D || key.Modifiers != ConsoleModifiers.Control);
            Console.WriteLine("Stopping service {0}...", service.Name);
            service.Stop();
            Console.WriteLine("Service stopped.");
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        #endregion
    }
}