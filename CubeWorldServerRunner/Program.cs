using System;
using System.Diagnostics;
using System.IO;

namespace CubeWorldServerRunner
{
    class Program
    {
        private static string _serverCfg = "server.cfg";

        static void Main(string[] args)
        {
            if (!File.Exists(_serverCfg)) return;

            string confSeed;

            using (FileStream readFileStream = new FileStream(_serverCfg, FileMode.Open))
            {
                using StreamReader reader = new StreamReader(readFileStream);
                confSeed = reader.ReadLine();
            }

            Console.Write($"Insert seed {(!string.IsNullOrEmpty(confSeed) ? $"({confSeed})" : "")}: ");

            var userSeed = Console.ReadLine();

            if (!string.IsNullOrEmpty(userSeed) && int.TryParse(userSeed, out _))
            {
                confSeed = userSeed;
            }

            using (StreamWriter writer = File.CreateText(_serverCfg))
            {
                writer.WriteLine(confSeed);
                Console.WriteLine($"New seed {userSeed} saved!");
            }

            var process = Process.Start("Server.exe");
            if (process == null) // failed to start
            {
                Console.WriteLine("Failed to run server.");
                Console.WriteLine("Press key to exit...");
                Console.ReadLine();
            }
            else // Started, wait for it to finish
            {
                process.WaitForExit();
            }
        }
    }
}