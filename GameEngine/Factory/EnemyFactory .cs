using GameEngine.Interfaces;
using GameEngine.Models;
using YamlDotNet.Serialization;


namespace GameEngine.Factory
{
    public class EnemySpec
    {
        public string Name { get; set; } = "";
        public int HP { get; set; }
        public string AttackStrategy { get; set; } = "";
        public int Experience { get; set; }
        public int AP { get; set; }
        public int DP { get; set; }
    }

    public static class EnemyFactory
    {
        private static readonly Dictionary<string, EnemySpec> _specs;

        // static コンストラクタで一度だけ読み込む
        static EnemyFactory()
        {
            try
            {
                //YAMLファイルから敵の仕様を読み込む
                var yaml = File.ReadAllText("./enemy-specs.yml");
                var deserializer = new DeserializerBuilder()
                .Build();

                _specs = deserializer.Deserialize<Dictionary<string, EnemySpec>>(yaml);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading enemy specs: {ex.Message}");
                throw;
            }
        }

        public static IEnemy Create(string key)
        {
            if (!_specs.TryGetValue(key, out var spec))
                throw new ArgumentException($"Unknown enemy key: {key}");

            // 文字列をストラテジー型にマッピング
            IAttackStrategy strat = spec.AttackStrategy switch
            {
                "Melee" => new MeleeAttackStrategy(),
                "Default" => new DefaultAttackStrategy(),
                "Magic" => new MagicAttackStrategy(),
                _ => throw new InvalidOperationException($"Unknown strategy: {spec.AttackStrategy}")
            };

            return new Enemy(
                name: spec.Name,
                hp: spec.HP,
                attackStrategy: strat,
                experience: spec.Experience,
                aP: spec.AP,
                dP: spec.DP
            );
        }

        public static IEnemy CreateRandomEnemy()
        {
            var keys = new List<string>(_specs.Keys);
            var rnd = new Random();
            string choice = keys[rnd.Next(keys.Count)];
            return Create(choice);
        }
    }

}
