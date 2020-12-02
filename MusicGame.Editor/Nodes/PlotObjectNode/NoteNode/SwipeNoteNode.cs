using Altseed2;

namespace MusicGame.Editor
{
    class SwipeNoteNode : NoteNode
    {
        private Texture2D _NoteOrange;
        private Texture2D _NotePurple;

        public SwipeNoteNode(Core.SwipeNote note) : base(note)
        {
            _NoteOrange = Texture2D.Load("Resource/Image/Note_Orange.png");
            _NotePurple = Texture2D.Load("Resource/Image/Note_Purple.png");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            switch(Note.LaneType)
            {
                case Core.LaneType.Orange:
                    Texture = _NoteOrange;
                    break;
                case Core.LaneType.Purple:
                    Texture = _NotePurple;
                    break;
            }
            
            Vector2F position = new Vector2F();
            position.X = 95;
            
            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)Note.Timing + scroll;

            Position = position;
        }
    }
}