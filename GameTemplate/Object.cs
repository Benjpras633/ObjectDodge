using System;
using System.Drawing;

namespace GameTemplate
{
    class Object
    {
        public Color color;
        public int x, y, size;

        public Object(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public Object(int _x, int _y, int _size, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            color = _color;
        }

        public void Fall(int speed)
        {
            y += speed;
        }

        public void Move(int speed, Boolean direction)
        {
            if (direction)
            {
                x += speed;
            }
            else
            {
                x -= speed;
            }
        }
    }
}
