
using ZeroElectric.Vinculum;

namespace Gyer;

public class Program
{
    public static int DefaultScreenWidth { get; } = 1280;
    public static int DefaultScreenHeight { get; } = 720;

    private static int Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT | ConfigFlags.FLAG_WINDOW_RESIZABLE);

        Raylib.InitWindow(DefaultScreenWidth, DefaultScreenHeight, "Gyer");

        RayGui.GuiLoadStyleDefault();

        Raylib.SetExitKey(KeyboardKey.KEY_NULL);

        GenPoints();

        while (Raylib.WindowShouldClose() == false)
        {
            // Begin drawing to the window
            Raylib.BeginDrawing();

            // Clear the background to white
            Raylib.ClearBackground(Raylib.RAYWHITE);

            foreach (Point item in Points)
            {
                Raylib.DrawCircle(item.X, item.Y, item.Radius, item.Color);
            }

            // End drawing to the window
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();

        return 0;
    }

    static List<Point> Points = [];
    public static void GenPoints()
    {
        int radius = 6;

        int x = 0;
        int y = 0;

        int startX = 0;
        int startY = 10;

        int linePoints = 20;
        int rowPoints = 12;

        int lineAdavnceH = DefaultScreenWidth / linePoints;
        int lineAdvanceV = DefaultScreenHeight / rowPoints;

        int lineAmt = (DefaultScreenWidth / lineAdavnceH) + 1;
        int rowAmt = (DefaultScreenHeight / lineAdvanceV) + 1;

        bool isOdd = false;
        for (int vert = 0; vert < rowAmt; vert++)
        {
            for (int ho = 0; ho < lineAmt; ho++)
            {
                if (isOdd)
                {
                    Points.Add(new Point(startX + x, (startY + y) + (lineAdvanceV / 2), radius, Raylib.BEIGE));
                }
                else
                {
                    Points.Add(new Point(startX + x, startY + y, radius, Raylib.BEIGE));
                }

                Vector3 vector = new Vector3();

                vector.x = 1;
                vector.y = 2;
                vector.z = 42;

                x += lineAdavnceH;
                isOdd = !isOdd;
            }

            isOdd = false;
            y += lineAdvanceV;
            x = startX;
        }
    }
}

class Vector3
{
    public int x;
    public int y;
    public int z;
}

public class Point(int x, int y, int radius, Color color)
{
    public int X = x;
    public int Y = y;

    public Color Color = color;
    public int Radius = radius;
}
