using Godot;
using System;

public class ControllerInput : Node
{
    public enum Keys { Up, Down, Left, Right, Accept, Cancel, Click, None };
    public event EventHandler<KeyPressedEventArgs> KeyPressed;

    public class KeyPressedEventArgs : EventArgs
    {
        private Keys _action;
        public Keys Action
        {
            get => _action;
            set => _action = value;
        }

        public KeyPressedEventArgs(Keys action)
        {
            this._action = action;
        }
    }

    public override void _Ready()
    {
		
    }
	
    public override void _Input(InputEvent ev)
	{
        Keys action = Keys.None;
        if (ev is InputEventKey keyEvent)
        {
            if (keyEvent.IsActionPressed("ui_up"))
            {
                action = Keys.Up;
            }
            else if (keyEvent.IsActionPressed("ui_down"))
            {
                action = Keys.Down;
            }
            else if (keyEvent.IsActionPressed("ui_left"))
            {
                action = Keys.Left;
            }
            else if (keyEvent.IsActionPressed("ui_right"))
            {
                action = Keys.Right;
            }
            else if (keyEvent.IsActionPressed("ui_accept"))
            {
                action = Keys.Accept;
            }
            else if (keyEvent.IsActionPressed("ui_cancel"))
            {
                action = Keys.Cancel;
            }
        }
        else if (ev is InputEventMouse mouseEvent)
        {
            if (mouseEvent.IsActionPressed("mouse_accept"))
            {
                action = Keys.Click;
            }
        }

        if (action != Keys.None)
        {
            OnKeyPressed(new KeyPressedEventArgs(action));
        }
    }

    protected virtual void OnKeyPressed(KeyPressedEventArgs eventArgs)
    {
        KeyPressed?.Invoke(this, eventArgs);
    }
}
