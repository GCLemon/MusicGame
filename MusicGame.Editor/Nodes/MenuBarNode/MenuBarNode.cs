using Altseed2;

namespace MusicGame.Editor
{
    class MenuBarNode : GUIManagerNode
    {
        GUIMenu _FileMenu;
        GUIMenu _EditMenu;

        public MenuBarNode()
        {
            AddGUIItem(GUIBuilder.Instance.CreateFromXMLFile("Resource/Widget/MainMenuBar.xml"));

            GUIMainMenuBar bar = GetItemWithAttr<GUIMainMenuBar>("MainMenu");
            _FileMenu = bar.GetItemWithName<GUIMenu>("File");
            _EditMenu = bar.GetItemWithName<GUIMenu>("Edit");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            bool shortcut, button;

            shortcut = InputManager.Instance.GetShortcut(Key.N, false);
            button = _FileMenu.GetItemWithName("New").IsPressed;
            if(shortcut || button) OnNew();

            shortcut = InputManager.Instance.GetShortcut(Key.O, false);
            button = _FileMenu.GetItemWithName("Open").IsPressed;
            if(shortcut || button) OnOpen();

            shortcut = InputManager.Instance.GetShortcut(Key.S, false);
            button = _FileMenu.GetItemWithName("Save").IsPressed;
            if(shortcut || button) OnSave();

            shortcut = InputManager.Instance.GetShortcut(Key.S, true);
            button = _FileMenu.GetItemWithName("Save As").IsPressed;
            if(shortcut || button) OnSaveAs();

            shortcut = InputManager.Instance.GetShortcut(Key.Q, false);
            button = _FileMenu.GetItemWithName("Quit").IsPressed;
            if(shortcut || button) OnQuit();

            shortcut = InputManager.Instance.GetShortcut(Key.Z, false);
            button = _EditMenu.GetItemWithName("Undo").IsPressed;
            if(shortcut || button) OnUndo();

            shortcut = InputManager.Instance.GetShortcut(Key.Z, true);
            button = _EditMenu.GetItemWithName("Redo").IsPressed;
            if(shortcut || button) OnRedo();

            shortcut = InputManager.Instance.GetShortcut(Key.X, false);
            button = _EditMenu.GetItemWithName("Cut").IsPressed;
            if(shortcut || button) OnCut();

            shortcut = InputManager.Instance.GetShortcut(Key.C, false);
            button = _EditMenu.GetItemWithName("Copy").IsPressed;
            if(shortcut || button) OnCopy();

            shortcut = InputManager.Instance.GetShortcut(Key.V, false);
            button = _EditMenu.GetItemWithName("Paste").IsPressed;
            if(shortcut || button) OnPaste();
        }

        private void OnNew()
        {
            
        }

        private void OnOpen()
        {

        }

        private void OnSave()
        {

        }

        private void OnSaveAs()
        {

        }

        private void OnQuit()
        {

        }

        private void OnUndo()
        {
            EditorModel.Instance.Undo();
        }

        private void OnRedo()
        {
            EditorModel.Instance.Redo();
        }

        private void OnCut()
        {

        }

        private void OnCopy()
        {

        }

        private void OnPaste()
        {

        }
    }
}