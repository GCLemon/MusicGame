using System;
using Altseed2;

namespace ScoreEditor
{
    class SwipeNoteNode : PlotObjectNode
    {
        private Texture2D _NoteOrange;
        private Texture2D _NotePurple;

        public SwipeNoteNode(PlotObjectInfo info) : base(info)
        {
            _NoteOrange = Texture2D.Load("Resource/Note_Orange.png");
            _NotePurple = Texture2D.Load("Resource/Note_Purple.png");
            
            ObjectInfo.ObjectType = ObjectType.SwipeNote;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            switch(ObjectInfo.LaneType)
            {
                case LaneType.Orange:
                    Texture = _NoteOrange;
                    break;
                case LaneType.Purple:
                    Texture = _NotePurple;
                    break;
            }
            
            Vector2F position = new Vector2F();
            position.X = 95;
            
            float scroll = InputManager.Instance.GetTotalScroll() * 5;
            position.Y = 634 - 40 * (float)ObjectInfo.Timing + scroll;

            Position = position;
        }
    }
}