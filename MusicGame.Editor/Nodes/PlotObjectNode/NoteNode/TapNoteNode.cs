using Altseed2;

namespace MusicGame.Editor
{
    class TapNoteNode : NoteNode
    {
        private Texture2D _NoteRed;
        private Texture2D _NoteYellow;
        private Texture2D _NoteGreen;
        private Texture2D _NoteBlue;

        public TapNoteNode(Core.TapNote note) : base(note)
        {
            _NoteRed = Texture2D.Load("Resource/Image/Note_Red.png");
            _NoteYellow = Texture2D.Load("Resource/Image/Note_Yellow.png");
            _NoteGreen = Texture2D.Load("Resource/Image/Note_Green.png");
            _NoteBlue = Texture2D.Load("Resource/Image/Note_Blue.png");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            Vector2F position = new Vector2F();
            switch(Note.LaneType)
            {
                case Core.LaneType.Red:
                    position.X = 288;
                    Texture = _NoteRed;
                    break;
                case Core.LaneType.Yellow:
                    position.X = 226;
                    Texture = _NoteYellow;
                    break;
                case Core.LaneType.Green:
                    position.X = 164;
                    Texture = _NoteGreen;
                    break;
                case Core.LaneType.Blue:
                    position.X = 102;
                    Texture = _NoteBlue;
                    break;
            }

            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)Note.Timing + scroll;

            Position = position;
        }
    }
}