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
using System.Data.Entity;

namespace Bytebank
{
    public partial class Form_UtoA : Form
    {
        Window wnd;
        private User user;
        private Administrator admin;
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        public Administrator Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public Form_UtoA()
        {
            InitializeComponent();
            LoadWnd();
            label1.Text = admin.Name;
            label2.Text = admin.Sirname;
            if (user.Language == 1)
                button1.Text = "Send";
            else if (user.Language == 2)
                button1.Text = "Отправить";
            else if (user.Language == 3)
                button1.Text = "Надіслати";
            else if (user.Language == 4)
                button1.Text = "Senden";
        }

        private void LoadWnd()
        {
            wnd = new Window(this);
            wnd.Resizable = false;
            wnd.BorderColor = Color.ForestGreen;
            wnd.Header.Maximize = false;
            wnd.Header.MouseOverColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
            wnd.Header.MouseDownColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            wnd.Header.Font = new Font("Calibri", 14);
            wnd.Header.TextLocation = new Point(4, 6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BytebankDataBase DB = new BytebankDataBase();
            if (textBox1.Text == "")
            {
                label3.Visible = true;
                if (user.Language == 1)
                    label3.Text = "Your message cannot be blank!";
                else if (user.Language == 2)
                    label3.Text = "Ваш месседж не может быть пустой!";
                else if (user.Language == 3)
                    label3.Text = "Ваш месседж не може бути пустим!";
                else if (user.Language == 4)
                    label3.Text = "Ihre Nachricht darf nicht leer sein!";
                return;
            }
            label3.Visible = false;
            label3.Text = "";
            Conv_UtoA Conversation = new Conv_UtoA { UserID = user.ID, AdminID = admin.ID, TextA = textBox1.Text };
            DB.Convs_UtoA.Add(Conversation);
            DB.SaveChanges();
            this.DialogResult = DialogResult.OK;
            return;
        }
    }
}
