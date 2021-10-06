using NUnit.Framework;
using AlgorithmsDataStructuresHashTable;

namespace Tests
{
    public class TestsHashTable
    {
        [Test]
        public static void TestHashTableHashFun()
        {
            var hashTable = new HashTable(19, 3);
            Assert.AreEqual(6, hashTable.HashFun("R"));
            Assert.AreEqual(3, hashTable.HashFun("Ro"));
            Assert.AreEqual(17, hashTable.HashFun("Rom"));
            Assert.AreEqual(0, hashTable.HashFun("Roma"));
            Assert.AreEqual(15, hashTable.HashFun("Roman"));
            Assert.AreEqual(6, hashTable.HashFun("Alphanumeric"));
            Assert.AreEqual(9, hashTable.HashFun("Number"));
        }

        [Test]
        public static void TestHashTableSeekSlot()
        {
            var hashTable = new HashTable(19, 3);
            var slot = hashTable.SeekSlot("Ro");
            Assert.AreEqual(3, slot);
            slot = hashTable.SeekSlot("R");
            Assert.AreEqual(6, slot);
            slot = hashTable.SeekSlot("Alphanumeric");
            Assert.AreEqual(6, slot);
            slot = hashTable.SeekSlot("Number");
            Assert.AreEqual(9, slot);

            var hashTable2 = new HashTable(3, 1);
            hashTable2.PutAndReturnNewSlotIndex("1");
            hashTable2.PutAndReturnNewSlotIndex("2");
            hashTable2.PutAndReturnNewSlotIndex("3");
            Assert.AreEqual(-1, hashTable2.SeekSlot("4"));
        }

        [Test]
        public static void TestHashTablePut()
        {
            var hashTable = new HashTable(19, 3);
            hashTable.PutAndReturnNewSlotIndex("Ro"); //3
            Assert.AreEqual("Ro", hashTable.slots[3]);
            hashTable.PutAndReturnNewSlotIndex("R"); //6
            Assert.AreEqual("R", hashTable.slots[6]);
            hashTable.PutAndReturnNewSlotIndex("Alphanumeric"); //6+3 =9
            Assert.AreEqual("Alphanumeric", hashTable.slots[9]);
            hashTable.PutAndReturnNewSlotIndex("Number"); //9+3=12
            Assert.AreEqual("Number", hashTable.slots[12]);

            var hashTable2 = new HashTable(3, 1);
            hashTable2.PutAndReturnNewSlotIndex("1");
            hashTable2.PutAndReturnNewSlotIndex("2");
            hashTable2.PutAndReturnNewSlotIndex("3");
            Assert.AreEqual(-1, hashTable2.PutAndReturnNewSlotIndex("4"));

            var hashTable3 = new HashTable(19,3);
            for(var i = 1; i <= 100; i++)
                Assert.DoesNotThrow(() => hashTable3.PutAndReturnNewSlotIndex(i.ToString()));
        }

        [Test]
        public static void TestHashTableFind()
        {
            var hashTable = new HashTable(19, 3);
            hashTable.PutAndReturnNewSlotIndex("Ro"); //3
            hashTable.PutAndReturnNewSlotIndex("R"); //6
            hashTable.PutAndReturnNewSlotIndex("Alphanumeric"); //6+3 =9
            hashTable.PutAndReturnNewSlotIndex("Number"); //9+3=12
            Assert.AreEqual(3, hashTable.FindSlotIndex("Ro"));
            Assert.AreEqual(6, hashTable.FindSlotIndex("R"));
            Assert.AreEqual(9, hashTable.FindSlotIndex("Alphanumeric"));
            Assert.AreEqual(12, hashTable.FindSlotIndex("Number"));
            Assert.AreEqual(-1, hashTable.FindSlotIndex("C#"));
        }
    }
}
