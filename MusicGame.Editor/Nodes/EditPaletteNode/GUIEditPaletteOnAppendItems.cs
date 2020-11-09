using System.Collections.Generic;
using Altseed2;

namespace ScoreEditor
{
    class GUIEditPaletteOnAppendItems : GUIItem
    {
        private List<GUIItem> _GUIItems;

        private GUIImageButton _TapNoteButton;
        private GUIImageButton _HoldNoteButton;
        private GUIImageButton _SwipeNoteRightButton;
        private GUIImageButton _SlideNoteRightButton;
        private GUIImageButton _SwipeNoteLeftButton;
        private GUIImageButton _SlideNoteLeftButton;
        private GUIImageButton _SpeedChangeButton;
        private GUIImageButton _TempoChangeButton;
        private GUIImageButton _MeasureChangeButton;

        private GUIInputFloat _DefaultLengthBox;
        private GUIInputFloat _DefaultNextSpeedBox;
        private GUIInputFloat _DefaultNextTempoBox;
        private GUIInputInt _DefaultNextMeasureBox;

        public GUIEditPaletteOnAppendItems()
        {
            _GUIItems = new List<GUIItem>();

            _GUIItems.Add(new GUIText { Label = "Object Palette :" });

            _TapNoteButton = new GUIImageButton { Image = Texture2D.Load("Resource/Tap_Button.png"), SameLine = false };
            _GUIItems.Add(_TapNoteButton);

            _HoldNoteButton = new GUIImageButton { Image = Texture2D.Load("Resource/Hold_Button.png"), SameLine = true };
            _GUIItems.Add(_HoldNoteButton);

            _SwipeNoteRightButton = new GUIImageButton { Image = Texture2D.Load("Resource/Swipe_Right_Button.png"), SameLine = true };
            _GUIItems.Add(_SwipeNoteRightButton);

            _SlideNoteRightButton = new GUIImageButton { Image = Texture2D.Load("Resource/Slide_Right_Button.png"), SameLine = true };
            _GUIItems.Add(_SlideNoteRightButton);

            _SwipeNoteLeftButton = new GUIImageButton { Image = Texture2D.Load("Resource/Swipe_Left_Button.png"), SameLine = true };
            _GUIItems.Add(_SwipeNoteLeftButton);

            _SlideNoteLeftButton = new GUIImageButton { Image = Texture2D.Load("Resource/Slide_Left_Button.png"), SameLine = true };
            _GUIItems.Add(_SlideNoteLeftButton);

            _SpeedChangeButton = new GUIImageButton { Image = Texture2D.Load("Resource/SpeedChange_Button.png"), SameLine = true };
            _GUIItems.Add(_SpeedChangeButton);

            _TempoChangeButton = new GUIImageButton { Image = Texture2D.Load("Resource/TempoChange_Button.png"), SameLine = true };
            _GUIItems.Add(_TempoChangeButton);

            _MeasureChangeButton = new GUIImageButton { Image = Texture2D.Load("Resource/MeasureChange_Button.png"), SameLine = true };
            _GUIItems.Add(_MeasureChangeButton);

            _GUIItems.Add(new GUISeparator());

            _GUIItems.Add(new GUIText { Label = "Length :      " });
            _DefaultLengthBox = new GUIInputFloat { Label = "###DefaultLength", SameLine = true };
            _GUIItems.Add(_DefaultLengthBox);

            _GUIItems.Add(new GUIText { Label = "Next Speed :  " });
            _DefaultNextSpeedBox = new GUIInputFloat { Label = "###DefaultNextSpeed", SameLine = true };
            _GUIItems.Add(_DefaultNextSpeedBox);
            
            _GUIItems.Add(new GUIText { Label = "Next Tempo :  " });
            _DefaultNextTempoBox = new GUIInputFloat { Label = "###DefaultTempoSpeed", SameLine = true };
            _GUIItems.Add(_DefaultNextTempoBox);

            _GUIItems.Add(new GUIText { Label = "Next Meausre :" });
            _DefaultNextMeasureBox = new GUIInputInt { Label = "###DefaultNextMeasure", SameLine = true };
            _GUIItems.Add(_DefaultNextMeasureBox);
        }

        protected override void OnUpdate()
        {
            _DefaultLengthBox.InputValue = EditorData.Instance.DefaultLength;
            _DefaultNextSpeedBox.InputValue = EditorData.Instance.DefaultNextSpeed;
            _DefaultNextTempoBox.InputValue = EditorData.Instance.DefaultNextTempo;
            _DefaultNextMeasureBox.InputValue = EditorData.Instance.DefaultNextMeasure;

            foreach(GUIItem item in _GUIItems) item.Update();

            if(_TapNoteButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.TapNote;
            if(_HoldNoteButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.HoldNote;
            if(_SwipeNoteRightButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.SwipeNoteRight;
            if(_SlideNoteRightButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.SlideNoteRight;
            if(_SwipeNoteLeftButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.SwipeNoteLeft;
            if(_SlideNoteLeftButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.SlideNoteLeft;
            if(_SpeedChangeButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.SpeedChange;
            if(_TempoChangeButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.TempoChange;
            if(_MeasureChangeButton.IsPressed) EditorData.Instance.AppendMode = AppendMode.MeasureChange;

            EditorData.Instance.DefaultLength = _DefaultLengthBox.InputValue;
            EditorData.Instance.DefaultNextSpeed = _DefaultNextSpeedBox.InputValue;
            EditorData.Instance.DefaultNextTempo = _DefaultNextTempoBox.InputValue;
            EditorData.Instance.DefaultNextMeasure  = _DefaultNextMeasureBox.InputValue;
        }
    }
}