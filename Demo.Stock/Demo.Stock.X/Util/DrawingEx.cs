using System.Drawing;

namespace Demo.Stock.X.Util
{
    public static class DrawingEx
    {
        public static int SetBitmap( string strPath )
        {
            Bitmap bitmap = new Bitmap( strPath );
            return bitmap.GetHbitmap().ToInt32();
        }

        public static int SetIcon( string strPath )
        {
            Icon icon = new Icon( strPath );
            return icon.Handle.ToInt32();
        }
    }
}
