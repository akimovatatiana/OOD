using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiGumballMachine.GumballMachineWithState;

namespace MultiGumballMachineTests.GumballMachineWithStateTests
{
    [TestClass]
    public class GumballMachineTests
    {
        private string GetGumballMachineString(uint count, string state)
        {
            return $"Mighty Gumball, Inc.\nC# - enabled Standing Gumball Model #2020 (with state)\nInventory: {count} gumball{(count != 1 ? "s" : "")}\nMachine is {state}\n";
        }

        [TestMethod]
        public void Refill_WithBalls_SouldRefillGumballMachine()
        {
            var gm = new GumballMachine(5);
            gm.Refill(2);
            Assert.AreEqual(GetGumballMachineString(7, "waiting for quarter"), gm.ToString());
        }
    }
}
