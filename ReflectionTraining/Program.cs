using System;

namespace ReflectionTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyFile assemblyfile = new AssemblyFile("C:/ReflectionOrnekClass.dll");
            var classtypes = assemblyfile.GetFile();

            Class classes = new Class(classtypes);
            classes.PrintClasses();

            Enum enums = new Enum(classtypes);
            enums.PrintEnums();

            Console.ReadKey();
        }
    }
}
