using System.Collections.Generic;
using System.Linq;
using Altseed2;

namespace MusicGame.Editor
{
    partial class EditSpaceNode : Node
    {
        public EditSpaceNode()
        {
            for(int i = -1; i <= 16; ++i) AddChildNode(new BeatLineNode(i));

            SpriteNode noteLane = new SpriteNode();
            noteLane.Texture = Texture2D.Load("Resource/Image/NoteLane.png");
            noteLane.Position = new Vector2F(94, 0);
            AddChildNode(noteLane);
        }

        protected override void OnUpdate()
        {
            switch(EditorModel.Instance.EditorMode)
            {
                case EditorMode.Append: OnAppend(); break;
                case EditorMode.Select: OnSelect(); break;
                case EditorMode.Delete: OnDelete(); break;
            }

            List<NoteNode> noteNodes = EnumerateDescendants<NoteNode>().ToList();
            List<Core.Note> notes = EditorModel.Instance.Score.Notes.ToList();

            foreach(Core.Note note in notes)
            {
                if(!noteNodes.Exists(x => x.Note == note))
                    switch(note.NoteType)
                    {
                        case Core.NoteType.TapNote:
                            AddChildNode(new TapNoteNode((Core.TapNote)note));
                            break;

                        case Core.NoteType.HoldNote:
                            AddChildNode(new HoldNoteNode((Core.HoldNote)note));
                            break;

                        case Core.NoteType.SwipeNote:
                            AddChildNode(new SwipeNoteNode((Core.SwipeNote)note));
                            break;

                        case Core.NoteType.SlideNote:
                            AddChildNode(new SlideNoteNode((Core.SlideNote)note));
                            break;
                    }
            }

            foreach(NoteNode node in noteNodes)
                if(!notes.Exists(x => node.Note == x)) RemoveChildNode(node);

            List<EffectNode> effectNodes = EnumerateDescendants<EffectNode>().ToList();
            List<Core.Effect> effects = EditorModel.Instance.Score.Effects.ToList();

            foreach(Core.Effect effect in effects)
                if(!effectNodes.Exists(x => x.Effect == effect))
                    switch(effect.EffectType)
                    {
                        case Core.EffectType.SpeedChange:
                            AddChildNode(new SpeedChangeNode((Core.SpeedChange)effect));
                            break;

                        case Core.EffectType.TempoChange:
                            AddChildNode(new TempoChangeNode((Core.TempoChange)effect));
                            break;

                        case Core.EffectType.MeasureChange:
                            AddChildNode(new MeasureChangeNode((Core.MeasureChange)effect));
                            break;
                    }

            foreach(EffectNode node in effectNodes)
                if(!effects.Exists(x => node.Effect == x)) RemoveChildNode(node);
        }
    }
}