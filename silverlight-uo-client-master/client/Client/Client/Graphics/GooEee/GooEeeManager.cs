using Client.Input;

namespace Client.Graphics.GooEee
{
    public sealed class GooEeeManager
    {
        public GooEeeManager(Engine engine)
        {
            IInputService inputService = engine.Services.GetService<IInputService>();

            inputService.KeyDown += OnKeyDown;
            inputService.MouseLeftDown += OnMouseLeftDown;
            inputService.MouseLeftUp += OnMouseLeftUp;
            inputService.MouseMove += OnMouseMove;
        }

        private void OnMouseLeftUp(object sender, MouseStateEventArgs e)
        {

        }

        private void OnMouseLeftDown(object sender, MouseStateEventArgs e)
        {

        }

        private void OnMouseMove(object sender, MouseStateEventArgs e)
        {

        }

        private void OnKeyDown(object sender, KeyStateEventArgs e)
        {

        }
    }
}
