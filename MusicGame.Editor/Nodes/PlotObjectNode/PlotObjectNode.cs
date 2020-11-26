using Altseed2;

namespace MusicGame.Editor
{
    class PlotObjectNode : SpriteNode
    {
        public PlotObjectInfo ObjectInfo { get; }

        public PlotObjectNode(PlotObjectInfo info)
        {
            ObjectInfo = info;
        }

        protected override void OnUpdate()
        {
            switch(ObjectInfo.ObjectState)
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
}