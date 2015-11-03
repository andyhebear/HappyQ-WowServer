using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Client.Graphics
{
    public interface IDraw
    {
        void Draw(DrawState state);
    }

    public interface IBeginDraw
    {
        bool BeginDraw(DrawState state);
    }

    public interface IEndDraw
    {
        void EndDraw();
    }
}
