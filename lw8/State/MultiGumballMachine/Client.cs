using MultiGumballMachine.GumballMachineWithState;
using System.IO;

namespace MultiGumballMachine
{
    public class Client
    {
        private readonly Menu _menu;
        private readonly IGumballMachine _gumballMachine;
        private readonly TextReader _textReader;
        private readonly TextWriter _textWriter;

        public Client(TextWriter textWriter, TextReader textReader, IGumballMachine gumballMachine)
        {
            _textReader = textReader;
            _textWriter = textWriter;
            _gumballMachine = gumballMachine;
            _menu = new Menu(_textWriter, _textReader);
            _menu.AddItem("insertQuarter", "Insert quarter to gumball machine", InsertQuarter);
            _menu.AddItem("ejectQuarter", "Eject all quarters from gumball machine", EjectQuarter);
            _menu.AddItem("turnCrank", "Turn crank of gumball machine", TurnCrank);
            _menu.AddItem("refill", "Refill gumball machine with <balls number>", Refill);
            _menu.AddItem("toString", "Show gumball machine info", GMToString);
            _menu.AddItem("help", "Show help", ShowInstructions);
            _menu.AddItem("exit", "Exit programm", Exit);
        }

        public void Start()
        {
            _menu.Run();
        }

        private void InsertQuarter(string[] args)
        {
            if (args.Length != 1)
            {
                _textWriter.WriteLine("Wrong arguments! Usage: insertQuarter");
            }
            else
            {
                _gumballMachine.InsertQuarter();
            }
        }

        private void EjectQuarter(string[] args)
        {
            if (args.Length != 1)
            {
                _textWriter.WriteLine("Wrong arguments! Usage: ejectQuarter");
            }
            else
            {
                _gumballMachine.EjectQuarter();
            }
        }

        private void TurnCrank(string[] args)
        {
            if (args.Length != 1)
            {
                _textWriter.WriteLine("Wrong arguments! Usage: ejectQuarter");
            }
            else
            {
                _gumballMachine.TurnCrank();
            }
        }

        private void Refill(string[] args)
        {
            if (args.Length != 2)
            {
                _textWriter.WriteLine("Wrong arguments! Usage: refill <balls number>");
            }
            else
            {
                uint numBalls = uint.Parse(args[1]);
                _gumballMachine.Refill(numBalls);
            }
        }

        private void GMToString(string[] args)
        {
            if (args.Length != 1)
            {
                _textWriter.WriteLine("Wrong arguments! Usage: toString");
            }
            else
            {
                _textWriter.Write(_gumballMachine.ToString());
            }
        }

        private void Exit(string[] args)
        {
            _menu.Exit();
        }

        private void ShowInstructions(string[] args)
        {
            _menu.ShowInstructions();
        }
    }
}
