using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet.Src.Shapes;

public class Shapes
{
    public static Texture2D CreateCircle(GraphicsDevice graphicsDevice,int diameter, Color color)
    {
        Texture2D circleTex = new Texture2D(graphicsDevice, diameter, diameter);
        Color[] colorData = new Color[diameter*diameter];
        float radius = diameter / 2f;
        float radiusSquare = radius * radius;

        for (int x = 0; x < diameter; x++)
        {
            for (int y = 0; y < diameter; y++)
            {
                int index = x * diameter + y;
                Vector2 pos = new Vector2(x - radius, y - radius);
                if (pos.LengthSquared() <= radiusSquare)
                {
                    colorData[index] = color;
                }
                else
                {
                    colorData[index] = Color.Transparent;
                }
            }
        }

        circleTex.SetData(colorData);
        return circleTex;
    }
}
