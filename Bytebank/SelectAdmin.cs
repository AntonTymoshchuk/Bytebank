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
    public partial class SelectAdmin : Form
    {
        private Window wnd;
        private User user;
        private List<Button> AdminList = new List<Button>();
        private List<PictureBox> FaceList = new List<PictureBox>();

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public SelectAdmin()
        {
            InitializeComponent();
            LoadWnd();
            BytebankDataBase DB = new BytebankDataBase();
            int offset = 10, c = 0;
            foreach (Administrator admin in DB.Administration)
            {
                if (admin.Language == user.Language)
                    LoadSelector(admin, offset, c);
            }
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

        private void LoadSelector(Administrator admin, int offset, int c)
        {
            AdminList.Add(new Button());
            AdminList[c].Name = "Admin" + Convert.ToString(c);
            AdminList[c].Location = new Point(12, offset);
            AdminList[c].TabIndex = 0;
            AdminList[c].TabStop = false;
            AdminList[c].Size = new Size(this.Width - 24, 40);
            AdminList[c].BackColor = Color.ForestGreen;
            AdminList[c].FlatStyle = FlatStyle.Flat;
            AdminList[c].FlatAppearance.BorderSize = 0;
            AdminList[c].FlatAppearance.MouseDownBackColor = Color.FromArgb(Color.ForestGreen.R + 25, Color.ForestGreen.G + 25, Color.ForestGreen.B + 25);
            AdminList[c].FlatAppearance.MouseDownBackColor = Color.FromArgb(Color.ForestGreen.R + 35, Color.ForestGreen.G + 35, Color.ForestGreen.B + 35);
            AdminList[c].Text = "   " + admin.Name + " " + admin.Sirname;
            AdminList[c].Font = new Font("Calibri", 16);
            AdminList[c].TextAlign = ContentAlignment.MiddleLeft;
            AdminList[c].MouseClick += adminSelectorMouseClick;
            FaceList.Add(new PictureBox());
            FaceList[c].Name = "Face" + Convert.ToString(c);
            FaceList[c].Location = new Point(16, offset + 4);
            FaceList[c].Size = new Size(32, 32);
            FaceList[c].SizeMode = PictureBoxSizeMode.StretchImage;
            FaceList[c].MouseClick += adminSelectorMouseClick;
            this.Controls.Add(AdminList[c]);
            this.Controls.Add(FaceList[c]);
            offset += 40;
            c++;
        }

        private void adminSelectorMouseClick(object sender, EventArgs e)
        {
            Form_UtoA conv = new Form_UtoA();
            conv.User = user;
            conv.ShowDialog();
            if (conv.DialogResult == DialogResult.OK)
                this.Close();
        }
    }
}
