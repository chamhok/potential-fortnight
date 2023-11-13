using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using TextRPG;

internal class Program
{
        static void Main(string[] args)
        {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                GameDataSetting();
                DisplayGameIntro();
        }

        static void GameDataSetting()
        {
                // 캐릭터 정보 세팅
                Character Mplayer = new Character("Chad", "전사", 1, 10, 5, 100, 1500);
                Mplayer.Add();
                // 아이템 정보 세팅
                Item inventory = new Item();

                Item.MyItem.Sort((a, b) => a.Name[0] - b.Name[0]);
                Item.Store.Sort((a, b) => a.Name[0] - b.Name[0]);
        }

        static void DisplayGameIntro()
        {

                Console.Clear();

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int input = CheckValidInput(1, 3);
                switch (input)
                {
                        case 1:
                                DisplayMyInfo();
                                break;

                        case 2:
                                DisplayInventory();
                                break;
                        case 3:
                                Displaystore();
                                break;
                }
        }

        static void DisplayMyInfo()
        {
                Console.Clear();
                foreach (var character in Character.Characters)
                {
                        Console.WriteLine("상태보기");
                        Console.WriteLine("캐릭터의 정보르 표시합니다.");
                        Console.WriteLine();
                        Console.WriteLine($"Lv.{character.Level}");
                        Console.WriteLine($"{character.Name}({character.Job})");
                        Console.Write($"공격력 :{character.Atk}");
                        Console.WriteLine($" (+{Item.MyItem.Where(x => x.Stallation).Select(x => x.Akt).Sum()})");
                        Console.Write($"방어력 : {character.Def}");
                        Console.WriteLine($"(+{Item.MyItem.Where(x => x.Stallation).Select(x => x.Def).Sum()})");
                        Console.WriteLine($"체력 : {character.Hp}");
                        Console.WriteLine($"Gold : {character.Gold} G");
                        Console.WriteLine();
                }
                Console.WriteLine("0. 나가기");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">>");


        int input = CheckValidInput(0, 0);
                switch (input)
                {
                        case 0:
                                DisplayGameIntro();
                                break;
                }
        }

        static void DisplayInventory()
        {
                Console.Clear();

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine($"[아이템 목록]");
                foreach (var item in Item.MyItem)
                {
                        Console.WriteLine($"- {Item.stallationManagement(item)} |" +
                                  $"{item.Name + new string('　', 10 - item.Name.Length)}|" +
                                  $"{item.Akt} |" +
                                  $"{item.Def} |" +
                                  $"{item.ItemDescription}");
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 장착관리");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int input = CheckValidInput(0, 1);
                switch (input)
                {
                        case 0:
                                DisplayGameIntro();
                                break;
                        case 1:
                                DisplayInventoryInstallationManagement();
                                break;
                }
        }
        static void DisplayInventoryInstallationManagement()
        {
                Console.Clear();

                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine($"[아이템 목록]");
                foreach (var item in Item.MyItem)
                {
                        Console.WriteLine($"- {Item.MyItem.IndexOf(item) + 1} " +
                                $"{Item.stallationManagement(item)} |" +
                                $"{item.Name + new string('　', 10 - item.Name.Length)}|" +
                                $"{item.Akt} |" +
                                $"{item.Def} |" +
                                $"{item.ItemDescription}");
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기"); 
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int input = CheckValidInput(0, Item.MyItem.Count);
                if (input == 0)
                {
                        DisplayInventory();
                }
                else
                {
                        foreach (var item in Item.MyItem)
                        {
                                if (input == Item.MyItem.IndexOf(item) + 1)
                                {
                                        Item.stallationReverse(item);
                                        item.MyItemAdd(item);
                                        Item.MyItem.RemoveAt(input - 1);
                                        Item.MyItem.Sort((a, b) => a.Name[0] - b.Name[0]);
                                        Character.putStatIncrease(item);
                                        DisplayInventoryInstallationManagement();
                                }
                        }
                }
        }
        static void Displaystore()
        {
                Console.Clear();
                
                Console.WriteLine("상점");
                Console.WriteLine("구매하시겠습니까?.");
                Console.WriteLine("판매 하시겠습니까?.");
                Console.WriteLine();
                Console.WriteLine($"[소지 골드 : {Character.Characters.First().Gold}골드 ]");
                Console.WriteLine();
                Console.WriteLine($"[아이템 목록]");
                Console.WriteLine();
                foreach (var item in Item.Store)
                {
                        string a = ((Item.Store.IndexOf(item) + 1).ToString().Length) > 1 ? "" : " ";
                        Console.WriteLine($"- {Item.Store.IndexOf(item) + 1} " +
                                $"{a}" +
                                $"{Item.stallationManagement(item)}||" +
                                $"{item.Name + new string('　', 10 - item.Name.Length)}|" +
                                $"{item.Akt} |" +
                                $"{item.Def} |" +
                                $"{item.Gold}G |" +
                                $"{item.ItemDescription}");
                }
                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 구매하기");
                Console.WriteLine("2. 판매하기");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");


                int input = CheckValidInput(0, 2);
                switch (input)
                {
                        case 0:
                                DisplayGameIntro();
                                break;
                        case 1:
                                DisplaystoreBuyManagement();
                                break;
                        case 2:
                                DisplaystoreSaleManagement();
                                break;
                }
        }
        static void DisplaystoreBuyManagement()
        {
                Console.Clear();

                Console.WriteLine("구매하기");
                Console.WriteLine("판매 중인 아이템을 구매할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine($"[소지 골드 : {Character.Characters.First().Gold}골드 ]");
                Console.WriteLine();
                Console.WriteLine($"[아이템 목록]");
                Console.WriteLine();
                foreach (var item in Item.Store)
                {
                        string a = ((Item.Store.IndexOf(item) + 1).ToString().Length) > 1 ? "" : " ";
                        Console.WriteLine($"- {Item.Store.IndexOf(item) + 1}" +
                                $"{a}" +
                                $"{Item.stallationManagement(item)}||" +
                                $"{item.Name + new string('　', 10 - item.Name.Length)}|" +
                                $"{item.Akt} |" +
                                $"{item.Def} |" +
                                $"{item.ItemDescription}" +
                                $"{item.Gold}G |" +
                                $"{Item.BuyManagement(item)}");
                }
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");


                int input = CheckValidInput(0, Item.Store.Count);

                if (input == 0)
                {
                        Displaystore();
                }
                else
                {
                        foreach (var item in Item.Store)
                        {
                                if (Character.Characters.First().Gold < item.Gold)
                                {
                                        DisplaystorefailedBuy();
                                }
                                if (input == Item.Store.IndexOf(item) + 1 && !item.Buy)
                                {
                                        Item.BuyReverse(item);
                                        item.StoreAdd(item);
                                        Item.Store.RemoveAt(input - 1);
                                        Item.MyItem.Add(item);
                                        Character.Characters.First().Gold -= item.Gold;
                                        Item.Store.Sort((a, b) => a.Name[0] - b.Name[0]);
                                        Character.putStatIncrease(item);
                                        DisplaystoreBuyManagement();
                                }

                        }

                        DisplaystorefailedBuy();

                }
        }
        static void DisplaystoreSaleManagement()
        {
                Console.Clear();

                Console.WriteLine("판매하기");
                Console.WriteLine("보유 중인 아이템을 판매 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine($"[소지 골드 : {Character.Characters.First().Gold}골드 ]");
                Console.WriteLine();
                Console.WriteLine($"[아이템 목록]");
                Console.WriteLine();
                foreach (var item in Item.Store)
                {
                        string a = ((Item.Store.IndexOf(item) + 1).ToString().Length) > 1 ? "" : " ";
                        Console.WriteLine($"- {Item.Store.IndexOf(item) + 1}" +
                                $"{a}" +
                                $"{Item.stallationManagement(item)}||" +
                                $"{item.Name + new string('　', 10 - item.Name.Length)}|" +
                                $"{item.Akt} |" +
                                $"{item.Def} |" +
                                $"{item.ItemDescription}" +
                                $"{item.Gold}G |" +
                                $"{Item.BuyManagement(item)}");
                }

                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");


                int input = CheckValidInput(0, Item.Store.Count);

                if (input == 0)
                {
                        Displaystore();
                }
                else
                {
                        foreach (var item in Item.Store)
                        {
                                if (input == Item.Store.IndexOf(item) + 1 && !item.Buy)
                                {
                                        DisplaystorefailedSale();
                                }
                                if (input == Item.Store.IndexOf(item) + 1 && item.Buy)
                                {
                                        Item.BuyReverse(item);
                                        item.StoreAdd(item);
                                        Item.Store.RemoveAt(input - 1);
                                        Item.MyItem.RemoveAll(x => x.Name == item.Name);
                                        Character.Characters.First().Gold += Convert.ToInt16(item.Gold * 0.85f);
                                        Item.Store.Sort((a, b) => a.Name[0] - b.Name[0]);
                                        Character.takeStatIncrease(item);
                                        DisplaystoreSaleManagement();
                                }
                        }
                        DisplaystorefailedSale();
                }
        }
        static void DisplaystorefailedBuy()
        {
                Console.WriteLine("불가능한 행동입니다.");
                Console.WriteLine("상점을 계속 이용하시려면 아무키나 눌러주세요.");
                Console.ReadLine();
                DisplaystoreBuyManagement();
        }
        static void DisplaystorefailedSale()
        {
                Console.WriteLine("불가능한 행동입니다.");
                Console.WriteLine("상점을 계속 이용하시려면 아무키나 눌러주세요.");
                Console.ReadLine();
                DisplaystoreSaleManagement();
        }
        static int CheckValidInput(int min, int max)
        {
                while (true)
                {
                        string input = Console.ReadLine() ?? " ";

                        bool parseSuccess = int.TryParse(input, out var ret);
                        if (parseSuccess)
                        {
                                if (ret >= min && ret <= max)
                                        return ret;
                        }

                        Console.WriteLine("잘못된 입력입니다.");
                }
        }
}
class MyClass
{
        public MyClass()
        {

        }
        public void Title(string title)
        {
                Console.SetCursorPosition(Console.WindowWidth / 2 - (title.Length / 2), 1);
                Console.WriteLine(title);
                Console.Write("║");
                foreach (var item in Enumerable.Range(0, Console.WindowWidth))
                {
                        if (item == 0 || item == Console.WindowWidth - 1) continue;
                        else
                        {
                                Console.Write("═");
                        }

                }
                Console.WriteLine();
        }
        public void Drow()
        {
                foreach (var item in Enumerable.Range(0, Console.WindowWidth))
                {
                        if (item == 0)
                        {
                                Console.SetCursorPosition(item, 0);
                                Console.Write("╔");
                        }
                        else if (item == Console.WindowWidth - 1)
                        {
                                Console.SetCursorPosition(item, 0);
                                Console.Write("╗");
                        }
                        else
                        {
                                Console.SetCursorPosition(item, 0);
                                Console.Write("═");
                        }

                }
                foreach (var item in Enumerable.Range(0, Console.WindowWidth))
                {
                        if (item == 0)
                        {
                                Console.SetCursorPosition(item, Console.WindowHeight - 1);
                                Console.Write("╚");
                        }
                        else if (item == Console.WindowWidth - 1)
                        {
                                Console.SetCursorPosition(item, Console.WindowHeight - 1);
                                Console.Write("╝");
                        }
                        else
                        {
                                Console.SetCursorPosition(item, Console.WindowHeight - 1);
                                Console.Write("═");
                        }

                }
                foreach (var item in Enumerable.Range(0, Console.WindowHeight - 1))
                {
                        if (item == 0 || item == Console.WindowHeight - 1) continue;
                        Console.SetCursorPosition(0, item);
                        Console.Write("║");
                }
                foreach (var item in Enumerable.Range(0, Console.WindowHeight - 1))
                {
                        if (item == 0 || item == Console.WindowHeight - 1) continue;
                        Console.SetCursorPosition(Console.WindowWidth - 1, item);
                        Console.Write("║");
                }
        }
}
