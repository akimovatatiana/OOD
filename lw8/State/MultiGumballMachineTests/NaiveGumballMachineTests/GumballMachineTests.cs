using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiGumballMachine.NaiveGumballMachine;
using System;
using System.IO;
using System.Text;

namespace MultiGumballMachineTests.NaiveGumballMachineTests
{
    [TestClass]
    public class GumballMachineTests
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
        public void InsertQuarter_InSoldOutState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachine(0);
            gm.InsertQuarter();

            Assert.AreEqual("You can't insert a quarter, the machine is sold out\r\n", sw.ToString());
        }

        [TestMethod]
        public void InsertQuarter_InNoQuarterState_ShouldChangeGMStateToHasQuarterState()
        {
            var gm = new GumballMachine(5);
            gm.InsertQuarter();

            Assert.AreEqual("You inserted a quarter. Quarters count: 1\r\n", sw.ToString());
            Assert.AreEqual(GetGumballMachineString(5, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void InsertQuarter_InHasQuarterState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachine(5);
            gm.InsertQuarter();
            gm.InsertQuarter();

            Assert.AreEqual("You inserted a quarter. Quarters count: 1\r\nYou inserted a quarter. Quarters count: 2\r\n", sw.ToString());
            Assert.AreEqual(GetGumballMachineString(5, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void InsertQuarter_WithMoreThanFiveQuarters_ShouldNotChangeGMState()
        {
            var gm = new GumballMachine(3);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.InsertQuarter();

            sb.Remove(0, sb.Length);
            gm.InsertQuarter();

            Assert.AreEqual("You can't insert another quarter. Max quarters quantity is 5\r\n", sw.ToString());
            Assert.AreEqual(GetGumballMachineString(3, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_InSoldOutState_ShouldReturnAllQuarters()
        {
            var gm = new GumballMachine(1);
            gm.InsertQuarter();
            gm.InsertQuarter();
            gm.TurnCrank();
            sb.Remove(0, sb.Length);
            gm.EjectQuarter();

            Assert.AreEqual("Quarter returned\r\n", sw.ToString());
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_InNoQuarterState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachine(5);
            gm.EjectQuarter();

            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_InHasQuarterState_ShouldReturnAllQuarters_And_ChangeGMStateToNoQuarterState()
        {
            var gm = new GumballMachine(5);
            gm.InsertQuarter();
            gm.InsertQuarter();

            Assert.AreEqual("You inserted a quarter. Quarters count: 1\r\nYou inserted a quarter. Quarters count: 2\r\n", sw.ToString());

            sb.Remove(0, sb.Length);
            gm.EjectQuarter();

            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_InSoldOutState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachine(0);
            gm.TurnCrank();

            Assert.AreEqual("You turned but there's no gumballs\r\n", sw.ToString());
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_InNoQuarterState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachine(5);
            gm.TurnCrank();

            Assert.AreEqual("You turned but there's no quarter\r\n", sw.ToString());
            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_InHasQuarterState_WithOneBall_ShouldChangeGMStateToSoldOutState()
        {
            var gm = new GumballMachine(1);
            gm.InsertQuarter();
            gm.TurnCrank();

            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
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
        public void Refill_InSoldOutState_ShouldRefill()
        {
            var gm = new GumballMachine(0);

            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.Refill(2);
            Assert.AreEqual("Gumballs refilled. Gumballs count: 2\r\n", sw.ToString());
        }

        [TestMethod]
        public void Refill_InHasQuarterState_ShouldRefill()
        {
            var gm = new GumballMachine(2);

            gm.InsertQuarter();
            gm.InsertQuarter();
            Assert.AreEqual(GetGumballMachineString(2, "waiting for turn of crank"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.Refill(2);

            Assert.AreEqual("Gumballs refilled. Gumballs count: 4\r\n", sw.ToString());
        }

        [TestMethod]
        public void Refill_InNoQuarterState_ShouldRefill()
        {
            var gm = new GumballMachine(2);

            Assert.AreEqual(GetGumballMachineString(2, "waiting for quarter"), gm.ToString());

            sb.Remove(0, sb.Length);
            gm.Refill(2);

            Assert.AreEqual("Gumballs refilled. Gumballs count: 4\r\n", sw.ToString());
        }
    }
}
