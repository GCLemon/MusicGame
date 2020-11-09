using Altseed2;

namespace MusicGame
{
    class Program
    {
        static void Main()
        {
            Engine.Initialize("", 1280, 720);

            while(Engine.DoEvents())
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
