namespace TurtleApp.Classes.Actions
{
    public class ActionSequence : IActionSequence
    {
        private readonly ITurtleAction[] _actions;

        public ActionSequence(ITurtleAction[] actions)
        {
            _actions = actions;
        }
        public ITurtleAction[] GetActions()
        {
            return _actions;
        }
    }
}