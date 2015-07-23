using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkAges_Cursor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, "DarkAges");
            RECT rc;
            GetWindowRect(hWnd, out rc);
            Rectangle rect = new Rectangle(rc.left, rc.top, rc.right, rc.bottom);


            Point p = Cursor.Position;
            if (rect.Contains(p))
            {
                label2.Text = (Cursor.Position.X - rc.left).ToString();
                label3.Text = (Cursor.Position.Y - rc.top).ToString();
            }
        }
    }
}
