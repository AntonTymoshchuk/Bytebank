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
using System.Threading;
using System.Data.Entity;
using System.Drawing.Imaging;

namespace Bytebank
{
    public partial class Login : Form
    {
        private Window wnd;
        private bool passwordHide = true;
        private bool secureIdHide = true;
        private bool personFound = false;
        private bool changeLang = false;
        private User loginUser;
        private Administrator loginAdmin;
        private string loginPerson;
        private int langID = 1;

        public User LoginUser
        {
            get { return loginUser; }
        }
        public Administrator LoginAdmin
        {
            get { return loginAdmin; }
        }
        public string LoginPerson
        {
            get { return loginPerson; }
        }
        public int LangID
        {
            get { return langID; }
        }

        public Login()
        {
            InitializeComponent();
            LoadWnd();
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            langID = 1;
            groupBox1.Text = "Select language";
            groupBox2.Text = "Login as";
            radioButton5.Text = "User";
            radioButton6.Text = "Administrator";
            label1.Text = "Login :";
            label2.Text = "Password :";
            button1.Text = "Continue";
            button2.Text = "Register";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            langID = 2;
            groupBox1.Text = "Выберите язык";
            groupBox2.Text = "Войти как";
            radioButton5.Text = "Пользователь";
            radioButton6.Text = "Администратор";
            label1.Text = "Логин :";
            label2.Text = "Пароль :";
            button1.Text = "Продолжить";
            button2.Text = "Регистрация";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            langID = 3;
            groupBox1.Text = "Оберіть мову";
            groupBox2.Text = "Увійти як";
            radioButton5.Text = "Користувач";
            radioButton6.Text = "Адміністратор";
            label1.Text = "Логін :";
            label2.Text = "Пароль :";
            button1.Text = "Продовжити";
            button2.Text = "Реєстрація";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            langID = 4;
            groupBox1.Text = "Sprache auswählen";
            groupBox2.Text = "Anmelden als";
            radioButton5.Text = "Benutzer";
            radioButton6.Text = "Verwalter";
            label1.Text = "Login :";
            label2.Text = "Passwort :";
            button1.Text = "Fortsetzen";
            button2.Text = "Registrieren";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                Thread AnonymousEffect = new Thread(delegate ()
                {
                    label3.Invoke((MethodInvoker)(delegate () { label3.Visible = false; }));
                    textBox3.Invoke((MethodInvoker)(delegate () { textBox3.Visible = false; }));
                    pictureBox2.Invoke((MethodInvoker)(delegate () { pictureBox2.Visible = false; }));
                    pictureBox2.Invoke((MethodInvoker)(delegate () { pictureBox2.BackColor = Color.ForestGreen; }));
                    textBox3.Invoke((MethodInvoker)(delegate () { textBox3.PasswordChar = '*'; }));
                    textBox3.Invoke((MethodInvoker)(delegate () { textBox3.Text = ""; }));
                    for (int i = 0; i < 28; i += 4)
                    {
                        this.Invoke((MethodInvoker)(delegate () { this.Height -= 4; }));
                        button1.Invoke((MethodInvoker)(delegate () { button1.Top -= 4; }));
                        button2.Invoke((MethodInvoker)(delegate () { button2.Top -= 4; }));
                        label4.Invoke((MethodInvoker)(delegate () { label4.Top -= 4; }));
                        Thread.Sleep(1);
                    }
                });
                AnonymousEffect.Start();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                Thread AnonymousEffect = new Thread(delegate ()
              {
                  for (int i = 0; i < 28; i += 4)
                  {
                      this.Invoke((MethodInvoker)(delegate () { this.Height += 4; }));
                      button1.Invoke((MethodInvoker)(delegate () { button1.Top += 4; }));
                      button2.Invoke((MethodInvoker)(delegate () { button2.Top += 4; }));
                      label4.Invoke((MethodInvoker)(delegate () { label4.Top += 4; }));
                      Thread.Sleep(1);
                  }
                  label3.Invoke((MethodInvoker)(delegate () { label3.Visible = true; }));
                  textBox3.Invoke((MethodInvoker)(delegate () { textBox3.Visible = true; }));
                  pictureBox2.Invoke((MethodInvoker)(delegate () { pictureBox2.Visible = true; }));
              });
                AnonymousEffect.Start();
            }
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (passwordHide == true)
            {
                textBox2.PasswordChar = '\0';
                passwordHide = false;
                pictureBox1.BackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            }
            else
            {
                textBox2.PasswordChar = '*';
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

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (secureIdHide == true)
            {
                textBox3.PasswordChar = '\0';
                secureIdHide = false;
                pictureBox2.BackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            }
            else
            {
                textBox3.PasswordChar = '*';
                secureIdHide = true;
                pictureBox2.BackColor = Color.ForestGreen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (changeLang == true)
            {
                label4.Visible = false;
                label4.Text = "";
                BytebankDataBase DB = new BytebankDataBase();
                if (radioButton5.Checked == true)
                {
                    DB.Users.Find(loginUser.ID).Language = langID;
                    DB.Users.Find(loginUser.ID).Active = true;
                    DB.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                else if (radioButton6.Checked == true)
                {
                    DB.Administration.Find(loginAdmin.ID).Language = langID;
                    DB.Administration.Find(loginAdmin.ID).Active = true;
                    DB.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" && radioButton6.Checked == true)
                {
                    label4.Visible = true;
                    if (radioButton1.Checked == true)
                        label4.Text = "* Please fill all fields!";
                    else if (radioButton2.Checked == true)
                        label4.Text = "* Заполните все поля!";
                    else if (radioButton3.Checked == true)
                        label4.Text = "* Заповніть усі поля!";
                    else if (radioButton4.Checked == true)
                        label4.Text = "* Bitte alle felder ausfüllen!";
                    return;
                }
                if (radioButton6.Checked == true && textBox3.Text.Length < 8 && textBox3.Text.Length > 0)
                {
                    label4.Visible = true;
                    if (radioButton1.Checked == true)
                        label4.Text = "* SecureID field must contain 8 symbols!";
                    else if (radioButton2.Checked == true)
                        label4.Text = "* Поле SecureID должно местить 8 символов!";
                    else if (radioButton3.Checked == true)
                        label4.Text = "* Поле SecureID повинне містити 8 символів!";
                    else if (radioButton4.Checked == true)
                        label4.Text = "* Das SecureID-feld muss 8 symbole enthalten!";
                    return;
                }
                else
                {
                    label4.Visible = false;
                    label4.Text = "";
                    BytebankDataBase DB = new BytebankDataBase();
                    if (radioButton5.Checked == true)
                    {
                        loginPerson = "User";
                        foreach (User user in DB.Users)
                        {
                            if (textBox1.Text == user.Login && textBox2.Text == user.Password)
                            {
                                personFound = true;
                                loginUser = user;
                                if (user.Language == langID)
                                {
                                    DB.Users.Find(loginUser.ID).Active = true;
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    changeLang = true;
                                    label4.Visible = true;
                                    if (radioButton1.Checked == true)
                                    {
                                        label4.Text = "* Do you want to change your language?";
                                        button1.Text = "Yes";
                                    }
                                    else if (radioButton2.Checked == true)
                                    {
                                        label4.Text = "* Вы хотите изменить ваш язык?";
                                        button1.Text = "Да";
                                    }
                                    else if (radioButton3.Checked == true)
                                    {
                                        label4.Text = "* Ви хочете змінити вашу мову?";
                                        button1.Text = "Так";
                                    }
                                    else if (radioButton4.Checked == true)
                                    {
                                        label4.Text = "* Möchten sie ihre sprache ändern?";
                                        button1.Text = "Ja";
                                    }
                                }
                                break;
                            }
                        }
                        if (personFound == false)
                        {
                            label4.Visible = true;
                            if (radioButton1.Checked == true)
                                label4.Text = "* Account not found!";
                            else if (radioButton2.Checked == true)
                                label4.Text = "* Аккаунт не найден!";
                            else if (radioButton3.Checked == true)
                                label4.Text = "* Аккаунт не знайдено!";
                            else if (radioButton4.Checked == true)
                                label4.Text = "* Konto nicht gefunden!";
                            return;
                        }
                    }
                    if (radioButton6.Checked == true)
                    {
                        loginPerson = "Admin";
                        foreach (Administrator admin in DB.Administration)
                        {
                            if (textBox1.Text == admin.Login && textBox2.Text == admin.Password && textBox3.Text == admin.SecureID)
                            {
                                personFound = true;
                                loginAdmin = admin;
                                if (admin.Language == langID)
                                {
                                    DB.Users.Find(loginUser.ID).Active = true;
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    changeLang = true;
                                    label4.Visible = true;
                                    if (radioButton1.Checked == true)
                                    {
                                        label4.Text = "* Do you want to change your language?";
                                        button1.Text = "Yes";
                                    }
                                    else if (radioButton2.Checked == true)
                                    {
                                        label4.Text = "* Вы хотите изменить ваш язык?";
                                        button1.Text = "Да";
                                    }
                                    else if (radioButton3.Checked == true)
                                    {
                                        label4.Text = "* Ви хочете змінити вашу мову?";
                                        button1.Text = "Так";
                                    }
                                    else if (radioButton4.Checked == true)
                                    {
                                        label4.Text = "* Möchten sie ihre sprache ändern?";
                                        button1.Text = "Ja";
                                    }
                                }
                                break;
                            }
                            else if (textBox1.Text == admin.Login && textBox2.Text == admin.Password && textBox3.Text != admin.SecureID)
                            {
                                label4.Visible = true;
                                if (radioButton1.Checked == true)
                                    label4.Text = "* Incorrect SecureID!";
                                else if (radioButton2.Checked == true)
                                    label4.Text = "* Неверный SecureID!";
                                else if (radioButton3.Checked == true)
                                    label4.Text = "* Неправильний SecureID!";
                                else if (radioButton4.Checked == true)
                                    label4.Text = "* Ungültig SecureID!";
                                return;
                            }
                        }
                        if (personFound == false)
                        {
                            label4.Visible = true;
                            if (radioButton1.Checked == true)
                                label4.Text = "* Account not found!";
                            else if (radioButton2.Checked == true)
                                label4.Text = "* Аккаунт не найден!";
                            else if (radioButton3.Checked == true)
                                label4.Text = "* Аккаунт не знайдено!";
                            else if (radioButton4.Checked == true)
                                label4.Text = "* Konto nicht gefunden!";
                            return;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton6.Checked = false;
            radioButton5.Checked = true;
            Registration reg = new Registration();
            if (radioButton1.Checked == true)
                reg.LangID = 1;
            else if (radioButton2.Checked == true)
                reg.LangID = 2;
            else if (radioButton3.Checked == true)
                reg.LangID = 3;
            else if (radioButton4.Checked == true)
                reg.LangID = 4;
            reg.ShowDialog();
        }
    }
}
