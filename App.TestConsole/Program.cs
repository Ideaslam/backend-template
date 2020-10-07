using Edura.Orchestrator.Tests;
using System;

namespace Edura.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var x =  MockInitializer.GetApplicationUserManager();
            Console.WriteLine(x);
        }
    }
}
