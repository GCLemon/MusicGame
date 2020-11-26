using Altseed2;

namespace MusicGame.Editor
{
    class Program
    {
        static void Main()
        {
            Configuration config = new Configuration();
            config.EnabledCoreModules = CoreModules.Default | CoreModules.Tool;

            Engine.Initialize("~~~ NEO TONE Score Editor ~~~", 960, 720, config);
            Engine.ClearColor = new Color();
;
            Engine.AddNode(new MenuBarNode());
            Engine.AddNode(new EditPaletteNode());
            Engine.AddNode(new ScoreDataNode());
            Engine.AddNode(new EditSpaceNode());

            while(Engine.DoEvents())
            {
                InputManager.Instance.Update();
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
