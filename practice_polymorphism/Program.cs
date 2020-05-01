using System;
using sub;
using fav = sub.sub2;//名前空間に別名設定

namespace practice_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var bs1 = new BookStore(1600,1);
            Console.WriteLine($"{bs1.GetAmount()}円です");

            var m1 = new Meal();
            m1.Foo("お好み焼き");//暗黙的

            var m2 = (ILunch)m1;//インターフェイス型にキャスト
            m2.Foo("パスタとビール");//明示的呼び出し

            var m3 = (IDinner)m1;//インターフェイス型にキャスト
            m3.Foo("サラダとパン");//明示的呼び出し

            //他の名前空間で定義されているクラスの呼び出し
            var s = new sub.Program { FirstName="佐藤",LastName="愛子"};
            Console.WriteLine(s.Show());

            var f = new fav::Program();//別名使って呼び出し
            Console.WriteLine(f.Show("いちご"));
        }



    }
    //インターフェイス定義
    interface IAmount
    {
        int GetAmount();
    }

    //同名のメソッドをもつインターフェイスを２つ定義
    interface ILunch
    {
        void Foo(string str);
    }
    interface IDinner
    {
        void Foo(string str);
    }

    //インターフェイス実装
    class BookStore : IAmount
    {
        //自動プロパティ定義
        public int Price { get; set; }
        public int Number { get; set; }
        public BookStore(int price,int number)
        {
            this.Price = price;
            this.Number = number;
        }
        public int GetAmount()
        {
            return this.Price * this.Number;
        }
    }
    //同名のメソッドをもつインターフェイスを同時に実装
    class Meal : ILunch, IDinner
    {
        //暗黙的実装
        public void Foo(string str)
        {
            Console.WriteLine($"暗黙的メソッド呼び出し:{str}");
        }
        //明示的実装
        void ILunch.Foo(string str)
        {
            Console.WriteLine($"明示的呼び出:ランチは{str}");
        }
        void IDinner.Foo(string str)
        {
            Console.WriteLine($"明示的呼び出:夕食は{str}");
        }
    }
}
