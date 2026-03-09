using LinkedListIntroduction.Lib; 

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{

    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
        public void TestDelete()
        {
            IntegerLinkedList list = new IntegerLinkedList();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            
            Assert.IsTrue(list.Delete(2));
            Assert.IsFalse(list.Delete(100));
            Assert.AreEqual("{1, 3}", list.ToString());
        }

        [TestMethod]
        public void TestInsert()
        {
            IntegerLinkedList list = new IntegerLinkedList();
            list.Append(1);
            list.Append(3);
            list.Insert(2, 1);
            Assert.AreEqual("{1, 2, 3}", list.ToString());
        }

        [TestMethod]
        public void TestContains()
        {
            IntegerLinkedList list = new IntegerLinkedList(5);
            Assert.IsTrue(list.Contains(5));
            Assert.IsFalse(list.Contains(10));
        }

        [TestMethod]
        public void TestDuplicates()
        {
            IntegerLinkedList list = new IntegerLinkedList();
            list.Append(1);
            list.Append(1);
            list.Append(2);
            list.RemoveDuplicates();
            Assert.AreEqual("{1, 2}", list.ToString());
        }

        [TestMethod]
        public void TestReverse()
        {
            IntegerLinkedList list = new IntegerLinkedList();
            list.Append(1);
            list.Append(2);
            IntegerLinkedList rev = list.Reverse();
            Assert.AreEqual("{2, 1}", rev.ToString());
        }

        [TestMethod]
        public void TestSorted()
        {
            SortedIntegerLinkedList sorted = new SortedIntegerLinkedList();
            sorted.AddSorted(10);
            sorted.AddSorted(5);
            sorted.AddSorted(8);
            Assert.AreEqual("{5, 8, 10}", sorted.ToString());
        }

        [TestMethod]
        public void TestJoin()
        {
            IntegerLinkedList list1 = new IntegerLinkedList(1);
            IntegerLinkedList list2 = new IntegerLinkedList(2);
            list1.Join(list2);
            Assert.AreEqual("{1, 2}", list1.ToString());
        }

        [TestMethod]
        public void TestMerge()
        { 
            IntegerLinkedList list1 = new IntegerLinkedList(1);
            list1.Append(3);
            IntegerLinkedList list2 = new IntegerLinkedList(2);
            list2.Append(4);
            list1.MergeAlternating(list2);
            Assert.AreEqual("{1, 2, 3, 4}", list1.ToString());
        }
}
