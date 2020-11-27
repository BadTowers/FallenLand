
namespace FallenLand
{
    public class GameWorldCoordinates
    {
        private readonly float X;
        private readonly float Y;

        public GameWorldCoordinates(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float GetX()
        {
            return X;
        }

        public float GetY()
        {
            return Y;
        }
    }
}