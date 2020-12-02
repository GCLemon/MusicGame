using Altseed2;

namespace MusicGame.Editor
{
    class SpeedChangeNode : EffectNode
    {
        private TextNode _AfterSpeed;

        public SpeedChangeNode(Core.SpeedChange change) : base(change)
        {
            Texture = Texture2D.Load("Resource/Image/Speed_Change.png");

            _AfterSpeed = new TextNode();
            _AfterSpeed.Font = Font.LoadDynamicFont("Resource/Image/Arial.ttf", 14);
            _AfterSpeed.Color = new Color(102, 217, 239, 255);
            _AfterSpeed.Position = new Vector2F(0, -12);
            AddChildNode(_AfterSpeed);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            Vector2F position = new Vector2F();
            position.X = 102;

            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)((Core.SpeedChange)Effect).Timing + scroll;

            Position = position;
            
            _AfterSpeed.Text = "Next Speed : ×" + ((Core.SpeedChange)Effect).AfterSpeed;
        }
    }
}