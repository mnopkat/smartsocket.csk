using System;
using System.Net;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace SSServer
{
    static class Program
    {

        private static NotifyIcon notifyIcon = null;
        private static string _port;
        private static bool state;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.Icon;
            //notifyIcon.MouseDoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            notifyIcon.Visible = true;
            startt();
            Application.Run();
        }
        public static void startt()
        {
            SerialPort por1 = new SerialPort();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                _port = port;
            }
            while (true)
            {
                por1.PortName = _port;
                por1.BaudRate = 9600;
                por1.Open();
                state = get_socket_state();

                if (state == true)
                {
                    por1.Write("on");
                    notifyIcon.Text = "Умная розетка v1.0.0\nСостояние розетки: включена";
                }
                else if (state == false)
                {
                    por1.Write("of");
                    notifyIcon.Text = "Умная розетка v1.0.0\nСостояние розетки: выключена";
                }

                else notifyIcon.Text = "Умная розетка v1.0.0\nПроизошла ошибка...";
                por1.Close();
                Thread.Sleep(500);
            }
        }

        public static bool get_socket_state()
        {
            WebRequest req = HttpWebRequest.Create("http://relaxcs.by/andrewkharkov/ss/status");
            Stream s = req.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string state = sr.ReadToEnd();
            sr.Close();
            if (state == "true")
                return true;
            else
                return false;
        }
        private static void notifyIcon1_DoubleClick(object Sender, MouseEventArgs e)
        {

        }
    }
}
