using System.Collections.Generic;
using Altseed2;

namespace ScoreEditor
{
    class GUIEditPaletteConstItems : GUIItem
    {
        private List<GUIItem> _GUIItems;

        private GUIInputInt _BeatPerMeasureBox;
        private GUIInputInt _QuantizeBox;

        private GUIImageButton _AppendButton;
        private GUIImageButton _SelectButton;
        private GUIImageButton _DeleteButton;

        public GUIEditPaletteConstItems()
        {
            _GUIItems = new List<GUIItem>();
            
            _GUIItems.Add(new GUIText { Label = "Beat Per Measure :" });
            _BeatPerMeasureBox = new GUIInputInt { Label = "###Measure", SameLine = true };
            _GUIItems.Add(_BeatPerMeasureBox);

            _GUIItems.Add(new GUIText { Label = "Quantize :        " });
            _QuantizeBox = new GUIInputInt { Label = "###Quantize", SameLine = true };
            _GUIItems.Add(_QuantizeBox);

            _GUIItems.Add(new GUISeparator());

            _GUIItems.Add(new GUIText { Label = "Editor Mode :" });
            
            _AppendButton = new GUIImageButton { Image = Texture2D.Load("Resource/Append.png"), SameLine = false };
            _GUIItems.Add(_AppendButton);
            
            _SelectButton = new GUIImageButton { Image = Texture2D.Load("Resource/Select.png"), SameLine = true };
            _GUIItems.Add(_SelectButton);
            
            _DeleteButton = new GUIImageButton { Image = Texture2D.Load("Resource/Delete.png"), SameLine = true };
            _GUIItems.Add(_DeleteButton);
        }

        protected override void OnUpdate()
        {
            _BeatPerMeasureBox.InputValue = EditorData.Instance.BeatPerMeasure;
            _QuantizeBox.InputValue = EditorData.Instance.Quantize;

            foreach(GUIItem item in _GUIItems) item.Update();

            EditorData.Instance.BeatPerMeasure = _BeatPerMeasureBox.InputValue;
            EditorData.Instance.Quantize = _QuantizeBox.InputValue;

            if(_AppendButton.IsPressed) EditorData.Instance.EditorMode = EditorMode.Append;
            if(_SelectButton.IsPressed) EditorData.Instance.EditorMode = EditorMode.Select;
            if(_DeleteButton.IsPressed) EditorData.Instance.EditorMode = EditorMode.Delete;
        }
    }
}