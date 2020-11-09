using System.Collections.Generic;

namespace ScoreEditor
{
    class GUIEditPaletteOnSelectItems : GUIItem
    {
        private List<GUIItem> _GUIItems;

        private GUIInputFloat _TimingBox;
        private GUIInputFloat _LengthBox;
        private GUIInputFloat _NextSpeedBox;
        private GUIInputFloat _NextTempoBox;
        private GUIInputInt _NextMeasureBox;

        public GUIEditPaletteOnSelectItems()
        {
            _GUIItems = new List<GUIItem>();

            _GUIItems.Add(new GUIText { Label = "Timing :      " });
            _TimingBox = new GUIInputFloat { Label = "###Timing", SameLine = true };
            _GUIItems.Add(_TimingBox);

            _GUIItems.Add(new GUIText { Label = "Length :      " });
            _LengthBox = new GUIInputFloat { Label = "###Length", SameLine = true };
            _GUIItems.Add(_LengthBox);

            _GUIItems.Add(new GUIText { Label = "Next Speed :  " });
            _NextSpeedBox = new GUIInputFloat { Label = "###NextSpeed", SameLine = true };
            _GUIItems.Add(_NextSpeedBox);

            _GUIItems.Add(new GUIText { Label = "Next Tempo :  " });
            _NextTempoBox = new GUIInputFloat { Label = "###NextTempo", SameLine = true };
            _GUIItems.Add(_NextTempoBox);

            _GUIItems.Add(new GUIText { Label = "Next Measure :" });
            _NextMeasureBox = new GUIInputInt { Label = "###NextMeasure", SameLine = true };
            _GUIItems.Add(_NextMeasureBox);
        }

        protected override void OnUpdate()
        {
            foreach(GUIItem item in _GUIItems) item.Update();
        }
    }
}