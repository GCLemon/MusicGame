using Altseed2;

namespace MusicGame.Editor
{
    class InputManager
    {
        public static InputManager Instance { get; } = new InputManager();

        private float _TotalScroll;

        private InputManager() { }

        public void Update()
        {
            _TotalScroll += Engine.Mouse.Wheel;
            _TotalScroll = System.Math.Max(_TotalScroll, 0);
        }

        public bool GetShortcut(Key key, bool withShift)
        {
            ButtonState stateLCtrl = Engine.Keyboard.GetKeyState(Key.LeftControl);
            ButtonState stateRCtrl = Engine.Keyboard.GetKeyState(Key.RightControl);
            ButtonState stateLShift = Engine.Keyboard.GetKeyState(Key.LeftShift);
            ButtonState stateRShift = Engine.Keyboard.GetKeyState(Key.RightShift);
            ButtonState stateKey = Engine.Keyboard.GetKeyState(key);
            
            bool ctrlState = (stateLCtrl == ButtonState.Hold) || (stateRCtrl == ButtonState.Hold);
            bool shiftState = (stateLShift == ButtonState.Hold) || (stateRShift == ButtonState.Hold);

            if(withShift) return ctrlState && shiftState && stateKey == ButtonState.Push;
            else return ctrlState && !shiftState && stateKey == ButtonState.Push;
        }

        public float GetTotalScroll()
        {
            return _TotalScroll;
        }

        public bool GetMousePush(MouseButton button)
        {
            ButtonState state = Engine.Mouse.GetMouseButtonState(button);
            return state == ButtonState.Push;
        }

        public bool GetMouseHold(MouseButton button)
        {
            ButtonState state = Engine.Mouse.GetMouseButtonState(button);
            return state == ButtonState.Hold;
        }

        public bool GetMouseRelease(MouseButton button)
        {
            ButtonState state = Engine.Mouse.GetMouseButtonState(button);
            return state == ButtonState.Release;
        }

        public bool GetMouseFree(MouseButton button)
        {
            ButtonState state = Engine.Mouse.GetMouseButtonState(button);
            return state == ButtonState.Free;
        }

        public Vector2F GetMousePosition()
        {
            return Engine.Mouse.Position;
        }
    }
}