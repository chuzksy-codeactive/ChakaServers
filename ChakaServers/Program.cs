using System;
using System.Collections.Generic;

namespace ChakaServers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serverArray = new List<List<int>> {
                new List<int> { 1, 0, 0 },
                new List<int> { 0, 0, 0 },
                new List<int> { 0, 0, 1 }
            };

            var svrLogic = new ServerLogic();

            var result = svrLogic.UpdateServer(serverArray);

            Console.WriteLine($"The number of days to update all servers is {result}");

            #region Console result for ServerLogic2
            //var cSvrLogic = new ServerLogic2();
            //var result2 = cSvrLogic.UpdateServer(serverArray);

            //Console.WriteLine(result2); 
            #endregion
        }
    }
}
