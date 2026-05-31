using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    public Form1()
    {
        this.Text = "Лабораторна 5 - варіант а";
        this.Width = 1980;
        this.Height = 1080;
        this.BackColor = Color.WhiteSmoke;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        //  1 Півколо 
        // DrawArc малює дугу: (x, y, шир, вис, початковий кут, кут дуги)
        Pen penBlue = new Pen(Color.DarkBlue, 3);
        g.DrawArc(penBlue, 80, 60, 160, 160, 0, 180);
        //                  x  y    шир вис від скільки
        // діаметр (пряма лінія внизу)
        g.DrawLine(penBlue, 80, 140, 240, 140);
        //від  x   y  до x   y

        // 2 Квадрат, сторони якого НЕ паралельні осям
        // Рахуємо 4 вершини квадрата вручну, повернутого на angel градусів

        float cx = 600, cy = 200;
        float side = 300;
        float angle = 45; //градус повороту 
        float rad = angle * (float)Math.PI / 180f; // перевод  в радіани

        // 1\2 сторони діагоналі
        float half = side / 2f;
        float dist = (float)Math.Sqrt(half * half + half * half);  // відстань від центру до кута

        PointF[] pts = new PointF[4];
        for (int i = 0; i < 4; i++)
        {
            // кути квадрата без повороту
            float baseAngle = (float)(Math.PI / 4 + Math.PI / 2 * i); // 45, 135, 225, 315 градусів
            pts[i] = new PointF(
                cx + dist * (float)Math.Cos(baseAngle + rad),
                cy + dist * (float)Math.Sin(baseAngle + rad)
            );
        }

        Pen penGreen = new Pen(Color.DarkGreen, 3);
        g.DrawPolygon(penGreen, pts); // замикає точки

        // 3 Зафарбований сектор кола 
        // FillPie заповнює сектор кольором
        // DrawPie малює контур сектора
        SolidBrush brushRed = new SolidBrush(Color.Tomato); //заливка
        Pen penRed = new Pen(Color.DarkRed, 2); //контур

        int sx = 430, sy = 300; // верхній лівий кут описаного прямокутника
        int diam = 180;//діаметр кола
        float startAngle = 20;   // звідки починається сектор
        float sweepAngle = 110;  // на скільки градусів розкривається

        g.FillPie(brushRed, sx, sy, diam, diam, startAngle, sweepAngle);
        g.DrawPie(penRed, sx, sy, diam, diam, startAngle, sweepAngle);
        //                x   y  шир    вис   звідки      скільки
        // підписи
        Font font = new Font("Arial", 10);
        SolidBrush brushText = new SolidBrush(Color.Black);
        g.DrawString("Півколо", font, brushText, 120, 230);
        g.DrawString("Повернутий квадрат", font, brushText, 600, 280);
        g.DrawString("Сектор кола", font, brushText, 460, 495);

        penBlue.Dispose();
        penGreen.Dispose();
        penRed.Dispose();
        brushRed.Dispose();
        brushText.Dispose();
        font.Dispose();
    }

    [STAThread]
    static void Main()
    {
        Application.Run(new Form1());
    }
}