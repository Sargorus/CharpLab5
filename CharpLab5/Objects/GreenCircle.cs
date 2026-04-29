using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharpLab5.Objects
{
    internal class GreenCircle : BaseObject
    {
        public Action<GreenCircle> ToDieOfOld;
        public float cost;
        public float timeToLive;
        public GreenCircle(float x, float y, float angle, float cost, float timeToLive) : base(x, y, angle)
        {
            this.cost = cost;
            this.timeToLive = timeToLive;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), -3, -3, 6, 6);
            g.DrawEllipse(new Pen(Color.Green, 2), -6, -6, 12, 12);
            g.DrawString(
                        $"Живет ещё {this.timeToLive}",
                        new Font("Verdana", 8), 
                        new SolidBrush(Color.Green), 
                        10, 10 
);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);
            return path;
        }

        public override void ToTick()
        {
            this.timeToLive -= 10.1f;
            if(this.timeToLive <= 0)
            {
                ToDieOfOld?.Invoke(this);
            }
        }

    }
}
