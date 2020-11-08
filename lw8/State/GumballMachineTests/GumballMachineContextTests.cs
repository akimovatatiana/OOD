using GumballMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GumballMachineTests
{
    [TestClass]
    public class GumballMachineContextTests
    {
        private string GetGumballMachineString(uint count, string state)
        {
            return $"Mighty Gumball, Inc.\nC# - enabled Standing Gumball Model #2020 (with state)\nInventory: {count} gumball{(count != 1 ? "s" : "")}\nMachine is {state}\n";
        }

        [TestMethod]
        public void GumballMachine_WithNoBalls_ShouldHaveSoldOutState()
        {
            var gm = new GumballMachineContext(0);
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void GumballMachine_WithBalls_ShouldHaveNoQuarterState()
        {
            var gm = new GumballMachineContext(5);
            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void GetBallCount_ShouldReturnBallCount()
        {
            var gm = new GumballMachineContext(5);
            Assert.AreEqual((uint)5, gm.GetBallCount());
        }

        [TestMethod]
        public void ReleaseBall_WithNoBalls_ShouldNotReleaseBall()
        {
            var gm = new GumballMachineContext(0);
            gm.ReleaseBall();
            Assert.AreEqual((uint)0, gm.GetBallCount());
        }

        [TestMethod]
        public void ReleaseBall_WithBalls_ShouldReleaseOneBall()
        {
            var gm = new GumballMachineContext(2);
            gm.ReleaseBall();
            Assert.AreEqual((uint)1, gm.GetBallCount());
        }

        [TestMethod]
        public void SetHasQuarterState_ShouldSetHasQuarterState()
        {
            var gm = new GumballMachineContext(5);
            gm.SetHasQuarterState();
            Assert.AreEqual(GetGumballMachineString(5, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void SetNoQuarterState_ShouldSetNoQuarterState()
        {
            var gm = new GumballMachineContext(5);
            gm.SetNoQuarterState();
            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void SetSoldOutState_ShouldSetSoldOutState()
        {
            var gm = new GumballMachineContext(5);
            gm.SetSoldOutState();
            Assert.AreEqual(GetGumballMachineString(5, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void SetSoldState_ShouldSetSoldState()
        {
            var gm = new GumballMachineContext(5);
            gm.SetSoldState();
            Assert.AreEqual(GetGumballMachineString(5, "delivering a gumball"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_InSoldOutState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachineContext(0);
            gm.EjectQuarter();
            Assert.AreEqual((uint)0, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_InHasQuaterState_ShouldChangeGMStateToNoQuaterState()
        {
            var gm = new GumballMachineContext(1);
            gm.InsertQuarter();
            gm.EjectQuarter();
            Assert.AreEqual((uint)1, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(1, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void EjectQuarter_InNoQuarterState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachineContext(5);
            gm.EjectQuarter();
            Assert.AreEqual((uint)5, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }
        
        [TestMethod]
        public void InsertQuarter_InSoldOutState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachineContext(0);
            gm.InsertQuarter();
            Assert.AreEqual((uint)0, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void InsertQuarter_InNoQuarterState_ShouldChangeGMStateToHasQuarterState()
        {
            var gm = new GumballMachineContext(5);
            gm.InsertQuarter();
            Assert.AreEqual((uint)5, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(5, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void InsertQuarter_InHasQuarterState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachineContext(5);
            gm.InsertQuarter();
            gm.InsertQuarter();
            Assert.AreEqual((uint)5, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(5, "waiting for turn of crank"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_InSoldOutState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachineContext(0);
            gm.TurnCrank();
            Assert.AreEqual((uint)0, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_InNoQuarterState_ShouldNotChangeGMState()
        {
            var gm = new GumballMachineContext(5);
            gm.TurnCrank();
            Assert.AreEqual((uint)5, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(5, "waiting for quarter"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_WithOneBall_InHasQuarterState_ShouldChangeGMStateToSoldOutState()
        {
            var gm = new GumballMachineContext(1);
            gm.InsertQuarter();
            gm.TurnCrank();
            Assert.AreEqual((uint)0, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(0, "sold out"), gm.ToString());
        }

        [TestMethod]
        public void TurnCrank_WithBalls_InHasQuarterState_ShouldChangeGMStateToNoQuarterState()
        {
            var gm = new GumballMachineContext(2);
            gm.InsertQuarter();
            gm.TurnCrank();
            Assert.AreEqual((uint)1, gm.GetBallCount());
            Assert.AreEqual(GetGumballMachineString(1, "waiting for quarter"), gm.ToString());
        }
    }
}
