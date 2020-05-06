namespace TurtleApp.Classes.Actions
{
    public class MoveAction : ITurtleAction
    {
        private readonly ITurtle _turtle;
        public MoveAction(ITurtle turtle)
        {
            _turtle = turtle;
        }

        public void Execute()
        {
            _turtle.Move(1);
        }

        public void Revert()
        {
            _turtle.Move(-1);
        }
    }
}