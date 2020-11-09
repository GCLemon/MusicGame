using Altseed2;

namespace ScoreEditor
{
    class GUIFileMenu : GUIMenu
    {
        private GUIMenuItem _New;
        private GUIMenuItem _Open;
        private GUIMenuItem _Save;
        private GUIMenuItem _SaveAs;
        private GUIMenuItem _Quit;

        public GUIFileMenu()
        {
            Label = "File";

            _New = new GUIMenuItem { Label = "New",　Shortcut = "Ctrl + N", IsEnabled = true };
            GUIItems.Add(_New);

            _Open = new GUIMenuItem { Label = "Open",　Shortcut = "Ctrl + O", IsEnabled = true };
            GUIItems.Add(_Open);

            _Save = new GUIMenuItem { Label = "Save",　Shortcut = "Ctrl + S", IsEnabled = true };
            GUIItems.Add(_Save);

            _SaveAs = new GUIMenuItem { Label = "SaveAs",　Shortcut = "Ctrl + Shift + S", IsEnabled = true };
            GUIItems.Add(_SaveAs);

            _Quit = new GUIMenuItem { Label = "Quit",　Shortcut = "Ctrl + Q", IsEnabled = true };
            GUIItems.Add(_Quit);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if(InputManager.Instance.GetShortcut(Key.N, false) || _New.IsPressed) OnNew();
            if(InputManager.Instance.GetShortcut(Key.O, false) || _Open.IsPressed) OnOpen();
            if(InputManager.Instance.GetShortcut(Key.S, false) || _Save.IsPressed) OnSave();
            if(InputManager.Instance.GetShortcut(Key.S, true) || _SaveAs.IsPressed) OnSaveAs();
            if(InputManager.Instance.GetShortcut(Key.Q, false) || _Quit.IsPressed) OnQuit();
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
    }
}