using System;
using System.Diagnostics;

namespace Wiccuwan
{
    public class GccCompiler : ICompiler
    {
        public void Compile(string output, string[] inputs)
        {
            var inputFileArguments = string.Join(" ", inputs);
            var arguments = $"{inputFileArguments} -o {output} -Wall";
            var process = Process.Start("gcc", arguments);
            process.WaitForExit();
        }
    }
}