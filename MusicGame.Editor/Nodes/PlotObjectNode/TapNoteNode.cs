using System;
using Altseed2;

namespace ScoreEditor
{
    class TapNoteNode : PlotObjectNode
    {
        private Texture2D _NoteRed;
        private Texture2D _NoteYellow;
        private Texture2D _NoteGreen;
        private Texture2D _NoteBlue;

        public TapNoteNode(PlotObjectInfo info) : base(info)
        {
            _NoteRed = Texture2D.Load("Resource/Note_Red.png");
            _NoteYellow = Texture2D.Load("Resource/Note_Yellow.png");
            _NoteGreen = Texture2D.Load("Resource/Note_Green.png");
            _NoteBlue = Texture2D.Load("Resource/Note_Blue.png");

            ObjectInfo.ObjectType = ObjectType.TapNote;
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
                    break;
                case LaneType.Yellow:
                    position.X = 226;
                    Texture = _NoteYellow;
                    break;
                case LaneType.Green:
                    position.X = 164;
                    Texture = _NoteGreen;
                    break;
                case LaneType.Blue:
                    position.X = 102;
                    Texture = _NoteBlue;
                    break;
            }

            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)ObjectInfo.Timing + scroll;

            Position = position;
        }
    }
}