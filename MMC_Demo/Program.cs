using System;
using System.Threading;

namespace MMC_Demo
{
    class Program
    {
        private static readonly AutoResetEvent AutoEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("MMC Demo");
            Console.WriteLine("--------");

            if (args.Length < 3)
            {
                Console.WriteLine("Please call as follows; MMC_Demo.exe <username> <registration> <state>");
                return;
            }

            var username = args[0];
            var reg = args[1];
            var state = args[2];

            var api = new regcheck.CarReg();

            api.CheckUSAAsync(reg, state, username, AutoEvent);
            api.CheckUSACompleted += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.Result.vehicleJson);
                ((AutoResetEvent) eventArgs.UserState).Set();
            };
            AutoEvent.WaitOne();
        }
    }
}
