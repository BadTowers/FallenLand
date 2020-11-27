
namespace FallenLand
{
    public class Coordinates
    {
        private readonly int X;
        private readonly int Y;

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

        public override bool Equals(object obj)
        {
            bool areEqual = false;
            if (obj is Coordinates rightHand)
            {
                if (X == rightHand.X && Y == rightHand.Y)
                {
                    areEqual = true;
                }
            }

            return areEqual;
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