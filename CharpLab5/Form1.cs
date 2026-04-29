using CharpLab5.Objects;

namespace CharpLab5
{
    public partial class Form1 : Form
    {
        MyRectangle myRect; // создадим поле под наш прямоугольник
        List<BaseObject> objects = new();

        public Form1()
        {
            InitializeComponent();
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));
            
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; // вытащили объект графики из события

            // залил фон
            //g.FillRectangle(new SolidBrush(Color.White), 0, 0, pbMain.Width, pbMain.Height);
            // залил фон (можно и так)
            g.Clear(Color.White);

            foreach (var obj in objects)
            {
                g.Transform = myRect.GetTransform();
                obj.Render(g);
            }

            
        }
    }
}
