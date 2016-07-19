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
                string classaccesstype = type.IsPublic ? "public class" : "class";
                File.WritetoLine("  " + classaccesstype + " " + CorrectString.SplitIt(type.FullName, '.', 1));
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
        }
    }
}
