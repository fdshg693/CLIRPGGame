namespace GameEngine.Systems
{
    public static class UserInteraction
    {
        public static void clearLastOutput()
        {
            Console.Write("\x1b[1A");  // 上へカーソル移動
            Console.Write("\x1b[2K");  // 行全体をクリア
        }
        /// <summary>
        /// コンソールから「1以上の整数」を入力させ、正しい値が来るまで繰り返すメソッド
        /// </summary>
        public static int ReadPositiveInteger(string prompt = "正の整数を入力してください: ")
        {
            while (true)
            {
                Console.Write(prompt);
                string? line = Console.ReadLine();

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
    }

}
