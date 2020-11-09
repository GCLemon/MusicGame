using Altseed2;

namespace ScoreEditor
{
    class ScoreDataNode : Node
    {
        private GUIWindow _ScoreDataWindow;

        private GUIInputText _SongTitleBox;
        private GUIInputText _SubtitleBox;
        private GUIInputText _SoundPathBox;
        private GUIInputText _JacketPathBox;

        private GUIButton _SoundPathButton;
        private GUIButton _JacketPathButton;

        private GUICombo<Difficulty> _DifficultyCombo;
        private GUIInputInt _LevelBox;

        private GUIInputFloat _InitBPMBox;
        private GUIInputFloat _OfsetBox;

        private GUIInputFloat _DemoStartBox;
        private GUIInputFloat _DemoEndBox;

        public ScoreDataNode()
        {
            _ScoreDataWindow = new GUIWindow();

            _ScoreDataWindow.Label = "Metadata";

            _ScoreDataWindow.WindowFlags |= ToolWindowFlags.NoMove;
            _ScoreDataWindow.WindowFlags |= ToolWindowFlags.NoResize;
            _ScoreDataWindow.WindowFlags |= ToolWindowFlags.NoTitleBar;

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Song Title : " });
            _SongTitleBox = new GUIInputText { Label = "###Title", MaxLength = 256, SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_SongTitleBox);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Subtitle :   " });
            _SubtitleBox = new GUIInputText { Label = "###Subtitle", MaxLength = 256, SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_SubtitleBox);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Sound Path : " });
            _SoundPathBox = new GUIInputText { Label = "###SoundPath", MaxLength = 256, SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_SoundPathBox);
            _SoundPathButton = new GUIButton { Label = "Browse###Sound", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_SoundPathButton);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Jacket Path :" });
            _JacketPathBox = new GUIInputText { Label = "###JacketPath", MaxLength = 256, SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_JacketPathBox);
            _JacketPathButton = new GUIButton { Label = "Browse###Jacket", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_JacketPathButton);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Difficulty : " });
            _DifficultyCombo = new GUICombo<Difficulty> { Label = "###Difficulty", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_DifficultyCombo);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Level :      " });
            _LevelBox = new GUIInputInt { Label = "###Level", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_LevelBox);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Initial BPM :" });
            _InitBPMBox = new GUIInputFloat { Label = "###InitialBPM", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_InitBPMBox);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Ofset :      " });
            _OfsetBox = new GUIInputFloat { Label = "###Ofset", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_OfsetBox);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Demo Start : " });
            _DemoStartBox = new GUIInputFloat { Label = "###DemoStart", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_DemoStartBox);

            _ScoreDataWindow.GUIItems.Add(new GUIText { Label = "Demo End :   " });
            _DemoEndBox = new GUIInputFloat { Label = "###DemoEnd", SameLine = true };
            _ScoreDataWindow.GUIItems.Add(_DemoEndBox);
        }

        protected override void OnUpdate()
        {
            _SongTitleBox.InputValue = ScoreData.Instance.Title;
            _SubtitleBox.InputValue = ScoreData.Instance.Subtitle;
            _SoundPathBox.InputValue = ScoreData.Instance.SoundPath;
            _JacketPathBox.InputValue = ScoreData.Instance.JacketPath;
            _DifficultyCombo.CurrentItem = ScoreData.Instance.Difficulty;
            _LevelBox.InputValue = ScoreData.Instance.Level;
            _InitBPMBox.InputValue = (float)ScoreData.Instance.InitialBPM;
            _OfsetBox.InputValue = (float)ScoreData.Instance.Ofset;
            _DemoStartBox.InputValue = (float)ScoreData.Instance.DemoStart;
            _DemoEndBox.InputValue = (float)ScoreData.Instance.DemoEnd;

            _ScoreDataWindow.Update();

            if(_SoundPathButton.IsPressed) _SoundPathBox.InputValue = Engine.Tool.OpenDialog("wav,ogg", "./");
            if(_JacketPathButton.IsPressed) _JacketPathBox.InputValue = Engine.Tool.OpenDialog("png", "./");

            ScoreData.Instance.Title = _SongTitleBox.InputValue;
            ScoreData.Instance.Subtitle = _SubtitleBox.InputValue;
            ScoreData.Instance.SoundPath = _SoundPathBox.InputValue;
            ScoreData.Instance.JacketPath = _JacketPathBox.InputValue;
            ScoreData.Instance.Difficulty = _DifficultyCombo.CurrentItem;
            ScoreData.Instance.Level = _LevelBox.InputValue;
            ScoreData.Instance.InitialBPM = _InitBPMBox.InputValue;
            ScoreData.Instance.Ofset = _OfsetBox.InputValue;
            ScoreData.Instance.DemoStart = _DemoStartBox.InputValue;
            ScoreData.Instance.DemoEnd = _DemoEndBox.InputValue;
        }
    }
}