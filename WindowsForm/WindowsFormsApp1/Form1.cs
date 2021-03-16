using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }
        public List<TVector> PointsEiler=null;
        public List<TVector> PointsKutt = null;
        public class TVector
        {
           public double[] Vec;
        }

        public List<TVector> ReadFile(string FName) //функция чтения файла
        {
            List<TVector> result = null;
            using (FileStream fstream = File.OpenRead(FName))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
                int ItemsCount = textFromFile.Split('\n').Length;
                result = textFromFile.Split('\n').Take(ItemsCount / 4 - 1).Select(x => new TVector()
                {
                    Vec = x.Split('|').Select(y => double.Parse(y.Replace('.', ','))).ToArray()
                }).ToList();
            }
            return result;
        }
  
private void Eiler_Click(object sender, EventArgs e)//ЭЙЛЕР
        {
            if (PointsEiler == null) { PointsEiler = ReadFile("result_TEuler.txt"); }
            
            Graphics g = GraphXYZ.CreateGraphics();
            Graphics gr = GraphSpeed.CreateGraphics();
            Pen myPen1 = new Pen(Color.Blue);
            Pen myPen2 = new Pen(Color.Red);
            Pen myPen3 = new Pen(Color.Green);
            Pen myPen4 = new Pen(Color.Black,2);
            double xmax = PointsEiler.Count;

            double ymax = Math.Max(Math.Max(PointsEiler.Max(x=>Math.Abs(x.Vec[0])), PointsEiler.Max(x=>Math.Abs(x.Vec[1]))), PointsEiler.Max(x => Math.Abs(x.Vec[2])));
           
            //масштаб
            double kx = GraphXYZ.Width / xmax; 
            double ky = GraphXYZ.Height / ymax/2.8;
            TVector PrevPoint = PointsEiler.FirstOrDefault();
            PrevPoint.Vec = new double[6] { 0, 0, 0, 0, 0, 0 };

            //ОСИ
            g.DrawLine(myPen4, 0, GraphXYZ.Height / 2,GraphXYZ.Width,GraphXYZ.Height/2);
            g.DrawLine(myPen4, 10, 10, 10, GraphXYZ.Height -10);

            //КООРДИНАТЫ
            int index = 0;
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush1 = new SolidBrush(Color.Blue);
            g.DrawString("X", drawFont, drawBrush1, new Point(10, 10));
            SolidBrush drawBrush2 = new SolidBrush(Color.Red);
            g.DrawString("Y", drawFont, drawBrush2, new Point(10,30));
            SolidBrush drawBrush3 = new SolidBrush(Color.Green);
            g.DrawString("Z", drawFont, drawBrush3, new Point(10, 50));
            foreach (var Point in PointsEiler)
            {       
                g.DrawLine(myPen1, (int)(kx *index), (int)(GraphXYZ.Height/2 + ky * PrevPoint.Vec[0]), (int)(kx * (index+1)), (int)(GraphXYZ.Height/2  + ky * Point.Vec[0]));
                g.DrawLine(myPen2, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[1]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[1]));
                g.DrawLine(myPen3, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[2]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[2]));
                PrevPoint = Point;
                index++;
            }

            //СКОРОСТИ
            ymax = Math.Max(Math.Max(PointsEiler.Max(x => Math.Abs(x.Vec[3])), PointsEiler.Max(x => Math.Abs(x.Vec[4]))), PointsEiler.Max(x => Math.Abs(x.Vec[5])));
            ky = GraphXYZ.Height / ymax / 2.8;
            gr.DrawLine(myPen4, 0, GraphXYZ.Height / 2, GraphXYZ.Width, GraphXYZ.Height / 2);
            gr.DrawLine(myPen4, 10, 10, 10, GraphXYZ.Height - 10);
            index = 0;
            gr.DrawString("Ux", drawFont, drawBrush1, new Point(10, 10));          
            gr.DrawString("Uy", drawFont, drawBrush2, new Point(10, 30));           
            gr.DrawString("Uz", drawFont, drawBrush3, new Point(10, 50));
            foreach (var Point in PointsEiler)
            {
                gr.DrawLine(myPen1, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[3]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[3]));
                gr.DrawLine(myPen2, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[4]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[4]));
                gr.DrawLine(myPen3, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[5]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[5]));
                PrevPoint = Point;
                index++;
            }

        }

        private void Kutt_Click(object sender, EventArgs e) //РУНГЕ-КУТТ
        {
            if (PointsKutt == null) { PointsKutt = ReadFile("result_TRungeKutta.txt"); }
            Graphics g = GraphXYZ.CreateGraphics();
            Graphics gr = GraphSpeed.CreateGraphics();
            Pen myPen1 = new Pen(Color.Blue);
            Pen myPen2 = new Pen(Color.Red);
            Pen myPen3 = new Pen(Color.Green);
            Pen myPen4 = new Pen(Color.Black, 2);
            double xmax = PointsKutt.Count;

            double ymax = Math.Max(Math.Max(PointsKutt.Max(x => Math.Abs(x.Vec[0])), PointsKutt.Max(x => Math.Abs(x.Vec[1]))), PointsKutt.Max(x => Math.Abs(x.Vec[2])));

            //масштаб
            double kx = GraphXYZ.Width / xmax;
            double ky = GraphXYZ.Height / ymax / 2.8;
            TVector PrevPoint = PointsKutt.FirstOrDefault();
            PrevPoint.Vec = new double[6] { 0, 0, 0, 0, 0, 0 };
            
            //ОСИ
            g.DrawLine(myPen4, 0, GraphXYZ.Height / 2, GraphXYZ.Width, GraphXYZ.Height / 2);
            g.DrawLine(myPen4, 10, 10, 10, GraphXYZ.Height - 10);

            //КООРДИНАТЫ
            int index = 0;
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush1 = new SolidBrush(Color.Blue);
            g.DrawString("X", drawFont, drawBrush1, new Point(10, 10));
            SolidBrush drawBrush2 = new SolidBrush(Color.Red);
            g.DrawString("Y", drawFont, drawBrush2, new Point(10, 30));
            SolidBrush drawBrush3 = new SolidBrush(Color.Green);
            g.DrawString("Z", drawFont, drawBrush3, new Point(10, 50));
            foreach (var Point in PointsKutt)
            {
                g.DrawLine(myPen1, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[0]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[0]));
                g.DrawLine(myPen2, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[1]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[1]));
                g.DrawLine(myPen3, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[2]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[2]));
                PrevPoint = Point;
                index++;
            }

            //СКОРОСТИ
            ymax = Math.Max(Math.Max(PointsKutt.Max(x => Math.Abs(x.Vec[3])), PointsKutt.Max(x => Math.Abs(x.Vec[4]))), PointsKutt.Max(x => Math.Abs(x.Vec[5])));
            ky = GraphXYZ.Height / ymax / 2.8;
            gr.DrawLine(myPen4, 0, GraphXYZ.Height / 2, GraphXYZ.Width, GraphXYZ.Height / 2);
            gr.DrawLine(myPen4, 10, 10, 10, GraphXYZ.Height - 10);
            index = 0;
            gr.DrawString("Ux", drawFont, drawBrush1, new Point(10, 10));
            gr.DrawString("Uy", drawFont, drawBrush2, new Point(10, 30));
            gr.DrawString("Uz", drawFont, drawBrush3, new Point(10, 50));
            foreach (var Point in PointsKutt)
            {
                gr.DrawLine(myPen1, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[3]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[3]));
                gr.DrawLine(myPen2, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[4]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[4]));
                gr.DrawLine(myPen3, (int)(kx * index), (int)(GraphXYZ.Height / 2 + ky * PrevPoint.Vec[5]), (int)(kx * (index + 1)), (int)(GraphXYZ.Height / 2 + ky * Point.Vec[5]));
                PrevPoint = Point;
                index++;
            }

        }

        private void button1_Click(object sender, EventArgs e)//ОЧИСТИТЬ
        {
             GraphXYZ.CreateGraphics().Clear(Color.White);
             GraphSpeed.CreateGraphics().Clear(Color.White);

        }

       
    }
}
