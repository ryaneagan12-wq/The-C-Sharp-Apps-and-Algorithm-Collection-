using System;
using System.Collections.Generic;
using System.IO;

namespace TheHUB
{
    class Book
    {
        public int book_id;
        public string book_title;
        public string author;
        public int total_copies;
        public int available_copies;

        public Book(int book_id, string book_title, string author, int total_copies, int available_copies)
        {
            this.book_id = book_id;
            this.book_title = book_title;
            this.author = author;
            this.total_copies = total_copies;
            this.available_copies = available_copies;
        }


        public void MessageOutput()
        {
            Console.WriteLine($"ID: {book_id}-{book_title} by {author}(Available:{available_copies}/{total_copies})");
        }

        public string FinalOutput()
        {
            return $"{book_id},{book_title},{author},{total_copies},{available_copies}";
        }
    }

    class Member
    {
        public int member_id;
        public string name;
        public List<string> borrowed_books = new List<string>();

        public Member(int member_id, string name, List<string> borrowed_books)
        {
            this.member_id = member_id;
            this.name = name;
            this.borrowed_books = borrowed_books;
        }


        public void MessageOutput()
        {
            string books_borrowed = string.Join(";", borrowed_books);
            Console.WriteLine($"Member: {name} (ID: {member_id}) - Books {books_borrowed}");
        }

        public string FinalOutput()
        {
            string Borrowed_books = string.Join(";", borrowed_books);
            return $"{member_id},{name},{Borrowed_books}";
        }
    }


    class Library
    {
        public List<Book> books = new List<Book>();
        public List<Member> members = new List<Member>();

        public Library()
        {
            this.books = new List<Book>();
            this.members = new List<Member>();
        }

        public Book Find_books(string book_title)
        {
            foreach (Book Book in books)
            {
                if ((Book.book_title.Trim().Equals(book_title.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    return Book;
                }
            }
            return null;
        }

        public Member Find_Members(int member_id)
        {
            foreach (Member Member in members)
            {
                if (Member.member_id == member_id)
                {
                    return Member;
                }
            }
            return null;
        }

        public Book Add_book(int book_id, string book_title, string author, int total_copies, int available_copies)
        {
            if (Find_books(book_title) != null)
            {
                Console.WriteLine("The Book already exists, please try again.");
                return null;
            }
            Book new_books = new Book(book_id, book_title, author, total_copies, available_copies);
            books.Add(new_books);
            Console.WriteLine($"Books: {book_title},Book ID: {book_id} has been successfully added.");
            return new_books;
        }

        public Member Add_member(int member_id, string name, List<string> borrowed_books)
        {
            if (Find_Members(member_id) != null)
            {
                Console.WriteLine("The member id already exist, please try again.");
                return null;
            }
            Member new_member = new Member(member_id, name, borrowed_books);
            members.Add(new_member);
            Console.WriteLine($"Member: {name},Member ID: {member_id} has been successfully added.");
            return new_member;
        }

        public Book BookCheckout(string book_title, int member_id)
        {
            Book book = Find_books(book_title);
            Member member = Find_Members(member_id);

            if (book == null)
            {
                Console.WriteLine("Book isn't found try again.");
                return null;
            }
            if (member == null)
            {
                Console.WriteLine("Member isn't found try again.");
                return null;
            }
            if (member.borrowed_books.Count >= 3)
            {
                Console.WriteLine("You have reached the Max space please try again and clear some files.");
                return null;
            }
            if (member.borrowed_books.Contains(book_title))
            {
                Console.WriteLine("Student exist try again.");
            }
            Console.WriteLine($"Book {book_title}, hase been added successfully to: {member.name}");
            member.borrowed_books.Add(book_title);
            return book;
        }
        public void Display_Book()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books found please try again.");
                return;
            }
            Console.WriteLine("Current Books: ");
            foreach (Book Book in books)
            {
                Book.MessageOutput();
            }
        }

        public void Display_Member()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No members found please try again.");
                return;
            }
            Console.WriteLine("Current Members: ");
            foreach (Member Member in members)
            {
                Member.MessageOutput();
            }
        }
        public void Save_data(string book_file, string member_file)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(book_file))
                {
                    foreach (Book book in books)
                    {
                        writer.WriteLine(book.FinalOutput());
                    }
                }
                using (StreamWriter writer = new StreamWriter(member_file))
                {
                    foreach (Member member in members)
                    {
                        writer.WriteLine(member.FinalOutput());
                    }
                    Console.WriteLine("Successfully saved the data.");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Data could not be loaded please try again.");
            }
        }
        public void Load_data(string book_file, string member_file)
        {
            this.books = new List<Book>();
            this.members = new List<Member>();

            try
            {
                using (StreamReader Reader = new StreamReader(book_file))
                {
                    string line;
                    while ((line = Reader.ReadLine()) != null)
                    {
                        if (line.Trim() != "")
                        {
                            string[] parts = line.Split(',');

                            if (parts.Length >= 5)
                            {
                                try
                                {
                                    int book_id = int.Parse(parts[0]);
                                    string book_title = parts[1];
                                    string author = parts[2];
                                    int total_copies = int.Parse(parts[3]);
                                    int available_copies = int.Parse(parts[4]);
                                    Book new_book = new Book(book_id, book_title, author, total_copies, available_copies);
                                    books.Add(new_book);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Warning: Skipping malformed line.");
                                }
                            }

                        }
                    }
                }
                using (StreamReader Reader = new StreamReader(member_file))
                {
                    string line;
                    while ((line = Reader.ReadLine()) != null)
                    {
                        if (line.Trim() != "")
                        {
                            string[] parts = line.Split(',');

                            if (parts.Length >= 3)
                            {
                                try
                                {
                                    int member_id = int.Parse(parts[0]);
                                    string name = parts[1];
                                    List<string> Borrowed_ids = new List<string>(parts[2].Split(';'));
                                    Member new_member = new Member(member_id, name, Borrowed_ids);
                                    members.Add(new_member);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Warning: Skipping malformed line.");
                                }
                            }
                        }
                    }
                }
                Console.WriteLine($"Data has loaded successfully! Loaded {books.Count} book/s and {members.Count} member/s."); // i know this is definetly still wrong somehow
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File is not found please try another.");
                this.books = new List<Book>();
                this.members = new List<Member>();
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error please try again.");
                this.books = new List<Book>();
                this.members = new List<Member>();
            }
        }
        public void Sort_books()
        {
            int Bookses = books.Count;
            int comp = 0;

            for (int i = 0; i < Bookses; i++)
            {
                for (int x = 0; x < Bookses - i - 1; x++)
                {
                    comp++;
                    if (this.books[x].book_title.CompareTo(this.books[x + 1].book_title) > 0) //kinda unsure yet
                    {
                        Book temp = this.books[x];
                        this.books[x] = this.books[x + 1];
                        this.books[x + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted list");
            Display_Book();

        }

    }
    public class LibraryApp 
    {
        public void Run()
        {
            Console.WriteLine("Library System Started!");
            Library Management = new Library();
            string Book_file = "C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Library Management Project\\Library Management Project\\bookfile.csv";
            string Member_file = "C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Library Management Project\\Library Management Project\\member.csv";

            Console.WriteLine($"Welcome to the Library Management System");
            Console.WriteLine($"Loading Book Files and Member Files:, {Book_file}, {Member_file}");
            Management.Load_data(Book_file, Member_file);


            while (true)
            {
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Register New member");
                Console.WriteLine("3. Checkout a Book");
                Console.WriteLine("4. Display all Books");
                Console.WriteLine("5. Display all members");
                Console.WriteLine("6. Sort Books By Title (challenge)");
                Console.WriteLine("7. Save Data");
                Console.WriteLine("8. Load Data");
                Console.WriteLine("9. Exit");
                Console.WriteLine("Choose a Number from 1-9:");
                int choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter the Book ID:");
                        int book_id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Book Title:");
                        string book_title = Console.ReadLine();
                        Console.WriteLine("Enter the author name of the book:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter the number of total copies:");
                        int total_copies = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the number of available copies:");
                        int available_copies = Convert.ToInt32(Console.ReadLine());
                        Management.Add_book(book_id, book_title, author, total_copies, available_copies);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid input please try again.");
                    }
                }

                else if (choose == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter the member ID:");
                        int member_id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the name of the member:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the name of the book to be borrowed");
                        List<string> borrowed_books = new List<string> { Console.ReadLine() };
                        Management.Add_member(member_id, name, borrowed_books);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid input please try again.");
                    }
                }
                else if (choose == 3)
                {
                    Console.WriteLine("Enter the book title to Checkout in:");
                    string book_title = Console.ReadLine();
                    Console.WriteLine("Enter the member ID to Checkout in:");
                    int member_id = Convert.ToInt32(Console.ReadLine());
                    Management.BookCheckout(book_title, member_id);
                }
                else if (choose == 4)
                {
                    Management.Display_Book();
                }
                else if (choose == 5)
                {
                    Management.Display_Member();
                }
                else if (choose == 6)
                {
                    Management.Sort_books();
                }
                else if (choose == 7)
                {
                    Management.Save_data(Book_file, Member_file);
                }
                else if (choose == 8)
                {
                    Management.Load_data(Book_file, Member_file);
                }
                else if (choose == 9)
                {
                    Console.WriteLine("Exiting Program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Choice is invalid, please try to input a valid number from 1 - 9 again.");
                }
            }
        }
    }
}