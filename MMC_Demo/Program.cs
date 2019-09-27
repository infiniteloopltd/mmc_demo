using System;

namespace MMC_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MMC Demo");
            Console.WriteLine("--------");

            if (args.Length < 3)
            {
                Console.WriteLine("Please call as follows; MMC_Demo.exe <username> <registration> <state>");
            }

            var username = args[0];
            var reg = args[1];
            var state = args[2];

            var api = new regcheck.CarReg();

            var data = api.CheckUSA(reg, state, username);

            Console.WriteLine(data.vehicleJson);




        }
    }
}
