using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace BalloonGame
{
    /// <summary>
    /// 气球类
    /// </summary>
    public class Balloon
    {
        #region 静态属性
        /// <summary>
        /// 屏幕当前气球个数
        /// </summary>
        public static int Count { get; set; }

        /// <summary>
        /// 点击次数
        /// </summary>
        public static int HitCount { get; set; }
        #endregion

        #region 气球属性
        private int x;
        private int y;
        private int with;
        private Color color;
        private int speed;
        /// <summary>
        /// 气球的水平坐标
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
        /// <summary>
        /// 气球的垂直坐标
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        /// <summary>
        /// 气球的宽度
        /// </summary>
        public int With
        {
            get
            {
                return with;
            }

            set
            {
                with = value;
            }
        }
        /// <summary>
        /// 气球高度
        /// </summary>
        public int Height
        {
            get
            {
                return (int)(with * 1.2);
            }
        }
        /// <summary>
        /// 气球颜色
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }
        /// <summary>
        /// 气球上升速度
        /// </summary>
        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 获取气球的外接矩形
        /// </summary>
        /// <returns></returns>
        public Rectangle GetBounds()
        {
            Rectangle rectangle = new Rectangle
            {
                X = x,
                Y = y,
                Height = Height,
                Width = with
            };
            return rectangle;
        }
        /// <summary>
        /// 绘制气球
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// 
        public void Draw(Graphics g)
        {
            Color borderColor = Color.FromArgb(210, color.R,color.G,color.B);
            Color balloonColor = Color.FromArgb(210, color.R, color.G, color.B);
            Pen penBorder = new Pen(borderColor);
            Brush brush = new SolidBrush(balloonColor);
            g.FillEllipse(brush, GetBounds());
            g.DrawEllipse(penBorder, GetBounds());
        }
        
        /// <summary>
        /// 气球上升
        /// </summary>
        /// <param name="clientHeight"></param>
        public void Up(int clientHeight ,int clientWidth)
        {
            y -= speed;
            Random r = new Random();
            int n = r.Next(0,2);
            if(n==0)
            {
                x -= speed;
            }
            else
            {
                x +=speed;
            }
            if (y < -1 * this.Height && x<-1*this.With)
            {
                y = clientHeight;
                x = clientWidth;
            }
            
            
               
            
            if (y < -1 * this.Height && x < -1 * this.With)
            {
                y = clientHeight;
                x = clientWidth;
            }

        }
        /// <summary>
        /// 测试是否击中气球内部
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsHit(int x, int y)
        {
            int deltaX = x - Center.X;
            int deltaY = y - Center.Y;
            int distance = (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            bool isHit = distance < with / 2;
            if (isHit)
            HitCount++;
             return isHit;

        }
        public bool IsEnter(int x,int y)
        {

            int deltaX = x - Center.X;
            int deltaY = y - Center.Y;
            int distance = (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            bool isEnter = distance < with / 2;
            if (isEnter) HitCount++;
            return isEnter;
        }

        /// <summary>
        /// 气球中心点
        /// </summary>
        public Point Center
        {
            get
            {
                Point point = new Point(x + with / 2, y + Height / 2);
                return point;
            }
        }
        #endregion

        #region 构造和析构函数
        public Balloon()
        {
            Count++;
        }
        ~Balloon()
        {
            Count--;
        } 
        #endregion
    }
   
}
