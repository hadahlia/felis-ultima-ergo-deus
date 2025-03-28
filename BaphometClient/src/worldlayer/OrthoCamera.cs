using Microsoft.Xna.Framework;
using System;

namespace Baphomet.Src;

public class OrthoCamera
{
    public Vector3 position { get; set; }

    public Vector3 target { get; set; }
    public float zoom { get; set; }


    //private Matrix rotationX { get; set; }
    //private Matrix rotationY { get; set; }

    public int ViewportWidth { get; set; }
    public int ViewportHeight { get; set; }

    public OrthoCamera()
    {
        position = new Vector3(0f,1f,100f);
        target = new Vector3(0f, 0f, -1f);

        
        //position = Vector3.Transform(position, rotationX);
        //position = Vector3.Transform(position, rotationY);
    }

    public Matrix ProjectionMatrix
    {
        get
        {
            //return Matrix.CreateOrthographic((float)ViewportWidth, (float)ViewportHeight, 1.0f, 1000.0f);
            return Matrix.CreateOrthographic((float)ViewportWidth, (float)ViewportHeight, 1.0f, 1000.0f);
        }
    }

    public Matrix ViewMatrix
    {
        get
        {
            return Matrix.CreateLookAt(position, target, Vector3.Up);
        }
    }

    public Matrix WorldMatrix
    {
        get
        {
            return Matrix.CreateWorld(target, Vector3.Forward, Vector3.Up); //* Matrix.CreateTranslation(new Vector3(0,0,0));
        }
    }

    public Matrix RotationMatrix
    {
        get
        {
            //return Matrix.CreateRotationX(MathHelper.ToRadians(60f)) *
            //    Matrix.CreateRotationY(MathHelper.ToRadians(45f)) *
            //    Matrix.CreateRotationZ(0f);

            return Matrix.CreateRotationX(MathHelper.ToRadians(0f)) *
                Matrix.CreateRotationY(MathHelper.ToRadians(0f)) *
                Matrix.CreateRotationZ(0f);
            //rotationX = Matrix.CreateRotationX(MathHelper.ToRadians(60f));
            //rotationY = Matrix.CreateRotationY(MathHelper.ToRadians(45f));
        }
    }

    public Vector2 ViewportCenter
    {
        get
        {
            return new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f);
        }
    }

    //public Matrix TranslationMatrix
    //{
    //    get
    //    {
    //        return Matrix.CreateTranslation(-(int)position.X,
    //            -(int)position.Y, 0) *
    //            Matrix.CreateRotationZ(rotation) *
    //            Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
    //            Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
    //    }
    //}

    //public void AdjustZoom(float amount)
    //{
    //    zoom += amount;
    //    if (zoom < 0.25f)
    //    {
    //        zoom = 0.25f;
    //    }
    //}

    public void MoveCamera(Vector3 offset, bool clamp = false)
    {
        Vector3 newPos = position + offset;

        if (clamp)
        {
            //uhhhhhh
        }
        else
        {
            position = newPos;
        }
    }

    //public void CenterCam() for later ig. center on player?
    //
    //public void HandleInput()

    //public Vector2 WorldToScreen(Vector3 worldPos)
    //{
    //    return Vector3.Transform(worldPos, TranslationMatrix);
    //}

    //public Vector2 ScreenToWorld(Vector2 screenPos)
    //{
    //    return Vector2.Transform(screenPos,
    //        Matrix.Invert(TranslationMatrix));
    //}
}
