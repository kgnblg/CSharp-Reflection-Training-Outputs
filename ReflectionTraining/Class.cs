using System;
using System.Reflection;

namespace ReflectionTraining
{
    class Class
    {
        Type[] classtypes { get; set; }

        public Class(Type [] classtypes)
        {
            this.classtypes = classtypes;
        }

        public void PrintClasses()
        {
            foreach (var type in classtypes)
            {
                if (type.IsClass)
                {
                    File file = new File("C:/" + type.Name + ".cs");
                    file.SetFile();

                    File.WritetoLine("using System;");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace);
                    File.WritetoLine("{");

                    string classaccesstype = type.IsPublic ? "public class" : "class";
                    File.WritetoLine("  " + classaccesstype + " " + type.Name);
                    File.WritetoLine("  {");

                    Field field = new Field(type.GetFields());
                    field.PrintFields();

                    File.WritetoLine("");

                    PropertyInfo[] propertyinfos = type.GetProperties();
                    Property property = new Property(propertyinfos);
                    property.PrintPropertys();

                    File.WritetoLine("  }");
                    File.WritetoLine("}");
                    file.CloseConnection();
                }
            }
        }
    }
}
