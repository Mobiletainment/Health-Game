using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillSystem;

namespace SkillSystemTest
{
    [TestClass]
    public class BasicTests
    {

        private static SkillManager _sm;

        private static BasicSkill _velocity;
        private static BasicSkill _size;
        private static BasicSkill _care;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _sm = new SkillManager();

            _velocity = new BasicSkill("Velocity", "Slow", "Fast");
            _size = new BasicSkill("Size", "Tiny", "Tall");
            _care = new BasicSkill("Care", "Careless", "Careful");

            Assert.IsTrue(_sm.AddSkill(_velocity));
            Assert.IsTrue(_sm.AddSkill(_size));
            Assert.IsTrue(_sm.AddSkill(_care));
        }

        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public void AddingSkillsToManager()
        {
            BasicSkill bs = new BasicSkill("NewSkill", "MinNewSkill", "MaxNewSkill");
            Assert.IsTrue(_sm.AddSkill(bs));
        }

        [TestMethod]
        public void AddingSkillToManagerTwice()
        {
            BasicSkill bs1 = new BasicSkill("Dummy", "MinDummy", "MaxDummy");
            Assert.IsTrue(_sm.AddSkill(bs1));
            Assert.IsFalse(_sm.AddSkill(bs1));
        }

        [TestMethod]
        public void AddingSkillsWithSameNameToManager()
        {
            BasicSkill bs1 = new BasicSkill("SameName", "Min", "Max");
            Assert.IsTrue(_sm.AddSkill(bs1));

            BasicSkill bs2 = new BasicSkill("SameName", "SameMin", "SameMax");
            Assert.IsFalse(_sm.AddSkill(bs2));
        }

        [TestMethod]
        public void GettingSkillsFromManager()
        {
            BasicSkill bs;
            bs = _sm.GetSkillByName(_velocity.Name);
            Assert.AreEqual(_velocity, bs); //true check
            Assert.AreSame(_velocity, bs); //reference check

            bs = _sm.GetSkillByName(_size.Name);
            Assert.AreEqual(_size, bs);
            Assert.AreSame(_size, bs);

            Assert.AreNotEqual(_velocity, bs);
            Assert.AreNotSame(_velocity, bs);
        }

        [TestMethod]
        public void NotExistingItemFromManager()
        {
            BasicSkill bs = _sm.GetSkillByName("I_do_not_exist");
            Assert.IsNull(bs);
        }

        [TestMethod]
        public void SaveSkills()
        {
            Assert.IsTrue(_sm.SaveSkillsToFile());
        }
    }
}
