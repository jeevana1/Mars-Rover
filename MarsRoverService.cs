using System;
using System.Collections.Generic;
public class MarsRoverService {
    int row = 0, col = 0;
    public MarsRoverService(int r, int c) {
        this.row = r;
        this.col = c;
    }

    private string GetMapKey(string orientation, string rot) {
        return orientation + rot;
    }

    public void Rotate(GridPositionWithOrientation bot, string direction) {
        if (bot.isLost)
        return;
        string key = GetMapKey(bot.orientation, direction);
        string value;
        bool isValuePresent = Constants.directionMap.TryGetValue(key, out value);
        if (isValuePresent)
        bot.orientation = value;
    }

    public void MoveForward(GridPositionWithOrientation bot) {
    if (bot.isLost)
    return;

    int[] updateBy = Constants.moveCoordinateDictionary[bot.orientation];
    bot.xCoordinate += updateBy[0];
    bot.yCoordinate += updateBy[1];
    MarkLastKnownPosition(bot, updateBy);
    }

    public void MarkLastKnownPosition (GridPositionWithOrientation bot, int[] commandToRevert) {
        if (bot.GetisLost(this.row, this.col)) {
            bot.isLost = true;
            bot.xCoordinate -= commandToRevert[0];
            bot.yCoordinate -= commandToRevert[1];
        }
    }
}
