public class GridPositionWithOrientation : IPosition {
    public int xCoordinate {get; set;}
    public int yCoordinate {get; set;}
    public string orientation;
    public string commands;
    public bool isLost;

    public bool GetisLost(int row, int col)
    {
        return xCoordinate < 0 || yCoordinate < 0 || xCoordinate > row - 1 || yCoordinate > col - 1;
    }

    public GridPositionWithOrientation(int x, int y, string d, string cmds) {
        this.xCoordinate = x;
        this.yCoordinate = y;
        this.orientation = d;
        this.commands = cmds;
    }
}
