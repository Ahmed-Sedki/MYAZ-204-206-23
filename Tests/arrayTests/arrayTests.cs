using Array;

namespace ArrayTests
{
    public class ArrayTests
    {
        [Fact]
        public void Array_Count_Test() => Assert.Equal(3, new Array<string> { "Ahmet", "Mehmet", "Can" }.Count);

        [Fact]
        public void Array_Add_Test() => Assert.Equal(5, new Array<string> { "Ahmet", "Mehmet", "Can", "Canan", "Filiz" }.Count);

        [Fact]
        public void Array_GetItem_Test() => Assert.Equal("Mehmet", new Array<string> { "Ahmet", "Mehmet" }.GetItem(1));

        [Fact]
        public void Arrry_Find_Test() => Assert.Equal(1, new Array<int> { 1, 2, 3, 4 }.Find(2));

        [Fact]
        public void Array_GetEnumerator() => Assert.Equal("AhmetMehmetCan", string.Join("", new Array<string> { "Ahmet", "Mehmet", "Can" }));

        [Fact]
        public void Array_Constructor_Test() => Assert.Equal(5, new Array<int>(36, 23, 55, 44, 61).Capacity);

        [Fact]
        public void Array_SetItem_Test()
        {
            var numbers = new Array<int>(1, 3, 5, 7);
            numbers.SetItem(2, 55);
            Assert.Equal(55, numbers.GetItem(2));
        }

        [Fact]
        public void Array_GetItem_Exception_Test()
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Array<string> { "Ahmet", "Mehmet" }.GetItem(-1));
        }

        [Fact]
        public void Array_Remove_Test()
        {
            var array = new Array<int> { 0, 1, 2, 3, 4 };
            Assert.Equal(2, array.RemoveItem(2));
            Assert.Equal(3, array.GetItem(2));
        }

        [Fact]
        public void Array_Copy_Test()
        {
            var array = new Array<string> { "Ahmet", "Mehmet", "Can", "Deniz" };
            Assert.Equal("Can", array.Copy(2, 3)[0]);
        }

        [Fact]
        public void Array_AddRange_Test() => Assert.Equal(new Array<int> { 1, 2, 3, 4, 5 }, new Array<int>().AddRange(new int[] { 1, 2, 3, 4, 5 }));

        [Fact]
        public void List_Remove_Test()
        {
            var array = new Array<int> { 1, 2, 3, 4, 5 };
            Assert.True(array.Remove(2));
            Assert.False(array.Remove(7));
            Assert.Equal(4, array.Capacity);
        }

        [Fact]
        public void List_Intersect_Test() => Assert.Equal(new string[] { "Mehmet", "Ali" }, new Array<string> { "Mehmet", "Ali", "Nursel", "Mert", "Emir" }.InterSect(new string[] { "Mehmet", "Ahmet", "Tekin", "Ali", "Naz" }));

        [Fact]
        public void List_Union_Test() => Assert.Equal(new string[] { "Mehmet", "Ali", "Nursel", "Mert", "Emir", "Ahmet", "Tekin", "Naz" }, new Array<string> { "Mehmet", "Ali", "Nursel", "Mert", "Emir" }.Union(new string[] { "Mehmet", "Ahmet", "Tekin", "Ali", "Naz" }));

        [Fact]
        public void List_Except_Test() => Assert.Equal(new string[] { "Emir" }, new Array<string> { "Mehmet", "Ali", "Nursel", "Mert", "Emir" }.Except(new string[] { "Mehmet", "Ahmet", "Nursel", "Ali", "Mert" }));
    }
}
