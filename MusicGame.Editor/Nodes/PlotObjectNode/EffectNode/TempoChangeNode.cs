using Altseed2;

namespace MusicGame.Editor
{
    class TempoChangeNode : EffectNode
    {
        private TextNode _AfterTempo;

        public TempoChangeNode(Core.TempoChange change) : base(change)
        {
            Texture = Texture2D.Load("Resource/Image/Tempo_Change.png");

            _AfterTempo = new TextNode();
            _AfterTempo.Font = Font.LoadDynamicFont("Resource/Image/Arial.ttf", 14);
            _AfterTempo.Color = new Color(166, 226,  46, 255);
            _AfterTempo.Position = new Vector2F(0, -12);
            AddChildNode(_AfterTempo);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            Vector2F position = new Vector2F();
            position.X = 102;

            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)((Core.TempoChange)Effect).Timing + scroll;

            Position = position;
            
            _AfterTempo.Text = "Next Tempo : " + ((Core.TempoChange)Effect).AfterTempo + " bpm.";
        }
    }
}