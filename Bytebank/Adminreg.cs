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
using System.IO;

namespace Bytebank
{
    public partial class Adminreg : Form
    {
        private Window wnd;
        private bool passwordHide = true;
        private bool secureIdHide = true;
        private int langId = 1;
        public int LangId
        {
            get { return langId; }
            set
            {
                langId = value;
                if (langId == 2)
                {
                    label1.Text = "Имя :";
                    label2.Text = "Фамилия :";
                    label3.Text = "Логин :";
                    label4.Text = "Пароль :";
                    label5.Text = "Ещё раз :";
                    label6.Text = "* Это только администраторская регистрация";
                    button1.Text = "Зарегистрироваться";
                }
                else if (langId == 3)
                {
                    label1.Text = "Ім'я :";
                    label2.Text = "Прізвище :";
                    label3.Text = "Логін :";
                    label4.Text = "Пароль :";
                    label5.Text = "Ще раз :";
                    label6.Text = "* Це тільки адміністраційна реєстрація";
                    button1.Text = "Зареєструватися";
                }
                else if (langId == 4)
                {
                    label1.Text = "Name :";
                    label2.Text = "Nachname :";
                    label3.Text = "Login :";
                    label4.Text = "Passwort :";
                    label5.Text = "Erneut :";
                    label6.Text = "* Dies ist nur eine Administratorregistrierung!";
                    button1.Text = "Registrieren";
                }
            }
        }
        public Adminreg()
        {
            InitializeComponent();
            LoadWnd();
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            Random rnd = new Random();
            textBox6.Text = Convert.ToString(rnd.Next(10000000, 100000000));
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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (passwordHide == true)
                pictureBox1.BackColor = Color.ForestGreen;
            else
                pictureBox1.BackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (passwordHide == true)
            {
                textBox4.PasswordChar = '\0';
                passwordHide = false;
                pictureBox1.BackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            }
            else
            {
                textBox4.PasswordChar = '*';
                passwordHide = true;
                pictureBox1.BackColor = Color.ForestGreen;
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (secureIdHide == true)
                pictureBox2.BackColor = Color.ForestGreen;
            else
                pictureBox2.BackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (secureIdHide == true)
            {
                textBox5.PasswordChar = '\0';
                secureIdHide = false;
                pictureBox2.BackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            }
            else
            {
                textBox5.PasswordChar = '*';
                secureIdHide = true;
                pictureBox2.BackColor = Color.ForestGreen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BytebankDataBase DB = new BytebankDataBase();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                label7.Visible = true;
                if (langId == 1)
                    label7.Text = "* Please fill all fields!";
                if (langId == 2)
                    label7.Text = "* Заполните все поля!";
                if (langId == 3)
                    label7.Text = "* Заповніть усі поля!";
                if (langId == 4)
                    label7.Text = "* Bitte alle felder ausfüllen!";
                return;
            }
            else if (textBox4.Text != textBox5.Text)
            {
                label7.Visible = true;
                if (langId == 1)
                    label7.Text = "* Passwords do not match!";
                if (langId == 2)
                    label7.Text = "* Пароли не совпадают!";
                if (langId == 3)
                    label7.Text = "* Паролі не збігаються!";
                if (langId == 4)
                    label7.Text = "* Passwörter stimmen nicht überein!";
                return;
            }
            else if (textBox4.Text.Length < 6)
            {
                label7.Visible = true;
                if (langId == 1)
                    label7.Text = "* Password is too short!";
                if (langId == 2)
                    label7.Text = "* Пароль слишком короткий!";
                if (langId == 3)
                    label7.Text = "* Пароль надто короткий!";
                if (langId == 4)
                    label7.Text = "* Das Passwort ist zu kurz!";
                return;
            }
            foreach (Administrator admin in DB.Administration)
            {
                if (textBox3.Text == admin.Login)
                {
                    label7.Visible = true;
                    if (langId == 1)
                        label7.Text = "* This login is already using!";
                    if (langId == 2)
                        label7.Text = "* Этот логин уже используется!";
                    if (langId == 3)
                        label7.Text = "* Цей логін вже використовується!";
                    if (langId == 4)
                        label7.Text = "* Diese anmeldung verwendet bereits!";
                    return;
                }
            }
            label7.Visible = false;
            label7.Text = "";
            FileStream fs = new FileStream(@"../../img/icons8-facepalm-filled-100.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            Administrator reg = new Administrator { Name = textBox1.Text, Sirname = textBox2.Text, Login = textBox3.Text, Password = textBox4.Text, Language = langId, SecureID = textBox6.Text, Active = true, LastConnected = DateTime.Now };
            DB.Administration.Add(reg);
            DB.SaveChanges();
            this.DialogResult = DialogResult.OK;
            return;
        }
    }
}
