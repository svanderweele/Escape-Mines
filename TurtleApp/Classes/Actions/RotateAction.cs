namespace TurtleApp.Classes.Actions
{
    public class RotateAction : ITurtleAction
    {
        private readonly ITurtle _turtle;
        private readonly RotationDirection _rotationDirection;
        private readonly RotationDirection _oppositeRotationDirection;

        public RotateAction(ITurtle turtle, RotationDirection rotationDirection, RotationDirection oppositeRotationDirection)
        {
            _turtle = turtle;
            _rotationDirection = rotationDirection;
            _oppositeRotationDirection = oppositeRotationDirection;
        }
        public void Execute()
        {
            _turtle.Rotate(_rotationDirection);
        }

        public void Revert()
        {
            _turtle.Rotate(_oppositeRotationDirection);
        }
    }
}