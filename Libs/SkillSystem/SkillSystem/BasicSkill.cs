using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SkillSystem
{
    public class BasicSkill
    {
        public string Name { private set; get; }
        public string NameMinimum { private set; get; }
        public string NameMaximum { private set; get; }

        public short Value { set; get; }
        public short MinValue { private set; get; }
        public short MaxValue { private set; get; }
        public short DefaultValue { private set; get; }

        public BasicSkill(string name, string nameMinumum, string nameMaximum, short value = 0, short minValue = -10, short maxValue = 10, short defaultValue = 0)
        {
            this.Name = name;
            this.NameMinimum = nameMinumum;
            this.NameMaximum = nameMaximum;

            this.Value = value;

            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.DefaultValue = defaultValue;
        }

        public XElement GetXElement()
        {
            return new XElement("BasicSkill",
                                new XAttribute("Name", Name),
                                new XAttribute("NameMinimum", NameMinimum),
                                new XAttribute("NameMaximum", NameMaximum),

                                new XAttribute("Value", Value),
                                new XAttribute("MinValue", MaxValue),
                                new XAttribute("MaxValue", MaxValue),
                                new XAttribute("DefaultValue", DefaultValue)
                                );
        }

    }
}
