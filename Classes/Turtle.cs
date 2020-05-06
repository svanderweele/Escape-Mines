using System.Numerics;

namespace TurtleApp.Classes
{
    public class Turtle : ITurtle
    {
        private Vector2 _position;
        private int _rotation;

        public Vector2 GetPosition()
        {
            return _position;
        }

        public void Init(int x, int y, int initialRotation)
        {
            _position = new Vector2(x, y);
            _rotation = initialRotation;
        }

        public void Move(int direction)
        {
            Vector2 moveVelocity = Vector2.Zero;

            if (_rotation == 0)
            {
                moveVelocity.X = -1;
            }
            if (_rotation == 90)
            {
                moveVelocity.Y = 1;
            }
            if (_rotation == 180)
            {
                moveVelocity.X = 1;
            }
            if (_rotation == 270)
            {
                moveVelocity.Y = -1;
            }

            _position += moveVelocity * direction;
        }

        public void Rotate(RotationDirection rotationDirection)
        {
            if (rotationDirection == RotationDirection.Left)
            {
                _rotation -= 90;
            }
            if (rotationDirection == RotationDirection.Right)
            {
                _rotation += 90;
            }

            if (_rotation < 0)
            {
                _rotation += 360;
            }

            if (_rotation >= 360)
            {
                _rotation -= 360;
            }

            System.Console.WriteLine("Turtle Rotation: {0}", _rotation);

        }
    }
}