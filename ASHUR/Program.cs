using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SFML_Test
{
   class Program
    {
        static List<Player> shapes;
        static List<CircleShape> meteorit;
        static List<RectangleShape> bullet;
        static float speed = 1f;
        static float positionX = 100f;
        static float positionY = 100f;
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
    
        static void Main()
        {
            Random random = new Random();
            Console.WriteLine(random.Next(1, 101));
            shapes = new List<Player>();
            meteorit = new List<CircleShape>();
            bullet = new List<RectangleShape>();    
            shapes.Add(new Player(new Vector2f(positionX, positionY), new Vector2f(390, 300), Color.Green));
            bullet.Add(new Bullet(new Vector2f(positionX + 10, positionY ), new Vector2f(20, 50), Color.Blue));
            meteorit.Add(new Meteorit(30, new Vector2f(), Color.Black, shapes[0]));
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            app.Closed += new EventHandler(OnClose);
            app.KeyPressed += OnKeyPressed;
            Event inputEvent;

            while (app.IsOpen)
            {
               
                Color windowColor = new Color(0, 192, 255);
                app.DispatchEvents();
                app.Clear(windowColor);
                shapes[0].Position = new Vector2f(positionX, positionY);
                app.Draw(shapes[0]);
                app.Display();
                
            } 
        }
       public  static float GetDistance(Vector2f a, Vector2f b)
        {

            return MathF.Sqrt(MathF.Pow(a.X - b.X, 2) - MathF.Pow(a.Y - b.Y, 2));
        }
        static void OnKeyPressed(object sender, KeyEventArgs e)
        {

            if (e.Code == Keyboard.Key.W)
            {
                Console.Write(positionX);
                positionY += speed;
            }
            if (e.Code == Keyboard.Key.W)
            {
                Console.Write(positionX);
                positionY += speed;
            }
            if (e.Code == Keyboard.Key.W)
            {
                Console.Write(positionX);
                positionY += speed;
            }
            if (e.Code == Keyboard.Key.W)
            {
                Console.Write(positionX);
                positionY += speed;
            }
        }

    }
    class Player : RectangleShape
    {
        public Player(Vector2f size,Vector2f position , Color color )
        {
            Position = position;
            Size = size;
            FillColor = color;
        }

    }
    class Meteorit : CircleShape
    {
        public Meteorit(int radius, Vector2f position, Color color, Player player)
        {
            Position = position;
            Radius = radius;
            FillColor = color;

            if (Program.GetDistance(Position, player.Position) < 0.5f)
            {
                // TODO
            }
        }

    }
    class Bullet : RectangleShape
    {
        public Bullet(Vector2f posititon, Vector2f size, Color color)
        {
            Position = posititon;
            Size = size;
            FillColor = color;
        }
    }

}