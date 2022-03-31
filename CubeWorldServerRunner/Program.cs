using System;
using System.Diagnostics;
using System.IO;

namespace CubeWorldServerRunner
{
    public class Program
    {
        // labels
        private const string PressKeyToExit = "Press key to exit...";

        // files paths
        private const string ServerCfg = "server.cfg";
        private const string ServerExe = "Server.exe";

        public static void Main(string[] args)
        {
            if (CheckConfigFileExists()) return;

            var confSeed = ReadConfigFile();

            confSeed = GetSeedFromUser(confSeed);

            WriteConfigFile(confSeed);

            if (CheckServerFileExists()) return;

            var process = Process.Start(ServerExe);
            if (process == null) // failed to start
            {
                Console.WriteLine("Failed to run server.");
                UserPressKey();
            }
            else // Started, wait for it to finish
            {
                process.WaitForExit();
            }

            UserPressKey();
        }

        #region files operations

        private static bool CheckConfigFileExists()
        {
            if (File.Exists(ServerCfg)) return false;

            Console.WriteLine("Can't find the configuration file.");
            Console.WriteLine("Be sure this executable is placed in Cube World installation folder.");
            UserPressKey();
            return true;
        }

        private static bool CheckServerFileExists()
        {
            if (File.Exists(ServerExe)) return false;

            Console.WriteLine("Can't find the server executable file.");
            Console.WriteLine("Be sure this executable is placed in Cube World installation folder.");
            UserPressKey();
            return true;
        }

        private static void WriteConfigFile(string confSeed)
        {
            using var writer = File.CreateText(ServerCfg);
            writer.WriteLine(confSeed);
            Console.WriteLine($"Seed {confSeed} saved!");
        }

        private static string ReadConfigFile()
        {
            using var readFileStream = new FileStream(ServerCfg, FileMode.Open);
            using var reader = new StreamReader(readFileStream);
            var confSeed = reader.ReadLine();

            if (IsInt(confSeed)) return confSeed;

            Console.WriteLine("The seed in your configuration file is not valid. Please specify a new valid one.");
            confSeed = string.Empty;

            return confSeed;
        }

        #endregion

        #region inputs

        private static string GetSeedFromUser(string confSeed)
        {
            string userSeed;

            do
            {
                Console.Write($"Insert seed{(!string.IsNullOrEmpty(confSeed) ? $" ({confSeed})" : "")}: ");
                userSeed = Console.ReadLine();
            } while (string.IsNullOrEmpty(confSeed) && !IsInt(userSeed));

            return IsInt(userSeed) ? userSeed : confSeed;
        }

        private static void UserPressKey()
        {
            Console.WriteLine(PressKeyToExit);
            Console.ReadLine();
        }

        #endregion

        #region other privates

        private static bool IsInt(string stringInt)
        {
            return int.TryParse(stringInt, out _);
        }

        #endregion
    }
}