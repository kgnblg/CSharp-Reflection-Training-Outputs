using System;
using System.Reflection;

namespace ReflectionTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFile("C:/ReflectionOrnekClass.dll");
            var classtypes = assembly.GetTypes();

            File file = new File("C:/cikti.cs");
            file.SetFile();

            File.WritetoLine("using System;");
            File.WritetoLine("");
            File.WritetoLine("namespace "+classtypes[1].Namespace);
            File.WritetoLine("{");

            Class classes = new Class(classtypes);
            classes.PrintClasses();

            File.WritetoLine("}");
            file.CloseConnection();
            Console.ReadKey();
        }
    }
}
