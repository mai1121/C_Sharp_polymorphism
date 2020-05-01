using System;
namespace sub
{
    class Program
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Show()
        {
            return $"私の名前は{this.LastName}{this.FirstName}です";
        }
    }
    //名前空間は階層構造にできる
    namespace sub2
    {
        class Program
        {
            public string Show(string favorite)
            {
                return $"私の好物は{favorite}です";
            }
        }
    }


}
