using System;
using System.Collections.Generic;

namespace Hangman_Game_C_
{
    public static class Word
    {
        private static List<string> words = new List<string>
        {
            "BOOK", "CAKE", "FISH", "GIRL", "HAND", "LAMP", "MILK", "MOON", "NOSE", "RAIN",
            "ROAD", "ROCK", "SHIP", "STAR", "TREE", "WIND", "DOOR", "FROG", "GOAT", "HILL",
            "APPLE", "BREAD", "CHAIR", "DANCE", "EAGLE", "FLAME", "GRAPE", "HEART", "JELLY", "KNIFE",
            "LEMON", "MUSIC", "NIGHT", "OCEAN", "PIANO", "QUEEN", "RIVER", "SNAKE", "SPOON", "TABLE",
            "BANANA", "CASTLE", "PLANET", "RABBIT", "BOTTLE", "CAMERA", "SILVER", "PIRATE", "WINDOW", "PENCIL",
            "DRAGON", "FOREST", "MOTHER", "GUITAR", "OFFICE", "CLOSET", "ROCKET", "TRAVEL", "SCHOOL", "ORANGE",
            "COLD", "COOL", "FACE", "JUMP", "KING", "LAKE", "LEAF", "LOVE", "PAGE", "RING",
            "BRUSH", "CLOUD", "DRINK", "FLUTE", "GLASS", "HONEY", "JUMPS", "LIGHT", "PLANT", "WATCH",
            "BUTTER", "CIRCLE", "DANGER", "FRIEND", "INSECT", "LETTER", "MARKET", "NAPKIN", "RESCUE", "SUNSET"
        };
        private static int Length { get; set; } = words.Count;
        public static string GetRandomWord()
        {
            int randomIndex = Utilities.GetRandomNumber(0, Length);
            return words[randomIndex];
        }
    }
}
