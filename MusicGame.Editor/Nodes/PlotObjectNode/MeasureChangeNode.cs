using System;
using Altseed2;

namespace ScoreEditor
{
    class MeasureChangeNode : PlotObjectNode
    {
        private TextNode _AfterMeasure;

        public MeasureChangeNode(PlotObjectInfo info) : base(info)
        {
            Texture = Texture2D.Load("Resource/Measure_Change.png");

            _AfterMeasure = new TextNode();
            _AfterMeasure.Font = Font.LoadDynamicFont("Resource/Arial.ttf", 14);
            _AfterMeasure.Color = new Color(253, 151,  31, 255);
            _AfterMeasure.Position = new Vector2F(0, -12);
            AddChildNode(_AfterMeasure);

            ObjectInfo.ObjectType = ObjectType.MeasureChange;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            Vector2F position = new Vector2F();
            position.X = 102;

            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)ObjectInfo.Timing + scroll;

            Position = position;
            
            _AfterMeasure.Text = "Next Measure : " + ObjectInfo.AfterMeasure + " beats.";
        }
    }
}