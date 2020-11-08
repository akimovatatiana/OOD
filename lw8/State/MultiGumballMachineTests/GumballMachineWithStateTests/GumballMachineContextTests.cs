using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiGumballMachine.GumballMachineWithState;
using System;
using System.IO;
using System.Text;

namespace MultiGumballMachineTests.GumballMachineWithStateTests
{
    [TestClass]
    public class GumballMachineContextTests
    {
        private readonly StringWriter sw = new StringWriter();
        private StringBuilder sb = new StringBuilder();

        private string GetGumballMachineString(uint count, string state)
        {
            return $"Mighty Gumball, Inc.\nC# - enabled Standing Gumball Model #2020 (with state)\nInventory: {count} gumball{(count != 1 ? "s" : "")}\nMachine is {state}\n";
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Console.SetOut(sw);
            sb = sw.GetStringBuilder();
        }

        [TestMethod]
        public void InsertQuarter_WithQuarter_ShouldInsertQuarter_And_PrintInfo()
        {
            var gm = new GumballMachineContext(3);
            gm.InsertQuarter();
            Assert.AreEqual((uint)1, gm.GetQuartersCount());
            Assert.AreEqual("You inserted a quarter. Quarters count: 1\r\n", sw.ToString());
        }

        [TestMethod]
        public void InsertQuarter_WithFiveQuarters_ShouldChangeGMStateToMaxQuarterState()
        {
            var gm = new GumballMachineContext(3);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            Assert.AreEqual((uint)5, gm.GetQuartersCount());
            Assert.AreEqual(GetGumballMachineString(3, "at the max quarters quantity, waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void InsertQuarter_WithMoreThanFiveQuarters_ShouldChangeGMStateToMaxQuarterState()
        {
            var gm = new GumballMachineContext(3);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();

            sb.Remove(0, sb.Length);
            gm.InsertQuarter();

            Assert.AreEqual((uint)5, gm.GetQuartersCount());
            Assert.AreEqual("You can't insert another quarter. Max quarters quantity is 5\r\n", sw.ToString());
            Assert.AreEqual(GetGumballMachineString(3, "at the max quarters quantity, waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_And_InsertExtraQuarters_ShouldNotChangeGMState()
        {
            var gm = new GumballMachineContext(5);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();

            Assert.AreEqual((uint)3, gm.GetQuartersCount());
            
            gm.TurnCrank();
            gm.TurnCrank();

            Assert.AreEqual((uint)1, gm.GetQuartersCount());
            Assert.AreEqual((uint)3, gm.GetBallCount());

            gm.InsertQuarter();

            Assert.AreEqual((uint)2, gm.GetQuartersCount());
            Assert.AreEqual(GetGumballMachineString(3, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_InHasQuarterState_WithBalls_And_OneQuarter_ShouldChangeGMStateToNoQuarterState()
        {
            var gm = new GumballMachine(5);
            gm.InsertQuarter();
            gm.TurnCrank();

            Assert.AreEqual(GetGumballMachineString(4, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_InHasQuarterState_WithBalls_And_Quarters_ShouldChangeGMStateToHasQuarterState()
        {
            var gm = new GumballMachine(5);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.TurnCrank();

            Assert.AreEqual(GetGumballMachineString(4, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_WithQuarters_ShouldReturnAllQuarters()
        {
            var gm = new GumballMachineContext(5);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            
            Assert.AreEqual((uint)3, gm.GetQuartersCount());

            sb.Remove(0, sb.Length);
            gm.EjectQuarter();
            Assert.AreEqual((uint)0, gm.GetQuartersCount());
            Assert.AreEqual("Quarters returned\r\n", sw.ToString());
        }

        [TestMethod]
        public void EjectQuarter_InSoldOutState_ShouldReturnAllQuarters()
        {
            var gm = new GumballMachineContext(1);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();

            Assert.AreEqual((uint)3, gm.GetQuartersCount());

            gm.TurnCrank();
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.EjectQuarter();
            Assert.AreEqual((uint)0, gm.GetQuartersCount());
            Assert.AreEqual("Quarters returned\r\n", sw.ToString());
        }

        [TestMethod]
        public void Refill_InSoldState_ShouldNotRefill()
        {
            var gm = new GumballMachineContext(5);
            gm.SetSoldState();

            Assert.AreEqual(GetGumballMachineString(5, "delivering a gumball"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.Refill(2);
            Assert.AreEqual((uint)5, gm.GetBallCount());
            Assert.AreEqual("Can't refill gumballs when machine is giving you a gumball\r\n", sw.ToString());
        }

        [TestMethod]
        public void Refill_InSoldOutState_ShouldRefill()
        {
            var gm = new GumballMachineContext(0);

            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.Refill(2);
            Assert.AreEqual((uint)2, gm.GetBallCount());
            Assert.AreEqual("Gumballs refilled. Gumballs count: 2\r\n", sw.ToString());
        }

        [TestMethod]
        public void Refill_InHasQuarterState_ShouldRefill_And_NotLostQuarters()
        {
            var gm = new GumballMachineContext(2);

            gm.InsertQuarter();
            gm.InsertQuarter();
            Assert.AreEqual(GetGumballMachineString(2, "waiting for turn of crank"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.Refill(2);

            Assert.AreEqual((uint)4, gm.GetBallCount());
            Assert.AreEqual((uint)2, gm.GetQuartersCount());
            Assert.AreEqual("Gumballs refilled. Gumballs count: 4\r\n", sw.ToString());
        }

        [TestMethod]
        public void Refill_InNoQuarterState_ShouldRefill()
        {
            var gm = new GumballMachineContext(2);

            Assert.AreEqual(GetGumballMachineString(2, "waiting for quarter"), gm.ToString());
            
            sb.Remove(0, sb.Length);
            gm.Refill(2);

            Assert.AreEqual((uint)4, gm.GetBallCount());
            Assert.AreEqual("Gumballs refilled. Gumballs count: 4\r\n", sw.ToString());
        }

        [TestMethod]
        public void Refill_InMaxQuarterState_ShouldRefill()
        {
            var gm = new GumballMachineContext(2);

            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();

            Assert.AreEqual(GetGumballMachineString(2, "at the max quarters quantity, waiting for turn of crank"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.Refill(2);

            Assert.AreEqual((uint)4, gm.GetBallCount());
            Assert.AreEqual("Gumballs refilled. Gumballs count: 4\r\n", sw.ToString());
        }
    }
}
