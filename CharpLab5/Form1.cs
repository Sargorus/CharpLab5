using System.Collections.Generic;
using System.Windows.Forms;
using CharpLab5.Objects;

namespace CharpLab5
{
    public partial class Form1 : Form
    {
        public float spore = 0;

        public static Random rnd = new Random();

        List<BaseObject> objects = new();
        Player player;
        Marker marker;


        public Form1()
        {
            InitializeComponent();
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            player.OnGreenMarkerOverlap += (m) =>
            {
                spore = m.cost + spore;
                txtLog.Text = $"{DateTime.Now:HH:mm:ss:ff}] Объект: {m} , был пренесен на координаты: {m.X} , {m.Y}.\n" + txtLog.Text;
                txtLog.Text = $"{DateTime.Now:HH:mm:ss:ff}] Добавлено: {m.cost} очков!\n" + txtLog.Text;
                objects.Remove(m);
                createGreen(objects);
                labelSpore.Text = $"Очки: {spore}";
            };


            
            for (int i = 0; i < 2; i++)
            {
                createGreen(objects);
            }

            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);


            objects.Add(marker);
            objects.Add(player);
            createGreen(objects);
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; 
            g.Clear(Color.White);

            updatePlayer();


            foreach (var obj in objects.ToList())
            {

                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj); 
                    obj.Overlap(player); 
                }
                if (obj is GreenCircle)
                {
                    obj.ToTick();
                }
                if(obj is GreenCircle)
                { 

                }
            }

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
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void updatePlayer()
        {
            if (marker != null)
            {

                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length; 
                dy /= length;

                player.vX += dx * 10.9f;
                player.vY += dy * 0.9f;


                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;


            player.X += player.vX;
            player.Y += player.vY;
        }

        private void createGreen(List<BaseObject> objects)
        {
            GreenCircle g = new GreenCircle(( rnd.Next() % (pbMain.Width - 25) + 25 ) , (rnd.Next() % (pbMain.Height - 25)), 0, rnd.Next() % 13 + 2, rnd.Next() % 350 + 100);
            g.ToDieOfOld += (green) =>
            {
                objects.Remove(green);
                createGreen(objects);
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Зелёный кружок умер, создан новый\n" + txtLog.Text;
            };
            objects.Add(g);
        }
    }

}
