using GameHack.GameElement;
using Microsoft.Xna.Framework;


namespace GameHack.GameLogic
{
    class GameProcess
    {
        public static bool Validate(int from, Point currentPoint, Item[,] fields, string type, Point lastPoint)
        {
            Item current = fields[currentPoint.X,currentPoint.Y];
            if (current == null)
                return false;
            if(from == 4)
            {
                if (current.resourceType != type)
                    return false;
                if (current.ElementType.X == -1)
                {
                    current.turn = 0;
                    int newFrom = current.ElementType.Y == 1 ? 3 : 1;
                    if(newFrom == 3)
                    {
                        if (currentPoint.Y - current.ElementType.Y < 0)
                        {
                            if (new Point(currentPoint.X, currentPoint.Y - current.ElementType.Y) != lastPoint)
                                return false;
                            else return true;
                        }
                    }
                    else if(currentPoint.Y - current.ElementType.Y >= 10)
                    {
                        if (new Point(currentPoint.X, currentPoint.Y - current.ElementType.Y) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X, currentPoint.Y - current.ElementType.Y), fields, type, lastPoint);
                }
                else if((current.ElementType.X == 0 && current.ElementType.Y == 1) || (current.ElementType.X == 1 && current.ElementType.Y == 0) || (current.ElementType.X == 0 && current.ElementType.Y == 0 ))
                {
                    current.turn = 0;
                    int newFrom = 4;
                    if (currentPoint.X + 1 >= 10)
                    {
                        if (new Point(currentPoint.X + 1, currentPoint.Y) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X + 1, currentPoint.Y), fields, type, lastPoint);
                }
                else return false;
            }
            if(from == 2)
            {
                if (current.resourceType != type)
                    return false;
                if (current.ElementType.X == 1 && current.ElementType.Y != 0)
                {
                    current.turn = 0;
                    int newFrom = current.ElementType.Y == 1 ? 3 : 1;
                    if (currentPoint.Y - current.ElementType.Y < 0 || currentPoint.Y - current.ElementType.Y > 10)
                    {
                        if (new Point(currentPoint.X, currentPoint.Y - current.ElementType.Y) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X, currentPoint.Y - current.ElementType.Y), fields, type, lastPoint);
                }
                else if ((current.ElementType.X == 0 && current.ElementType.Y == 1) || (current.ElementType.X == 1 && current.ElementType.Y == 0) || (current.ElementType.X == 0 && current.ElementType.Y == 0))
                {
                    current.turn = 0;
                    int newFrom = 2;
                    if (currentPoint.X - 1 < 0)
                    {
                        if (new Point(currentPoint.X - 1, currentPoint.Y) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X - 1, currentPoint.Y), fields, type, lastPoint);
                }
                else return false;
            }
            if (from == 3)
            {
                if (current.ElementType.Y == -1 && current.ElementType.X != 0)
                {
                    if (current.resourceType != type)
                        return false;
                    current.turn = 0;
                    int newFrom = current.ElementType.X == 1 ? 4 : 2;
                    if (currentPoint.X + current.ElementType.X > 10)
                    {
                        if (new Point(currentPoint.X + current.ElementType.Y, currentPoint.Y ) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X + current.ElementType.X, currentPoint.Y), fields, type, lastPoint);
                }
                else if ((current.ElementType.X == 0 && current.ElementType.Y == -1) || (current.ElementType.X == 1 && current.ElementType.Y == 0))
                {
                    if (current.resourceType != type)
                        return false;
                    current.turn = 0;
                    int newFrom = 3;
                    if (currentPoint.Y - 1 < 0)
                    {
                        if (new Point(currentPoint.X, currentPoint.Y - 1) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X, currentPoint.Y - 1), fields, type, lastPoint);
                }
                else if (current.ElementType.X == 0 && current.ElementType.Y == 0)
                {
                    if (current.resourceType2 != type)
                        return false;
                    current.turn = 0;
                    int newFrom = 3;
                    if (currentPoint.Y - 1 < 0)
                    {
                        if (new Point(currentPoint.X, currentPoint.Y - 1) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X, currentPoint.Y - 1), fields, type, lastPoint);
                }
                else return false;
            }
            if (from == 1)
            {
                if (current.ElementType.Y == 1 && current.ElementType.X != 0)
                {
                    if (current.resourceType != type)
                        return false;
                    current.turn = 0;
                    int newFrom = current.ElementType.X == 1 ? 4 : 2;
                    if (currentPoint.X + current.ElementType.X > 10 || currentPoint.X + current.ElementType.X < 0)
                    {
                        if (new Point(currentPoint.X + current.ElementType.X, currentPoint.Y) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X + current.ElementType.X, currentPoint.Y), fields, type, lastPoint);

                }
                else if ((current.ElementType.X == 0 && current.ElementType.Y == -1) || (current.ElementType.X == 1 && current.ElementType.Y == 0))
                {
                    if (current.resourceType != type)
                        return false;
                    current.turn = 0;
                    int newFrom = 1;
                    if (currentPoint.Y + 1 >= 10)
                    {
                        if (new Point(currentPoint.X, currentPoint.Y + 1) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X, currentPoint.Y + 1), fields, type, lastPoint);
                }
                else if (current.ElementType.X == 0 && current.ElementType.Y == 0)
                {
                    if (current.resourceType2 != type)
                        return false;
                    current.turn = 0;
                    int newFrom = 3;
                    if (currentPoint.Y + 1 >= 10)
                    {
                        if (new Point(currentPoint.X, currentPoint.Y + 1) != lastPoint)
                            return false;
                        else return true;
                    }
                    return Validate(newFrom, new Point(currentPoint.X, currentPoint.Y + 1), fields, type, lastPoint);
                }
                else return false;
            }
            return false;
        }
    }
}
