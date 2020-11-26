using System;
using Altseed2;

namespace MusicGame.Editor
{
    class HoldNoteNode : PlotObjectNode
    {
        private Texture2D _NoteRed;
        private Texture2D _NoteYellow;
        private Texture2D _NoteGreen;
        private Texture2D _NoteBlue;

        private Texture2D _EndRed;
        private Texture2D _EndYellow;
        private Texture2D _EndGreen;
        private Texture2D _EndBlue;

        private RectangleNode _HoldObject;
        private SpriteNode _EndObject;

        public HoldNoteNode(PlotObjectInfo info) : base(info)
        {
            _NoteRed = Texture2D.Load("Resource/Image/Note_Red.png");
            _NoteYellow = Texture2D.Load("Resource/Image/Note_Yellow.png");
            _NoteGreen = Texture2D.Load("Resource/Image/Note_Green.png");
            _NoteBlue = Texture2D.Load("Resource/Image/Note_Blue.png");

            _EndRed = Texture2D.Load("Resource/Image/End_Red.png");
            _EndYellow = Texture2D.Load("Resource/Image/End_Yellow.png");
            _EndGreen = Texture2D.Load("Resource/Image/End_Green.png");
            _EndBlue = Texture2D.Load("Resource/Image/End_Blue.png");

            ObjectInfo.ObjectType = ObjectType.HoldNote;

            _HoldObject = new RectangleNode();
            _EndObject = new SpriteNode();

            AddChildNode(_HoldObject);
            AddChildNode(_EndObject);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            Vector2F position = new Vector2F();
            switch(ObjectInfo.LaneType)
            {
                case LaneType.Red:
                    position.X = 288;
                    Texture = _NoteRed;
                    _EndObject.Texture = _EndRed;
                    _HoldObject.Color = new Color(249, 38, 114, 127);
                    break;
                case LaneType.Yellow:
                    position.X = 226;
                    Texture = _NoteYellow;
                    _EndObject.Texture = _EndYellow;
                    _HoldObject.Color = new Color(230, 219, 116, 127);
                    break;
                case LaneType.Green:
                    position.X = 164;
                    Texture = _NoteGreen;
                    _EndObject.Texture = _EndGreen;
                    _HoldObject.Color = new Color(116, 226, 46, 127);
                    break;
                case LaneType.Blue:
                    position.X = 102;
                    Texture = _NoteBlue;
                    _EndObject.Texture = _EndBlue;
                    _HoldObject.Color = new Color(102, 217, 229, 127);
                    break;
            }

            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)ObjectInfo.Timing + scroll;

            Position = position;

            float length = (float)(ObjectInfo.Length);
            _EndObject.Position = new Vector2F(0, -40 * length);

            _HoldObject.RectangleSize = new Vector2F(58, 40 * length - 4);
            _HoldObject.Position = new Vector2F(1, -40 * length + 8);
        }
    }
}