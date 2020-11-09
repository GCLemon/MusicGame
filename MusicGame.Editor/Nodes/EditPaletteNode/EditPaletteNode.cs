using Altseed2;

namespace ScoreEditor
{
    class EditPaletteNode : Node
    {
        private GUIWindow _EditPaletteWindow;

        private GUIEditPaletteConstItems _ConstItems;
        private GUIEditPaletteOnAppendItems _OnAppendItems;
        private GUIEditPaletteOnSelectItems _OnSelectItems;

        public EditPaletteNode()
        {
            _EditPaletteWindow = new GUIWindow();

            _ConstItems = new GUIEditPaletteConstItems();
            _OnAppendItems = new GUIEditPaletteOnAppendItems();
            _OnSelectItems = new GUIEditPaletteOnSelectItems();

            _EditPaletteWindow.Label = "Edit Palette";

            _EditPaletteWindow.WindowFlags |= ToolWindowFlags.NoMove;
            _EditPaletteWindow.WindowFlags |= ToolWindowFlags.NoResize;
            _EditPaletteWindow.WindowFlags |= ToolWindowFlags.NoTitleBar;
            
            _EditPaletteWindow.GUIItems.Add(_ConstItems);
            _EditPaletteWindow.GUIItems.Add(new GUISeparator());
            _EditPaletteWindow.GUIItems.Add(_OnAppendItems);
            _EditPaletteWindow.GUIItems.Add(_OnSelectItems);
        }

        protected override void OnUpdate()
        {
            switch(EditorData.Instance.EditorMode)
            {
                case EditorMode.Append:
                    _OnAppendItems.IsUpdated = true;
                    _OnSelectItems.IsUpdated = false;
                    break;
                case EditorMode.Select:
                    _OnAppendItems.IsUpdated = false;
                    _OnSelectItems.IsUpdated = true;
                    break;
                case EditorMode.Delete:
                    _OnAppendItems.IsUpdated = false;
                    _OnSelectItems.IsUpdated = false;
                    break;
            }

            _EditPaletteWindow.Update();
        }
    }
}