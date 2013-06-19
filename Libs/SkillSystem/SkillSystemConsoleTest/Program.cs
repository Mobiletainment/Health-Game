using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillSystem;

namespace SkillSystemConsoleTest
{
    class Program
    {
        private static SkillManager _sm;

        static void Main(string[] args)
        {
            _sm = new SkillManager();
            /*
            _sm.AddSkill(new BasicSkill("Beweglichkeit", "min", "max", 5, 0, 10, 5));
            _sm.AddSkill(new BasicSkill("Geschwindigkeit", "min", "max", 5, 0, 10, 5));
            _sm.AddSkill(new BasicSkill("Boost", "min", "max", 5, 0, 10, 5));
            _sm.AddSkill(new BasicSkill("Ausdauer", "min", "max", 5, 0, 10, 5));
            _sm.AddSkill(new BasicSkill("Sichtweite", "min", "max", 5, 0, 10, 5));
            _sm.AddSkill(new BasicSkill("Fitness", "min", "max", 5, 0, 10, 5));

            _sm.GetSkillByName("Beweglichkeit").Value = 5;
            _sm.GetSkillByName("Geschwindigkeit").Value = 3;
            _sm.GetSkillByName("Boost").Value = 8;
            _sm.GetSkillByName("Ausdauer").Value = 2;
            _sm.GetSkillByName("Sichtweite").Value = 6;
            _sm.GetSkillByName("Fitness").Value = 4;

            _sm.SaveSkillsToFile();*/

            _sm.LoadSkillsFromFile();

            Console.Read();
        }
    }
}
