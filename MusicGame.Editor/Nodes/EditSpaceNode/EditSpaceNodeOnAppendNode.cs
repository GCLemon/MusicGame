using System;
using Altseed2;

namespace MusicGame.Editor
{
    partial class EditSpaceNode
    {
        private object _PlottingObject;

        private void OnAppend()
        {
            switch(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft))
            {
                case ButtonState.Push:
                {
                    Vector2F dragPos = InputManager.Instance.GetMousePosition();
                    if(102 <= dragPos.X && dragPos.X <= 348)
                    {
                        EditorModel.Instance.ArraySave();
                        switch(EditorModel.Instance.AppendMode)
                        {
                            case AppendMode.TapNote:
                                _PlottingObject = new Core.TapNote();
                                EditorModel.Instance.Score.Notes.Add((Core.TapNote)_PlottingObject);
                                break;
                            case AppendMode.HoldNote:
                                _PlottingObject = new Core.HoldNote();
                                ((Core.HoldNote)_PlottingObject).Length = EditorModel.Instance.DefaultLength;
                                EditorModel.Instance.Score.Notes.Add((Core.HoldNote)_PlottingObject);
                                break;
                            case AppendMode.SwipeNoteRight:
                                _PlottingObject = new Core.SwipeNote();
                                ((Core.SwipeNote)_PlottingObject).LaneType = Core.LaneType.Orange;
                                EditorModel.Instance.Score.Notes.Add((Core.SwipeNote)_PlottingObject);
                                break;
                            case AppendMode.SlideNoteRight:
                                _PlottingObject = new Core.SlideNote();
                                ((Core.SlideNote)_PlottingObject).LaneType = Core.LaneType.Orange;
                                ((Core.SlideNote)_PlottingObject).Length = EditorModel.Instance.DefaultLength;
                                EditorModel.Instance.Score.Notes.Add((Core.SlideNote)_PlottingObject);
                                break;
                            case AppendMode.SwipeNoteLeft:
                                _PlottingObject = new Core.SwipeNote();
                                ((Core.SwipeNote)_PlottingObject).LaneType = Core.LaneType.Purple;
                                EditorModel.Instance.Score.Notes.Add((Core.SwipeNote)_PlottingObject);
                                break;
                            case AppendMode.SlideNoteLeft:
                                _PlottingObject = new Core.SlideNote();
                                ((Core.SlideNote)_PlottingObject).LaneType = Core.LaneType.Purple;
                                ((Core.SlideNote)_PlottingObject).Length = EditorModel.Instance.DefaultLength;
                                EditorModel.Instance.Score.Notes.Add((Core.SlideNote)_PlottingObject);
                                break;
                            case AppendMode.SpeedChange:
                                _PlottingObject = new Core.SpeedChange();
                                ((Core.SpeedChange)_PlottingObject).AfterSpeed = EditorModel.Instance.DefaultNextSpeed;
                                EditorModel.Instance.Score.Effects.Add((Core.SpeedChange)_PlottingObject);
                                break;
                            case AppendMode.TempoChange:
                                _PlottingObject = new Core.TempoChange();
                                ((Core.TempoChange)_PlottingObject).AfterTempo = EditorModel.Instance.DefaultNextTempo;
                                EditorModel.Instance.Score.Effects.Add((Core.TempoChange)_PlottingObject);
                                break;
                            case AppendMode.MeasureChange:
                                _PlottingObject = new Core.MeasureChange();
                                ((Core.MeasureChange)_PlottingObject).AfterMeasure = EditorModel.Instance.DefaultNextMeasure;
                                EditorModel.Instance.Score.Effects.Add((Core.MeasureChange)_PlottingObject);
                                break;
                        }
                    }
                    break;
                }
                case ButtonState.Hold:
                {
                    Vector2F dragPos = InputManager.Instance.GetMousePosition();

                    float quantize = EditorModel.Instance.Quantize * 0.25f;
                    float posY = dragPos.Y;
                    float scroll = InputManager.Instance.GetTotalScroll() * 5;
                    float timing = MathF.Floor((640 - posY + scroll) * 0.025f * quantize + 0.5f) / quantize;

                    if(_PlottingObject != null)
                    {
                        if(_PlottingObject is Core.Note)
                        {
                            ((Core.Note)_PlottingObject).Timing = timing;

                            switch(((Core.Note)_PlottingObject).NoteType)
                            {
                                case Core.NoteType.TapNote:
                                    if(102 <= dragPos.X && dragPos.X <= 162)
                                        ((Core.TapNote)_PlottingObject).LaneType = Core.LaneType.Blue;
                                    if(164 <= dragPos.X && dragPos.X <= 224)
                                        ((Core.TapNote)_PlottingObject).LaneType = Core.LaneType.Green;
                                    if(226 <= dragPos.X && dragPos.X <= 286)
                                        ((Core.TapNote)_PlottingObject).LaneType = Core.LaneType.Yellow;
                                    if(288 <= dragPos.X && dragPos.X <= 348)
                                        ((Core.TapNote)_PlottingObject).LaneType = Core.LaneType.Red;
                                    break;

                                case Core.NoteType.HoldNote:
                                    if(102 <= dragPos.X && dragPos.X <= 162)
                                        ((Core.HoldNote)_PlottingObject).LaneType = Core.LaneType.Blue;
                                    if(164 <= dragPos.X && dragPos.X <= 224)
                                        ((Core.HoldNote)_PlottingObject).LaneType = Core.LaneType.Green;
                                    if(226 <= dragPos.X && dragPos.X <= 286)
                                        ((Core.HoldNote)_PlottingObject).LaneType = Core.LaneType.Yellow;
                                    if(288 <= dragPos.X && dragPos.X <= 348)
                                        ((Core.HoldNote)_PlottingObject).LaneType = Core.LaneType.Red;
                                    break;
                            }
                        }
                        else if(_PlottingObject is Core.Effect)
                        {
                            ((Core.Effect)_PlottingObject).Timing = timing;
                        }
                    }
                    break;
                }
                case ButtonState.Release:
                {
                    if(_PlottingObject != null) _PlottingObject = null;
                    break;
                }
            }
        }
    }
}