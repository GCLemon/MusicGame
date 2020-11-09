using Altseed2;

namespace ScoreEditor
{
    class MenuBarNode : Node
    {
        GUIMainMenuBar _MainMenuBar;

        public MenuBarNode()
        {
            _MainMenuBar = new GUIMainMenuBar();
            _MainMenuBar.GUIItems.Add(new GUIFileMenu());
            _MainMenuBar.GUIItems.Add(new GUIEditMenu());
        }

        protected override void OnUpdate()
        {
            _MainMenuBar.Update();
        }
    }
}