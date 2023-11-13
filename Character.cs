public class Character
{
        public static List<Character> Characters = new List<Character>();
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
                Name = name;
                Job = job;
                Level = level;
                Atk = atk;
                Def = def;
                Hp = hp;
                Gold = gold;
        }
        public static void putStatIncrease(Item inventory)
        {
                if (inventory.Stallation)
                {
                        foreach (var character in Characters)
                        {
                                character.Atk += inventory.Akt;
                                character.Def += inventory.Def;
                        }
                }
        }
        public static void takeStatIncrease(Item inventory)
        {
                if (!inventory.Stallation)
                {
                        foreach (var character in Characters)
                        {
                                character.Atk -= inventory.Akt;
                                character.Def -= inventory.Def;
                        }
                }
        }

        public void Add()
        {
                Characters.Add(this);
        }
}