using System.Reflection;

namespace ReflectionTraining
{
    class Property
    {
        PropertyInfo [] propertyinfo { get; set; }

        public Property(PropertyInfo [] propertyinfo)
        {
            this.propertyinfo = propertyinfo;
        }

        public void PrintPropertys()
        {
            foreach (var property in propertyinfo)
            {
                var accessors = property.GetAccessors();
                string[] getsetcontrol = new string[2];

                if (CorrectString.SplitIt(accessors[0].Name, '_', 0) == "get")
                {
                    getsetcontrol[0] = "get;";
                }

                if (CorrectString.SplitIt(accessors[1].Name, '_', 0) == "set")
                {
                    getsetcontrol[1] = "set;";
                }

                File.WritetoLine("  public " + CorrectString.SplitIt(property.PropertyType.ToString(),'.',1) + " " + property.Name + "{ " + getsetcontrol[0] + " " + getsetcontrol[1] + " }");
                getsetcontrol[0] = getsetcontrol[1] = "";
            }
        }
    }
}
