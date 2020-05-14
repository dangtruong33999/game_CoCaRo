using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_Caro
{
    public partial class Form1 : Form
    {
        private Button[,] banCo;
        private int size;

        public Form1()
        {
            InitializeComponent();

            taiGiaoDien();
        }

        private void taiGiaoDien()
        {
            size = 10;
            banCo = new Button[size, size];

            Button btn;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    btn = createButton(j * 40, i * 40);
                    pnBanCo.Controls.Add(btn);
                    banCo[i, j] = btn;
                }
            }
        }

        private Button createButton(int x, int y)
        {
            Button btn = new Button();
            btn.Width = btn.Height = 40;
            btn.Location = new Point(x, y);
            btn.Click += btn_Click;

            return btn;
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.AliceBlue;
        }
    }
}