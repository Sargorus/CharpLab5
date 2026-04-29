using CharpLab5.Objects;

namespace CharpLab5
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;

        public Form1()
        {
            InitializeComponent();
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            // реакция на пересечение
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(marker);
            objects.Add(player);
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; // вытащили объект графики из события


            //g.FillRectangle(new SolidBrush(Color.White), 0, 0, pbMain.Width, pbMain.Height);
            // залил фон (можно и так)
            g.Clear(Color.White);

            updatePlayer();

            // Пересечения их пересчет
            foreach (var obj in objects.ToList())
            {
                // Проверка столкновления с игроком 
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj); // Игрок пересекся с объектом
                    obj.Overlap(player); // И объект пересекся с игроком
                }
            }

            // Перерисуем
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0,0,0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void updatePlayer()
        {
            if (marker != null)
            {
                // Расчет вектора между игроком и маркером
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                // Нахождение длинны
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length; // Нормализация координаты
                dy /= length;

                // Пересчет координаты игрока
                player.vX += dx * 0.3f;
                player.vY += dy * 0.25f;

                // Расчёт угла поворота игрока
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            // тормозящий момент,
            // нужен чтобы, когда игрок достигнет маркера произошло постепенное замедление
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            // пересчет позиция игрока с помощью вектора скорости
            player.X += player.vX;
            player.Y += player.vY;
        }
    }
}
