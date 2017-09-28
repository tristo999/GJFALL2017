using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public static class AppConstants
    {
        public static int numPlayers = 3;
        public static int numRounds = 5;
        public static int currentRound = 0;
        public static float shoutRefreshTime = 2.0f;
        public static int[] score;
        public static int[] playerControls = new int[] {1,2,3,4};
        public static bool[] playerInMatch = new bool[] { false, false, false, false };
}

