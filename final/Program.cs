using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using System.Media;


namespace glasses_project
{
    class Program
    {
        //to enlarge the screen 
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        // it's over


        public static void MainMenu()
        {
            string myChoice;

            // Print A Menu
            Console.ResetColor();
            Console.Clear();
            Console.SetCursorPosition(55, 5);
            Console.WriteLine(@" __  __         _             __  __                     ");
            Console.SetCursorPosition(55, 6);
            Console.WriteLine(@"|  \/  |  __ _ (_) _ __      |  \/  |  ___  _ __   _   _ ");
            Console.SetCursorPosition(55, 7);
            Console.WriteLine(@"| |\/| | / _` || || '_ \     | |\/| | / _ \| '_ \ | | | |");
            Console.SetCursorPosition(55, 8);
            Console.WriteLine(@"| |  | || (_| || || | | |    | |  | ||  __/| | | || |_| |");
            Console.SetCursorPosition(55, 9);
            Console.WriteLine(@"|_|  |_| \__,_||_||_| |_|    |_|  |_| \___||_| |_| \__,_|");

            Console.SetCursorPosition(38, 13);
            Console.WriteLine("╔═════════╦════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(38, 14);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 15);
            Console.WriteLine("║    A    ║                            Add New Client                                      ║");
            Console.SetCursorPosition(38, 16);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 17);
            Console.WriteLine("╠═════════╬════════════════════════════════════════════════════════════════════════════════╣");
            Console.SetCursorPosition(38, 18);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 19);
            Console.WriteLine("║    D    ║                            Show Clients Details                                ║");
            Console.SetCursorPosition(38, 20);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 21);
            Console.WriteLine("╠═════════╬════════════════════════════════════════════════════════════════════════════════╣");
            Console.SetCursorPosition(38, 22);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 23);
            Console.WriteLine("║    M    ║                            Search For Client Details                           ║");
            Console.SetCursorPosition(38, 24);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 25);
            Console.WriteLine("╠═════════╬════════════════════════════════════════════════════════════════════════════════╣");
            Console.SetCursorPosition(38, 26);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 27);
            Console.WriteLine("║    V    ║                            Buy a Glass                                         ║");
            Console.SetCursorPosition(38, 28);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 29);
            Console.WriteLine("╠═════════╬════════════════════════════════════════════════════════════════════════════════╣");
            Console.SetCursorPosition(38, 30);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 31);
            Console.WriteLine("║    Q    ║                            Quit                                                ║");
            Console.SetCursorPosition(38, 32);
            Console.WriteLine("║         ║                                                                                ║");
            Console.SetCursorPosition(38, 33);
            Console.WriteLine("╚═════════╩════════════════════════════════════════════════════════════════════════════════╝");
            int top = Console.CursorTop + 2;
            int left = Console.CursorLeft + 18;


            Console.CursorTop = top;
            Console.CursorLeft = left;
            Console.ResetColor();
            Console.WriteLine("Choice (A,D,M,V,or Q): ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(26, Console.CursorTop - 1);
            Console.Write("A");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(28, Console.CursorTop);
            Console.Write("D");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(30, Console.CursorTop);
            Console.Write("M");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(32, Console.CursorTop);
            Console.Write("V");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(37, Console.CursorTop);
            Console.Write("Q");

            Console.SetCursorPosition(40, Console.CursorTop);
            Console.ResetColor();
            // Retrieve the user's choice
            myChoice = Console.ReadLine();

            //location read line
            int t = Console.CursorTop - 1;


            while (myChoice.Length != 1)
            {

                Console.SetCursorPosition(40, t);
                Console.Write("                          ");
                Console.SetCursorPosition(40, t);
                myChoice = Console.ReadLine();
            }
            // Make a decision based on the user's choice
            switch (myChoice)
            {
                //add new customer
                case "A":
                case "a":
                    AddClient();
                    Console.ResetColor();
                    break;
                case "D":
                case "d":
                    ShowClients();
                    //   Console.ResetColor();
                    break;
                case "M":
                case "m":
                    SearchClient();
                    Console.ResetColor();
                    break;
                case "V":
                case "v":
                    BuyGlasses();
                    Console.ResetColor();
                    break;

                case "Q":
                case "q":
                    Console.ResetColor();
                    Console.Clear();
                    if (File.Exists("goodbye.txt"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        StreamReader sd = new StreamReader("goodbye.txt");
                        string read = "";
                        while ((read = sd.ReadLine()) != null)
                        {
                            Console.WriteLine(read);
                        }
                        Console.SetCursorPosition(10, 12);
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    break;
                default:
                    int endTop;

                    Console.CursorLeft = left - 2;
                    Console.WriteLine("┌────────────────────────────────────┐");

                    Console.CursorLeft = left - 2;
                    Console.WriteLine("│                                    │");
                    Console.CursorLeft = left - 2;
                    Console.WriteLine("│                                    │");
                    Console.ResetColor();
                    endTop = Console.CursorTop - 1;
                    Console.CursorLeft = left - 2;
                    Console.Write("│                                    │\n");
                    Console.CursorLeft = left - 2;
                    Console.Write("└────────────────────────────────────┘");
                    Console.CursorLeft = left + 5;
                    Console.CursorTop = endTop;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} is not a valid choice", myChoice);
                    Console.WriteLine();
                    Console.ResetColor();
                    Thread.Sleep(3000);
                    MainMenu();
                    break;
            }

            if (myChoice != "Q" && myChoice != "q")
            {
                // Pause to allow the user to see the results
                Console.WriteLine();
                Console.CursorLeft = left;
                Console.Write("Press Enter key to continue...");
                Console.ReadLine();
                Console.WriteLine();
            }
            //عند الخروج من البرنامج
        }
        public static void AddClient()
        {
            clients[] client;
            int top = Console.CursorTop + 2;
            int left = Console.CursorLeft + 18;

            //if not exit - press q
            bool cust = true;
            //loop in window customer if need to add many client
            while (cust)
            {
                //if back to menu game -not print the ("press any key")

                //Menu Details Customer
                //clear screen
                //start with menu details customer
                Console.Clear();
                //clear all color if change
                Console.ResetColor();
                Console.WriteLine("\n\n");
                Console.WriteLine("\t\t┌──────Input New Customer────────────────────────────────┐");
                Console.WriteLine("\t\t│                                                        │");
                Console.WriteLine("\t\t│        (1) First Name Customer:                        │");
                Console.WriteLine("\t\t│        (2) Last Name Customer:                         │");
                Console.WriteLine("\t\t│        (3) Id Number Customer:                         │");
                Console.WriteLine("\t\t│        (4) Phone Number Customer:                      │");
                Console.WriteLine("\t\t│        (5) BrithDay Customer:                          │");
                Console.WriteLine("\t\t│        (6) Age Customer:                               │");
                Console.WriteLine("\t\t│                                                        │");
                Console.WriteLine("\t\t│                                                        │");
                Console.WriteLine("\t\t└────────────────────────────────────────────────────────┘");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(22, 16);
                Console.WriteLine("press S - SAVE , C - CANCEL , Q -BACK HOME:_");
                Console.ResetColor();



                //read first name
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(49, 5);
                string firstname = Console.ReadLine();
                //read last name
                Console.SetCursorPosition(48, 6);
                string lastname = Console.ReadLine();

                //location focus - from where to begin to input value
                int leftChar = 48;


                string id = "";
                //validate value only number
                while (true)
                {
                    Console.SetCursorPosition(leftChar, 7);
                    char key = Console.ReadKey(true).KeyChar;
                    //if char between 0-9 and length if id only  9 digit
                    if (key >= '0' && key <= '9' && id.Length < 10)
                    {
                        id += key;

                        Console.SetCursorPosition(48, 7);
                        Console.Write("             ");
                        Console.SetCursorPosition(48, 7);
                        Console.Write(id);
                        leftChar++;
                    }

                    //press enter -exit from while
                    if (key == '\r')
                    {
                        break;
                    }
                    //press backspace -clear the last index from string

                    if (key == '\b')
                    {
                        if (id.Length - 1 >= 0 && leftChar - 1 >= 48)
                        {
                            leftChar--;
                            id = id.Substring(0, id.Length - 1);

                            Console.SetCursorPosition(leftChar, 7);
                            Console.Write(" ");
                            Console.SetCursorPosition(48, 7);

                            Console.Write(id);
                        }
                    }
                }
                leftChar = 51;
                string phone = "";
                while (true)
                {
                    Console.SetCursorPosition(leftChar, 8);
                    char key = Console.ReadKey(true).KeyChar;
                    if (key >= '0' && key <= '9' && phone.Length < 10)
                    {
                        phone += key;

                        Console.SetCursorPosition(51, 8);
                        Console.Write("             ");
                        Console.SetCursorPosition(51, 8);
                        Console.Write(phone);
                        leftChar++;
                    }

                    if (key == '\r')
                    {
                        break;
                    }
                    if (key == '\b')
                    {
                        if (phone.Length - 1 >= 0 && leftChar - 1 >= 51)
                        {
                            leftChar--;
                            phone = phone.Substring(0, phone.Length - 1);

                            Console.SetCursorPosition(leftChar, 8);
                            Console.Write(" ");

                            Console.SetCursorPosition(51, 8);
                            Console.Write(id);
                        }
                    }
                }

                Console.SetCursorPosition(47, 9);
                string date = Console.ReadLine();

                string age = "";

                leftChar = 42;

                while (true)
                {
                    Console.SetCursorPosition(leftChar, 10);
                    char key = Console.ReadKey(true).KeyChar;
                    if (key >= '0' && key <= '9' && age.Length < 2)
                    {
                        age += key;

                        Console.SetCursorPosition(42, 10);
                        Console.Write("             ");
                        Console.SetCursorPosition(42, 10);
                        Console.Write(age);
                        leftChar++;
                    }

                    if (key == '\r')
                    {
                        break;
                    }
                    if (key == '\b')
                    {
                        if (age.Length - 1 >= 0 && leftChar - 1 >= 42)
                        {

                            age = age.Substring(0, age.Length - 1);

                            leftChar--;


                            Console.SetCursorPosition(leftChar, 10);
                            Console.Write(" ");
                            Console.SetCursorPosition(42, 10);

                            Console.Write(id);


                        }
                    }
                }
                Console.SetCursorPosition(65, 16);
                top = Console.CursorTop;
                left = Console.CursorLeft;
                Console.ResetColor();
                bool s = true;
                while (s)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    char key = Console.ReadKey(true).KeyChar;
                    switch (key)
                    {
                        case 'Q':
                        case 'q':
                            s = false;
                            cust = false;
                            MainMenu();
                            break;
                        case 'C':
                        case 'c':
                            s = false;
                            Console.Clear();
                            break;
                        case 'S':
                        case 's':

                            StreamReader sd = new StreamReader("clients.txt");
                            string rr = "";

                            int count = 0;
                            while ((rr = sd.ReadLine()) != null)
                            {
                                count++;
                            }
                            sd.Close();
                            sd = new StreamReader("clients.txt");
                            client = new clients[count + 1];
                            count = 0;
                            while ((rr = sd.ReadLine()) != null)
                            {
                                string[] array = rr.Split(',');
                                string fname = array[0];
                                string lname = array[1];
                                string idcust = array[2];
                                string phonecust = array[3];
                                string agecust = array[4];
                                string datecust = array[5];
                                client[count] = new clients(fname, lname, idcust, phonecust, int.Parse(agecust), datecust);
                                count++;
                            }
                            sd.Close();
                            if (firstname != "" && lastname != "" && id != "" && phone != "" && age != "" && date != "")
                            {
                                client[count] = new clients(firstname, lastname, id, phone, int.Parse(age), date);

                                StreamWriter fr = new StreamWriter("clients.txt");
                                for (int i = 0; i < client.Length; i++)
                                {
                                    string fname = client[i].getfirstname();
                                    string lname = client[i].getlastname();
                                    string idcust = client[i].getid();
                                    string phonecust = client[i].getPhone();
                                    int agecust = client[i].getage();
                                    string datecust = client[i].getdate();
                                    fr.WriteLine(fname + "," + lname + "," + idcust + "," + phonecust + "," + agecust + "," + datecust);
                                }
                                fr.Close();
                                Console.SetCursorPosition(24, 17);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("New Customer Saved!!");
                                Console.ResetColor();
                                Console.ReadKey();
                                s = false;
                                Console.Clear();
                            }
                            else
                            {
                                Console.SetCursorPosition(24, 14);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("<details customer empty>");
                                Console.SetCursorPosition(50, 14);
                                Thread.Sleep(1600);
                                Console.SetCursorPosition(24, 14);
                                Console.WriteLine("                              ");
                                //Console.ResetColor();
                                // Console.ReadKey();

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine("_               ");
                                Console.SetCursorPosition(65, 16);
                                Console.ResetColor();

                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine("_               ");
                            Console.SetCursorPosition(65, 16);
                            Console.ResetColor();

                            break;

                    }
                }

            }
            Console.ResetColor();


            Console.SetCursorPosition(40, Console.CursorTop);
            left = Console.CursorLeft;
            top = Console.CursorTop;

        }
        public static void ShowClients()
        {
            clients[] client;
            int top = Console.CursorTop + 2;
            int left = Console.CursorLeft + 18;

            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t┌──────Report Customer───────────────────────────────────────────────────────────────┐");
            Console.WriteLine("\t\t│                                                                                    │");
            Console.WriteLine("\t\t│ ┌─────────────┬────────────┬────────────┬─────────────┬─────────────┬────────────┐ │");
            Console.WriteLine("\t\t│ │    Name     │   Family   │     ID     │     Phone   │     Age     │    Date    │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┴────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
            Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┴────────────┘ │");
            Console.WriteLine("\t\t└────────────────────────────────────────────────────────────────────────────────────┘");

            StreamReader sdd = new StreamReader("clients.txt");
            string rrr = "";

            int count1 = 0;
            while ((rrr = sdd.ReadLine()) != null)
            {
                count1++;
            }
            sdd.Close();
            sdd = new StreamReader("clients.txt");
            client = new clients[count1];
            count1 = 0;
            while ((rrr = sdd.ReadLine()) != null)
            {
                string[] array = rrr.Split(',');
                string fname = array[0];
                string lname = array[1];
                string idcust = array[2];
                string phonecust = array[3];
                string agecust = array[4];
                string datecust = array[5];
                client[count1] = new clients(fname, lname, idcust, phonecust, int.Parse(agecust), datecust);
                count1++;
            }
            sdd.Close();

            int tt = 8;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < client.Length; i++)
            {
                string fname = client[i].getfirstname();
                string lname = client[i].getlastname();
                string idcust = client[i].getid();
                string phonecust = client[i].getPhone();
                int agecust = client[i].getage();
                string datecust = client[i].getdate();
                Console.SetCursorPosition(22, tt);
                Console.Write("{0}", fname);
                Console.SetCursorPosition(37, tt);
                Console.Write("{0}", lname);
                Console.SetCursorPosition(48, tt);
                Console.Write("{0}", idcust);
                Console.SetCursorPosition(61, tt);
                Console.Write("{0}", phonecust);
                Console.SetCursorPosition(78, tt);
                Console.Write("{0}", agecust);
                Console.SetCursorPosition(88, tt);
                Console.Write("{0}", datecust);
                tt += 2;

            }


            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(37, 31);
            Console.WriteLine("Press q to back Home:_");
            Console.SetCursorPosition(58, Console.CursorTop - 1);
            bool b = true;
            while (b)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case 'q':
                    case 'Q':
                        b = false;
                        MainMenu();
                        break;
                    default:
                        Console.SetCursorPosition(58, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("_");
                        Console.ResetColor();
                        Console.SetCursorPosition(58, Console.CursorTop);
                        break;

                }
            }
            Console.ResetColor();

        }
        public static void SearchClient()
        {
            Order[] order;
            clients[] client;
            int top = Console.CursorTop + 2;
            int left = Console.CursorLeft + 18;

            bool msearh = true;
            StreamReader sd2 = new StreamReader("clients.txt");
            string r2 = "";

            int count2 = 0;
            while ((r2 = sd2.ReadLine()) != null)
            {
                count2++;
            }
            sd2.Close();

            StreamReader sdd = new StreamReader("clients.txt");
            client = new clients[count2];
            count2 = 0;
            while ((r2 = sdd.ReadLine()) != null)
            {
                string[] array = r2.Split(',');
                string fname = array[0];
                string lname = array[1];
                string idcust = array[2];
                string phonecust = array[3];
                string agecust = array[4];
                string datecust = array[5];
                client[count2] = new clients(fname, lname, idcust, phonecust, int.Parse(agecust), datecust);
                count2++;
            }
            sdd.Close();


            //order

            sd2 = new StreamReader("order.txt");
            r2 = "";

            count2 = 0;
            while ((r2 = sd2.ReadLine()) != null)
            {
                count2++;
            }
            sd2.Close();
            sdd = new StreamReader("order.txt");
            order = new Order[count2];
            count2 = 0;
            while ((r2 = sdd.ReadLine()) != null)
            {
                string[] array = r2.Split(',');
                string id = array[0];
                string code = array[1];
                string item = array[2];
                int quantity = int.Parse(array[3]);
                float price = float.Parse(array[4]);

                order[count2] = new Order(id, code, item, quantity, price);
                count2++;
            }
            sdd.Close();

            while (msearh)
            {

                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t┌──────Search Orders Customer────────────────────────────────────────────────────────┐");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t│                                                                                    │");
                Console.WriteLine("\t\t│  Search By Id Number:                                                              │");
                Console.WriteLine("\t\t│                                                                                    │");
                Console.WriteLine("\t\t│ ┌────Details Customer────────────────────────────────────────────────────────────┐ │");
                Console.WriteLine("\t\t│ ├─────────────┬────────────┬────────────┬─────────────┬─────────────┬────────────┤ │");
                Console.WriteLine("\t\t│ │    Name     │   Family   │     ID     │     Phone   │     Age     │    Date    │ │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┴────────────┘ │");
                Console.WriteLine("\t\t│ ┌────Orders Customer────────────────────────────────────────────────┐              │");
                Console.WriteLine("\t\t│ ├─────────────┬────────────┬────────────┬─────────────┬─────────────┤              │");
                Console.WriteLine("\t\t│ │      Code   │    Item    │  quantity  │    Price    │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┘              │");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t└────────────────────────────────────────────────────────────────────────────────────┘");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(23, 4);
                Console.Write("Details Customer");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(23, 10);
                Console.Write("Orders Customer");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(37, Console.WindowHeight+3);
                Console.WriteLine("Press a-search q-back Home:_");
                Console.SetCursorPosition(39, 2);

                int leftChar1;
                string id1 = "";
                leftChar1 = 39;
                Console.ForegroundColor = ConsoleColor.Magenta;

                while (true)//Need
                {
                    Console.SetCursorPosition(leftChar1, 2);
                    char key = Console.ReadKey(true).KeyChar;
                    if (key >= '0' && key <= '9' && id1.Length < 10)
                    {
                        id1 += key;

                        Console.SetCursorPosition(39, 2);
                        Console.Write("             ");
                        Console.SetCursorPosition(39, 2);
                        Console.Write(id1);
                        leftChar1++;
                    }

                    if (key == '\r')
                    {
                        break;
                    }
                    if (key == '\b')
                    {
                        if (id1.Length - 1 >= 0 && leftChar1 - 1 >= 39)
                        {

                            id1 = id1.Substring(0, id1.Length - 1);
                            leftChar1--;


                            Console.SetCursorPosition(leftChar1, 2);
                            Console.Write(" ");
                            Console.SetCursorPosition(39, 2);

                            Console.Write(id1);


                        }
                    }
                }
                bool idexist = false;
                for (int i = 0; i < client.Length; i++)
                {
                    if (id1 == client[i].getid())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        idexist = true;
                        string fname = client[i].getfirstname();
                        string lname = client[i].getlastname();
                        string idcust = client[i].getid();
                        string phonecust = client[i].getPhone();
                        int agecust = client[i].getage();
                        string datecust = client[i].getdate();
                        Console.SetCursorPosition(22, 8);
                        Console.Write("{0}", fname);
                        Console.SetCursorPosition(37, 8);
                        Console.Write("{0}", lname);
                        Console.SetCursorPosition(48, 8);
                        Console.Write("{0}", idcust);
                        Console.SetCursorPosition(61, 8);
                        Console.Write("{0}", phonecust);
                        Console.SetCursorPosition(78, 8);
                        Console.Write("{0}", agecust);
                        Console.SetCursorPosition(88, 8);
                        Console.Write("{0}", datecust);

                        break;
                    }
                }

                int toporder = 14;
                for (int i = 0; i < order.Length; i++)
                {
                    if (id1 == order[i].getId())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        idexist = true;

                        string id = order[i].getId();
                        string code = order[i].getCode();
                        string item = order[i].getItem();
                        int quantity = order[i].getQuantity();
                        float price = order[i].getPrice();
                        Console.SetCursorPosition(22, toporder);
                        Console.Write("{0}", code);
                        Console.SetCursorPosition(35, toporder);
                        Console.Write("{0}", item);
                        Console.SetCursorPosition(52, toporder);
                        Console.Write("{0}", quantity);
                        Console.SetCursorPosition(64, toporder);
                        Console.Write("{0}", price);
                        toporder += 2;

                    }
                }
                if (idexist == false)
                {

                    Console.SetCursorPosition(27, Console.WindowHeight - 4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("< id not found > ");
                }
                Console.ResetColor();
                Console.SetCursorPosition(64, Console.WindowHeight - 2);
                bool b1 = true;
                while (b1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    char c = Console.ReadKey(true).KeyChar;
                    switch (c)
                    {
                        case 'a':
                        case 'A':
                            b1 = false;
                            break;
                        case 'q':
                        case 'Q':
                            b1 = false;
                            msearh = false;
                            MainMenu();
                            break;
                        default:
                            Console.SetCursorPosition(64, Console.WindowHeight - 2);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("_");
                            Console.ResetColor();
                            Console.SetCursorPosition(64, Console.WindowHeight - 2);
                            break;

                    }
                }
            }
            Console.ResetColor();

        }
        public static void BuyGlasses()
        {
            Order[] order;
            Order[] curorder;//class to store order before write in file;
            int maxorder = 100;//Maximum Order Value-before write in file
            clients[] client;
            glasses[] glass;
            int top = Console.CursorTop + 2;
            int left = Console.CursorLeft + 18;


            //check if id is exists in row clients
            bool idexist1 = false;


            //get the index if client in list
            int indexclient = -1;
            //string input-id number
            string id2 = "";
            //string input-code number of glasses
            string code1 = "";
            //add-new order without save in file
            bool isadded = false;
            //quantity order
            int o = 0;
            //index start 0 with new order -before write in file
            int indexorder = 0;
            curorder = new Order[maxorder];

            //if not exit from loop while -same window order
            bool msearh1 = true;
            //clients
            //get all clients from file text
            StreamReader sd3 = new StreamReader("clients.txt");
            string r3 = "";

            int count3 = 0;
            while ((r3 = sd3.ReadLine()) != null)
            {
                count3++;
            }
            sd3.Close();
            sd3 = new StreamReader("clients.txt");
            client = new clients[count3];
            int count2 = 0;
            while ((r3 = sd3.ReadLine()) != null)
            {
                string[] array = r3.Split(',');
                string fname = array[0];
                string lname = array[1];
                string idcust = array[2];
                string phonecust = array[3];
                string agecust = array[4];
                string datecust = array[5];
                client[count2] = new clients(fname, lname, idcust, phonecust, int.Parse(agecust), datecust);
                count2++;
            }
            sd3.Close();
            //glasses
            //get all items from file text-glass
            sd3 = new StreamReader("glasses.txt");
            r3 = "";

            count3 = 0;
            while ((r3 = sd3.ReadLine()) != null)
            {
                count3++;
            }
            sd3.Close();
            sd3 = new StreamReader("glasses.txt");
            glass = new glasses[count3];
            count3 = 0;
            while ((r3 = sd3.ReadLine()) != null)
            {
                string[] array = r3.Split(',');
                string code = array[0];
                string item = array[1];
                string type = array[2];
                int quantity = int.Parse(array[3]);
                float price = float.Parse(array[4]);

                glass[count3] = new glasses(code, item, type,quantity, price);
                count3++;
            }
            sd3.Close();

            //loop while
            while (msearh1)
            {
                //print the screen order
                //search id -from clients
                //search code -from glasses
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t┌──────Add Orders Customer───────────────────────────────────────────────────────────┐");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t│                                                                                    │");
                Console.WriteLine("\t\t│  Search By Id Number:                                                              │");
                Console.WriteLine("\t\t│  Code Item          :                                                              │");
                Console.WriteLine("\t\t│                                                                                    │");
                Console.WriteLine("\t\t│ ┌────Details Customer────────────────────────────────────────────────────────────┐ │");
                Console.WriteLine("\t\t│ ├─────────────┬────────────┬────────────┬─────────────┬─────────────┬────────────┤ │");
                Console.WriteLine("\t\t│ │    Name     │   Family   │     ID     │     Phone   │     Age     │    Date    │ │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┴────────────┘ │");
                Console.WriteLine("\t\t│ ┌────Details Glass───────────────────────────────────────────────────────────────┐ │");
                Console.WriteLine("\t\t│ ├─────────────┬────────────┬────────────┬─────────────┬─────────────┬────────────┤ │");
                Console.WriteLine("\t\t│ │    Code     │    Item    │    Type    │    Amount   │    Price    │            │ │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┴────────────┘ │");
                Console.WriteLine("\t\t│ ┌────Orders Customer────────────────────────────────────────────────┐              │");
                Console.WriteLine("\t\t│ ├─────────────┬────────────┬────────────┬─────────────┬─────────────┤              │");
                Console.WriteLine("\t\t│ │      Code   │    Item    │  quantity  │    Price    │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┤              │");
                Console.WriteLine("\t\t│ │             │            │            │             │             │              │");
                Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┘              │");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t└────────────────────────────────────────────────────────────────────────────────────┘");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(23, 5);
                Console.Write("Details Customer");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(23, 11);
                Console.Write("Details Glass");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(23, 17);
                Console.Write("Orders Customer");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 29);
                Console.WriteLine("Press a-search, d-Customer,g-glasses,q-back Home,+ to ADD:_");



                //print order -before store in file

                int toporder = 21;
                for (int i = 0; i < o; i++)
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;


                    string id = curorder[i].getId();
                    string code = curorder[i].getCode();
                    string item = curorder[i].getItem();
                    int quantity = curorder[i].getQuantity();
                    float price = curorder[i].getPrice();

                    Console.SetCursorPosition(22, toporder);
                    Console.Write("{0}", code);
                    Console.SetCursorPosition(35, toporder);
                    Console.Write("{0}", item);
                    Console.SetCursorPosition(52, toporder);
                    Console.Write("{0}", quantity);
                    Console.SetCursorPosition(64, toporder);
                    Console.Write("{0}", price);


                    toporder += 2;


                }


                int leftChar1;
                if (!isadded)
                {
                    Console.SetCursorPosition(39, 2);
                    leftChar1 = 39;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    //loop to validate id number
                    while (true)
                    {
                        //char from keyboard
                        //check if the char is digit 0-9
                        //check if the string only max 10 digits
                        Console.SetCursorPosition(leftChar1, 2);
                        char key = Console.ReadKey(true).KeyChar;
                        if (key >= '0' && key <= '9' && id2.Length < 10)
                        {
                            id2 += key;

                            Console.SetCursorPosition(39, 2);
                            Console.Write("             ");
                            Console.SetCursorPosition(39, 2);
                            Console.Write(id2);
                            leftChar1++;
                        }

                        //press enter -exit from while loop
                        if (key == '\r')
                        {
                            break;
                        }
                        //backspace-remove last index from id
                        if (key == '\b')
                        {
                            if (id2.Length - 1 >= 0 && leftChar1 - 1 >= 39)
                            {

                                id2 = id2.Substring(0, id2.Length - 1);
                                leftChar1--;


                                Console.SetCursorPosition(leftChar1, 2);
                                Console.Write(" ");
                                Console.SetCursorPosition(39, 2);

                                Console.Write(id2);


                            }
                        }
                    }

                }
                else
                {
                    Console.SetCursorPosition(39, 2);
                    Console.Write(id2);
                }

                //loop check id client
                for (int i = 0; i < client.Length; i++)
                {
                    if (id2 == client[i].getid())
                    {
                        indexclient = i;
                        Console.ForegroundColor = ConsoleColor.Green;
                        idexist1 = true;

                        string fname = client[i].getfirstname();
                        string lname = client[i].getlastname();
                        string idcust = client[i].getid();
                        string phonecust = client[i].getPhone();
                        int agecust = client[i].getage();
                        string datecust = client[i].getdate();
                        Console.SetCursorPosition(22, 9);
                        Console.Write("{0}", fname);
                        Console.SetCursorPosition(37, 9);
                        Console.Write("{0}", lname);
                        Console.SetCursorPosition(48, 9);
                        Console.Write("{0}", idcust);
                        Console.SetCursorPosition(61, 9);
                        Console.Write("{0}", phonecust);
                        Console.SetCursorPosition(78, 9);
                        Console.Write("{0}", agecust);
                        Console.SetCursorPosition(88, 9);
                        Console.Write("{0}", datecust);

                        break;
                    }
                }

                //if id not exist print 'id not found'
                if (idexist1 == false && id2 != "")
                {
                    id2 = "";

                    Console.SetCursorPosition(27, 28);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("< id not found > ");
                    Thread.Sleep(700);
                    BuyGlasses();

                }

                //get the index if code in list
                int indexcode = -1;

                //location input the code glass
                Console.SetCursorPosition(39, 3);
                code1 = Console.ReadLine();


                //check if code is exists in row glasses
                bool codexist = false;


                //loop -check code glass
                for (int i = 0; i < glass.Length; i++)
                {
                    if (code1 == glass[i].getCode())
                    {
                        indexcode = i;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        codexist = true;

                        string code = glass[i].getCode();
                        string item = glass[i].getItem();
                        string type = glass[i].getType();
                        int amount = glass[i].getquantity();
                        float price = glass[i].Getprice();
                        Console.SetCursorPosition(22, 15);
                        Console.Write("{0}", code);
                        Console.SetCursorPosition(37, 15);
                        Console.Write("{0}", item);
                        Console.SetCursorPosition(48, 15);
                        Console.Write("{0}", type);
                        Console.SetCursorPosition(61, 15);
                        Console.Write("{0}", amount);
                        Console.SetCursorPosition(78, 15);
                        Console.Write("{0}", price);


                        break;
                    }

                }

                //if code not exist print 'code not found'
                if (codexist == false && code1 != "")
                {
                    code1 = "";
                    Console.SetCursorPosition(27, 28);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("< code not found > ");
                }

                if (codexist && code1 != "" && glass[indexcode].getquantity() - 1 < 0)
                {
                    indexcode = -1;
                    Console.SetCursorPosition(27, 28);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("< the amount is empty > ");
                }

                Console.ResetColor();
                Console.SetCursorPosition(82, 29);
                bool b1 = true;
                while (b1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    char c = Console.ReadKey(true).KeyChar;
                    switch (c)
                    {
                        case 'a':
                        case 'A':
                            b1 = false;
                            BuyGlasses();
                            break;
                        case '+':
                            //check if client and code is exist in list
                            if (indexclient != -1 && indexcode != -1)
                            {
                                isadded = true;
                                //amount order
                                o++;
                                string id = client[indexclient].getid();
                                string code = glass[indexcode].getCode();
                                string item = glass[indexcode].getItem();
                                int quantity = 1;//glass[indexcode].getQuantity();
                                float price = glass[indexcode].Getprice();

                                curorder[indexorder] = new Order(id, code, item, quantity, price);
                                indexorder++;

                                int amount = glass[indexcode].getquantity() - 1;
                                glass[indexcode].setquantity(amount);
                                //reset code glass to add new glass
                                indexcode = -1;

                                Console.WriteLine();

                                Console.WriteLine("                    Press any key to keep buying And S to save");
                                string key = Console.ReadKey().Key.ToString();
                                if (key == "S"|| key == "s")
                                {
                                    if (o > 0)
                                    {
                                        //order
                                        //get all order from file text-orders
                                        sd3 = new StreamReader("order.txt");
                                        r3 = "";

                                        count3 = 0;
                                        while ((r3 = sd3.ReadLine()) != null)
                                        {
                                            count3++;
                                        }
                                        sd3.Close();
                                        sd3 = new StreamReader("order.txt");
                                        order = new Order[count3 + o];
                                        count3 = 0;
                                        while ((r3 = sd3.ReadLine()) != null)
                                        {
                                            string[] array = r3.Split(',');
                                             id = array[0];
                                             code = array[1];
                                             item = array[2];
                                             quantity = int.Parse(array[3]);
                                             price = float.Parse(array[4]);

                                            order[count3] = new Order(id, code, item, quantity, price);
                                            count3++;
                                        }
                                        sd3.Close();

                                        for (int i = 0; i < o; i++)
                                        {

                                             id = curorder[i].getId();
                                             code = curorder[i].getCode();
                                             item = curorder[i].getItem();
                                             quantity = curorder[i].getQuantity();
                                             price = curorder[i].getPrice();

                                            order[count3] = new Order(id, code, item, quantity, price);
                                            count3++;
                                        }
                                        StreamWriter sw = new StreamWriter("order.txt");
                                        for (int i = 0; i < order.Length; i++)
                                        {
                                             id = order[i].getId();
                                             code = order[i].getCode();
                                             item = order[i].getItem();
                                             quantity = order[i].getQuantity();
                                             price = order[i].getPrice();
                                            sw.WriteLine(string.Format("{0},{1},{2},{3},{4}", id, code, item, quantity, price));

                                        }
                                        sw.Close();


                                        //update the report glasses in file text after buy

                                        sw = new StreamWriter("glasses.txt");
                                        for (int i = 0; i < glass.Length; i++)
                                        {
                                             code = glass[i].getCode();
                                             item = glass[i].getItem();
                                            string type = glass[i].getType();
                                             quantity = glass[i].getquantity();
                                             price = glass[i].Getprice();
                                            sw.WriteLine(string.Format("{0},{1},{2},{3},{4}", code, item, type, quantity, price));

                                        }
                                        sw.Close();



                                        Console.SetCursorPosition(27, 28);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("< order is saved!! > ");
                                        System.Threading.Thread.Sleep(800);
                                        b1 = false;

                                        //reset values after saved!!
                                        isadded = false;
                                        indexorder = 0;
                                        o = 0;
                                        idexist1 = false;
                                        id2 = "";
                                        code1 = "";
                                        indexclient = -1;
                                        indexcode = -1;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(27, 28);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("< order is empty > ");
                                    }
                                    Thread.Sleep(200);
                                    MainMenu();
                                }
                            }
                            b1 = false;
                            break;
                        case 'g':
                        case 'G':

                            Console.Clear();


                            Console.ResetColor();
                            Console.WriteLine("\n\n");
                            Console.WriteLine("\t\t┌──────Report Glasses────────────────────────────────────────────────────────────────┐");
                            Console.WriteLine("\t\t│                                                                                    │");
                            Console.WriteLine("\t\t│ ┌─────────────┬────────────┬────────────┬─────────────┬─────────────┬────────────┐ │");
                            Console.WriteLine("\t\t│ │    Code     │   Item     │    Type    │    Amount   │     Price   │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┴────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┴────────────┘ │");
                            Console.WriteLine("\t\t└────────────────────────────────────────────────────────────────────────────────────┘");

                            //    StreamReader sdglass = new StreamReader("glasses.txt");
                            //    string rs1 = "";

                            //    int count5 = 0;
                            //    while ((rs1 = sdglass.ReadLine()) != null)
                            //    {
                            //        count5++;
                            //    }
                            //    sdglass.Close();
                            //    sdglass = new StreamReader("glasses.txt");
                            //glasses[]    glass1 = new glasses[count5];
                            //    count5 = 0;
                            //    while ((rs1 = sdglass.ReadLine()) != null)
                            //    {
                            //        string[] array = rs1.Split(',');
                            //        string code = array[0];
                            //        string item = array[1];
                            //        string type = array[2];
                            //        int amount = int.Parse(array[3]);
                            //        float price = float.Parse(array[4]);

                            //        glass1[count5] = new glasses(code, item, type, amount, price);
                            //        count5++;
                            //    }
                            //    sdglass.Close();

                            int tt2 = 8;
                            Console.ForegroundColor = ConsoleColor.Green;
                            for (int i = 0; i < glass.Length; i++)
                            {
                                string code = glass[i].getCode();
                                string item = glass[i].getItem();
                                string type = glass[i].getType();
                                int quantity = glass[i].getquantity();
                                float price = glass[i].Getprice();

                                Console.SetCursorPosition(22, tt2);
                                Console.Write("{0}", code);
                                Console.SetCursorPosition(37, tt2);
                                Console.Write("{0}", item);
                                Console.SetCursorPosition(48, tt2);
                                Console.Write("{0}", type);
                                Console.SetCursorPosition(61, tt2);
                                Console.Write("{0}", quantity);
                                Console.SetCursorPosition(78, tt2);
                                Console.Write("{0}", price);

                                tt2 += 2;

                            }

                            Console.SetCursorPosition(10, 2);
                            Console.ResetColor();

                            Console.ReadKey();
                            b1 = false;


                            break;
                        case 'd':
                        case 'D':
                            Console.Clear();


                            Console.ResetColor();
                            Console.WriteLine("\n\n");
                            Console.WriteLine("\t\t┌──────Report Customer───────────────────────────────────────────────────────────────┐");
                            Console.WriteLine("\t\t│                                                                                    │");
                            Console.WriteLine("\t\t│ ┌─────────────┬────────────┬────────────┬─────────────┬─────────────┬────────────┐ │");
                            Console.WriteLine("\t\t│ │    Name     │   Family   │     ID     │     Phone   │     Age     │    Date    │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┴────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ ├─────────────┼────────────┼────────────┼─────────────┼─────────────┼────────────┤ │");
                            Console.WriteLine("\t\t│ │             │            │            │             │             │            │ │");
                            Console.WriteLine("\t\t│ └─────────────┴────────────┴────────────┴─────────────┴─────────────┴────────────┘ │");
                            Console.WriteLine("\t\t└────────────────────────────────────────────────────────────────────────────────────┘");

                            StreamReader sdclient = new StreamReader("clients.txt");
                            string rs = "";

                            int count4 = 0;
                            while ((rs = sdclient.ReadLine()) != null)
                            {
                                count4++;
                            }
                            sdclient.Close();
                            sdclient = new StreamReader("clients.txt");
                            client = new clients[count4];
                            count4 = 0;
                            while ((rs = sdclient.ReadLine()) != null)
                            {
                                string[] array = rs.Split(',');
                                string fname = array[0];
                                string lname = array[1];
                                string idcust = array[2];
                                string phonecust = array[3];
                                string agecust = array[4];
                                string datecust = array[5];
                                client[count4] = new clients(fname, lname, idcust, phonecust, int.Parse(agecust), datecust);
                                count4++;
                            }
                            sdclient.Close();

                            int tt1 = 8;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            for (int i = 0; i < client.Length; i++)
                            {
                                string fname = client[i].getfirstname();
                                string lname = client[i].getlastname();
                                string idcust = client[i].getid();
                                string phonecust = client[i].getPhone();
                                int agecust = client[i].getage();
                                string datecust = client[i].getdate();
                                Console.SetCursorPosition(22, tt1);
                                Console.Write("{0}", fname);
                                Console.SetCursorPosition(37, tt1);
                                Console.Write("{0}", lname);
                                Console.SetCursorPosition(48, tt1);
                                Console.Write("{0}", idcust);
                                Console.SetCursorPosition(61, tt1);
                                Console.Write("{0}", phonecust);
                                Console.SetCursorPosition(78, tt1);
                                Console.Write("{0}", agecust);
                                Console.SetCursorPosition(88, tt1);
                                Console.Write("{0}", datecust);
                                tt1 += 2;

                            }


                            Console.ResetColor();

                            Console.ReadKey();
                            b1 = false;
                            break;
                        case 'q':
                        case 'Q':
                            b1 = false;
                            msearh1 = false;
                            MainMenu();
                            break;
                        default:
                            Console.SetCursorPosition(82, 29);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("_");
                            Console.ResetColor();
                            Console.SetCursorPosition(82, 29);
                            break;

                    }
                }
            }
            Console.ResetColor();





        }
        static void Main(string[] args)
        {
            int x = 1;
            while (x > 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                ShowWindow(ThisConsoleMAXIMIZE);//تكبير الشاشة

                SoundPlayer sp1;   //  Add this variable
                sp1 = new SoundPlayer("s.wav"); //The file s.wav should be in BIN directory
                sp1.Play();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;

                Console.Title = "OOTICA GLASSES";
                Console.SetCursorPosition(20, 7);
                Console.WriteLine("¤¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤¤");
                for (int i = 8; i < 33; i++)
                {
                    Console.SetCursorPosition(20, i);
                    Console.WriteLine("¤¤");
                    Console.SetCursorPosition(145, i);
                    Console.WriteLine("¤¤");
                }

                Console.SetCursorPosition(20, 33);
                Console.WriteLine("¤¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤¤");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(40, 12);
                Console.WriteLine("          ██████╗      ██████╗     ████████╗    ██╗     ██████╗     █████╗                ");
                Console.SetCursorPosition(40, 13);
                Console.WriteLine("         ██╔═══██╗    ██╔═══██╗    ╚══██╔══╝    ██║    ██╔════╝    ██╔══██╗               ");
                Console.SetCursorPosition(40, 14);
                Console.WriteLine("         ██║   ██║    ██║   ██║       ██║       ██║    ██║         ███████║               ");
                Console.SetCursorPosition(40, 15);
                Console.WriteLine("         ██║   ██║    ██║   ██║       ██║       ██║    ██║         ██╔══██║               ");
                Console.SetCursorPosition(40, 16);
                Console.WriteLine("         ╚██████╔╝    ╚██████╔╝       ██║       ██║    ╚██████╗    ██║  ██║               ");
                Console.SetCursorPosition(40, 17);
                Console.WriteLine("          ╚═════╝      ╚═════╝        ╚═╝       ╚═╝     ╚═════╝    ╚═╝  ╚═╝               ");
                Console.SetCursorPosition(40,22);
                Console.WriteLine("   ██████╗     ██╗          █████╗     ███████╗    ███████╗    ███████╗    ███████╗");
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("  ██╔════╝     ██║         ██╔══██╗    ██╔════╝    ██╔════╝    ██╔════╝    ██╔════╝");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("  ██║  ███╗    ██║         ███████║    ███████╗    ███████╗    █████╗      ███████╗");
                Console.SetCursorPosition(40, 25);
                Console.WriteLine("  ██║   ██║    ██║         ██╔══██║    ╚════██║    ╚════██║    ██╔══╝      ╚════██║");
                Console.SetCursorPosition(40, 26);
                Console.WriteLine("  ╚██████╔╝    ███████╗    ██║  ██║    ███████║    ███████║    ███████╗    ███████║");
                Console.SetCursorPosition(40, 27);
                Console.WriteLine("   ╚═════╝     ╚══════╝    ╚═╝  ╚═╝    ╚══════╝    ╚══════╝    ╚══════╝    ╚══════╝");
                Console.SetCursorPosition(4, 38);

                Console.WriteLine("Press Enter To Continue Else Exit");

                string key = Console.ReadKey().Key.ToString();
                if (key == "Enter")
                    MainMenu();
                else// للخروج من الشاشة الرئيسية
                    Environment.Exit(0);
                Console.ReadKey();
            }

            Console.ReadLine();
        }
    }
}
