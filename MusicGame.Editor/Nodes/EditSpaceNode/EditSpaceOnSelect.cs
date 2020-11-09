using System.Collections.Generic;
using System.Linq;
using Altseed2;

namespace ScoreEditor
{
    class EditSpaceOnSelect
    {
        private EditSpaceNode _EditSpaceNode;
        
        public EditSpaceOnSelect(EditSpaceNode node)
        {
            _EditSpaceNode = node;
        }

        public void Update()
        {
            List<PlotObjectNode> nodes = _EditSpaceNode.EnumerateDescendants<PlotObjectNode>().ToList();

            foreach(PlotObjectNode node in nodes)
                if(node.GetIsClicked())
                {
                    ButtonState lShift = Engine.Keyboard.GetKeyState(Key.LeftShift);
                    ButtonState rShift = Engine.Keyboard.GetKeyState(Key.LeftShift);
                    if(lShift != ButtonState.Hold || rShift != ButtonState.Hold)
                        foreach(PlotObjectNode n in nodes) n.ObjectInfo.ObjectState = ObjectState.Unselected;

                    node.ObjectInfo.ObjectState = ObjectState.Selected;
                }
        }
    }
}