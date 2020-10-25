using System;

namespace Editor
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a command. For more info enter 'help'");
            var editor = new Editor(Console.Out, Console.In);
            editor.Start();
        }
    }
}
