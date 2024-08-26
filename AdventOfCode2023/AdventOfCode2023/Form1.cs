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
                        int.TryParse(matches[0].Value.Substring(0, 1), out firstInt);
                        int.TryParse(matches[matches.Count - 1].Value.Substring(matches[matches.Count - 1].Value.Length - 1, 1), out lastInt);

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

                    if (matches.Count() > 0)
                    {
                        matches.Sort((t1, t2) => t1.Item3.CompareTo(t2.Item3));
                        int.TryParse(matches[0].Item2, out firstInt);
                        int.TryParse(matches[matches.Count - 1].Item2, out lastInt);

                        int sum = 0;
                        int.TryParse(firstInt.ToString().Substring(0, 1) + (lastInt % 10).ToString(), out sum);

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
                if (redCount >= 0 && blueCount >= 0 && greenCount >= 0)
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

        private void Day31Btn_Click(object sender, EventArgs e)
        {
            int total = 0;
            int comparisonCount = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            //<symbol or number, x, y>
            List<Tuple<String, int, int>> symbols = new List<Tuple<String, int, int>>();
            List<Tuple<String, int, int>> numbers = new List<Tuple<String, int, int>>();
            String curNum = "";
            int i_num = -1;
            int j_num = -1;

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');

                for (int i = 0; i < lines.Length; i++)
                {
                    String curLine = lines[i];
                    for (int j = 0; j < curLine.Length; j++)
                    {
                        char curChar = curLine[j];

                        //if it is symbol
                        if (Regex.IsMatch(curChar.ToString(), @"[^\d]"))
                        {
                            if (curNum != "")
                            {
                                numbers.Add(new Tuple<string, int, int>(curNum, i_num, j_num));
                                i_num = -1;
                                j_num = -1;
                                curNum = "";
                            }
                            if (curChar != '.')
                                symbols.Add(new Tuple<string, int, int>(curChar.ToString(), i, j));
                        }
                        //if it is a number
                        else
                        {
                            if (i_num == -1) i_num = i;
                            if (j_num == -1) j_num = j;

                            curNum += curChar.ToString();
                        }
                    }

                    //handle scenario for end of input number
                    if (curNum != "")
                    {
                        numbers.Add(new Tuple<string, int, int>(curNum, i_num, j_num));
                        i_num = -1;
                        j_num = -1;
                        curNum = "";
                    }
                }

                //check to see if each number is adjacent to any symbols
                foreach (Tuple<String, int, int> number in numbers)
                {
                    int numX = number.Item2;
                    int numY = number.Item3;
                    int numLength = number.Item1.Length;
                    bool adjacent = false;

                    foreach (Tuple<String, int, int> symbol in symbols)
                    {
                        int symX = symbol.Item2;
                        int symY = symbol.Item3;

                        comparisonCount++;

                        if (Math.Abs(numX - symX) <= 1)
                        {
                            for (int i = 0; i < numLength; i++)
                            {
                                if (Math.Abs(numY + i - symY) <= 1)
                                {
                                    total += int.Parse(number.Item1);
                                    adjacent = true;
                                    break;
                                }
                            }
                        }
                        if (adjacent)
                            break;
                    }
                }

                OutputTxtBox.Text += $"Numbers Found: {numbers.Count()}{Environment.NewLine}Symbols Found: {symbols.Count()}{Environment.NewLine}" +
                    $"Comparisons Performed: {comparisonCount}{Environment.NewLine}Result: {total.ToString()}";

                OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
                OutputTxtBox.ScrollToCaret();

                MessageBox.Show($"Finished: {total}");
            }
        }

        private void Day32Btn_Click(object sender, EventArgs e)
        {
            int total = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            //<symbol or number, x, y>
            List<Tuple<String, int, int>> symbols = new List<Tuple<String, int, int>>();
            List<Tuple<String, int, int>> numbers = new List<Tuple<String, int, int>>();
            String curNum = "";
            int i_num = -1;
            int j_num = -1;

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');

                for (int i = 0; i < lines.Length; i++)
                {
                    String curLine = lines[i];
                    for (int j = 0; j < curLine.Length; j++)
                    {
                        char curChar = curLine[j];

                        //if it is symbol
                        if (Regex.IsMatch(curChar.ToString(), @"[^\d]"))
                        {
                            if (curNum != "")
                            {
                                numbers.Add(new Tuple<string, int, int>(curNum, i_num, j_num));
                                i_num = -1;
                                j_num = -1;
                                curNum = "";
                            }
                            if (curChar != '.')
                                symbols.Add(new Tuple<string, int, int>(curChar.ToString(), i, j));
                        }
                        //if it is a number
                        else
                        {
                            if (i_num == -1) i_num = i;
                            if (j_num == -1) j_num = j;

                            curNum += curChar.ToString();
                        }
                    }

                    //handle scenario for end of input number
                    if (curNum != "")
                    {
                        numbers.Add(new Tuple<string, int, int>(curNum, i_num, j_num));
                        i_num = -1;
                        j_num = -1;
                        curNum = "";
                    }
                }

                //check to see if each number is adjacent to any symbols
                foreach (Tuple<String, int, int> symbol in symbols)
                {
                    int symX = symbol.Item2;
                    int symY = symbol.Item3;
                    int adjacentNum1 = -1;
                    int adjacentNum2 = -1;
                    int adjacentCount = 0;

                    foreach (Tuple<String, int, int> number in numbers)
                    {
                        int numX = number.Item2;
                        int numY = number.Item3;
                        int numLength = number.Item1.Length;

                        if (Math.Abs(numX - symX) <= 1)
                        {
                            for (int i = 0; i < numLength; i++)
                            {
                                if (Math.Abs(numY + i - symY) <= 1)
                                {
                                    if (adjacentNum1 == -1) adjacentNum1 = int.Parse(number.Item1);
                                    else if (adjacentNum2 == -1) adjacentNum2 = int.Parse(number.Item1);

                                    adjacentCount++;
                                    break;
                                }
                            }
                        }
                        if (adjacentCount == 2)
                        {
                            total += adjacentNum1 * adjacentNum2;
                            break;
                        }
                    }
                }

                OutputTxtBox.Text += $"Numbers Found: {numbers.Count()}{Environment.NewLine}Symbols Found: {symbols.Count()}{Environment.NewLine}Result: {total.ToString()}";

                OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
                OutputTxtBox.ScrollToCaret();

                MessageBox.Show($"Finished: {total}");
            }
        }

        private void Day41Btn_Click(object sender, EventArgs e)
        {
            int total = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');

                foreach (String tmp in lines)
                {
                    String line = tmp;
                    String[] splitStr = line.Split('|');
                    String[] winningNumbers = splitStr[0].Split(':')[1].Trim().Replace("  ", " ").Split(' ');
                    String[] cardNumbers = splitStr[1].Trim().Replace("  ", " ").Split(' ');
                    int cardScore = 0;

                    foreach (String number in cardNumbers)
                    {
                        if (winningNumbers.Contains(number))
                        {
                            if (cardScore == 0)
                                cardScore++;
                            else
                                cardScore = cardScore * 2;
                        }
                    }
                    total += cardScore;
                }
            }

            OutputTxtBox.Text += $"Result: {total.ToString()}";

            OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
            OutputTxtBox.ScrollToCaret();

            MessageBox.Show($"Finished: {total}");
        }

        public class Card
        {
            public String input { get; set; }
            public int cardSeq { get; set; }
            public String[] winningNumbers { get; set; }
            public String[] cardNumbers { get; set; }
            public int winningNumbersCount { get; set; } = 0;
            public int instances { get; set; } = 1;
        }

        private void Day42Btn_Click(object sender, EventArgs e)
        {
            int total = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');
                List<Card> cards = new List<Card>();
                int cardSeq = 0;

                foreach (String tmp in lines)
                {
                    String line = tmp;
                    String[] splitStr = line.Split('|');
                    String[] winningNumbers = splitStr[0].Split(':')[1].Trim().Replace("  ", " ").Split(' ');
                    String[] cardNumbers = splitStr[1].Trim().Replace("  ", " ").Split(' ');
                    int winningNumbersCount = 0;
                    cardSeq++;

                    foreach (String number in cardNumbers)
                    {
                        if (winningNumbers.Contains(number))
                        {
                            winningNumbersCount++;
                        }
                    }

                    Card curCard = new Card { };
                    curCard.input = input;
                    curCard.cardSeq = cardSeq;
                    curCard.winningNumbers = winningNumbers;
                    curCard.cardNumbers = cardNumbers;
                    curCard.winningNumbersCount = winningNumbersCount;

                    cards.Add(curCard);
                }

                //loop through cards to see what needs to be copied
                foreach (Card card in cards)
                {
                    //recursive function needed because of the indeterminate number of nested levels
                    ProcessCardInstances(card, cards);
                }

                total = cards.Sum(c => c.instances);
            }

            OutputTxtBox.Text += $"Result: {total.ToString()}";

            OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
            OutputTxtBox.ScrollToCaret();

            MessageBox.Show($"Finished: {total}");
        }

        private void ProcessCardInstances(Card card, List<Card> cards)
        {
            int startIndex = card.cardSeq;
            int endIndex = startIndex + card.winningNumbersCount;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (i < cards.Count)
                {
                    cards[i].instances++;
                    ProcessCardInstances(cards[i], cards); // Recursively process child cards
                }
            }
        }

        public class SeedMap
        {
            public String mapName { get; set; } = "";

            //<destination range start, source range start, range length>
            public List<Tuple<long, long, long>> entries;
        }

        public class Seed
        {
            public long seedNo;
            public long soil = -1;
            public long fertilizer = -1;
            public long water = -1;
            public long light = -1;
            public long temp = -1;
            public long humidity = -1;
            public long location = -1;
        }

        private void Day51Btn_Click(object sender, EventArgs e)
        {
            long total = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');
                List<Seed> seeds = new List<Seed>();
                List<SeedMap> seedMaps = new List<SeedMap>();
                SeedMap tmpMap = new SeedMap();
                List<Tuple<long, long, long>> tmpEntries = new List<Tuple<long, long, long>>();

                foreach (String tmp in lines)
                {
                    if (tmp.Contains("seeds:"))
                    {
                        foreach (long i in tmp.Replace("seeds: ", "").Split(' ').Select(long.Parse))
                        {
                            Seed seed = new Seed();
                            seed.seedNo = i;

                            seeds.Add(seed);
                        }

                        OutputTxtBox.Text += $"Seeds Stored: {seeds.Count}{Environment.NewLine}";
                    }
                    else
                    {
                        if (tmp.Contains(":"))
                        {
                            if (tmpEntries.Count > 0)
                            {
                                tmpMap.entries = tmpEntries;
                                seedMaps.Add(tmpMap);

                                OutputTxtBox.Text += $"{tmpMap.mapName} Map Stored: {tmpMap.entries.Count}{Environment.NewLine}";

                                tmpMap = new SeedMap();
                                tmpEntries = new List<Tuple<long, long, long>>();
                            }

                            tmpMap.mapName = tmp.Replace(" map:", "");
                        }
                        else if (tmp != "")
                        {
                            String[] tmpArr = tmp.Split(' ');
                            tmpEntries.Add(new Tuple<long, long, long>(long.Parse(tmpArr[0]), long.Parse(tmpArr[1]), long.Parse(tmpArr[2])));
                        }
                    }
                }

                tmpMap.entries = tmpEntries;
                seedMaps.Add(tmpMap);

                OutputTxtBox.Text += $"{tmpMap.mapName} Map Stored: {tmpMap.entries.Count}{Environment.NewLine}";

                tmpMap = new SeedMap();
                tmpEntries = new List<Tuple<long, long, long>>();

                //Find the lowest location number that corresponds to any seed
                long lowestLoc = -1;
                foreach (Seed seed in seeds)
                {
                    String curMap = "";

                    foreach (SeedMap seedMap in seedMaps)
                    {
                        if (curMap == "") curMap = seedMap.mapName;
                        else if (curMap != "" && curMap != seedMap.mapName)
                        {
                            curMap = seedMap.mapName;

                            if (seed.soil == -1 && curMap == "soil-to-fertilizer") seed.soil = seed.seedNo;
                            if (seed.fertilizer == -1 && curMap == "fertilizer-to-water") seed.fertilizer = seed.soil;
                            if (seed.water == -1 && curMap == "water-to-light") seed.water = seed.fertilizer;
                            if (seed.light == -1 && curMap == "light-to-temperature") seed.light = seed.water;
                            if (seed.temp == -1 && curMap == "temperature-to-humidity") seed.temp = seed.light;
                            if (seed.humidity == -1 && curMap == "humidity-to-location") seed.humidity = seed.temp;
                        }

                        foreach (Tuple<long, long, long> entry in seedMap.entries)
                        {
                            long source = entry.Item2;
                            long destination = entry.Item1;
                            long length = entry.Item3;

                            if (seedMap.mapName == "seed-to-soil")
                            {
                                if (seed.seedNo >= source && seed.seedNo <= source + length)
                                {
                                    seed.soil = destination + (seed.seedNo - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "soil-to-fertilizer")
                            {
                                if (seed.soil >= source && seed.soil <= source + length)
                                {
                                    seed.fertilizer = destination + (seed.soil - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "fertilizer-to-water")
                            {
                                if (seed.fertilizer >= source && seed.fertilizer <= source + length)
                                {
                                    seed.water = destination + (seed.fertilizer - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "water-to-light")
                            {
                                if (seed.water >= source && seed.water <= source + length)
                                {
                                    seed.light = destination + (seed.water - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "light-to-temperature")
                            {
                                if (seed.light >= source && seed.light <= source + length)
                                {
                                    seed.temp = destination + (seed.light - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "temperature-to-humidity")
                            {
                                if (seed.temp >= source && seed.temp <= source + length)
                                {
                                    seed.humidity = destination + (seed.temp - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "humidity-to-location")
                            {
                                if (seed.humidity >= source && seed.humidity <= source + length)
                                {
                                    seed.location = destination + (seed.humidity - source);

                                    if (lowestLoc == -1) lowestLoc = seed.location;
                                    else if (lowestLoc > seed.location) lowestLoc = seed.location;

                                    break;
                                }
                            }
                        }
                    }

                    if (seed.location == -1) seed.location = seed.humidity;

                    if (lowestLoc == -1) lowestLoc = seed.location;
                    else if (lowestLoc > seed.location) lowestLoc = seed.location;

                    total = lowestLoc;
                }
                OutputTxtBox.Text += $"Output: {total}";
            }

            OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
            OutputTxtBox.ScrollToCaret();

            MessageBox.Show($"Finished: {total}");
        }

        private void Day52Btn_Click(object sender, EventArgs e)
        {
            long total = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');
                List<Seed> seeds = new List<Seed>();
                List<SeedMap> seedMaps = new List<SeedMap>();
                SeedMap tmpMap = new SeedMap();
                List<Tuple<long, long, long>> tmpEntries = new List<Tuple<long, long, long>>();

                foreach (String tmp in lines)
                {
                    if (tmp.Contains("seeds:"))
                    {
                        long[] seedList = tmp.Replace("seeds: ", "").Split(' ').Select(long.Parse).ToArray();

                        for (long i = 0; i < seedList.Length; i++)
                        {
                            if ((i + 1) % 2 == 0)
                            {
                                long ctr = 0;

                                while (ctr < seedList[i])
                                {
                                    Seed seed = new Seed();
                                    seed.seedNo = seedList[i - 1] + ctr;
                                    seeds.Add(seed);

                                    ctr++;
                                }
                            }
                        }

                        OutputTxtBox.Text += $"Seeds Stored: {seeds.Count}{Environment.NewLine}";
                    }
                    else
                    {
                        if (tmp.Contains(":"))
                        {
                            if (tmpEntries.Count > 0)
                            {
                                tmpMap.entries = tmpEntries;
                                seedMaps.Add(tmpMap);

                                OutputTxtBox.Text += $"{tmpMap.mapName} Map Stored: {tmpMap.entries.Count}{Environment.NewLine}";

                                tmpMap = new SeedMap();
                                tmpEntries = new List<Tuple<long, long, long>>();
                            }

                            tmpMap.mapName = tmp.Replace(" map:", "");
                        }
                        else if (tmp != "")
                        {
                            String[] tmpArr = tmp.Split(' ');
                            tmpEntries.Add(new Tuple<long, long, long>(long.Parse(tmpArr[0]), long.Parse(tmpArr[1]), long.Parse(tmpArr[2])));
                        }
                    }
                }

                tmpMap.entries = tmpEntries;
                seedMaps.Add(tmpMap);

                OutputTxtBox.Text += $"{tmpMap.mapName} Map Stored: {tmpMap.entries.Count}{Environment.NewLine}";

                tmpMap = new SeedMap();
                tmpEntries = new List<Tuple<long, long, long>>();

                //Find the lowest location number that corresponds to any seed
                long lowestLoc = -1;
                foreach (Seed seed in seeds)
                {
                    String curMap = "";

                    foreach (SeedMap seedMap in seedMaps)
                    {
                        if (curMap == "") curMap = seedMap.mapName;
                        else if (curMap != "" && curMap != seedMap.mapName)
                        {
                            curMap = seedMap.mapName;

                            if (seed.soil == -1 && curMap == "soil-to-fertilizer") seed.soil = seed.seedNo;
                            if (seed.fertilizer == -1 && curMap == "fertilizer-to-water") seed.fertilizer = seed.soil;
                            if (seed.water == -1 && curMap == "water-to-light") seed.water = seed.fertilizer;
                            if (seed.light == -1 && curMap == "light-to-temperature") seed.light = seed.water;
                            if (seed.temp == -1 && curMap == "temperature-to-humidity") seed.temp = seed.light;
                            if (seed.humidity == -1 && curMap == "humidity-to-location") seed.humidity = seed.temp;
                        }

                        foreach (Tuple<long, long, long> entry in seedMap.entries)
                        {
                            long source = entry.Item2;
                            long destination = entry.Item1;
                            long length = entry.Item3;

                            if (seedMap.mapName == "seed-to-soil")
                            {
                                if (seed.seedNo >= source && seed.seedNo <= source + length)
                                {
                                    seed.soil = destination + (seed.seedNo - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "soil-to-fertilizer")
                            {
                                if (seed.soil >= source && seed.soil <= source + length)
                                {
                                    seed.fertilizer = destination + (seed.soil - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "fertilizer-to-water")
                            {
                                if (seed.fertilizer >= source && seed.fertilizer <= source + length)
                                {
                                    seed.water = destination + (seed.fertilizer - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "water-to-light")
                            {
                                if (seed.water >= source && seed.water <= source + length)
                                {
                                    seed.light = destination + (seed.water - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "light-to-temperature")
                            {
                                if (seed.light >= source && seed.light <= source + length)
                                {
                                    seed.temp = destination + (seed.light - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "temperature-to-humidity")
                            {
                                if (seed.temp >= source && seed.temp <= source + length)
                                {
                                    seed.humidity = destination + (seed.temp - source);
                                    break;
                                }
                            }
                            else if (seedMap.mapName == "humidity-to-location")
                            {
                                if (seed.humidity >= source && seed.humidity <= source + length)
                                {
                                    seed.location = destination + (seed.humidity - source);

                                    if (lowestLoc == -1) lowestLoc = seed.location;
                                    else if (lowestLoc > seed.location) lowestLoc = seed.location;

                                    break;
                                }
                            }
                        }
                    }

                    if (seed.location == -1) seed.location = seed.humidity;

                    if (lowestLoc == -1) lowestLoc = seed.location;
                    else if (lowestLoc > seed.location) lowestLoc = seed.location;

                    total = lowestLoc;
                }
                OutputTxtBox.Text += $"Output: {total}";
            }

            OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
            OutputTxtBox.ScrollToCaret();

            MessageBox.Show($"Finished: {total}");
        }

        private void Day61Btn_Click(object sender, EventArgs e)
        {
            int total = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');
                List<int> times = new List<int>();
                List<int> distances = new List<int>();
                List<int> winCount = new List<int>();

                foreach (String tmp in lines)
                {
                    if (tmp.Contains("Time"))
                    {
                        foreach (String s in tmp.Replace("Time:", "").Trim().Split(' '))
                            if (s != " " && s != "")
                            {
                                times.Add(int.Parse(s));
                                winCount.Add(0);
                            }
                    }
                    else if (tmp.Contains("Distance"))
                    {
                        foreach (String s2 in tmp.Replace("Distance:", "").Trim().Split(' '))
                            if (s2 != " " && s2 != "")
                                distances.Add(int.Parse(s2));
                    }
                }

                //find the number of ways to win based on how long we charge
                for(int i = 0; i < times.Count; i++)
                {
                    for(int j = 0; j < times[i]; j++)
                    {
                        if (j * (times[i] - j) > distances[i])
                            winCount[i]++;
                        else if (winCount[i] > 0)
                            break;
                    }
                }

                total = winCount.Aggregate(1, (acc, x) => acc * x);
            }

            OutputTxtBox.Text += $"Result: {total.ToString()}";

            OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
            OutputTxtBox.ScrollToCaret();

            MessageBox.Show($"Finished: {total}");
        }

        private void Day62Btn_Click(object sender, EventArgs e)
        {
            long total = 0;

            String input = InputTxtbox.Text;
            OutputTxtBox.Text = "";

            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Input is Missing");
            else
            {
                //search input and store x,y indexes of everything that is not a number or "."
                String[] lines = input.Split('\n');
                List<long> times = new List<long>();
                List<long> distances = new List<long>();
                List<long> winCount = new List<long>();

                foreach (String tmp in lines)
                {
                    if (tmp.Contains("Time"))
                    {
                        foreach (String s in tmp.Replace("Time:", "").Replace(" ","").Trim().Split(' '))
                            if (s != " " && s != "")
                            {
                                times.Add(long.Parse(s));
                                winCount.Add(0);
                            }
                    }
                    else if (tmp.Contains("Distance"))
                    {
                        foreach (String s2 in tmp.Replace("Distance:", "").Replace(" ", "").Trim().Split(' '))
                            if (s2 != " " && s2 != "")
                                distances.Add(long.Parse(s2));
                    }
                }

                //find the number of ways to win based on how long we charge
                for (int i = 0; i < times.Count; i++)
                {
                    for (int j = 0; j < times[i]; j++)
                    {
                        if (j * (times[i] - j) > distances[i])
                            winCount[i]++;
                        else if (winCount[i] > 0)
                            break;
                    }
                }

                total = winCount.Aggregate(1L, (acc, x) => acc * x);
            }

            OutputTxtBox.Text += $"Result: {total.ToString()}";

            OutputTxtBox.SelectionStart = OutputTxtBox.Text.Length;
            OutputTxtBox.ScrollToCaret();

            MessageBox.Show($"Finished: {total}");
        }
    }
}
