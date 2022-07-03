using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloApp
{
    public partial class Form2 : Form
    {
        Point moveStart; // точка для перемещения

        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Yellow;
            Button button2 = new Button
            {
                Location = new Point
                {
                    X = this.Width / 3,
                    Y = this.Height / 3
                }
            };
            button2.Text = "Закрыть";
            button2.Click += button2_Click;
            this.Controls.Add(button2); // добавляем кнопку на форму
            this.Load += Form2_Load;
            this.MouseDown += Form2_MouseDown;
            this.MouseMove += Form2_MouseMove;
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.Yellow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }
  

    private void Form2_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            // создаем эллипс с высотой и шириной формы
            myPath.AddEllipse(0, 0, this.Width, this.Height);
            // создаем с помощью элипса ту область формы, которую мы хотим видеть
            Region myRegion = new Region(myPath);
            // устанавливаем видимую область
            this.Region = myRegion;
        }
    }
}
