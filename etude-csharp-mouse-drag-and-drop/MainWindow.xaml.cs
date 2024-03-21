using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Win32;
using Windows.Win32.UI.Input.KeyboardAndMouse;
using Windows.Win32.Foundation;

namespace etude_csharp_mouse_drag_and_drop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MOUSE_EVENT_FLAGS MouseEventLeftDown = (MOUSE_EVENT_FLAGS)0x0002;
        MOUSE_EVENT_FLAGS MouseEventLeftUp = (MOUSE_EVENT_FLAGS)0x0004;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //await MouseMove();
            //await MouseMove();
            await MoveX(true);
            await MoveY();
            await MoveX(false);
        }
        private new async Task MouseMove()
        {
            var startX = 100;
            var startY = 500;
            var endX = 1000;
            var endY = 500;

            var duration = 2000; // ミリ秒
            var startTime = DateTime.Now;




            var mouseThread = new Thread(() =>
            {
                DateTime startTime = DateTime.Now;
                PInvoke.SetCursorPos(startX, startY);
                PInvoke.mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
                Thread.Sleep(10);
                while (true)
                {
                    var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
                    var t = Math.Min(elapsed / duration, 1.0);

                    var currentX = (int)Math.Round(startX + (endX - startX) * t);
                    var currentY = (int)Math.Round(startY + (endY - startY) * t);

                    PInvoke.SetCursorPos(currentX, currentY);

                    if (t >= 1.0) break;

                    Thread.Sleep(10); // 10ミリ秒ごとに更新
                }
                PInvoke.mouse_event(MouseEventLeftUp, 0, 0, 0, 0);

            });

            await Task.Run(() => mouseThread.Start());
            Thread.Sleep(duration);

        }

        public async Task MoveX(bool left)
        {
            int startX;
            int startY;
            int endX;
            int endY;
            if (left)
            {
                startX = 1000;
                startY = 500;
                endX = 100;
                endY = 500;
            }
            else
            {
                startX = 100;
                startY = 500;
                endX = 1000;
                endY = 500;
            }

            var startTime = DateTime.Now;
            var delay = 3 * 1000;


            var mouseThread = new Thread(() =>
            {
                DateTime startTime = DateTime.Now;
                PInvoke.SetCursorPos(startX, startY);
                PInvoke.mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
                Thread.Sleep(10);
                while (true)
                {
                    var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
                    var t = Math.Min(elapsed / delay, 1.0);

                    var currentX = (int)Math.Round(startX + (endX - startX) * t);
                    var currentY = (int)Math.Round(startY + (endY - startY) * t);

                    PInvoke.SetCursorPos(currentX, currentY);

                    if (t >= 1.0) break;

                    Thread.Sleep(10);
                }
                PInvoke.mouse_event(MouseEventLeftUp, 0, 0, 0, 0);

            });

            await Task.Run(() => mouseThread.Start());
            Thread.Sleep(delay);

        }

        public async Task MoveY()
        {
            var startX = 1000;
            var startY = 900;
            var endX = 1000;
            var endY = 500;
            var delay = 3 * 1000;


            var startTime = DateTime.Now;


            var mouseThread = new Thread(() =>
            {
                DateTime startTime = DateTime.Now;
                PInvoke.SetCursorPos(startX, startY);
                PInvoke.mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
                Thread.Sleep(10);
                while (true)
                {
                    var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
                    var t = Math.Min(elapsed / delay, 1.0);

                    var currentX = (int)Math.Round(startX + (endX - startX) * t);
                    var currentY = (int)Math.Round(startY + (endY - startY) * t);

                    PInvoke.SetCursorPos(currentX, currentY);

                    if (t >= 1.0) break;

                    Thread.Sleep(10);
                }
                PInvoke.mouse_event(MouseEventLeftUp, 0, 0, 0, 0);

            });

            await Task.Run(() => mouseThread.Start());
            Thread.Sleep(delay);

        }
    }
}