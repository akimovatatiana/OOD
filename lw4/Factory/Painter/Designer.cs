using System;
using System.IO;

namespace Painter
{
    public class Designer
    {
        private readonly IShapeFactory _factory;

        public Designer(IShapeFactory factory)
        {
            _factory = factory;
        }

        public PictureDraft CreateDraft(TextReader inputData)
        {
            PictureDraft draft = new PictureDraft();
            string line;
            while ((line = inputData.ReadLine()) != null && line != "exit")
            {
                try
                {
                    draft.AddShape(_factory.CreateShape(line));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
            return draft;
        }
    }
}
