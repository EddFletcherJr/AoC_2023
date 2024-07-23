using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Day11Btn_Click(object sender, EventArgs e)
        {
            String calStr = InputTxtbox.Text;
            int total = 0;

            if (String.IsNullOrEmpty(calStr))
                MessageBox.Show("Calibration Input is Missing");
            else
            {
                String[] calStrs = calStr.Split('\n');

                foreach (String str in calStrs)
                {
                    int firstInt = -1;
                    int lastInt = -1;
                    int combinedInt = -1;

                    Regex regex = new Regex(@"\d+");
                    MatchCollection matches = regex.Matches(str);

                    if (matches.Count > 0)
                    {
                        int.TryParse(matches[0].Value.Substring(0,1), out firstInt);
                        int.TryParse(matches[matches.Count - 1].Value.Substring(matches[matches.Count - 1].Value.Length - 1,1), out lastInt);

                        int.TryParse(firstInt.ToString() + lastInt.ToString(), out combinedInt);
                        total += combinedInt;
                        OutputTxtBox.Text += $"Input {str} Parses {combinedInt.ToString()}. Running Total {total.ToString()}" + Environment.NewLine;
                    }
                    else
                        MessageBox.Show($"Calibration String {str} Contains No Integers");
                }

                OutputTxtBox.Text += $"Final Total {total.ToString()}";
            }
        }

        private void Day12Btn_Click(object sender, EventArgs e)
        {
            String calStr = InputTxtbox.Text;
            int total = 0;
            OutputTxtBox.Text = "";

            String[,] numberMap =
            {
                {"zero","0"},
                {"one","1"},
                {"two","2"},
                {"three","3"},
                {"four","4"},
                {"five","5"},
                {"six","6"},
                {"seven","7"},
                {"eight","8"},
                {"nine","9"}
            };

            if (String.IsNullOrEmpty(calStr))
                MessageBox.Show("Calibration Input is Missing");
            else
            {
                String[] calStrs = calStr.Split('\n');

                foreach (String str in calStrs)
                {
                    //<numWord, NumVal, Index>
                    List<Tuple<string, string, int>> matches = new List<Tuple<string, string, int>>();

                    //Search for words or numbers and store match with index
                    for (int i = 0; i < (numberMap.Length / 2); i++)
                    {
                        //Search for word integers
                        int index = -1;

                        String numWord = numberMap[i, 0];
                        String numInt = numberMap[i, 1];

                        index = 0;
                        while ((index = str.IndexOf(numWord, index)) != -1)
                        {
                            matches.Add(new Tuple<string, string, int>(numWord, numInt, index));
                            index += numWord.Length;
                        }

                        //Search for numeric integers
                        index = 0;
                        while ((index = str.IndexOf(numInt, index)) != -1)
                        {
                            matches.Add(new Tuple<string, string, int>(numWord, numInt, index));
                            index += numInt.Length;
                        }
                    }

                    int firstInt = 0;
                    int lastInt = 0;

                    if(matches.Count() > 0)
                    {
                        matches.Sort((t1, t2) => t1.Item3.CompareTo(t2.Item3));
                        int.TryParse(matches[0].Item2, out firstInt);
                        int.TryParse(matches[matches.Count - 1].Item2, out lastInt);

                        int sum = 0;
                        int.TryParse(firstInt.ToString().Substring(0,1) + (lastInt % 10).ToString(), out sum);

                        total += sum;

                        StringBuilder csvBuilder = new StringBuilder();

                        for (int i = 0; i < matches.Count; i++)
                        {
                            csvBuilder.Append(matches[i].Item2);
                            if (i < matches.Count - 1)
                            {
                                csvBuilder.Append(", ");
                            }
                        }

                        string csvMatches = csvBuilder.ToString();

                        OutputTxtBox.Text += $"{str}{Environment.NewLine}{csvMatches}{Environment.NewLine}   Sum: {sum}{Environment.NewLine}   Running Total: {total}{Environment.NewLine}";
                    }
                    else
                        MessageBox.Show($"Calibration String {str} Contains No Integers");
                }

                OutputTxtBox.Text += $"{Environment.NewLine}Final Total {total.ToString()}";

                OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
                OutputTxtBox.ScrollToCaret();

                MessageBox.Show($"Finished: {total}");
            }
        }

        private void Day21Btn_Click(object sender, EventArgs e)
        {
            int total = 0;
            int redLimit = 12;
            int greenLimit = 13;
            int blueLimit = 14;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                String[] gameEntries = input.Split('\n');
                List<Game> games = new List<Game>();

                foreach (String entry in gameEntries)
                {
                    int colonPos = entry.IndexOf(':');
                    String gameId = entry.Substring(0, colonPos);
                    String[] cubes = entry.Substring(colonPos + 2, entry.Length - colonPos - 2).Split(';');

                    gameId = gameId.Replace("Game ", "");

                    Game curGame = new Game { };
                    curGame.input = entry;
                    curGame.gameId = int.Parse(gameId);
                    curGame.redCount = 0;
                    curGame.greenCount = 0;
                    curGame.blueCount = 0;

                    foreach (String color in cubes)
                    {
                        String[] pairs = color.Split(',');

                        foreach (String str in pairs)
                        {
                            if (curGame.GetValid())
                            {
                                String tmp = str.Trim();
                                String[] scoreColor = tmp.Split(' ');

                                if (scoreColor[1] == "red" && int.Parse(scoreColor[0]) > curGame.redCount) curGame.redCount = int.Parse(scoreColor[0]);
                                if (scoreColor[1] == "green" && int.Parse(scoreColor[0]) > curGame.greenCount) curGame.greenCount = int.Parse(scoreColor[0]);
                                if (scoreColor[1] == "blue" && int.Parse(scoreColor[0]) > curGame.blueCount) curGame.blueCount = int.Parse(scoreColor[0]);
                            }
                        }
                        curGame.SetValid(redLimit, blueLimit, greenLimit);
                    }
                    games.Add(curGame);
                }

                foreach (Game game in games)
                {
                    OutputTxtBox.Text += $"{game.input}{Environment.NewLine}  Red: {game.redCount}{Environment.NewLine}  Green: {game.greenCount}{Environment.NewLine}  Blue: {game.blueCount}{Environment.NewLine}";

                    if (game.GetValid())
                        total += game.gameId;
                }

                OutputTxtBox.Text += $"Total {total.ToString()}";

                OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
                OutputTxtBox.ScrollToCaret();

                MessageBox.Show($"Finished: {total}");
            }
        }

        public class Game
        {
            public String input { get; set; }
            public int gameId { get; set; }
            List<Tuple<int, int, int>> rounds = new List<Tuple<int, int, int>>();
            public int redCount { get; set; }
            public int blueCount { get; set; }
            public int greenCount { get; set; }
            bool valid { get; set; } = true;

            public void SetValid(int redLimit, int blueLimit, int greenLimit)
            {
                if(redCount >= 0 && blueCount >= 0 && greenCount >= 0)
                {
                    if (redCount <= redLimit && blueCount <= blueLimit && greenCount <= greenLimit)
                        valid = true;
                    else
                        valid = false;
                }
            }

            public bool GetValid()
            {
                return valid;
            }
        }

        private void Day22btn_Click(object sender, EventArgs e)
        {
            int total = 0;
            int redLimit = 12;
            int greenLimit = 13;
            int blueLimit = 14;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                String[] gameEntries = input.Split('\n');
                List<Game> games = new List<Game>();

                foreach (String entry in gameEntries)
                {
                    int colonPos = entry.IndexOf(':');
                    String gameId = entry.Substring(0, colonPos);
                    String[] cubes = entry.Substring(colonPos + 2, entry.Length - colonPos - 2).Split(';');

                    gameId = gameId.Replace("Game ", "");

                    Game curGame = new Game { };
                    curGame.input = entry;
                    curGame.gameId = int.Parse(gameId);
                    curGame.redCount = 0;
                    curGame.greenCount = 0;
                    curGame.blueCount = 0;

                    foreach (String color in cubes)
                    {
                        String[] pairs = color.Split(',');

                        foreach (String str in pairs)
                        {
                            if (curGame.GetValid())
                            {
                                String tmp = str.Trim();
                                String[] scoreColor = tmp.Split(' ');

                                if (scoreColor[1] == "red" && int.Parse(scoreColor[0]) > curGame.redCount) curGame.redCount = int.Parse(scoreColor[0]);
                                if (scoreColor[1] == "green" && int.Parse(scoreColor[0]) > curGame.greenCount) curGame.greenCount = int.Parse(scoreColor[0]);
                                if (scoreColor[1] == "blue" && int.Parse(scoreColor[0]) > curGame.blueCount) curGame.blueCount = int.Parse(scoreColor[0]);
                            }
                        }
                    }
                    games.Add(curGame);
                }

                foreach (Game game in games)
                {
                    OutputTxtBox.Text += $"{game.input}{Environment.NewLine}  Red: {game.redCount}{Environment.NewLine}  Green: {game.greenCount}{Environment.NewLine}  Blue: {game.blueCount}{Environment.NewLine}";

                    total += game.redCount * game.blueCount * game.greenCount;
                }

                OutputTxtBox.Text += $"Total {total.ToString()}";

                OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
                OutputTxtBox.ScrollToCaret();

                MessageBox.Show($"Finished: {total}");
            }
        }
    }
}
