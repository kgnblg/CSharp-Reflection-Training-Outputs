using System;
using System.Reflection;

namespace ReflectionTraining
{
    class Class: ITypes
    {
        public Type[] types { get; set; }

        public Class(Type [] types)
        {
            this.types = types;
        }

        public void PrintIt()
        {
            foreach (var type in types)
            {
                if (type.IsClass)
                {
                    File file = new File("C:/dlloutputs/" + type.Name + ".cs");
                    file.SetFile();

                    File.WritetoLine("using System;");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace);
                    File.WritetoLine("{");

                    File.WritetoLine("  public class " + type.Name);
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
