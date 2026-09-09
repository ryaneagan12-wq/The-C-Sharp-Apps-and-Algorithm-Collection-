using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace HashBrown
{
    class Record
    {
        public int Key;
        public int Data;

        public Record(int KeyX, int DataX)
        {
            Key = KeyX;
            Data = DataX;
        }
    }
    class HashBrown
    {
        public List<List<Record>> HashTable;

        public void Main(string[] args)
        {

            InitialseHashTable();
            ReadData();

            Console.WriteLine("Enter any number for the first keyfield: ");
            int KeyField1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any number for the second keyfield: ");
            int KeyField2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any number for the third keyfield: ");
            int KeyField3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any number for the fourth keyfield: ");
            int KeyField4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any number for the fifth keyfield: ");
            int KeyField5 = Convert.ToInt32(Console.ReadLine());

            int output1 = GetRecord(KeyField1);
            Console.WriteLine(output1);
            int output2 = GetRecord(KeyField2);
            Console.WriteLine(output2);
            int output3 = GetRecord(KeyField3);
            Console.WriteLine(output3);
            int output4 = GetRecord(KeyField4);
            Console.WriteLine(output4);
            int output5 = GetRecord(KeyField5);
            Console.WriteLine(output5);
        }

        public void InitialseHashTable() // might be the wrong way crap
        {
            HashTable = new List<List<Record>>();
            for (int x = 0; x < 100; x++)
            {
                HashTable.Add(new List<Record>()) ;
            }
        }
        public int Hash(int key)
        {
            int Result = key % 100;
            return Result;
        }
        public void InsertData(Record Data)
        {
            int Value = Hash(Data.Key);
            HashTable[Value].Add(Data);
            for (int x = 0; x < 10; x++)
            {
                if (HashTable[Value][x].Key == -1)
                {
                    HashTable[Value].Add(Data);
                }
            }
        }
        public void ReadData()
        {
            try
            {
                string Reading = File.ReadAllText("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\HashBrown\\HashBrown\\HashTableData.txt");
                string[] Vars = Reading.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                InsertData(Record(Data[0, Data[1]].ToString(int))); //not sure yet wth is Record in c#?
            }
            catch (Exception)
            {
                Console.WriteLine("The File is not found please try again.");
            }
        }
        public int GetRecord(int DataY)
        {
            int Value2 = Hash(DataY);

            for (int x = 0; x < 10; x++)
            {
                if (HashTable[Value2][x].DataY == DataY)
                {
                    return HashTable[Value2][x].Data;
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }

        }
    }
}
