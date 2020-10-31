using System;

namespace Adapter
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Should we use new API (y)?");
            Console.Write(">");
            string userInput = Console.ReadLine();
            if (userInput != null && userInput.ToLower() == "y")
            {
                App.App.PaintPictureOnMGRObjectAdapter();
                Console.WriteLine("------------");
                App.App.PaintPictureOnMGRClassAdapter();
            }
            else
            {
                App.App.PaintPictureOnCanvas();
            }
        }
    }
}
