using System;
using System.Collections.Generic;
using Altseed2;

namespace ScoreEditor
{
    class GUIItem
    {
        public string Label { get; set; }
        public bool SameLine { get; set; }
        public bool IsUpdated { get; set; }

        public GUIItem()
        {
            Label = "";
            SameLine = false;
            IsUpdated = true;
        }

        public void Update()
        {
            if(SameLine) Engine.Tool.SameLine();
            if(IsUpdated) OnUpdate();
        }

        protected virtual void OnUpdate() { }
    }
    
    class GUIWindow : GUIItem
    {
        public List<GUIItem> GUIItems { get; }
        public ToolWindowFlags WindowFlags { get; set; }

        public GUIWindow()
        {
            GUIItems = new List<GUIItem>();
            WindowFlags = ToolWindowFlags.None;
        }

        protected override void OnUpdate()
        {
            if(Engine.Tool.Begin(Label, WindowFlags))
            {
                foreach(GUIItem item in GUIItems) item.Update();
                Engine.Tool.End();
            }
        }
    }

    class GUIMainMenuBar : GUIItem
    {
        public List<GUIItem> GUIItems { get; }

        public GUIMainMenuBar()
        {
            GUIItems = new List<GUIItem>();
        }

        protected override void OnUpdate()
        {
            if(Engine.Tool.BeginMainMenuBar())
            {
                foreach(GUIItem item in GUIItems) item.Update();
                Engine.Tool.EndMainMenuBar();
            }
        }
    }

    class GUIMenu : GUIItem
    {
        public List<GUIMenuItem> GUIItems { get; }

        public GUIMenu()
        {
            GUIItems = new List<GUIMenuItem>();
        }

        protected override void OnUpdate()
        {
            if(Engine.Tool.BeginMenu(Label, true))
            {
                foreach(GUIMenuItem item in GUIItems) item.Update();
                Engine.Tool.EndMenu();
            }
            else
            {
                foreach(GUIMenuItem item in GUIItems) item.IsPressed = false;
            }
        }
    }

    class GUIText : GUIItem
    {
        protected override void OnUpdate()
        {
            if(SameLine) Engine.Tool.SameLine();
            Engine.Tool.Text(Label);
        }
    }

    class GUISeparator : GUIItem
    {
        protected override void OnUpdate()
        {
            Engine.Tool.Separator();
        }
    }

    class GUIButton : GUIItem
    {
        public Vector2F ButtonSize { get; set; }
        public bool IsPressed { get; private set; }

        public GUIButton()
        {
            ButtonSize = new Vector2F();
        }

        protected override void OnUpdate()
        {
            IsPressed = Engine.Tool.Button(Label, new Vector2F());
        }
    }

    class GUIImageButton : GUIItem
    {
        public Texture2D Image { get; set; }
        public Vector2F ButtonSize { get; set; }
        public bool IsPressed { get; private set; }

        public GUIImageButton()
        {
            Image = null;
            ButtonSize = new Vector2F(32, 32);
        }

        protected override void OnUpdate()
        {
            Vector2F uv0 =  new Vector2F(0, 0);
            Vector2F uv1 =  new Vector2F(1, 1);
            Color tColor = new Color(0, 0, 0, 0);
            Color bColor = new Color(255, 255, 255);

            IsPressed = Engine.Tool.ImageButton(Image, ButtonSize, uv0, uv1, 1, tColor, bColor);
        }
    }

    class GUIInputText : GUIItem
    {
        public int MaxLength { get; set; }
        public ToolInputTextFlags Flags { get; set; }

        public string InputValue
        {
            get => _InputValue;
            set => _InputValue = value;
        }
        private string _InputValue;

        public GUIInputText()
        {
            _InputValue = "";
        }

        protected override void OnUpdate()
        {
            _InputValue = Engine.Tool.InputText(Label, _InputValue, MaxLength, Flags) ?? "";
        }
    }

    class GUIInputInt : GUIItem
    {
        public int InputValue
        {
            get => _InputValue;
            set => _InputValue = value;
        }
        private int _InputValue;

        protected override void OnUpdate()
        {
            Engine.Tool.InputInt(Label, ref _InputValue);
        }
    }

    class GUIInputFloat : GUIItem
    {
        public float InputValue
        {
            get => _InputValue;
            set => _InputValue = value;
        }
        private float _InputValue;

        protected override void OnUpdate()
        {
            Engine.Tool.InputFloat(Label, ref _InputValue);
        }
    }

    class GUIMenuItem : GUIItem
    {
        public string Shortcut { get; set; }
        public bool IsSelected { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsPressed { get; set; }

        protected override void OnUpdate()
        {
            IsPressed = Engine.Tool.MenuItem(Label, Shortcut, IsSelected, IsEnabled);
        }
    }

    class GUICombo<T> : GUIItem where T : Enum
    {
        public T CurrentItem { get; set; }

        private string _Items;

        public GUICombo()
        {
            _Items = String.Join("\t", (T[])Enum.GetValues(typeof(T)));
        }

        protected override void OnUpdate()
        {
            int item = (int)(object)CurrentItem;
            Engine.Tool.Combo(Label, ref item, _Items, 4);
            CurrentItem = (T)Enum.ToObject(typeof(T), item);
        }
    }
}