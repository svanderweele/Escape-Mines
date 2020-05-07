using System.Numerics;

namespace TurtleApp.Classes
{
    public interface ITurtle
    {
        void Init(int x, int y, int initialRotation);
        void Rotate(RotationDirection rotationDirection);
        void Move(int direction);
        Vector2 GetPosition();
    }
}