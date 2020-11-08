using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GumballMachineWithStateTests
{
    [TestClass]
    public class GumballMachineTests
    {
        private string GetGumballMachineString(uint count, string state)
        {
            return $"Mighty Gumball, Inc.\nC# - enabled Standing Gumball Model #2020 (with state)\nInventory: {count} gumball{(count != 1 ? "s" : "")}\nMachine is {state}\n";
        }

        [TestMethod]
        public void CanCreateGumballMachine()
        {
            var gm = new GumballMachine.GumballMachine(5);
            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_WithBalls_SouldEjectQuarter()
        {
            var gm = new GumballMachine.GumballMachine(5);
            gm.EjectQuarter();
            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void InsertQuarter_ShouldInsertQuarter()
        {
            var gm = new GumballMachine.GumballMachine(5);
            gm.InsertQuarter();
            Assert.AreEqual(GetGumballMachineString(5, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_AfterInsertQuarter_ShouldTurnCrank()
        {
            var gm = new GumballMachine.GumballMachine(5);
            gm.InsertQuarter();
            gm.TurnCrank();
            Assert.AreEqual(GetGumballMachineString(4, "waiting for quarter"), gm.ToString());
        }
    }
}
