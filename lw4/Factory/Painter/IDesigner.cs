using System.IO;

namespace Painter
{
    public interface IDesigner
    {
        PictureDraft CreateDraft(TextReader inputData);
    }
}
