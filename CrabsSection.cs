
using System;


namespace Ernest.Solution
{
    public class CrabsSection
    {
        private int numberOfPlays = 0;


        private int? previousValuePlayed = null;

        private Random _random = new Random();

        private int[] record = new int[12];

        public int RollDice()
        {
            var diece1 = _random.Next(1, 7);
            var diece2 = _random.Next(1, 7);
            return diece1 + diece2;
        }


        public (bool, string, int) Play()
        {
            numberOfPlays++;

            var playedValue = RollDice();
            record[playedValue - 1]++;
            var frequency = HighestFrequency(record);
            if (numberOfPlays > 5)
            {
                while (playedValue == frequency)
                {
                    playedValue = RollDice();
                }
            }
            var result = GameRules(previousValuePlayed, playedValue);
            var message = (result) switch
            {
                GameResult.Win => "Hurray! You won.",
                GameResult.Lost => "Awww! You lost. Find money and play again.",
                _ => "Game On Roll dice"
            };

            if (numberOfPlays == 1) previousValuePlayed = playedValue;

            return (result != GameResult.Replay, message, playedValue);
        }




        public GameResult GameRules(int? previousValuePlayed, int currentValuePlayed)
        {
            var Rules = (previousValuePlayed, currentValuePlayed) switch
            {
                (null, 7 or 11) => GameResult.Win,
                (null, 2 or 3 or 12) => GameResult.Lost,
                (null, 4 or 5 or 6 or 8 or 9) => GameResult.Replay,
                (int, 7) => GameResult.Lost,
                (int, _) => (currentValuePlayed == previousValuePlayed ? GameResult.Win : GameResult.Replay)
            };
            return Rules;
        }

        public int HighestFrequency(int[] number)
        {
            int HighestOutCome = 0;
            for (int i = 1; i < number.Length; i++)
            {
                if (number[HighestOutCome] < number[i])
                    HighestOutCome = i;
            }
            return HighestOutCome;

        }


        public enum GameResult
        {
            Win,

            Lost,

            Replay
        }
    }
}
