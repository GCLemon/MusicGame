using System.Collections.Generic;
using System.Linq;

namespace ScoreEditor
{
    class EditSpaceOnDelete
    {
        private EditSpaceNode _EditSpaceNode;
        
        public EditSpaceOnDelete(EditSpaceNode node)
        {
            _EditSpaceNode = node;
        }
        
        public void Update()
        {
            List<PlotObjectNode> nodes = _EditSpaceNode.EnumerateDescendants<PlotObjectNode>().ToList();

            foreach(PlotObjectNode node in nodes)
                if(node.GetIsClicked())
                {
                    ScoreData.Instance.Save();
                    ScoreData.Instance.PlotedObjects.Remove(node.ObjectInfo);
                }
        }
    }
}