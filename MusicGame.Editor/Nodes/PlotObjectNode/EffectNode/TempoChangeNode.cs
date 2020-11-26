using System;
using Altseed2;

namespace MusicGame.Editor
{
    class TempoChangeNode : PlotObjectNode
    {
        private TextNode _AfterTempo;

        public TempoChangeNode(PlotObjectInfo info) : base(info)
        {
            Texture = Texture2D.Load("Resource/Image/Tempo_Change.png");

            _AfterTempo = new TextNode();
            _AfterTempo.Font = Font.LoadDynamicFont("Resource/Image/Arial.ttf", 14);
            _AfterTempo.Color = new Color(166, 226,  46, 255);
            _AfterTempo.Position = new Vector2F(0, -12);
            AddChildNode(_AfterTempo);

            ObjectInfo.ObjectType = ObjectType.TempoChange;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            Vector2F position = new Vector2F();
            position.X = 102;

            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)ObjectInfo.Timing + scroll;

            Position = position;
            
            _AfterTempo.Text = "Next Tempo : " + ObjectInfo.AfterTempo + " bpm.";
        }
    }
}