namespace Slides
{
    public struct Rect<T>
    {
        public T Left { get; }
        public T Top { get; }
        public T Width { get; }
        public T Height { get; }

        public Rect(T left, T top, T width, T height)
        {
            Left = left;
            Width = width;
            Top = top;
            Height = height;
        }
    }
}
