using Microsoft.Xna.Framework;

namespace Client.Graphics
{
    public interface ICamera
    {
        int FarClip { get; set; }
        int NearClip { get; set; }
        Vector2 Position { get; set; }
        Vector2 HalfVector { get; }
        Matrix Projection { get; }
        //Matrix View { get; }
        BoundingFrustum BoundingFrustum { get; }
    }
}
