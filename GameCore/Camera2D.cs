using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameCore
{
    public class Camera2d
    {
        public Matrix Transform;
        public Vector2 Pos;
        protected float Rotation;
        private float _zoom;

        //private const float VIRTUAL_WIDTH = 1280;
        //private const float VIRTUAL_HEIGHT = 720;
        private const float VIRTUAL_WIDTH = 1366;
        private const float VIRTUAL_HEIGHT = 768;

        public float Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;

                if (_zoom <= 0f)
                    throw new Exception(
                        "Cameras Zoom must be greater than zero! Negative zoom will flip image"
                    );
            }
        }

        public Camera2d()
        {
            _zoom = 1.0f;
            Rotation = 0.0f;
            Pos = Vector2.Zero;
        }

        public Matrix GetTransformation(GraphicsDevice graphicsDevice)
        {
            var widthDiff = graphicsDevice.Viewport.Width / VIRTUAL_WIDTH;
            var HeightDiff = graphicsDevice.Viewport.Height / VIRTUAL_HEIGHT;

            Transform =
              Matrix.CreateTranslation(
                  new Vector3(-Pos.X, -Pos.Y, 0))
                    * Matrix.CreateRotationZ(Rotation)
                    * Matrix.CreateScale(new Vector3(Zoom * widthDiff, Zoom * HeightDiff, 1))
                    * Matrix.CreateTranslation(new Vector3(
                        graphicsDevice.Viewport.Width * 0.5f,
                        graphicsDevice.Viewport.Height * 0.5f, 0));

            return Transform;
        }

        public Vector2 ToWorldLocation(Vector2 position)
        {
            return Vector2.Transform(
                position
                , Matrix.Invert(Transform)
            );
        }

        public Vector2 ToLocalLocation(Vector2 position)
        {
            return Vector2.Transform(position, Transform);
        }
    }
}
