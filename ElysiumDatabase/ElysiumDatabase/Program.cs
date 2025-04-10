// See https://aka.ms/new-console-template for more information

#define SERVER

using System;
using RebirthStudios.DataAccessLayer;
using RebirthStudios.DataAccessLayer.Enums;

namespace MyNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var logger = new Logger
            {
                LogMethod          = Console.WriteLine, 
                LogDebugMethod     = Console.WriteLine, 
                LogProfilingMethod = Console.WriteLine, 
                LogWarningMethod   = Console.WriteLine,
                LogErrorMethod     = Console.WriteLine,
                LogExceptionMethod = Console.WriteLine
            };
            var dataTableStoredProcs = new DataTableStoredProcs(logger, 1, 10, 100,5,14, 5,true);
            dataTableStoredProcs.Init();
            EnumLoader.Initialize(logger, dataTableStoredProcs._dataTables);
        }
    }


}
