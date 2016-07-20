using System;

namespace ReflectionTraining
{
    class Enum
    {
        Type [] enumtypes { get; set; }

        public Enum(Type [] enumtypes)
        {
            this.enumtypes = enumtypes;
        }

        public void PrintEnums()
        {
            foreach (var type in enumtypes)
            {
                if (type.IsEnum)
                {
                    File file = new File("C:/" + type.Name + ".cs");
                    file.SetFile();

                    File.WritetoLine("using System;");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace);
                    File.WritetoLine("{");

                    string enumaccesstype = type.IsPublic ? "public enum" : "enum";
                    File.WritetoLine("  " + enumaccesstype + " " + type.Name);
                    File.WritetoLine("  {");

                    string[] enumvalues = type.GetEnumNames();

                    foreach (var value in enumvalues)
                    {
                        File.WritetoLine("  "+value+",");
                    }

                    File.WritetoLine("  }");
                    File.WritetoLine("}");
                    file.CloseConnection();
                }
            }
        }
    }
}
