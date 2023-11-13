public class Store
{
        public static List<Store> Items = new List<Store>();
        public string Name { get; set; }
        public int Akt { get; set; }
        public int Def { get; set; }
        public string ItemDescription { get; set; }
        public bool Stallation { get; set; }
        public int Gold { get; }
        public Store()
        {
                Items.Add(new Store("무쇠갑옷", 0, 2, "무쇠로 만들어져 튼튼한 갑옷입니다.", true));
                Items.Add(new Store("낡은검", 2, 0, "쉽게 볼 수 있는 낡은 검 입니다.", true));
        }
        public Store(string name, int atk, int def, string ItemDescription, bool stallation)
        {
                this.Name = name;
                this.Akt = atk;
                this.Def = def;
                this.ItemDescription = ItemDescription;
                this.Stallation = stallation;
        }
        public void Add(Store item)
        {
                Items.Add(item);
        }
        public static void stallationReverse(Store item)
        {
                item.Stallation = item.Stallation == true ? false : true;
        }
        private void setStatIncrease(Store item)
        {

        }
        public static string stallationManagement(Store item)
        {
                return item.Stallation == true ? "[E]" : "   ";
        }
        public override string ToString()
        {
                return $"{this.Name} {this.Akt} {this.Def} {this.ItemDescription} {this.Stallation}";
        }
}
