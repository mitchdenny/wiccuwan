using System;

namespace Wiccuwan
{
    public interface ICompiler
    {
        void Compile(string output, string[] inputs);
    }
}