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

            if(_Window.GetItemWithAttr<GUIImageButton>("Append").IsClicked)
                EditorModel.Instance.EditorMode = EditorMode.Append;

            if(_Window.GetItemWithAttr<GUIImageButton>("Select").IsClicked)
                EditorModel.Instance.EditorMode = EditorMode.Select;
                
            if(_Window.GetItemWithAttr<GUIImageButton>("Delete").IsClicked)
                EditorModel.Instance.EditorMode = EditorMode.Delete;

            switch(EditorModel.Instance.EditorMode)
            {
                case EditorMode.Append: OnAppend(); break;
                case EditorMode.Select: OnSelect(); break;
                case EditorMode.Delete: OnDelete(); break;
            }
        }

        private void OnAppend()
        {
            SetAppendGUI(true);
        }

        private void OnSelect()
        {
            SetAppendGUI(false);
        }

        private void OnDelete()
        {
            SetAppendGUI(false);
        }

        private void SetAppendGUI(bool showGUI)
        {
            _Window.GetItemWithName("Object Palette : ").IsUpdated = showGUI;

            _Window.GetItemWithAttr("Tap_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("Hold_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("Swipe_Right_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("Slide_Right_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("Swipe_Left_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("Slide_Left_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("SpeedChange_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("TempoChange_Button").IsUpdated = showGUI;
            _Window.GetItemWithAttr("MeasureChange_Button").IsUpdated = showGUI;

            _Window.GetItemWithName("Timing :        ").IsUpdated = showGUI;
            _Window.GetItemWithName("Length :        ").IsUpdated = showGUI;
            _Window.GetItemWithName("After Speed :   ").IsUpdated = showGUI;
            _Window.GetItemWithName("After Tempo :   ").IsUpdated = showGUI;
            _Window.GetItemWithName("After Measure : ").IsUpdated = showGUI;
            
            _Window.GetItemWithAttr("Timing").IsUpdated = showGUI;
            _Window.GetItemWithAttr("Length").IsUpdated = showGUI;
            _Window.GetItemWithAttr("AfterSpeed").IsUpdated = showGUI;
            _Window.GetItemWithAttr("AfterTempo").IsUpdated = showGUI;
            _Window.GetItemWithAttr("AfterMeasure").IsUpdated = showGUI;
        }
    }
}