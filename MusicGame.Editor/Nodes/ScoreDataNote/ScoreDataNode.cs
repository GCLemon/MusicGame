using Altseed2;

namespace MusicGame.Editor
{
    class ScoreDataNode : GUIManagerNode
    {
        GUIWindow _Window;
        
        public ScoreDataNode()
        {
            AddGUIItem(GUIBuilder.Instance.CreateFromXMLFile("Resource/Widget/ScoreData.xml"));
            _Window = GetItemWithName<GUIWindow>("Score Data");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            Core.Score score = EditorModel.Instance.Score;

            score.Title = _Window.GetItemWithAttr<GUIInputText>("Title").InputValue;
            score.Subtitle = _Window.GetItemWithAttr<GUIInputText>("Subtitle").InputValue;
            score.SoundPath = _Window.GetItemWithAttr<GUIInputText>("SoundPath").InputValue;
            score.JacketPath = _Window.GetItemWithAttr<GUIInputText>("JacketPath").InputValue;

            score.Difficulty = (Core.Difficulty)_Window.GetItemWithAttr<GUICombo>("Difficulty").CurrentItem;
            score.Level = _Window.GetItemWithAttr<GUIInputInt>("Level").Values[0];

            score.InitBPM = _Window.GetItemWithAttr<GUIInputFloat>("InitialBPM").Values[0];
            score.Offset = _Window.GetItemWithAttr<GUIInputFloat>("Offset").Values[0];

            score.DemoStart = _Window.GetItemWithAttr<GUIInputInt>("DemoStart").Values[0];
            score.DemoEnd = _Window.GetItemWithAttr<GUIInputInt>("DemoEnd").Values[0];
        }
    }
}