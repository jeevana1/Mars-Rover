using System.Collections.Generic;
public static class Constants {
         public static Dictionary<string, string> directionMap = new Dictionary<string, string>() {
         {"EL", "N"},
         {"ER", "S"},
         {"WL", "S"},
         {"WR", "N"},
         {"NL", "W"},
         {"NR", "E"},
         {"SL", "E"},
         {"SR", "W"},
    };

    public static Dictionary<string, int[]> moveCoordinateDictionary = new Dictionary<string, int[]>() {
        {"N", new int[2] {0, 1}},
        {"S", new int[2] {0, -1}},
        {"E", new int[2] {1, 0}},
        {"W", new int[2] {-1, 0}}
    };
}
