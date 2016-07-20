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

                File.WritetoLine("  public "+takefield+" "+field.Name+";");
            }
        }
    }
}
