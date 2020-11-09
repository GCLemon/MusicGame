using System;
using Altseed2;

namespace ScoreEditor
{
    class EditSpaceOnAppend
    {
        private EditSpaceNode _EditSpaceNode;
        private PlotObjectInfo _PlottingObject;

        public EditSpaceOnAppend(EditSpaceNode node)
        {
            _EditSpaceNode = node;
        }

        public void Update()
        {
            switch(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft))
            {
                case ButtonState.Push:
                {
                    Vector2F dragPos = InputManager.Instance.GetMousePosition();
                    if(102 <= dragPos.X && dragPos.X <= 348)
                    {
                        _PlottingObject = new PlotObjectInfo();
                        _PlottingObject.ObjectState = ObjectState.Moving;
                        ScoreData.Instance.Save();
                        ScoreData.Instance.PlotedObjects.Add(_PlottingObject);
                        switch(EditorData.Instance.AppendMode)
                        {
                            case AppendMode.TapNote:
                                _PlottingObject.ObjectType = ObjectType.TapNote;
                                break;
                            case AppendMode.HoldNote:
                                _PlottingObject.ObjectType = ObjectType.HoldNote;
                                _PlottingObject.Length = EditorData.Instance.DefaultLength;
                                break;
                            case AppendMode.SwipeNoteRight:
                                _PlottingObject.ObjectType = ObjectType.SwipeNote;
                                _PlottingObject.LaneType = LaneType.Orange;
                                break;
                            case AppendMode.SlideNoteRight:
                                _PlottingObject.ObjectType = ObjectType.SlideNote;
                                _PlottingObject.LaneType = LaneType.Orange;
                                _PlottingObject.Length = EditorData.Instance.DefaultLength;
                                break;
                            case AppendMode.SwipeNoteLeft:
                                _PlottingObject.ObjectType = ObjectType.SwipeNote;
                                _PlottingObject.LaneType = LaneType.Purple;
                                break;
                            case AppendMode.SlideNoteLeft:
                                _PlottingObject.ObjectType = ObjectType.SlideNote;
                                _PlottingObject.LaneType = LaneType.Purple;
                                _PlottingObject.Length = EditorData.Instance.DefaultLength;
                                break;
                            case AppendMode.SpeedChange:
                                _PlottingObject.ObjectType = ObjectType.SpeedChange;
                                _PlottingObject.AfterSpeed = EditorData.Instance.DefaultNextSpeed;
                                break;
                            case AppendMode.TempoChange:
                                _PlottingObject.ObjectType = ObjectType.TempoChange;
                                _PlottingObject.AfterTempo = EditorData.Instance.DefaultNextTempo;
                                break;
                            case AppendMode.MeasureChange:
                                _PlottingObject.ObjectType = ObjectType.MeasureChange;
                                _PlottingObject.AfterMeasure = EditorData.Instance.DefaultNextMeasure;
                                break;
                        }
                    }
                    break;
                }
                case ButtonState.Hold:
                {
                    if(_PlottingObject != null)
                    {
                        Vector2F dragPos = InputManager.Instance.GetMousePosition();

                        float quantize = EditorData.Instance.Quantize * 0.25f;
                        float posY = dragPos.Y;
                        float scroll = InputManager.Instance.GetTotalScroll() * 5;
                        
                        _PlottingObject.Timing = MathF.Floor((640 - posY + scroll) * 0.025f * quantize + 0.5f) / quantize;

                        switch(_PlottingObject.ObjectType)
                        {
                            case ObjectType.TapNote:
                            case ObjectType.HoldNote:
                                if(102 <= dragPos.X && dragPos.X <= 162) _PlottingObject.LaneType = LaneType.Blue;
                                if(164 <= dragPos.X && dragPos.X <= 224) _PlottingObject.LaneType = LaneType.Green;
                                if(226 <= dragPos.X && dragPos.X <= 286) _PlottingObject.LaneType = LaneType.Yellow;
                                if(288 <= dragPos.X && dragPos.X <= 348) _PlottingObject.LaneType = LaneType.Red;
                                break;
                        }
                    }
                    break;
                }
                case ButtonState.Release:
                {
                    if(_PlottingObject != null)
                    {
                        _PlottingObject.ObjectState = ObjectState.Unselected;
                        _PlottingObject = null;
                    }
                    break;
                }
            }
        }
    }
}