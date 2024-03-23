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
using System.Runtime.InteropServices;
using System;

namespace etude_csharp_mouse_drag_and_drop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MOUSE_EVENT_FLAGS MouseEventLeftDown = (MOUSE_EVENT_FLAGS)0x0002;
        //MOUSE_EVENT_FLAGS MouseEventLeftUp = (MOUSE_EVENT_FLAGS)0x0004;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //await MouseMove();
            //await MouseMove();

            //await MoveX(true);
            //await MoveY();
            //await MoveX(false);
            MoveX(true);
            //for(var i = 0; i < 10; i++)
            //{
            //    //(int X, int Y) topLeft = (1200, 480);
            //    //(int X, int Y) rightBottom = (2100, 1100);

            //    var random = new Random().Next() % 2;
            //    if(random == 0)
            //    {
            //        var random2 = new Random().Next() % 2;
            //        MoveX(random2 % 2 == 0);
            //    } else
            //    {
            //        MoveY();
            //    }
            //}
        }

        private void MoveX(bool left)
        {
            (int X, int Y) start = (1200, 480);
            (int X, int Y) end = (2100 , 480);
            var delay = TimeSpan.FromSeconds(3).TotalMicroseconds;

            var startTime = DateTime.Now;
            INPUT[] input = new INPUT[1];

            input[0].type = INPUT_TYPE.INPUT_MOUSE;
            input[0].Anonymous.mi.dwFlags = MOUSE_EVENT_FLAGS.MOUSEEVENTF_MOVE | MOUSE_EVENT_FLAGS.MOUSEEVENTF_ABSOLUTE;
            input[0].Anonymous.mi.dx = start.X;
            input[0].Anonymous.mi.dy = start.Y;
            PInvoke.SendInput(input.AsSpan(), Marshal.SizeOf(typeof(INPUT)));
            input[0].Anonymous.mi.dwFlags = MOUSE_EVENT_FLAGS.MOUSEEVENTF_LEFTDOWN;
            PInvoke.SendInput(input.AsSpan(), Marshal.SizeOf(typeof(INPUT)));
            Thread.Sleep(TimeSpan.FromSeconds(0.1));
            while (true)
            {
                var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
                var t = Math.Min(elapsed / delay, 1.0);

                var currentX = (int)Math.Round(start.X + (end.X - start.X) * t);
                input[0].Anonymous.mi.dx = currentX;
                PInvoke.SendInput(input.AsSpan(), Marshal.SizeOf(typeof(INPUT)));

                Thread.Sleep(TimeSpan.FromMilliseconds(10));
                if (t >= 1.0) break;
            }
            input[0].Anonymous.mi.dwFlags = MOUSE_EVENT_FLAGS.MOUSEEVENTF_LEFTUP;
            PInvoke.SendInput(input.AsSpan(), Marshal.SizeOf(typeof(INPUT)));
        }

        private void MoveY()
        {
            (int X, int Y) start = (2100, 1100);
            (int X, int Y) end = (2100, 480);
        }
        //private new async Task MouseMove()
        //{
        //    var startX = 100;
        //    var startY = 500;
        //    var endX = 1000;
        //    var endY = 500;

        //    var duration = 2000; // ミリ秒
        //    var startTime = DateTime.Now;




        //    var mouseThread = new Thread(() =>
        //    {
        //        DateTime startTime = DateTime.Now;
        //        PInvoke.SetCursorPos(startX, startY);
        //        PInvoke.mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
        //        Thread.Sleep(10);
        //        while (true)
        //        {
        //            var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
        //            var t = Math.Min(elapsed / duration, 1.0);

        //            var currentX = (int)Math.Round(startX + (endX - startX) * t);
        //            var currentY = (int)Math.Round(startY + (endY - startY) * t);

        //            PInvoke.SetCursorPos(currentX, currentY);

        //            if (t >= 1.0) break;

        //            Thread.Sleep(10); // 10ミリ秒ごとに更新
        //        }
        //        PInvoke.mouse_event(MouseEventLeftUp, 0, 0, 0, 0);

        //    });

        //    await Task.Run(() => mouseThread.Start());
        //    Thread.Sleep(duration);

        //}

        //public async Task MoveX(bool left)
        //{
        //    int startX;
        //    int startY;
        //    int endX;
        //    int endY;
        //    if (left)
        //    {
        //        startX = 1000;
        //        startY = 500;
        //        endX = 100;
        //        endY = 500;
        //    }
        //    else
        //    {
        //        startX = 100;
        //        startY = 500;
        //        endX = 1000;
        //        endY = 500;
        //    }

        //    var startTime = DateTime.Now;
        //    var delay = 3 * 1000;


        //    var mouseThread = new Thread(() =>
        //    {
        //        DateTime startTime = DateTime.Now;
        //        PInvoke.SetCursorPos(startX, startY);
        //        PInvoke.mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
        //        Thread.Sleep(10);
        //        while (true)
        //        {
        //            var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
        //            var t = Math.Min(elapsed / delay, 1.0);

        //            var currentX = (int)Math.Round(startX + (endX - startX) * t);
        //            var currentY = (int)Math.Round(startY + (endY - startY) * t);

        //            PInvoke.SetCursorPos(currentX, currentY);

        //            if (t >= 1.0) break;

        //            Thread.Sleep(10);
        //        }
        //        PInvoke.mouse_event(MouseEventLeftUp, 0, 0, 0, 0);

        //    });

        //    await Task.Run(() => mouseThread.Start());
        //    Thread.Sleep(delay);

        //}

        //public async Task MoveY()
        //{
        //    var startX = 1000;
        //    var startY = 900;
        //    var endX = 1000;
        //    var endY = 500;
        //    var delay = 3 * 1000;


        //    var startTime = DateTime.Now;


        //    var mouseThread = new Thread(() =>
        //    {
        //        DateTime startTime = DateTime.Now;
        //        PInvoke.SetCursorPos(startX, startY);
        //        PInvoke.mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
        //        Thread.Sleep(10);
        //        while (true)
        //        {
        //            var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
        //            var t = Math.Min(elapsed / delay, 1.0);

        //            var currentX = (int)Math.Round(startX + (endX - startX) * t);
        //            var currentY = (int)Math.Round(startY + (endY - startY) * t);

        //            PInvoke.SetCursorPos(currentX, currentY);

        //            if (t >= 1.0) break;

        //            Thread.Sleep(10);
        //        }
        //        PInvoke.mouse_event(MouseEventLeftUp, 0, 0, 0, 0);

        //    });

        //    await Task.Run(() => mouseThread.Start());
        //    Thread.Sleep(delay);

        //}
    }
}