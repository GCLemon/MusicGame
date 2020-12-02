using Altseed2;

namespace MusicGame.Editor
{
    class BeatLineNode : LineNode
    {
        private int _BeatLineID;
        private TextNode _MeasureIDText;

        public BeatLineNode(int index)
        {
            _BeatLineID = index;

            Point1 = new Vector2F(0, 0);
            Point2 = new Vector2F(248, 0);
            Thickness = 2;

            _MeasureIDText = new TextNode();
            _MeasureIDText.Font = Font.LoadDynamicFont("Resource/Font/Arial.ttf", 20);
            _MeasureIDText.Color = new Color(255, 255, 255);
            _MeasureIDText.Text = "";
            _MeasureIDText.Position = new Vector2F(-20, 0);
            
            AddChildNode(_MeasureIDText);
        }

        protected override void OnUpdate()
        {
            float scroll = InputManager.Instance.GetTotalScroll() * 5;

            float assignedBeat = _BeatLineID + (int)scroll / 40;
            if(assignedBeat % 4 == 0)
            {
                Color = new Color(255, 255, 255, 192);
                _MeasureIDText.Text = (assignedBeat / 4).ToString();
            }
            else
            {
                Color = new Color(255, 255, 255, 127);
                _MeasureIDText.Text = "";
            }
            
            Position = new Vector2F(100, 640 - _BeatLineID * 40 + scroll % 40);

            Vector2F size = _MeasureIDText.ContentSize;
            _MeasureIDText.CenterPosition = size * new Vector2F(1.0f, 0.5f);
        }
    }
}