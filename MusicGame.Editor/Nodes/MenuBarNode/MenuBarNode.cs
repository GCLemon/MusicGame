using Altseed2;

namespace MusicGame.Editor
{
    class MenuBarNode : GUIManagerNode
    {
        GUIMainMenuBar _MenuBar;
        
        public MenuBarNode()
        {
            AddGUIItem(GUIBuilder.Instance.CreateFromXMLFile("Resource/Widget/MainMenuBar.xml"));
            _MenuBar = GetItemWithName<GUIMainMenuBar>("MainMenu");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}