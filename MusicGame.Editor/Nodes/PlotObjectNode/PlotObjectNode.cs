using Altseed2;

namespace MusicGame.Editor
{
    abstract class PlotObjectNode : SpriteNode
    {
        public ObjectState State { get; set; }

        protected override void OnUpdate()
        {
            switch(State)
            {
                case ObjectState.Unselected:
                    Color = new Color(255, 255, 255);
                    break;
                case ObjectState.Selected:
                    Color = new Color(255, 255, 0);
                    break;
                case ObjectState.Moving:
                    Color = new Color(255, 255, 255, 192);
                    break;
            }
        }

        public bool GetIsHovered()
        {
            Vector2F mousePos = InputManager.Instance.GetMousePosition();
            bool isInRangeX = Position.X <= mousePos.X && mousePos.X <= Position.X + ContentSize.X;
            bool isInRangeY = Position.Y <= mousePos.Y && mousePos.Y <= Position.Y + ContentSize.Y;
            return isInRangeX && isInRangeY;
        }

        public bool GetIsClicked()
        {
            bool mousePush = InputManager.Instance.GetMousePush(MouseButton.ButtonLeft);
            return GetIsHovered() && mousePush;
        }
    }
    
    abstract class NoteNode : PlotObjectNode
    {
        public Core.Note Note { get; }

        public NoteNode(Core.Note note)
        {
            Note = note;
        }
    }

    abstract class EffectNode : PlotObjectNode
    {
        public Core.Effect Effect { get; }

        public EffectNode(Core.Effect effect)
        {
            Effect = effect;
        }
    }
}