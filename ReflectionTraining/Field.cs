using System.Reflection;

namespace ReflectionTraining
{
    class Field
    {
        public FieldInfo [] fieldinfo { get; set; }
        public Field(FieldInfo [] fieldinfo)
        {
            this.fieldinfo = fieldinfo;
        }

        public void PrintFields()
        {
            foreach (var field in fieldinfo)
            {
                string takefield = CorrectString.SplitIt(field.FieldType.ToString(),'.',1);

                string staticcontrol = field.IsStatic ? "static" : "";
                string publiccontrol = field.IsPublic ? "public" : "";

                File.WritetoLine("  "+publiccontrol+" "+staticcontrol+" "+takefield+" "+field.Name+";");
            }
        }
    }
}
