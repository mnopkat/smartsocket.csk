using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace SSServer
{
    public partial class Form1 : Form
    {
        private static string _port;
        private static bool state;
        public Form1()
        {
            InitializeComponent();
            this.Visible = false;
            this.IsVisibilityChangeAllowed = false;
        }
        
        bool IsVisibilityChangeAllowed { get; set; }

        protected override void SetVisibleCore(bool value)
        {
            if (this.IsVisibilityChangeAllowed)
            {
                base.SetVisibleCore(value);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
            Application.ExitThread();
            Application.Exit();
        }
    }
}
