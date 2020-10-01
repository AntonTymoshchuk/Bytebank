using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chromius.Window;

namespace Bytebank
{
    public partial class Form1 : Form
    {
        private Window wnd;
        private User user;
        private Administrator admin;

        public Form1()
        {
            InitializeComponent();
            LoadWnd();
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.Cancel)
                this.Close();
            if (login.LoginPerson == "User")
            {
                user = login.LoginUser;
                LoadForUser();
            }
            else
            {
                admin = login.LoginAdmin;
                LoadForAdmin();
            }
        }

        private void LoadWnd()
        {
            wnd = new Window(this);
            wnd.BorderColor = Color.ForestGreen;
            wnd.Header.MouseOverColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
            wnd.Header.MouseDownColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            wnd.Header.Font = new Font("Calibri", 14);
            wnd.Header.TextLocation = new Point(4, 6);
        }

        private void LoadForUser()
        {
            Panel background = new Panel();
            background.Name = "Background";
            background.TabIndex = 0;
            background.TabStop = false;
            background.Location = new Point(4, 0);
            background.Size = new Size(300, this.Height);
            background.BackColor = Color.ForestGreen;
            this.Controls.Add(background);
        }

        private void LoadForAdmin()
        {

        }
    }
}
