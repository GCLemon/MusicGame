using Altseed2;

namespace ScoreEditor
{
    class GUIEditMenu : GUIMenu
    {
        private GUIMenuItem _Undo;
        private GUIMenuItem _Redo;
        private GUIMenuItem _Cut;
        private GUIMenuItem _Copy;
        private GUIMenuItem _Paste;

        public GUIEditMenu()
        {
            Label = "Edit";

            _Undo = new GUIMenuItem { Label = "Undo",　Shortcut = "Ctrl + Z", IsEnabled = true };
            GUIItems.Add(_Undo);

            _Redo = new GUIMenuItem { Label = "Redo",　Shortcut = "Ctrl + Shift + Z", IsEnabled = true };
            GUIItems.Add(_Redo);

            _Cut = new GUIMenuItem { Label = "Cut",　Shortcut = "Ctrl + X", IsEnabled = true };
            GUIItems.Add(_Cut);

            _Copy = new GUIMenuItem { Label = "Copy",　Shortcut = "Ctrl + C", IsEnabled = true };
            GUIItems.Add(_Copy);

            _Paste = new GUIMenuItem { Label = "Paste",　Shortcut = "Ctrl + V", IsEnabled = true };
            GUIItems.Add(_Paste);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            if(InputManager.Instance.GetShortcut(Key.Z, false) || _Undo.IsPressed) OnUndo();
            if(InputManager.Instance.GetShortcut(Key.Z, true) || _Redo.IsPressed) OnRedo();
            if(InputManager.Instance.GetShortcut(Key.X, false) || _Cut.IsPressed) OnCut();
            if(InputManager.Instance.GetShortcut(Key.C, false) || _Copy.IsPressed) OnCopy();
            if(InputManager.Instance.GetShortcut(Key.V, false) || _Paste.IsPressed) OnPaste();
        }

        private void OnUndo()
        {
            ScoreData.Instance.Undo();
        }

        private void OnRedo()
        {
            ScoreData.Instance.Redo();
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