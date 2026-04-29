using CharpLab5.Objects;

namespace CharpLab5
{
    public partial class Form1 : Form
    {
        MyRectangle myRect; // создадим поле под наш пр€моугольник
        public Form1()
        {
            InitializeComponent();
            myRect = new MyRectangle(100, 100, 0); // создать экземпл€р класса
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; // вытащили объект графики из событи€

            // залил фон
            //g.FillRectangle(new SolidBrush(Color.White), 0, 0, pbMain.Width, pbMain.Height);
            // залил фон (можно и так)
            g.Clear(Color.White);

            g.Transform = myRect.GetTransform();

            myRect.Render(g); // теперь так рисуем
            
        }
    }
}
