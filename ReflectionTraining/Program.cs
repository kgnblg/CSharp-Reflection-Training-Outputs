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

            foreach (var type in classtypes)
            {
                string classaccesstype = type.IsPublic ? "public class" : "class";
                File.WritetoLine("  "+classaccesstype + " " + CorrectString.SplitIt(type.FullName,'.',1));
                File.WritetoLine("  {");

                Field field = new Field(type.GetFields());
                field.PrintFields();

                File.WritetoLine("");

                PropertyInfo[] propertyinfos = type.GetProperties();
                Property property = new Property(propertyinfos);
                property.PrintPropertys();

                File.WritetoLine("  }");
                File.WritetoLine("");

            }
            File.WritetoLine("}");
            file.CloseConnection();
            Console.ReadKey();
        }
    }
}
