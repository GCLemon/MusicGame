using System.Collections.Generic;
using System.Linq;
using Altseed2;

namespace ScoreEditor
{
    class EditSpaceNode : Node
    {
        private EditSpaceOnAppend _OnAppendNode;
        private EditSpaceOnSelect _OnSelectNode;
        private EditSpaceOnDelete _OnDeleteNode;

        public EditSpaceNode()
        {
            for(int i = -1; i <= 16; ++i) AddChildNode(new BeatLineNode(i));

            SpriteNode noteLane = new SpriteNode();
            noteLane.Texture = Texture2D.Load("Resource/NoteLane.png");
            noteLane.Position = new Vector2F(94, 0);
            AddChildNode(noteLane);

            _OnAppendNode = new EditSpaceOnAppend(this);
            _OnSelectNode = new EditSpaceOnSelect(this);
            _OnDeleteNode = new EditSpaceOnDelete(this);
        }

        protected override void OnUpdate()
        {
            List<PlotObjectNode> nodes = EnumerateDescendants<PlotObjectNode>().ToList();
            List<PlotObjectInfo> infos = ScoreData.Instance.PlotedObjects;

            foreach(PlotObjectInfo info in infos)
                if(!nodes.Exists(x => x.ObjectInfo == info))
                    switch(info.ObjectType)
                    {
                        case ObjectType.TapNote: AddChildNode(new TapNoteNode(info)); break;
                        case ObjectType.HoldNote: AddChildNode(new HoldNoteNode(info)); break;
                        case ObjectType.SwipeNote: AddChildNode(new SwipeNoteNode(info)); break;
                        case ObjectType.SlideNote: AddChildNode(new SlideNoteNode(info)); break;
                        case ObjectType.SpeedChange: AddChildNode(new SpeedChangeNode(info)); break;
                        case ObjectType.TempoChange: AddChildNode(new TempoChangeNode(info)); break;
                        case ObjectType.MeasureChange: AddChildNode(new MeasureChangeNode(info)); break;
                    }

            foreach(PlotObjectNode node in nodes)
                if(!infos.Exists(x => node.ObjectInfo == x)) RemoveChildNode(node);

            switch(EditorData.Instance.EditorMode)
            {
                case EditorMode.Append: _OnAppendNode.Update(); break;
                case EditorMode.Select: _OnSelectNode.Update(); break;
                case EditorMode.Delete: _OnDeleteNode.Update(); break;
            }
        }
    }
}