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
    public partial class AddCard : Form
    {
        private Window wnd;
        public AddCard()
        {
            InitializeComponent();
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
    }
}
