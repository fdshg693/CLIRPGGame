namespace GameEngine.Systems
{
    public static class UserInteraction
    {
        /// <summary>
        /// Clears the last line of output from the console.
        /// </summary>
        /// <remarks>This method moves the cursor up by one line and clears the entire line, effectively
        /// removing         the most recent output from the console. It is useful for scenarios where the last output  
        /// needs to be erased or replaced.</remarks>
        public static void clearLastOutput()
        {
            Console.Write("\x1b[1A");  // 上へカーソル移動
            Console.Write("\x1b[2K");  // 行全体をクリア
        }
        /// <summary>
        /// コンソールから「1以上の整数」を入力させ、正しい値が来るまで繰り返すメソッド
        /// </summary>
        public static int? ReadPositiveInteger(string prompt = "正の整数を入力してください: ", string interruptKeyWord = "Q")
        {
            while (true)
            {
                Console.WriteLine($"{interruptKeyWord}を入力することで、入力せずに次に進みます");
                Console.Write(prompt);
                string? line = Console.ReadLine();
                // Quit が入力されたら、ループを抜ける
                if (line == interruptKeyWord)
                {
                    return null;
                }
                // null もしくは空文字の場合も弾く
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("入力が空です。1以上の整数を入力してください。");
                    continue;
                }

                // TryParse で数値変換を試み、かつ 0 より大きいかをチェック
                if (int.TryParse(line, out int value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("正の整数（1以上の整数）を入力してください。");
            }
        }
        public static string SelectAttackStrategy()
        {
            //Player's turn
            //Choose attack strategy                
            var AttackStrategyArray = new string[] { "Default", "Melee", "Magic" };
            var StrategyIndex = 0;
            Console.WriteLine($"Selected Attack Strategy: {AttackStrategyArray[StrategyIndex]}");

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);
                if (new[] { ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Enter }.Contains(keyInfo.Key))
                {
                    UserInteraction.clearLastOutput();
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        // カーソルを 1 行上に移動（\x1b[1A）して、その行をクリア（\x1b[2K）

                        StrategyIndex = (StrategyIndex - 1 + AttackStrategyArray.Length) % AttackStrategyArray.Length;
                        Console.WriteLine($"Selected Attack Strategy: {AttackStrategyArray[StrategyIndex]}");
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        StrategyIndex = (StrategyIndex + 1) % AttackStrategyArray.Length;
                        Console.WriteLine($"Selected Attack Strategy: {AttackStrategyArray[StrategyIndex]}");
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            return AttackStrategyArray[StrategyIndex];

        }
    }

}
