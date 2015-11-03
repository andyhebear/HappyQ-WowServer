using Microsoft.Xna.Framework;

namespace Client.Graphics.Particles
{
    public struct Particle
    {
        public Vector2 Position;
        public float Scale;
        public float Rotation;
        public Vector4 Color;
        public Vector2 Momentum;
        public Vector2 Velocity;
        public float Inception;
        public float Age;

        public void ApplyForce(ref Vector2 force)
        {
            Velocity.X += force.X;
            Velocity.Y += force.Y;
        }

        public void Rotate(float radians)
        {
            Rotation += radians;

            if (Rotation > MathHelper.Pi)
                Rotation -= MathHelper.TwoPi;
            else if (Rotation < -MathHelper.Pi)
                Rotation += MathHelper.TwoPi;
        }
    }
}
