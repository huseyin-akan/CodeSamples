using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Test
{
    public static class HackerRank
    {

        public static int findRoses(string flowers, string roses)
        {
            var result = 0;
            var roseTypes = roses.ToCharArray();

            for (int i = 0; i < flowers.Length; i++)
            {
                if (roseTypes.Contains(flowers[i]))
                {
                    result++;
                }
            }

            return result;
        }

        public static int deletionSize(List<string> input)
        {
            var result = 0;
            var tmpList = new List<string>();
            foreach (var item in input)
            {
                tmpList.Add(item);
            }

            for (int i = 0; i < tmpList[0].Length; i++)
            {
                for (int j = 0; j < tmpList.Count - 1; j++)
                {
                    if (tmpList[j][i] > tmpList[j + 1][i])
                    {
                        result++;
                        break;
                    }
                }
            }
            return result;
        }

        public static int profitAtMax(List<int> bitcoin)
        {
            var maxProfit = 0;

            for (int i = 0; i < bitcoin.Count; i++)
            {
                for (int j = i + 1; j < bitcoin.Count; j++)
                {
                    if (bitcoin[j] - bitcoin[i] > maxProfit)
                    {
                        maxProfit = bitcoin[j] - bitcoin[i];
                    }
                }
            }

            return maxProfit;
        }

        public static int alternate(string wordToCheck)
        {
            var chars = new HashSet<char>(wordToCheck.ToCharArray() );

            if (chars.Count < 2) return 0; //there are less then 2 distinct chars.

            var possibleVariants = getAllPossibleVariants(chars);

            var tmpResult = 0;
            foreach (var variant in possibleVariants)
            {
                var variantCharArr = removeCharsExcept(wordToCheck, variant);

                if (!checkIfVariantIsValid(variantCharArr))
                {
                    continue;
                }

                var variantString = new string(variantCharArr);

                if (tmpResult < variantString.Length)
                {
                    tmpResult = variantString.Length;
                }
            }

            return tmpResult;
        }

        private static List<Tuple<char, char>> getAllPossibleVariants(HashSet<char> chars)
        {
            var result = new List<Tuple<char, char>>();

            for (int i = 0; i < chars.Count; i++)
            {
                for (int j = i+1; j < chars.Count; j++)
                {
                    result.Add(new Tuple<char, char>(chars.ElementAt(i), chars.ElementAt(j)));
                }
            }

            return result;
        }

        private static char[] removeCharsExcept(string word, Tuple<char, char> variant)
        {
            return word.ToCharArray().Where(c => c.Equals(variant.Item1) || c.Equals(variant.Item2)).ToArray();
        }

        private static bool checkIfVariantIsValid(char[] variantArray)
        {
            for (int i = 0; i < variantArray.Length-1; i++)
            {
                if (variantArray[i].Equals(variantArray[i+1]))
                {
                    return false;
                }
            }
            return true;
        }

        public static int theLoveLetterMystery(string s)
        {
            int result = 0;

            while (s.Length > 1)
            {
                char firstChar = s[0];
                char lastChar = s[s.Length - 1];

                //if the first and last chars are not same then we modify them
                if (!firstChar.Equals(lastChar))
                {
                    result += Math.Abs((int)firstChar - (int)lastChar);
                }
                //we remove the first and last letters
                s = s.Substring(1, s.Length - 2);
            }

            return result;
        }
        public static List<int> acmTeam(List<string> topic)
        {
            var maxTopic = 0;
            var countOfteams = 0;
            var tmp = 0;

            for (int i = 0; i < topic.Count - 1; i++)
            {
                for (int j = i + 1; j < topic.Count; j++)
                {
                    tmp = calculateTeam(topic[i], topic[j]);
                    if (tmp > maxTopic)
                    {
                        maxTopic = tmp;
                        countOfteams = 1;
                    }
                    else if (tmp == maxTopic)
                    {
                        countOfteams++;
                    }
                }
            }

            return new List<int> { maxTopic, countOfteams };
        }

        private static int calculateTeam(string personA, string personB)
        {
            var result = 0;

            for (int i = 0; i < personA.Length; i++)
            {
                if (personA[i].Equals('1') || personB[i].Equals('1'))
                {
                    result++;
                }
            }

            return result;
        }

        public static int beautifulTriplets(int d, List<int> arr)
        {
            var result = 0;
            for (int i = 0; i < arr.Count - 2; i++)
            {
                for (int j = i + 1; j < arr.Count - 1; j++)
                {
                    if (arr[j] - arr[i] != d)
                    {
                        continue;
                    }
                    for (int k = i + 2; k < arr.Count; k++)
                    {
                        if (arr[k] - arr[j] == d)
                        {
                            result++;
                        }
                    }
                }
            }
            return result;
        }

        public static int howManyGames(int startPrice, int decrease, int lowest, int wallet)
        {
            int currentPrice = startPrice;
            int buyCount = 0;

            //the first time we buy
            if (wallet > currentPrice)
            {
                Console.WriteLine("Game bought.The price is: " + currentPrice);
                buyCount++;
                Console.WriteLine("Number of games bought: " + buyCount);
                wallet -= currentPrice;
                Console.WriteLine("the current wallet : " + wallet);

                //reset currentPrice
                if (currentPrice - decrease < lowest)
                {
                    currentPrice = lowest;
                }
                else
                {
                    currentPrice -= decrease;
                }
                Console.WriteLine("the current price after buy: " + currentPrice);

            }
            else
            {
                return buyCount;
            }

            //as long as we have money to buy
            while (wallet > currentPrice)
            {
                Console.WriteLine("Game bought.The price is: " + currentPrice);
                buyCount++;
                Console.WriteLine("Number of games bought: " + buyCount);
                wallet -= currentPrice;
                Console.WriteLine("the current wallet : " + wallet);

                //reset currentPrice
                if (currentPrice - decrease < lowest)
                {
                    currentPrice = lowest;
                }
                else
                {
                    currentPrice -= decrease;
                }
                Console.WriteLine("the current price after buy: " + currentPrice);
            }
            return buyCount;
        }
        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n == 1)
            {
                return grid;
            }

            List<string> fullyBombed = plantBombsEverywhere(grid);
            if (n % 2 == 0)
            {
                return fullyBombed;
            }

            n = n % 4 + 4;
            List<string> lastGridState = grid;

            for (int i = 0; i < (n - 1) / 2; i++)
            {
                lastGridState = detonateGrid(lastGridState, fullyBombed);
            }
            return lastGridState;

        }
        private static List<string> plantBombsEverywhere(List<string> grid)
        {
            List<string> fullyBombed = new List<string>();
            string tmp = "";
            for (int i = 0; i < grid[0].Length; i++)
            {
                tmp += "O";
            }
            for (int i = 0; i < grid.Count; i++)
            {
                fullyBombed.Add(tmp);
            }
            return fullyBombed;
        }

        public static List<int> serviceLane(List<int> width, List<List<int>> cases)
        {
            var result = new List<int>();
            int tmpMin;

            for (int i = 0; i < cases.Count; i++)
            {
                tmpMin = width[cases[i][0]];
                for (int j = cases[i][0]; j <= cases[i][1]; j++)
                {
                    if (tmpMin > width[j])
                    {
                        tmpMin = width[j];
                    }
                }
                result.Add(tmpMin);
            }

            return result;
        }

        public static int introTutorial(int V, List<int> arr)
        {
            var result = 0;
            bool indexNotFound = true;
            int min = 0;
            int max = arr.Count() - 1;
            int indexToCheck = arr.Count / 2;

            while (indexNotFound)
            {
                Console.WriteLine("Kontrol edilen index: " + indexToCheck);
                if (arr[indexToCheck] == V)
                {
                    result = indexToCheck;
                    indexNotFound = false;
                }
                else if (arr[indexToCheck] < V)
                {
                    min = indexToCheck + 1;
                    indexToCheck = (max + min) / 2;
                }
                else
                {
                    max = indexToCheck - 1;
                    indexToCheck = (max + min) / 2;
                }
            }
            return result;
        }

        public static string happyLadybugs(string board)
        {
            //if it is 1 length
            if (board.Length == 1)
            {
                if (board == "_") return "YES";
                return "NO";
            }

            //if it doesnt contain underscore:
            if (!board.Contains('_'))
            {
                if (checkIfBoardIsHappyLadyBug(board))
                {
                    return "YES";
                }
                return "NO";
            }
            //if it contains underscore
            else
            {
                if (checkIfBoardCanBeModified(board))
                {
                    return "YES";
                }
                return "NO";
            }
        }

        private static bool checkIfBoardCanBeModified(string board)
        {
            var countOfLetters = new Dictionary<char, int>();
            foreach (var letter in board)
            {
                if (letter == '_') continue;

                if (countOfLetters.ContainsKey(letter))
                {
                    countOfLetters[letter]++;
                }
                else
                {
                    countOfLetters.Add(letter, 1);
                }
            }

            foreach (var item in countOfLetters)
            {
                if (item.Value == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool checkIfBoardIsHappyLadyBug(string board)
        {
            bool isHappyLadyBug = true;

            //for the first character
            if (board[0] != board[1])
            {
                isHappyLadyBug = false;
                //then it is not a happy ladybug                    
            }
            else
            {
                for (int i = 1; i < board.Length - 1; i++)
                {
                    if (board[i] != board[i + 1] && board[i] != board[i - 1])
                    {
                        //then it is not a happy ladybug
                        isHappyLadyBug = false;
                        break;
                    }
                }
            }
            //for the last character
            if (isHappyLadyBug && board[board.Length - 2] != board[board.Length - 1])
            {
                isHappyLadyBug = false;
            }

            return isHappyLadyBug;
        }

        public static int marsExploration(string message)
        {
            var result = 0;

            for (int i = 0; i < message.Length; i++)
            {
                if ((i % 3 == 0 || i % 3 == 2))
                {
                    if (message[i] != 'S')
                        result++;
                }
                else
                {
                    if (message[i] != 'O')
                        result++;
                }
            }

            return result;
        }

        public static string gameOfThrones(string message)
        {
            var result = true;

            var countOfLetters = new int[26];
            var numberOfOdds = 0;

            foreach (var letter in message)
            {
                countOfLetters[letter - 'a']++;
            }

            foreach (var count in countOfLetters)
            {
                if (count % 2 != 0)
                {
                    numberOfOdds++;
                }
            }

            //then no odd numbers are allowed
            if (message.Length % 2 == 0 && numberOfOdds > 0)
            {
                result = false;
            }
            //then only one odd number is allowed
            else if (message.Length % 2 == 1 && numberOfOdds > 1)
            {
                result = false;
            }

            return result ? "YES" : "NO";
        }

        public static string caesarCipher(string wordToCheck, int shiftNumber)
        {
            var result = "";
            var lowerLettersStr = "abcdefghijklmnopqrstuvwxyz";
            var upperLettersStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int tmpIndex = 0;

            for (int i = 0; i < wordToCheck.Length; i++)
            {
                //if uppercase
                if (Char.IsUpper(wordToCheck[i]))
                {
                    tmpIndex = (wordToCheck[i] - 'A' + shiftNumber) % lowerLettersStr.Length;
                    result += upperLettersStr[tmpIndex];

                }
                //if lowercase
                else if (Char.IsLower(wordToCheck[i]))
                {
                    tmpIndex = (wordToCheck[i] - 'a' + shiftNumber) % lowerLettersStr.Length;
                    result += lowerLettersStr[tmpIndex];
                }
                else
                {
                    result += wordToCheck[i];
                }
            }
            return result;
        }

        public static string pangrams(string word)
        {
            //if length < 26, return not pangram
            bool isPangram = true;
            int tmpLetter;

            var letters = new int[26];
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                tmpLetter = word[i] - 'a';
                if (tmpLetter <= 26 && tmpLetter >= 0)
                {
                    letters[tmpLetter]++;
                }
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == 0)
                {
                    isPangram = false;
                    break;
                }
            }

            return isPangram ? "pangram" : "not pangram";
        }

        public static int palindromeIndex(string word)
        {
            var result = -1;
            var tmpWord = word;
            bool errorNotFound = true;
            string firstHalf, secondHalf;
            int minIndex, maxIndex;

            //check if palindrome, if so return -1
            if (checkIfPalindrome(word))
            {
                return result;
            }

            if (word.Length < 4)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!word[i].Equals(word[word.Length - 1 - i]))
                    {
                        tmpWord = word.Substring(0, i) + word.Substring(i + 1);
                        if (checkIfPalindrome(tmpWord))
                        {
                            result = i;
                            break;
                        }

                        tmpWord = word.Substring(0, word.Length - 1);
                        if (checkIfPalindrome(tmpWord))
                        {
                            result = word.Length - 1 - i;
                            break;
                        }
                    }
                }
            }

            result = 0;
            while (errorNotFound)
            {
                minIndex = tmpWord.Length / 4;
                maxIndex = tmpWord.Length - minIndex;

                firstHalf = tmpWord.Substring(0, minIndex);
                char[] charArray = tmpWord.Substring(maxIndex).ToCharArray();
                Array.Reverse(charArray);
                secondHalf = new string(charArray);

                if (firstHalf.Equals(secondHalf))
                {
                    result += minIndex;
                    tmpWord = tmpWord.Substring(minIndex, maxIndex - minIndex);
                }
                else
                {
                    Array.Reverse(charArray);
                    secondHalf = new string(charArray);
                    tmpWord = firstHalf + secondHalf;
                }

                if (tmpWord.Length == 2)
                {
                    errorNotFound = false;
                }
            }

            tmpWord = word.Substring(0, result) + word.Substring(result + 1);
            if (checkIfPalindrome(tmpWord))
            {
                return result;
            }
            else
            {
                return word.Length - 1 - result;
            }
        }

        public static string twoStrings(string s1, string s2)
        {
            bool isCommon = false;

            int[] letters = new int[26];
            foreach (var letter in s1.ToLower())
            {
                letters[letter - 'a']++;
            }

            foreach (var letter in s2)
            {
                if (letters[letter - 'a'] > 0)
                {
                    isCommon = true;
                    break;
                }
            }

            return isCommon ? "YES" : "NO";
        }

        private static bool checkIfPalindrome(string word)
        {
            var firstHalf = word.Substring(0, word.Length / 2);

            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            var secondHalf = new string(charArray).Substring(0, word.Length / 2);

            return firstHalf.Equals(secondHalf);
        }

        public static int flatlandSpaceStations(int cityCount, int[] stations)
        {
            var maxDinstance = 0;
            var sortedStations = stations.OrderBy(x => x).ToList();
            for (int i = 0; i < sortedStations.Count-1; i++)
            {
                if (maxDinstance < (sortedStations[i+1] - sortedStations[i])/2 )
                {
                    maxDinstance = (sortedStations[i + 1] - sortedStations[i])/ 2;
                }
            }

            if(cityCount-1 - sortedStations[sortedStations.Count-1] > maxDinstance)
            {
                maxDinstance = cityCount-1 - sortedStations[sortedStations.Count-1];
            }

            if (sortedStations[0]-0 > maxDinstance)
            {
                maxDinstance = sortedStations[0] - 0;
            }

            return maxDinstance;
        }

        public static List<int> stones(int n, int a, int b)
        {
            HashSet<int> stonesToRead = new HashSet<int>();
            HashSet<int> resultStones = new HashSet<int>();
            var result = new List<int>();

            if (n == 1)
            {
                result.Add(0);
                return result;
            }
            else if (n == 2)
            {
                resultStones.Add(a);
                resultStones.Add(b);
            }

            stonesToRead.Add(a);
            stonesToRead.Add(b);

            for (int i = 0; i < n - 2; i++)
            {
                resultStones.Clear();
                foreach (var stone in stonesToRead)
                {
                    resultStones.Add(stone + a);
                    resultStones.Add(stone + b);
                }
                stonesToRead.Clear();
                stonesToRead = new HashSet<int>(resultStones);
            }
            result = resultStones.ToList();
            result.Sort();
            return result;
        }

        public static string funnyString(string wordToCheck)
        {
            bool isFunny = true;

            for (int i = 0, j = wordToCheck.Length - 1; i < wordToCheck.Length / 2; i++, j--)
            {
                if (Math.Abs(wordToCheck[i] - wordToCheck[i + 1]) != Math.Abs(wordToCheck[j] - wordToCheck[j - 1]))
                {
                    isFunny = false;
                    break;
                }
            }

            return isFunny ? "Funny" : "Not Funny";
        }

        public static int surfaceArea(List<List<int>> A)
        {
            int result;
            int sideXArea = A.Count * A[0].Count;
            int sideYArea = 0;
            int sideZArea;
            int countOfHoles;

            //step 1. calc the outer surface

            for (int i = 0; i < A.Count; i++)
            {
                sideYArea += findTallestYColumn(A[i]);
            }

            sideZArea = findZArea(A);

            result = (sideXArea + sideYArea + sideZArea) * 2;

            //step 2. find the holes and add 2 for each hole
            countOfHoles = findCountOfHoles(A);
            result += countOfHoles * 2;
            return result;
        }
        private static int findTallestYColumn(List<int> columns)
        {
            var result = columns[0];
            for (int i = 1; i < columns.Count; i++)
            {
                if (columns[i] > result)
                {
                    result = columns[i];
                }
            }
            return result;
        }

        private static int findCountOfHoles(List<List<int>> columns)
        {
            var result = 0;
            bool decreaseAwaiting = true;
            bool increaseAwaiting = true;
            bool curveChangeOrEndAwaiting = true;
            int minSide = 0, maxSide = 0, minObstacle = int.MaxValue;
            LastCurveStatus lastCurveStatus = LastCurveStatus.Neutral;

            for (int i = 0; i < columns.Count; i++)
            {
                for (int j = 1; j < columns[0].Count - 1; j++)
                {
                    var previousCell = columns[i][j - 1];
                    var currentCell = columns[i][j];
                    var nextCell = columns[i][j + 1];

                    //check if decreasingStarted:
                    // düşüş yaşandı mı
                    // düşüş yaşandıysa orası minSide olacak
                    if (decreaseAwaiting && previousCell < currentCell)
                    {
                        continue;
                    }

                    if (previousCell > currentCell)
                    {
                        decreaseAwaiting = false;
                        minSide = previousCell;
                    }

                    // düşüş yaşandıktan sonra ise, aradaki min Obstacle bulunmalı.
                    if (!decreaseAwaiting && currentCell < minObstacle)
                    {
                        minObstacle = currentCell;
                    }                                        

                    // yükseliş yaşandı mı
                    // yükseliş yaşanıdıysa son veya curve beklenir. Bu aşamada artık sonraki aşama önden izlenmeli. Son veya curve geliyorsa, maxSide'ımızı bulduk

                    //son veya curve geliyorsa hesaplamalar yapıldıktan sonra result'a eklenir ve tüm bool'lar resetlenir. Yeni curveler aranır.





                    if (columns[i][j] < columns[i][j - 1] && columns[i][j] < columns[i][j + 1])
                    {
                        result += Math.Abs(columns[i][j - 1] - columns[i][j + 1]);
                    }
                }
            }

            for (int i = 0; i < columns.Count; i++)
            {
                for (int j = 1; j < columns[0].Count - 1; j++)
                {
                    if (columns[i][j] < columns[i][j - 1] && columns[i][j] < columns[i][j + 1])
                    {
                        result += Math.Abs(columns[i][j - 1] - columns[i][j + 1]);
                    }
                }
            }

            for (int i = 1; i < columns.Count - 1; i++)
            {
                for (int j = 0; j < columns[0].Count; j++)
                {
                    if (columns[i][j] < columns[i - 1][j] && columns[i][j] < columns[i + 1][j])
                    {
                        result += Math.Min(columns[i - 1][j], columns[i + 1][j]) - columns[i][j];
                    }
                }
            }

            return result;
        }
        private enum LastCurveStatus
        {
            Neutral,
            Decreased,
            Increased
        }

        private static int findZArea(List<List<int>> columns)
        {
            var result = 0;
            var tmp = 0;

            for (int i = 0; i < columns[0].Count; i++)
            {
                for (int j = 0; j < columns.Count; j++)
                {
                    if (columns[j][i] > tmp)
                    {
                        tmp = columns[j][i];
                    }
                }
                result += tmp;
                tmp = 0;
            }
            return result;
        }


        public static string fairRations(List<int> People)
        {
            var countOfBreads = 0;
            var tmpCountOfOdds = 0;
            bool firstOddFound = false;

            for (int i = 0; i < People.Count; i++)
            {
                if (firstOddFound == false && People[i]%2 != 0)
                {
                    firstOddFound = true;
                    continue;
                }

                if (firstOddFound && People[i] % 2 == 0)
                {
                    tmpCountOfOdds++;
                }

                if (firstOddFound && People[i] % 2 != 0)
                {
                    countOfBreads += (tmpCountOfOdds + 1) * 2;
                    tmpCountOfOdds = 0;
                    firstOddFound = false;
                }
            }

            return firstOddFound==false ? countOfBreads.ToString() : "NO";
        }

        public static int anagram(string word)
        {
            var result = -1;            

            if (word.Length % 2 != 0)
            {
                return result;
            }

            int[] letters = new int[26];
            string word1 = word.Substring(0, word.Length / 2).ToLower();
            string word2 = word.Substring(word.Length / 2).ToLower();
            result = 0;

            for (int i = 0; i < word.Length/2; i++)
            {
                letters[word1[i] - 'a']++;
                letters[word2[i] - 'a']--;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] > 0)
                {
                    result += letters[i];
                }
            }

            return result;
        }

        public static int makingAnagrams(string word1, string word2)
        {
            var result = 0;
            int[] letters = new int[26];

            for (int i = 0; i < word1.Length; i++)
            {
                letters[word1[i] - 'a']++;
            }

            for (int i = 0; i < word2.Length; i++)
            {
                letters[word2[i] - 'a']--;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] != 0)
                {
                    result += Math.Abs(letters[i]);
                }
            }

            return result;
        }

        public static int beautifulBinaryString(string word)
        {
            var result = 0;

            for (int i = 0; i < word.Length-2; i++)
            {
                if (word.Substring(i, 3).Equals("010"))
                {
                    result++;
                    i = i + 2;
                }
            }

            return result;
        }

        public static string hackerrankInString(string wordToCheck)
        {
            string hackerRank = "hackerrank";
            int tempIndex = 0;

            for (int i = 0; i < wordToCheck.Length; i++)
            {  
                if (wordToCheck[i].Equals(hackerRank[tempIndex]))
                {
                    tempIndex++;

                }

                if (tempIndex == hackerRank.Length)
                {
                    return "YES";
                }
            }
            return "NO";
        }

        public static int maximumToys(List<int> prices, int budget)
        {
            var result = 0;

            prices.Sort();
            for (int i = 0; i < prices.Count; i++)
            {
                if (budget>= prices[i])
                {
                    budget -= prices[i];
                    result++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public static List<int> icecreamParlor(int budget, List<int> prices)
        {
            var result = new List<int>();

            for (int i = 0; i < prices.Count-1; i++)
            {
                for (int j = i+1; j < prices.Count; j++)
                {
                    if (prices[i] + prices[j] == budget)
                    {
                        result.Add(i+1);
                        result.Add(j+1);
                        return result;
                    }
                }
            }

            return result;
        }

        public static string appendAndDelete(string sourceString, string targetString, int guess)
        {
            int minOperation;
            var tmpIndex = 0;

            if (sourceString.Length + targetString.Length <= guess) return "Yes";

            for (int i = 0; i < Math.Min(sourceString.Length, targetString.Length); i++)
            {
                if (sourceString[i].Equals(targetString[i]))
                {
                    tmpIndex++;
                }
                else
                {
                    break;
                }
            }
            minOperation = sourceString.Length - tmpIndex; //count of chars to delete
            minOperation += targetString.Length - tmpIndex; //count of chars to append

            if (guess < minOperation)
            {
                return "No";
            }else if(guess == minOperation)
            {
                return "Yes";
            }else if(guess > minOperation)
            {
                return (guess - minOperation) % 2 == 0 ? "Yes" : "No";
            }

            return "Unexpected Case";
        }

        public static List<int> jimOrders(List<List<int>> orders)
        {
            var result = new List<int>();
            var jimOrders = new List<JimOrder>();

            for (int i = 0; i < orders.Count; i++)
            {
                jimOrders.Add(
                   new JimOrder(customerId: i+1, orderCount: orders[i][0], prepTime: orders[i][1])
                   );
            }   

            var sortedResult = jimOrders.OrderBy(x => x.ServeTime);

            return sortedResult.Select(x => x.CustomerId).ToList();
        }

        public class JimOrder
        {
            public JimOrder(int customerId, int orderCount, int prepTime)
            {
                CustomerId = customerId;
                OrderCount = orderCount;
                PrepTime = prepTime;
                ServeTime = PrepTime + OrderCount;
            }
            public int CustomerId { get; set; }
            public int OrderCount { get; set; }
            public int PrepTime { get; set; }
            public int ServeTime { get; set; }
        }

        public static int stringConstruction(string wordToCheck)
        {
            int result = 0;
            int[] letters = new int[26];

            for (int i = 0; i < wordToCheck.Length; i++)
            {
                letters[wordToCheck[i] - 'a']++;
            }
            foreach (var letterCount in letters)
            {
                if (letterCount > 0)
                {
                    result++;
                }
            }

            return result;
        }

        public static int stringConstruction2(string wordToCheck)
        {
            return new HashSet<char>(wordToCheck.ToCharArray()).Count;
        }

        public static string findFileExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf("."));
        }

        public static string pokerNim(int k, List<int> c)
        {
            var count = c.Sum();
            return count % 2 != 0 ? "First" : "Second";
        }

        public static int gemstones(List<string> arr)
        {
            var gemStones = new HashSet<char>(arr[0].ToCharArray());
            for (int i = 1; i < arr.Count; i++)
            {
                if (gemStones.Count == 0)
                {
                    return 0;
                }
                var copyGemStones = new HashSet<char>(gemStones);
                foreach (var gem in copyGemStones)
                {
                    if (!arr[i].Contains(gem))
                    {
                        gemStones.Remove(gem);
                    }
                }
                
            }
            return gemStones.Count;
        }

        public static int lonelyinteger(List<int> a)
        {
            int[] myIntegers = new int[101];

            for (int i = 0; i < a.Count; i++)
            {
                myIntegers[a[i]]++;
            }

            for (int i = 0; i < myIntegers.Length; i++)
            {
                if (myIntegers[i] == 1)
                {
                    return i;
                }
            }
            
            return -1;
        }

        public static int queensAttack(int boardSide, int numberOfObstacles, int queenRow, int queenColumn, List<List<int>> obstacles)
        {
            var countOfSquares = 0;

            List<int> leftObstacle = obstacles.Where(o => o[0] == queenRow && o[1] < queenColumn).OrderByDescending(o => o[1]).FirstOrDefault();
            List<int> rightObstacle = obstacles.Where(o => o[0] == queenRow && o[1] > queenColumn).OrderBy(o => o[1]).FirstOrDefault();
            List<int> upperObstacle = obstacles.Where(o => o[0] > queenRow && o[1] == queenColumn).OrderBy(o => o[0]).FirstOrDefault();
            List<int> lowerObstacle = obstacles.Where(o => o[0] < queenRow && o[1] == queenColumn).OrderByDescending(o => o[0]).FirstOrDefault();

            List<int> leftUpperDiagonal = obstacles.Where(o => (o[0]- queenRow) == (queenColumn -o[1]) && o[0] > queenRow && o[1] < queenColumn).OrderBy(o => o[0]).OrderByDescending(o => o[1]).FirstOrDefault();
            List<int> rightUpperDiagoanal = obstacles.Where(o => (o[0] - queenRow) == (o[1] - queenColumn) && o[0] > queenRow && o[1] > queenColumn).OrderBy(o => o[0]).OrderBy(o => o[1]).FirstOrDefault();
            List<int> leftLowerDiagoanal = obstacles.Where(o => (queenRow - o[0]) == (queenColumn - o[1]) && o[0] < queenRow && o[1] < queenColumn).OrderByDescending(o => o[0]).OrderByDescending(o => o[1]).FirstOrDefault();
            List<int> rightLowerDiagonal = obstacles.Where(o => (queenRow - o[0]) == (o[1] - queenColumn) && o[0] < queenRow && o[1] > queenColumn).OrderByDescending(o => o[0]).OrderBy(o => o[1]).FirstOrDefault();

            countOfSquares += leftObstacle != null ? queenColumn - leftObstacle[1] - 1 : queenColumn -1;
            countOfSquares += rightObstacle != null ? rightObstacle[1] - queenColumn - 1 : boardSide - queenColumn;
            countOfSquares += upperObstacle != null ? upperObstacle[0] - queenRow - 1 : boardSide - queenRow;
            countOfSquares += lowerObstacle != null ? queenRow - lowerObstacle[0] - 1 : queenRow - 1;
            countOfSquares += leftUpperDiagonal != null ? leftUpperDiagonal[0] - queenRow - 1 : Math.Min(queenColumn - 1, boardSide - queenRow);
            countOfSquares += rightUpperDiagoanal != null ? rightUpperDiagoanal[0] - queenRow - 1: Math.Min(boardSide - queenRow, boardSide - queenColumn);
            countOfSquares += leftLowerDiagoanal != null ? queenRow - leftLowerDiagoanal[0] - 1: Math.Min(queenRow -1, queenColumn -1) ;
            countOfSquares += rightLowerDiagonal != null ? queenRow - rightLowerDiagonal[0] - 1 : Math.Min(queenRow - 1, boardSide - queenColumn);

            return countOfSquares;
        }

        public static string balancedSums(List<int> arr)
        {
            var totalSum = arr.Sum();
            int leftSum = 0;
            int rightSum = totalSum;

            for (int i = 0; i < arr.Count; i++)
            {
                rightSum -= arr[i];
                if (leftSum == rightSum)
                {
                    return "YES";
                }else if(leftSum > rightSum)
                {
                    return "NO";
                }
                leftSum -= arr[i];
            }
            return "ERROR";
        }

        public static List<int> missingNumbers(List<int> missingArray, List<int> completeArray)
        {
            List<int> missingNums = new List<int>();
            int[] numberCounter = new int[10000];
            for (int i = 0; i < completeArray.Count; i++)
            {
                numberCounter[completeArray[i] -1]++;
            }
            for (int i = 0; i < missingArray.Count; i++)
            {
                numberCounter[missingArray[i] - 1]--;
            }
            for (int i = 0; i < numberCounter.Length; i++)
            {
                if (numberCounter[i] >0)
                {
                    missingNums.Add(i + 1);
                }
            }
            return missingNums;
        }

        public static string superReducedString(string wordToCheck)
        {
            bool resultFound = false;
            bool changeMade = false;

            while (!resultFound)
            {
                for (int i = 0; i < wordToCheck.Length-1; i++)
                {
                    if (wordToCheck[i].Equals(wordToCheck[i+1]) )
                    {
                        wordToCheck = wordToCheck.Remove(i, 2);
                        changeMade = true;
                        i--;
                    }                                      
                }
                if (changeMade)
                {
                    changeMade = false;
                }
                else
                {
                    resultFound = true;
                }
            }
            return string.IsNullOrEmpty(wordToCheck) ? "Empty String" : wordToCheck;
        }

        public static void insertionSort1(int n, List<int> arr)
        {
            int tmp = arr[n - 1];
            bool placeFound = false;
            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] > tmp)
                {                    
                    arr[i + 1] = arr[i];
                    writeSortedListToConsole(arr);
                }
                else
                {
                    arr[i + 1] = tmp;
                    writeSortedListToConsole(arr);
                    placeFound = true;
                    break;
                }                
            }

            if (!placeFound)
            {
                arr[0] = tmp;
                writeSortedListToConsole(arr);
            }
        }

        public static void insertionSort2(int n, List<int> arr)
        {
            for (int i = 1; i < arr.Count; i++)
            {
                arr = sortForInsertion2(i, arr);
                writeSortedListToConsole(arr);
            }
        }

        private static List<int> sortForInsertion2(int n, List<int> arr)
        {
            int tmp = arr[n];
            bool placeFound = false;
            for (int i = n-1; i >= 0; i--)
            {
                if (arr[i] > tmp)
                {
                    arr[i + 1] = arr[i];
                }
                else
                {
                    arr[i + 1] = tmp;
                    placeFound = true;
                    break;
                }
            }

            if (!placeFound)
            {
                arr[0] = tmp;
            }
            return arr;
        }        

        private static void writeSortedListToConsole(List<int> arr)
        {
            foreach (var num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public static long nearlySimilarRectangles(List<List<long>> sides)
        {
            long result = 0;
            var rectangleRates = new List<double>();

            //first we find the rectangle side rate
            for (int i = 0; i < sides.Count; i++)
            {
                rectangleRates.Add(Convert.ToDouble(sides[i][0]) / Convert.ToDouble(sides[i][1]));                
            }

            for (int i = 0; i < rectangleRates.Count; i++)
            {
                for (int j = i+1; j < rectangleRates.Count; j++)
                {
                    if (rectangleRates[i] == rectangleRates[j])
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        public static void insertionSort(int[] A)
        {
            Console.WriteLine(string.Join(" ", A.ToList().OrderBy(n => n).ToList()));
        }

        public static List<int> quickSort(List<int> arr)
        {
            List<int> left = new List<int>();
            List<int> equal = new List<int>();
            List<int> right = new List<int>();
            
            var pivot = arr[0];
            equal.Add(pivot);

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] < pivot)
                {
                    left.Add(arr[i]);
                }
                else if (arr[i] > pivot)
                {
                    right.Add(arr[i]);
                }
                else
                {
                    equal.Add(arr[i]);
                }
            }

            foreach (var item in equal)
            {
                left.Add(item);
            }

            foreach (var item in right)
            {
                left.Add(item);
            }
            return left;            
        }

        public static List<string> bigSorting(List<string> unsorted)
        {
            return unsorted.OrderBy(x => x).OrderBy(x => x.Length).ToList();
        }

        public static long minTime(List<int> files, int numCores, int limit)
        {
            long result = 0;
            var paralelWorkableFiles = new List<int>();
            var nonParalelFiles = new List<int>();

            //we find which files are paralel and which are not
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i] % numCores == 0)
                {
                    paralelWorkableFiles.Add(files[i]);
                }
                else
                {
                    nonParalelFiles.Add(files[i]);
                }
            }
            var paralelWorkableFiles2 = paralelWorkableFiles.OrderByDescending(f => f).ToList();

            //we share paralel files to the cores as long as limit is not exceeded
            foreach (var file in paralelWorkableFiles2)
            {
                if (limit > 0)
                {
                    result += (file / numCores);
                    limit--;
                }
                else
                {
                    result += file;
                }
            }

            //We add all the lines of non paralel files
            foreach (var file in nonParalelFiles)
            {
                result += file;
            }

            return result;
        }

        public static List<string> weightedUniformStrings(string word, List<int> queries)
        {
            var result = new List<string>();
            var validSubstrings = new List<string>();
            var allSubStrWeights = new List<int>();

            var subStrAddInLoop = 0;
            for (int i = 0; i < word.Length; i++)
            {
                allSubStrWeights.Add(calculateStrWeight(word[i].ToString() ));

                for (int j = i+1; j < word.Length; j++)
                {
                    if (word[i].Equals(word[j]))
                    {
                        allSubStrWeights.Add(calculateStrWeight(word[i..(j + 1)].ToString()));
                        subStrAddInLoop++;
                    }
                    else
                    { 
                        break;
                    }
                }
                i += subStrAddInLoop;
                subStrAddInLoop = 0;
            }

           
            foreach (var query in queries)
            {
                if (allSubStrWeights.Contains(query) )
                {
                    result.Add("Yes");
                }
                else
                {
                    result.Add("No");
                }
            }

            return result;
        }

        private static int calculateStrWeight(string strToCalc)
        {            
            return (strToCalc[0] - 'a' + 1 )*strToCalc.Length;
        }

        public static void separateNumbers(string s)
        {

        }

        public static long nearlySimilarRectangles2(List<List<long>> sides)
        {
            long result = 0;
            long innerResult = 0;
            var deneme = string.IsNullOrEmpty("askdhaksf");

            for (int i = 0; i < sides.Count; i++)
            {
                for (int j = i + 1; j < sides.Count; j++)
                {
                    if (sides[i][0] * sides[j][1] == sides[i][1] * sides[j][0])
                    {
                        innerResult++;
                        sides.RemoveAt(j);
                        j--;
                    }
                }
                result += innerResult * (innerResult + 1) / 2;
                innerResult = 0;
            }
            return result;
        }

        public static int maxHarfBul(string kelime)
        {
            kelime = kelime.ToLower();
            int[] letters = new int[26];
            var tmpCount = 0;
            var result = 0;

            for (int i = 0; i < kelime.Length; i++)
            {
                letters[kelime[i] - 'a']++;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] > tmpCount)
                {
                    tmpCount = letters[i];
                    result = i;
                }
            }
            return result;
        }

        public static int refDeneme(List<int> kelime)
        {
            kelime.Add(5);
            return kelime.Count;
        }

        public static int queensAttack2(int boardSide, int numberOfObstacles, int queenRow, int queenColumn, List<List<int>> obstacles)
        {
            var countOfSquares = 0;
            var currentRowIndex = queenRow;
            int currentColumnIndex;

            //we look at the left side of the queen
            currentColumnIndex = queenColumn - 1;
            while (currentColumnIndex > 0 && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentColumnIndex--;
            }

            //we look at the right side of the queen
            currentColumnIndex = queenColumn + 1;
            while (currentColumnIndex <= boardSide && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentColumnIndex++;
            }

            //we look at the up side of the queen
            currentRowIndex = queenRow + 1;
            currentColumnIndex = queenColumn;
            while (currentRowIndex <= boardSide && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentRowIndex++;
            }

            //we look at the lower side of the queen
            currentRowIndex = queenRow - 1;
            while (currentRowIndex > 0 && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentRowIndex--;
            }

            //we look at the left-upper diagonal of the queen
            currentColumnIndex = queenColumn - 1;
            currentRowIndex = queenRow + 1;
            while (currentColumnIndex > 0 && currentRowIndex <= boardSide && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentColumnIndex--;
                currentRowIndex++;
            }

            //we look at the right-upper side of the queen
            currentColumnIndex = queenColumn + 1;
            currentRowIndex = queenRow + 1;
            while (currentColumnIndex <= boardSide && currentRowIndex <= boardSide && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentColumnIndex++;
                currentRowIndex++;
            }

            //we look at the left-lower diagonal side of the queen
            currentRowIndex = queenRow - 1;
            currentColumnIndex = queenColumn -1 ;
            while (currentColumnIndex > 0 && currentRowIndex >0 && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentRowIndex--;
                currentColumnIndex--;
            }

            //we look at the right-lower diagonal side of the queen
            currentColumnIndex = queenColumn + 1;
            currentRowIndex = queenRow - 1;
            while (currentColumnIndex <= boardSide && currentRowIndex > 0 && !checkIfObstacleExists(currentRowIndex, currentColumnIndex, obstacles))
            {
                countOfSquares++;
                currentColumnIndex++;
                currentRowIndex--;
            }

            return countOfSquares;
        }

        private static bool checkIfObstacleExists(int rowIndex, int columnIndex, List<List<int>> obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle[0] == rowIndex && obstacle[1] == columnIndex)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<string> mixColors(List<List<int>> colors, List<List<int>> queries)
        {
            var result = new List<string>();
            var bools = new bool[3];
            bools[0] = false;
            bools[1] = false;
            bools[2] = false;

            foreach (var query in queries)
            {
                var tmpColorTrios = new List<List<int>>();

                foreach (var colorTrio in colors)
                {
                    if (colorTrio[0] <= query[0] && colorTrio[1] <= query[1] && colorTrio[2] <= query[2])
                    {
                        tmpColorTrios.Add(colorTrio);
                    }
                }

                for (int i = 0; i < query.Count; i++)
                {
                    foreach (var tmpColorTrio in tmpColorTrios)
                    {
                        if (tmpColorTrio[i] == query[i])
                        {
                            bools[i] = true;
                            break;
                        }
                    }
                }

                if (bools[0] && bools[1] && bools[2])
                {
                    result.Add("YES");
                }
                else
                {
                    result.Add("NO");
                }

                bools[0] = false;
                bools[1] = false;
                bools[2] = false;
            }

            return result;
        }

        public static int minimumNumber(int n, string password)
        {
            var result = 0;
            bool hasDigit = false, hasLowerCase = false, hasUpperCase = false, hasSpecChars = false;

            char[] special_characters = "!@#$%^&*()-+".ToCharArray();

            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]))
                {
                    hasDigit = true;
                    continue;
                }

                if (special_characters.Contains(password[i]))
                {
                    hasSpecChars = true;
                    continue;
                }

                if (Char.IsLower(password[i]))
                {
                    hasLowerCase = true;
                    continue;
                }

                if (Char.IsUpper(password[i]))
                {
                    hasUpperCase = true;
                    continue;
                }
            }

            //last controls
            if (!hasDigit) result++;
            if (!hasLowerCase) result++;
            if (!hasUpperCase) result++;
            if (!hasSpecChars) result++;

            if (result < 6 - password.Length) result = 6 - password.Length;

            return result;
        }

        private static List<string> detonateGrid(List<string> lastGridState, List<string> fullyBombed)
        {
            var resultGrid = new List<string>();

            var tmpGrid = new List<char[]>();

            foreach (var row in fullyBombed)
            {
                tmpGrid.Add(row.ToArray());
            }

            for (int i = 0; i < lastGridState.Count; i++)
            {
                var currentRow = lastGridState[i];
                for (int j = 0; j < lastGridState[i].Length; j++)
                {
                    //check the cell itself, if it is not a bomb continue, if it is detonate surrounding cells
                    if (!currentRow[j].Equals('O'))
                    {
                        continue;
                    }

                    //detonate the cell itself
                    tmpGrid[i][j] = '.';

                    //check left cell if exists
                    if (j - 1 >= 0)
                    {
                        tmpGrid[i][j - 1] = '.';
                    }
                    //check upper cell if exists
                    if (i - 1 >= 0)
                    {
                        tmpGrid[i - 1][j] = '.';
                    }
                    //check right cell if exists
                    if (j + 1 < lastGridState[i].Length)
                    {
                        tmpGrid[i][j + 1] = '.';
                    }
                    //check bottom cell if exists
                    if (i + 1 < lastGridState.Count)
                    {
                        tmpGrid[i + 1][j] = '.';
                    }
                }
            }

            foreach (var item in tmpGrid)
            {
                resultGrid.Add(new string(item));
            }
            return resultGrid;
        }

        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            var result = 0;

            //if delivery is done on time
            if (y1 < y2 || (y1 == y2 && m1 < m2) || (y1 == y2 && m1 == m2 && d1 <= d2))
            {
                return result;
            }
            //if delivery is done same month but late
            else if (y1 == y2 && m1 == m2 && d1 > d2)
            {
                return (d1 - d2) * 15;
            }
            //if delivery is done same year but another month
            else if (y1 == y2 && m1 > m2)
            {
                return (m1 - m2) * 500;
            }
            //if delivery is done after the calendar year
            else if (y1 > y2)
            {
                return 10000;
            }
            return -1;
        }

        public static int workbook(int n, int k, List<int> questionsOfChapters)
        {
            var result = 0;
            var page = 1;
            var tmp = 0;

            foreach (var questions in questionsOfChapters)
            {
                for (int i = 1; i <= questions; i++)
                {
                    if (tmp == k)
                    {
                        page++;
                        tmp = 0;
                    }

                    if (i == page)
                    {
                        result++;
                    }
                    tmp++;
                }
                page++;
                tmp = 0;
            }
            return result;
        }

        public static int minimumDistances(List<int> a)
        {
            var result = int.MaxValue;

            for (int i = 0; i < a.Count - 1; i++)
            {
                for (int j = i + 1; j < a.Count; j++)
                {
                    if (a[i] == a[j] && (j - i) < result)
                    {
                        result = j - i;
                        break;
                    }
                }
            }

            return result == int.MaxValue ? -1 : result;
        }

        public static List<int> cutTheSticks(List<int> arr)
        {
            List<int> result = new List<int>();

            while (arr.Count > 0)
            {
                result.Add(arr.Count);

                //find the smallest value
                var smallest = arr.Min();

                //cut the pieces and if zero remove from the array
                for (int i = 0; i < arr.Count; i++)
                {
                    arr[i] -= smallest;
                    if (arr[i] == 0)
                    {
                        arr.RemoveAt(i);
                        i--;
                    }
                }
            }

            return result;
        }



        public static long taumBday(int b, int w, int bc, int wc, int z)
        {
            long result = 0;
            Product cheaperProduct = new Product();
            Product expensiveProduct = new Product();

            if (bc < wc)
            {
                cheaperProduct.Count = b;
                cheaperProduct.Price = bc;
                expensiveProduct.Count = w;
                expensiveProduct.Price = wc;
            }
            else
            {
                cheaperProduct.Count = w;
                cheaperProduct.Price = wc;
                expensiveProduct.Count = b;
                expensiveProduct.Price = bc;
            }

            //if it is better to buy cheaper and convert
            if (cheaperProduct.Price + z < expensiveProduct.Price)
            {
                result += (cheaperProduct.Price + z) * expensiveProduct.Count;
            }
            else
            {
                result += expensiveProduct.Price * expensiveProduct.Count;
            }

            //in any case we should buy the cheaper also
            result += cheaperProduct.Count * cheaperProduct.Price;
            return result;
        }

        public static long repeatedString(string s, long n)
        {
            long result = 0;
            long fullCountOfS = n / s.Length;
            int divisionCountOfS = Convert.ToInt32(n % s.Length);
            int countOfAInFullS = s.Count(c => c.Equals('a'));
            int countOfAInSubStringS = s.Substring(0, divisionCountOfS)
        .Count(c => c.Equals('a'));

            result += countOfAInFullS * fullCountOfS;
            result += countOfAInSubStringS;

            return result;
        }

        public static int jumpingOnClouds(List<int> c)
        {
            int i = 0;  //current cloud
            int result = 0;

            while (i < c.Count - 1)
            {
                //This happens when we are just one step away from the finish
                if (i + 2 >= c.Count)
                {
                    result++;
                    i++;
                    break;
                }
                //try jumping two steps
                if (c[i + 2] != 1)
                {
                    result++;
                    i += 2;
                }
                //if we cant jump two steps then we have to jump one step
                else
                {
                    result++;
                    i++;
                }
            }

            return result;
        }

        public static int squares(int a, int b)
        {
            var count = 0;
            int tmp = 0;

            //find the first square number
            for (int i = a; i <= b; i++)
            {
                float precision = 0.01f;
                float min = 0;
                float max = i;
                float result = 0;

                while (max - min > precision)
                {
                    result = (min + max) / 2;
                    if ((result * result) >= i)
                    {
                        max = result;
                    }
                    else
                    {
                        min = result;
                    }
                }
                int roundedResult = (int)Math.Round(result);

                if (roundedResult * roundedResult == i)
                {
                    count++;
                    tmp = roundedResult + 1;
                    break;
                }
            }
            while (tmp * tmp <= b && tmp > 0)
            {
                count++;
                tmp++;
            }

            return count;
        }

        public static int camelcase(string wordToCheck)
        {
            int count = 0;

            foreach (var charToCheck in wordToCheck)
            {
                if ((int)charToCheck >= 65 && (int)charToCheck <= 90)
                {
                    count++;
                }
            }

            return count + 1;
        }
        public static int chocolateFeast(int n, int c, int m)
        {
            int countOfWrappers = 0;
            countOfWrappers = n / c;
            int chocos = countOfWrappers;
            while (countOfWrappers >= m)
            {
                countOfWrappers = countOfWrappers - m;
                countOfWrappers++;
                chocos++;
            }
            return chocos;
        }

        public static List<string> cavityMap(List<string> grid)
        {
            var result = new List<string>(grid);

            for (int i = 1; i < grid.Count - 1; i++)
            {
                //we only check cells which are located not on borders
                for (int j = 1; j < grid.Count - 1; j++)
                {
                    var charToCheck = Convert.ToInt32(grid[i][j].ToString());
                    var leftAdjacent = Convert.ToInt32(grid[i][j - 1].ToString());
                    var rightAdjacent = Convert.ToInt32(grid[i][j + 1].ToString());
                    var upperAdjacent = Convert.ToInt32(grid[i - 1][j].ToString());
                    var lowerAdjacent = Convert.ToInt32(grid[i + 1][j].ToString());

                    if (charToCheck > leftAdjacent &&
                        charToCheck > rightAdjacent &&
                        charToCheck > upperAdjacent &&
                        charToCheck > lowerAdjacent
                        )
                    {
                        result[i] = result[i].Substring(0, j) + 'X' + result[i].Substring(j + 1);
                    }
                }
            }
            return result;
        }

        public static void kaprekarNumbers(int p, int q)
        {
            List<int> numbers = new List<int>();


            if (p < 4)
            {
                if (p == 1)
                {
                    numbers.Add(1);
                }
                if (q < 4)
                {
                    writeResult(numbers);
                    return;
                }
                p = 4;
            }

            for (int i = p; i <= q; i++)
            {
                string squared = ((long)i * i).ToString();
                string left = squared.Substring(0, squared.Length / 2);
                string right = squared.Substring(squared.Length / 2);
                var result = Convert.ToInt32(left) + Convert.ToInt32(right);
                if (result == i)
                {
                    numbers.Add(i);
                }
            }

            writeResult(numbers);
        }

        private static void writeResult(List<int> numbers)
        {
            StringBuilder sb = new StringBuilder();
            if (numbers.Count == 0)
            {
                Console.WriteLine("INVALID RANGE");
            }
            else
            {
                foreach (var num in numbers)
                {
                    sb.Append(num + " ");
                }
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }

        public static long strangeCounter(long t)
        {
            long result = 0;
            long tmp = 3;
            int i = 0;
            List<long> specialNums = new List<long>();
            bool rangeFound = false;
            specialNums.Add(1);

            while (!rangeFound)
            {
                specialNums.Add(specialNums[i] + tmp);
                i++;

                if (t < specialNums[i])
                {
                    rangeFound = true;
                    result = specialNums[i] - t;
                }

                tmp *= 2;
            }

            return result;
        }

        public class Product
        {
            public long Price { get; set; }
            public long Count { get; set; }
        }
    }
}
