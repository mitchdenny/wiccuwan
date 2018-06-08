using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Wiccuwan
{
    public class Program
    {
        private static void ProcessDirectory(DirectoryInfo directory)
        {
            var sourceFiles = directory.GetFiles("*.cpp");

            var isEntryPoint = sourceFiles.Any(fi => fi.Name == "main.cpp");

            if (isEntryPoint)
            {
                var compiler = new GccCompiler();
                var inputs = sourceFiles.Select(fi => fi.FullName).ToArray();
                compiler.Compile(directory.Name, inputs);
            }            
            
        }

        public static int Main(string[] args)
        {
            if (args.Length != 1 || args[0].ToLower() != "watch") return 1;

            var workingDirectory = Directory.GetCurrentDirectory();
            var workingDirectoryInfo = new DirectoryInfo(workingDirectory);
            ProcessDirectory(workingDirectoryInfo);

            return 0;
        }
    }
}
