using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace SkillSystem
{
    public class SkillManager
    {
        private Dictionary<string, BasicSkill> _skills = new Dictionary<string, BasicSkill>();

        public SkillManager()
        {
        }

        public bool AddSkill(BasicSkill skill)
        {
            if (_skills.ContainsKey(skill.Name))
                return false;

            _skills.Add(skill.Name, skill);
            return true;
        }

        public BasicSkill GetSkillByName(string name)
        {
            BasicSkill bs;

            if (_skills.TryGetValue(name, out bs))
                return bs;
            else
                return null;
        }

#warning TODO: SkillManager - Save skills to XML or JSON-File
        public bool SaveSkillsToFile(string filename = "skills.data")
        {
            try
            {
                //DONE: SkillManager - XElement for skill should be created in BasicSkill-Class ('cause only the class knows its members)
                XDocument file = new XDocument(
                                    new XDeclaration("1.0", "utf-8", "yes"),
                                    new XComment("List of monster skills."),
                                    new XElement("Skills",
                                        from skill in _skills.Values
                                        select skill.GetXElement()));

                file.Save(filename);

                //string dir = Directory.GetCurrentDirectory() + "\\" + filename;
                //file.Save(dir);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

#warning TODO: SkillManager - Load skills from XML or JSON-File
        public bool LoadSkillsFromFile(string filename = "skills.data")
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(filename);

                //BasicSkill members
                string name;
                string nameMinumum;
                string nameMaximum;
                short value;
                short minValue;
                short maxValue;
                short defaultValue;

                XmlNodeList nodeList = xml.GetElementsByTagName("BasicSkill");
                foreach (XmlNode node in nodeList)
                {
                    name = node.Attributes["Name"].Value;
                    nameMinumum = node.Attributes["NameMinimum"].Value;
                    nameMaximum = node.Attributes["NameMaximum"].Value;
                    value = short.Parse(node.Attributes["Value"].Value);
                    minValue = short.Parse(node.Attributes["MinValue"].Value);
                    maxValue = short.Parse(node.Attributes["MaxValue"].Value);
                    defaultValue = short.Parse(node.Attributes["DefaultValue"].Value);
                    BasicSkill skill = new BasicSkill(name, nameMinumum, nameMaximum, value, minValue, maxValue, defaultValue);

                    AddSkill(skill);

                    Console.WriteLine(node.OuterXml);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
