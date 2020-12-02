using Altseed2;

namespace MusicGame.Editor
{
    class SlideNoteNode : NoteNode
    {
        private Texture2D _NoteOrange;
        private Texture2D _NotePurple;

        private Texture2D _EndOrange;
        private Texture2D _EndPurple;

        private RectangleNode _HoldObject;
        private SpriteNode _EndObject;

        public SlideNoteNode(Core.SlideNote note) : base(note)
        {
            _NoteOrange = Texture2D.Load("Resource/Image/Note_Orange.png");
            _NotePurple = Texture2D.Load("Resource/Image/Note_Purple.png");

            _EndOrange = Texture2D.Load("Resource/Image/End_Orange.png");
            _EndPurple = Texture2D.Load("Resource/Image/End_Purple.png");

            _HoldObject = new RectangleNode();
            _EndObject = new SpriteNode();

            AddChildNode(_HoldObject);
            AddChildNode(_EndObject);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            switch(Note.LaneType)
            {
                case Core.LaneType.Orange:
                    Texture = _NoteOrange;
                    _EndObject.Texture = _EndOrange;
                    _HoldObject.Color = new Color(253, 151, 31, 127);
                    break;
                case Core.LaneType.Purple:
                    Texture = _NotePurple;
                    _EndObject.Texture = _EndPurple;
                    _HoldObject.Color = new Color(174, 129, 255, 127);
                    break;
            }
            Vector2F position = new Vector2F();
            position.X = 95;
            
            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)Note.Timing + scroll;

            Position = position;

            float length = (float)(((Core.SlideNote)Note).Length);
            _EndObject.Position = new Vector2F(0, -40 * length);

            _HoldObject.RectangleSize = new Vector2F(246, 40 * length - 4);
            _HoldObject.Position = new Vector2F(7, -40 * length + 8);
        }
    }
}