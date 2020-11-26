using Altseed2;

namespace MusicGame.Editor
{
    class EditPaletteNode : GUIManagerNode
    {
        GUIWindow _Window;

        public EditPaletteNode()
        {
            AddGUIItem(GUIBuilder.Instance.CreateFromXMLFile("Resource/Widget/EditPalette.xml"));
            _Window = GetItemWithName<GUIWindow>("Edit Palette");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}