﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Baphomet.Src;

public class IsoTiles
{
    public Vector3 position {  get; set; }
    //public Sprite _tileTex {  get; set; }

    public IsoTiles()
    {
        position = new Vector3(100,100,0);
    }
    public Texture2D tileTex { get; set; }

    public VertexBuffer buildVertexBuffer(VertexPositionColorTexture[] vertexArray)
    {
        return null;
    }

    public VertexBuffer buildIndexBuffer(short[] indices)
    {
        return null;
    }

    public void LoadContent()
    {
        tileTex = Engine.Content.Load<Texture2D>("tile/tile_0");
    }

    public void Draw(Matrix view, Matrix projection)
    {
        Matrix translateMatrix = Matrix.CreateTranslation(position);
        Matrix worldMatrix = translateMatrix;

    }

    public class Cuboid
    {
        public Cuboid()
        {

        }
    }
}
