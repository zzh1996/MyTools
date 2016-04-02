using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace MyTools
{
    public partial class Form1 : Form
    {
        private bool Hidden=false;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wparam, int lparam);
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键            
            {
                Capture = false;//释放鼠标使能够手动操作                
                SendMessage(Handle, 0x00A1, 2, 0);//拖动窗体            
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text.Length > 0)
            {
                if (e.Control)
                {
                    System.Diagnostics.Process.Start("https://www.google.com/search?q=" + System.Web.HttpUtility.UrlEncode(textBox1.Text));
                }
                else if (e.Shift)
                {
                    System.Diagnostics.Process.Start("https://www.google.com/search?q=" +System.Web.HttpUtility.UrlEncode( textBox1.Text + " site:pan.baidu.com"));
                }
                else
                {
                    System.Diagnostics.Process.Start("https://www.baidu.com/s?wd=" + System.Web.HttpUtility.UrlEncode(textBox1.Text));
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
                if (Hidden)
                {
                    Hidden = false;
                    this.Left = ScreenArea.Width - this.Width;

                }
                this.Show();
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    System.Diagnostics.Process.Start(textBox2.Text);
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("- -!");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start("http://www.wolframalpha.com/input/?i=" + System.Web.HttpUtility.UrlEncode(textBox3.Text));
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            if (this.Right > ScreenArea.Width && !Hidden )
            {
                this.Left = ScreenArea.Width - this.Width;
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            if (this.Right >= ScreenArea.Width && !Hidden && !this.RectangleToScreen(this.ClientRectangle).Contains(Control.MousePosition))
            {
                Hidden = true;
                this.Left = ScreenArea.Width - 5;
                
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            if (Hidden)
            {
                Hidden = false;
                this.Left = ScreenArea.Width - this.Width;
                
            }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            if (this.Right >= ScreenArea.Width && !Hidden)
            {
                Hidden = true;
                this.Left = ScreenArea.Width - 5;

            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
