Problem:

    Given a 2D grid and few bots positioned in the grid, Move the bots in the grid based on the commands entered
        - each bot position is given by x, y co-ordinates and orientation
        - commands are L(rotate left), R(rotate right), F (forward)

Overview:

    GridPositionWithOrientation: represents the each bot position.

    MarsRoverService: Has main functionalities

        - Move Forward
        - Rotate Left
        - Rotate Right
        - If Lost Move to Last Know position
    Service functionalities use the dictionaries from static constant class
    Constants: Maintained two dictionaries
        1. Dictionary to know the final orientation given initial orientation and rotate direction.
        2. Dictionary to know the update value required for both co-ordinates given a direction.
    MarsRoverController: Main entry point to read input and write output, Few invalid input exceptions are handled. Each test case is handled parallely.

Sample Input:

    Enter Input:
    4 8 // Grid Size
    1   // Number of bots
    2 3 E LFRFF // position with Commands

Sample Output:

    Last known positions of bots:
    3 4 E LOST

Running on cmd line:

    dotnet run < input.txt
    dotnet run < input2.txt

