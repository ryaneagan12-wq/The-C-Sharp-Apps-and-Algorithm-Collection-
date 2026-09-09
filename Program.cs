    using System;
    using System.Collections.Generic;
    using System.IO;

    namespace HashBrown
    {
        class Record
        {
            public int Key;
            public string Data;

            public Record(int KeyX, string DataX)
            {
                Key = KeyX;
                Data = DataX;
            }
        }
        class HashesBrown
        {
            public static List<List<Record>> HashTable;

            public static void Main(string[] args)
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

                string output1 = GetRecord(KeyField1);
                Console.WriteLine(output1);
                string output2 = GetRecord(KeyField2);
                Console.WriteLine(output2);
                string output3 = GetRecord(KeyField3);
                Console.WriteLine(output3);
                string output4 = GetRecord(KeyField4);
                Console.WriteLine(output4);
                string output5 = GetRecord(KeyField5);
                Console.WriteLine(output5);
            }

            public static void InitialseHashTable()    
            {
                HashTable = new List<List<Record>>();
                for (int x = 0; x < 100; x++)
                {
                    HashTable.Add(new List<Record>()) ;
                    for (int i = 0; i < 10; i++)
                    {
                        HashTable[x].Add(new Record(-1, ""));
                    }
                }
            }
            public static int Hash(int key)
            {
                int Result = key % 100;
                return Result;
            }
            public static void InsertData(Record Data)
            {
                int Value = Hash(Data.Key);
                for (int x = 0; x < 10; x++)
                {
                    if (HashTable[Value][x].Key == -1)
                    {
                        HashTable[Value][x] = Data;
                        return; 
                    }
                }
            }
            public static void ReadData()
            {
                try
                {
                string[] Reading = File.ReadAllLines("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\HashBrown\\HashBrown\\HashTableData.txt");
                foreach (string Line in Reading)
                    {
                        string[] Vars = Line.Split(','); //Reading.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        InsertData(new Record(Convert.ToInt32(Vars[0]), Vars[1])); //not sure yet wth is Record in c#?
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The File is not found please try again.");
                }
            }
            public static string GetRecord(int DataY)
            {
                int Value2 = Hash(DataY);

                for (int x = 0; x < 10; x++)
                {
                    if (HashTable[Value2][x].Key == DataY)
                    {
                        return HashTable[Value2][x].Data;
                    }
                }
                return "Not Found";
            }
        }
    }