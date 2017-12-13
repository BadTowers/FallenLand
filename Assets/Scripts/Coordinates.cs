public class Coordinates {

	private int x;
	private int y;

	public Coordinates(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public int getX()
	{
		return x;
	}

	public int getY()
	{
		return y;
	}

	public override bool Equals(object Obj)
	{
		if (this.x == ((Coordinates)Obj).x && this.y == ((Coordinates)Obj).y) {
			return true;
		} else {
			return false;
		}
	}
}
