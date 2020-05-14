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
        private bool laNguoiChoiA;

        public Form1()
        {
            InitializeComponent();

            taiGiaoDien();
        }

        private void taiGiaoDien()
        {
            size = 10;
            banCo = new Button[size, size];
            laNguoiChoiA = true;

            Button btn;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    btn = createButton(j * 40, i * 40);
                    pnBanCo.Controls.Add(btn);
                    btn.Tag = i + "," + j;
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

            if (!string.IsNullOrEmpty(btn.Text))
                return;

            btn.BackColor = Color.AliceBlue;

            if (laNguoiChoiA)
                btn.Text = "Cet";
            else
                btn.Text = "Loz";

            //kiem tra co thang game hay la ko.
            if (laThangGame(btn))
            {
                MessageBox.Show("thang");
                return;
            }

            laNguoiChoiA = !laNguoiChoiA;
        }

        private bool laThangGame(Button btn)
        {
            string[] M = btn.Tag.ToString().Split(',');
            Point xy = new Point(int.Parse(M[0]), int.Parse(M[1]));

            //Kiem tra theo hang doc.

            //kiem tra theo hang ngang

            //kiem tra cheo chinh.

            //kiem tra cheo phu.

            return kiemTraDoc(xy);
        }

        private bool kiemTraDoc(Point xy)
        {
            //Tim vi tri bat dau
            int x = xy.X, y = xy.Y;
            string coChoi = banCo[x, y].Text;
            while (x >= 1 && banCo[x - 1, y].Text.Equals(coChoi))
                x -= 1;

            int dem = 1;
            while (x < size - 1 && banCo[x + 1, y].Text.Equals(coChoi))
            {
                dem += 1;
                x += 1;
            }

            return dem >= 5;
        }
    }
}