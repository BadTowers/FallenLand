namespace FallenLand
{
    public class Coordinates
    {
        private int X;
        private int Y;

        public Coordinates(int x, int y)
        {
            if (x < Constants.INVALID_LOCATION)
            {
                x = Constants.INVALID_LOCATION;
            }
            if (y < Constants.INVALID_LOCATION)
            {
                y = Constants.INVALID_LOCATION;
            }
            X = x;
            Y = y;
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public override bool Equals(object Obj)
        {
            if (X == ((Coordinates)Obj).X && Y == ((Coordinates)Obj).Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return System.Tuple.Create(X, Y).GetHashCode();
        }

        public override string ToString()
        {
            return "(x, y) = (" + X.ToString() + ", " + Y.ToString() + ")";
        }
    }
}