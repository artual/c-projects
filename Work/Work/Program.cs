using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    delegate R Del<T, R>(T item, Employee ToWorkOn);
    delegate void Del(Employee ToWorkOn);
    class Program
    {
        public static Random rand = new Random();
        public static Company RandomComp(int depth, int numOfSubordinates)
            // Depth cant be positive if num of subordinates isnt positive...
            // The maximum amount of workers is: (subordinates ^ depth) - 1
            // There is a sub function here.
        {
            Company comp = new Company("cmp", 0, null);
            Employee epic = new Employee("epic", -1, 0, comp);
            RandomSubordinates(depth, epic);
            comp.SetManagers(epic.GetSubordinates());
            return comp;


            void RandomSubordinates(int low, Employee boss)
            {
                boss.SetSubordinates(new Node<Employee>(null));
                Node<Employee> p1 = boss.GetSubordinates();

                for (int i = rand.Next(1, numOfSubordinates + 1); i > 0; i--)
                {
                    double id = comp.GenerateID();
                    p1.SetValue(new Employee(id.ToString(), id, rand.Next(500, 1001) * (low + 1), comp));

                    if (rand.Next(low + 1) != 0)
                    {
                        RandomSubordinates(low - 1, p1.GetValue());
                    }

                    p1.SetNext(new Node<Employee>(null));
                    p1 = p1.GetNext();
                }

                p1 = boss.GetSubordinates();
                while (p1.GetNext().GetNext() != null)
                {
                    p1 = p1.GetNext();
                }
                p1.SetNext(null);
            }
        }
        public static Company TestingOnly()
        {
            Console.WriteLine("HEY!");
            Console.WriteLine("I see you found my little easter egg!");
            Console.WriteLine("I'm sure you're quite proud of yourself! but");
            Console.WriteLine("  be careful as you stumbled upon a testing site, thus dangering yourself.");
            Console.WriteLine("The following won't be so nice as I'm now...");
            Console.Write("depth: ");
            int depth = int.Parse(Console.ReadLine());
            Console.Write("numOfSubordinates: ");
            int numOfSubordinates = int.Parse(Console.ReadLine());
            return RandomComp(depth, numOfSubordinates);
        }
        public static Company CreateRandomCompany()
        {
            // A list of possible names
            string[] names = new string[] { "Aiden Fuller", "Mikolaj Maldonado", "Nichola Correa", "Jobe Kemp", "Finnian Cano", "Dawn Clements", "Giovanni Craft", "Charity Keenan", "Evie-Rose Potts", "Maxim Delgado", "Luis Ware", "Aleksander Bowers", "Ameena Velazquez", "Rylan Regan", "Riaz Cook", "Keenan Conroy", "Suzanne Mcdermott", "Kyron Odonnell", "Dotty Hensley", "Kamile Knights", "Konrad Bloggs", "Orlando Sheehan", "Moses Davenport", "Nimrah Anthony", "Milton Dean", "Tamara Wills", "Hywel Clay", "Andreea Quinn", "Abdi Watson", "Abdur Rose", "Elysia Peacock", "Ammara Flynn", "June Gilmour", "Brittany Coffey", "Marwah Mccullough", "Adam Donald", "Cheryl Hodge", "Oakley Martins", "Marshall Hess", "Aleisha Childs", "Marcus Davidson", "Oluwatobiloba Hawkins", "Indigo Swift", "Yasser Ventura", "Osama Guevara", "Domonic Cameron", "Amanda Hoover", "Lexie Jacobson", "Buddy Davies", "Shyam John", "Wilf Rudd", "Keane Hickman", "Greg Petersen", "Francisco Adamson", "Uzma Williams", "Leila Millar", "Garin Day", "Alara Noble", "Sebastian East", "Russell Gay", "Humzah Cooke", "Amy Hansen", "Kimberley Bouvet", "Zander Vaughan", "Lulu Wilde", "Zacharia Paine", "Aurelia Dunkley", "Niko Simon", "Haydon Carey", "James Norton", "Christopher Townsend", "Nigel Hooper", "Elaine Fraser", "Daisie Harding", "Ihsan Frederick", "Rimsha Barrett", "Cassie Bone", "Massimo Allen", "Lynn Andrew", "Conah Perez", "Viktor Couch", "Shawn Downs", "Kali Kay", "Clarke Vo", "Kayla Sparrow", "Darcie Atkinson", "Eryn Davila", "Azaan Garza", "Sunil Callaghan", "Layton Mcneill", "Farhana Feeney", "Myles Kirk", "Maksymilian Carroll", "Elisha Melia", "Aizah Lake", "Gracie-Mae Galloway", "Kaiser Randolph", "Josh Mueller", "Kasper Woodard", "Said Power" };
            
            Console.WriteLine("What would be the company's name?");
            string name = Console.ReadLine();
            Console.WriteLine("What would be its worth?");
            double worth = double.Parse(Console.ReadLine());
            Console.WriteLine("How many subordinates will a manager have?");
            int numOfSubordinates = int.Parse(Console.ReadLine());
            int depth = 0;
            if (numOfSubordinates != 0)
            {
                Console.WriteLine("How low will the hierarchy go?");
                depth = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("In what range will the lowest salary be? (num-num)");
            string[] temp = Console.ReadLine().Split('-');
            double salary1 = double.Parse(temp[0]), salary2 = double.Parse(temp[1]);

            Company comp = new Company(name, worth, null);
            Employee epic = new Employee("epic", -1, 0, comp);
            RandomSubordinates(depth, epic);
            comp.SetManagers(epic.GetSubordinates());

            Console.WriteLine(comp);
            return comp;


            void RandomSubordinates(int low, Employee boss)
            {
                boss.SetSubordinates(new Node<Employee>(null));
                Node<Employee> p1 = boss.GetSubordinates();

                for (int i = rand.Next(1, numOfSubordinates + 1); i > 0; i--)
                {
                    double id = comp.GenerateID();
                    p1.SetValue(new Employee(names[rand.Next(names.Length)], id, rand.Next(Math.Min((int)salary1, (int)salary2), Math.Max((int)salary1, (int)salary2)) * (low + 1), comp));

                    if (rand.Next(low + 1) != 0)
                    {
                        RandomSubordinates(low - 1, p1.GetValue());
                    }

                    p1.SetNext(new Node<Employee>(null));
                    p1 = p1.GetNext();
                }

                p1 = boss.GetSubordinates();
                while (p1.GetNext().GetNext() != null)
                {
                    p1 = p1.GetNext();
                }
                p1.SetNext(null);
            }
        }
        public static Company CreateCompany()
        {
            // Defining Company with name and worth
            Console.WriteLine("How would you like to call your company?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the company's worth?");
            double worth = double.Parse(Console.ReadLine());
            Company comp = new Company(name, worth, null);

            // Definining managers of company
            Console.WriteLine("Who are the managers of the company? (manager1, manager2, etc...)");
            string[] managerNames = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            Console.WriteLine("What will be their salary?");
            double salary = double.Parse(Console.ReadLine());

            Node<Employee> p1 = new Node<Employee>(null), l1 = p1;
            for (int i = managerNames.Length; i > 0; i--)
            {
                p1.SetNext(new Node<Employee>(new Employee(managerNames[i], comp.GenerateID(), salary, comp)));
                p1 = p1.GetNext();
            }
            l1 = l1.GetNext();
            comp.SetManagers(l1);
            return comp;
        }
        public static void PrintCompany(Company comp)
        {
            Console.WriteLine(comp);
        }
        public static void PrintEmployee(Company comp)
        {
            Console.WriteLine("Whats his name / id?");
            string name = Console.ReadLine();
            if (double.TryParse(name, out double id))
            {
                Console.WriteLine(comp.FindEmployee(id).ToStringWithoutSubs());
            }
            else
            {
                Node<Employee> p1 = comp.FindEmployee(name);
                while (p1 != null)
                {
                    Console.WriteLine(p1.GetValue().ToStringWithoutSubs());
                }
            }
        }
        public static void Hire(Company comp)
        {
            // A list of possible names
            string[] names = new string[] { "Aiden Fuller", "Mikolaj Maldonado", "Nichola Correa", "Jobe Kemp", "Finnian Cano", "Dawn Clements", "Giovanni Craft", "Charity Keenan", "Evie-Rose Potts", "Maxim Delgado", "Luis Ware", "Aleksander Bowers", "Ameena Velazquez", "Rylan Regan", "Riaz Cook", "Keenan Conroy", "Suzanne Mcdermott", "Kyron Odonnell", "Dotty Hensley", "Kamile Knights", "Konrad Bloggs", "Orlando Sheehan", "Moses Davenport", "Nimrah Anthony", "Milton Dean", "Tamara Wills", "Hywel Clay", "Andreea Quinn", "Abdi Watson", "Abdur Rose", "Elysia Peacock", "Ammara Flynn", "June Gilmour", "Brittany Coffey", "Marwah Mccullough", "Adam Donald", "Cheryl Hodge", "Oakley Martins", "Marshall Hess", "Aleisha Childs", "Marcus Davidson", "Oluwatobiloba Hawkins", "Indigo Swift", "Yasser Ventura", "Osama Guevara", "Domonic Cameron", "Amanda Hoover", "Lexie Jacobson", "Buddy Davies", "Shyam John", "Wilf Rudd", "Keane Hickman", "Greg Petersen", "Francisco Adamson", "Uzma Williams", "Leila Millar", "Garin Day", "Alara Noble", "Sebastian East", "Russell Gay", "Humzah Cooke", "Amy Hansen", "Kimberley Bouvet", "Zander Vaughan", "Lulu Wilde", "Zacharia Paine", "Aurelia Dunkley", "Niko Simon", "Haydon Carey", "James Norton", "Christopher Townsend", "Nigel Hooper", "Elaine Fraser", "Daisie Harding", "Ihsan Frederick", "Rimsha Barrett", "Cassie Bone", "Massimo Allen", "Lynn Andrew", "Conah Perez", "Viktor Couch", "Shawn Downs", "Kali Kay", "Clarke Vo", "Kayla Sparrow", "Darcie Atkinson", "Eryn Davila", "Azaan Garza", "Sunil Callaghan", "Layton Mcneill", "Farhana Feeney", "Myles Kirk", "Maksymilian Carroll", "Elisha Melia", "Aizah Lake", "Gracie-Mae Galloway", "Kaiser Randolph", "Josh Mueller", "Kasper Woodard", "Said Power" };

            // printing the names to choose from and organizing
            Console.WriteLine("You posted a hiring poster and these want to be hired:");
            Console.WriteLine();
            int exp;
            string[] noticed = new string[rand.Next(2, 6)];
            for (int i = 0; i < noticed.Length; i++)
            {
                noticed[i] = names[rand.Next(names.Length)];
                exp = rand.Next(7);

                Console.WriteLine("Name: {0} \nExperience: {1} years \n", noticed[i], exp);
            }

            // choosing the employee
            Console.WriteLine("Which one do you want to choose? (index)");
            int ind = int.Parse(Console.ReadLine());
            Console.WriteLine("And in which group would you like to put him/her? (0 - {0})", comp.GetLowestEmployees().GetValue().BossCount() + 1);
            Console.WriteLine("0 - Manager");
            Console.WriteLine("{0} - Subordinate of a rookie", comp.GetLowestEmployees().GetValue().BossCount() + 1);
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine("What would be his/her salary?");
            double salary = double.Parse(Console.ReadLine());
            Employee newOne = new Employee(noticed[ind], comp.GenerateID(), salary, comp);

            

            if (position == 0)
            {
                comp.GetManagers().GetLast().SetNext(new Node<Employee>(newOne));
            }
            else
            {
                Node<Employee> possibleBosses = new Node<Employee>(null);
                Del<object, object> okBoss = delegate (object nothing, Employee emp1)
                {
                    if (position - 1 == emp1.BossCount())
                    {
                        possibleBosses.GetLast().SetNext(new Node<Employee>(emp1));
                    }
                    return null;
                };
                comp.ForEveryEmployee<object, object>(okBoss);
                possibleBosses = possibleBosses.GetNext();

                possibleBosses.GetNext(rand.Next(possibleBosses.GetLength())).GetValue().AddSubordinate(new Node<Employee>(newOne));
            }
        }
        public static void Fire(Company comp)
        {
            // finding the unlucky
            Console.WriteLine("Who would you like to fire?");
            string answer = Console.ReadLine();
            Employee unlucky;
            if (double.TryParse(answer, out double id))
            {
                unlucky = comp.FindEmployee(id);
            }
            else
            {
                Node<Employee> p1 = comp.FindEmployee(answer);
                Console.WriteLine("Which one? (index)");
                while (p1 != null)
                {
                    Console.WriteLine(p1.GetValue().ToStringWithoutSubs());
                }
                unlucky = p1.GetNext(int.Parse(Console.ReadLine())).GetValue();
            }

            // firing the unlucky
            if (unlucky.GetSubordinates() != null) // if the unlucky has subordinates
            {
                Console.WriteLine("What would you like to do with his subordinates?");
                Console.WriteLine("1. Spread them within the company's bosses");
                Console.WriteLine("2. Give them to his boss (if he's a manager, make them managers)");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    Node<Employee> p1 = unlucky.GetSubordinates();
                    unlucky.GetBoss().RemoveSub(unlucky);
                    while (p1 != null)
                    {
                        comp.GetRandomEmployee().AddSubordinate(new Node<Employee>(p1.GetValue()));
                        p1 = p1.GetNext();
                    }
                }
                else // option 2
                {
                    if(unlucky.BossCount() == 0) // the unlucky is a manager
                    {
                        comp.GetManagers().GetLast().SetNext(unlucky.GetSubordinates());
                        if (comp.GetManagers().GetValue() == unlucky)
                        {
                            comp.SetManagers(comp.GetManagers().GetNext());
                        }
                        else
                        {
                            Node<Employee> p1 = comp.GetManagers();
                            while (p1.GetNext().GetValue() != unlucky)
                            {
                                p1 = p1.GetNext();
                            }
                            p1.SetNext(p1.GetNext(2));
                        }
                    }
                    else
                    {
                        unlucky.GetBoss().AddSubordinate(unlucky.GetSubordinates());
                        unlucky.GetBoss().RemoveSub(unlucky);
                    }
                }
            }
            else
            {
                unlucky.GetBoss().RemoveSub(unlucky);
            }
            Console.WriteLine("DONE");
            Console.WriteLine("MUHAHAHA");
            Console.WriteLine();
            Console.WriteLine(@" ,    ,    /\   /\  ");
            Console.WriteLine(@"/( /\ )\  _\ \_/ /_ ");
            Console.WriteLine(@"|\_||_/| < \_   _/ >");
            Console.WriteLine(@"\______/  \|0   0|/ ");
            Console.WriteLine(@"  _\/_   _(_  ^  _)_ ");
            Console.WriteLine(@" ( () ) /`\|V'''V|/`\");
            Console.WriteLine(@"   {}   \  \_____/  /");
            Console.WriteLine(@"   ()   /\   )=(   /\");
            Console.WriteLine(@"   {}  /  \_/\=/\_/  \");
        }
        public static void TopPaid(Company comp)
        {
            Node<Employee> topPaid = new Node<Employee>(comp.GetManagers().GetValue());
            Del<object, object> higherPaid = delegate (object nothing, Employee emp1)
            {
                if (emp1.GetSalary() > topPaid.GetValue().GetSalary())
                {
                    topPaid = new Node<Employee>(emp1);
                    return null;
                }
                if (emp1.GetSalary() == topPaid.GetValue().GetSalary() && topPaid.GetValue() != emp1)
                {
                    topPaid.GetLast().SetNext(new Node<Employee>(emp1));
                }
                return null;
            };
            comp.ForEveryEmployee<object, object>(higherPaid);

            Console.WriteLine("The top paid employees are:");
            Console.WriteLine();
            while (topPaid != null)
            {
                Console.WriteLine(topPaid.GetValue().ToStringWithoutSubs());
                topPaid = topPaid.GetNext();
            }
        }
        public static void BottomEmployee(Company comp)
        {
            Node<Employee> bottom = comp.GetLowestEmployees();

            Console.WriteLine("The bottom employees of the hierarchy are:");
            Console.WriteLine();
            Console.WriteLine(bottom);
        }
        public static void AvgPay(Company comp)
        {
            double sum = 0;
            int count = 0;
            Del avg = delegate (Employee emp1)
            {
                sum += emp1.GetSalary();
                count++;
            };
            comp.ForEveryEmployee(avg);

            Console.WriteLine("The average salary in the company is: " + sum / count);
        }
        public static void ChangeSalary(Company comp)
        {
            Console.WriteLine("Who's salary would you like to change?");
            string answer = Console.ReadLine();
            Employee lucky;
            if (double.TryParse(answer, out double id))
            {
                lucky = comp.FindEmployee(id);
            }
            else
            {
                Node<Employee> p1 = comp.FindEmployee(answer);
                Console.WriteLine("Which one? (index)");
                while (p1 != null)
                {
                    Console.WriteLine(p1.GetValue().ToStringWithoutSubs());
                }
                lucky = p1.GetNext(int.Parse(Console.ReadLine())).GetValue();
            }

            Console.WriteLine($"His/Hers current salary is {lucky.GetSalary()}, what would be his/hers new one?");
            lucky.SetSalary(double.Parse(Console.ReadLine()));
        }
        public static void Craziness(Company comp)
        {
            comp.SetWorth(comp.GetWorth() * -0.5);
            comp.Beswitching();
            Console.WriteLine("The CEO and managers got crazy! they decided that everyone in the company should switch jobs!");
            Console.WriteLine("Including Themselves! This is the mess they've created: ");
            Console.WriteLine();
            Console.WriteLine("THE MESSY {0} \n\nWorth: {1} \n\nManagers: \n\n{2}", comp.GetName().ToUpper(), comp.GetWorth(), comp.GetManagers());
        }
        public static void Plague(Company comp)
        {
            Console.WriteLine("A terrible plague happened and a lot of employees are sick!");
            Console.WriteLine("Would you like to treat them or save the money?");
            Console.WriteLine("1. Treat them");
            Console.WriteLine("2. Save the Money");
            double numOfDead = 0;
            if (int.Parse(Console.ReadLine()) == 1) // option 1
            {
                Console.WriteLine("You successfully saved nearly all of them");
                Console.WriteLine("Here's the company now:");
                comp.SetWorth(comp.GetWorth() - comp.EmployeeCount() * 100);
                numOfDead = comp.EmployeeCount() * 0.05;
                
            }
            else // option 2
            {
                Console.WriteLine("You are really evil but you did save a lot of money...");
                Console.WriteLine("Most of the company is dead now... Here's who is left:");
                numOfDead = comp.EmployeeCount() * 0.6;
            }
            for (int i = 0; i < numOfDead; i++) // killing
            {
                Employee unlucky = comp.GetRandomEmployee();
                if (unlucky.BossCount() == 0) // the unlucky is a manager
                {
                    comp.GetManagers().GetLast().SetNext(unlucky.GetSubordinates());
                    if (comp.GetManagers().GetValue() == unlucky)
                    {
                        comp.SetManagers(comp.GetManagers().GetNext());
                    }
                    else
                    {
                        Node<Employee> p1 = comp.GetManagers();
                        while (p1.GetNext().GetValue() != unlucky)
                        {
                            p1 = p1.GetNext();
                        }
                        p1.SetNext(p1.GetNext(2));
                    }
                }
                else
                {
                    unlucky.GetBoss().AddSubordinate(unlucky.GetSubordinates());
                    unlucky.GetBoss().RemoveSub(unlucky);
                }
            }
            Console.WriteLine();
            Console.WriteLine(comp);
        }
        public static int ShowMenu(Company comp)
        {
            Console.Clear();

            string[] main = new string[] { @" __  __       _         __  __", @"|  \/  |     (_)       |  \/  |", @"| \  / | __ _ _ _ __   | \  / | ___ _ __  _   _", @"| |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |", @"| |  | | (_| | | | | | | |  | |  __/ | | | |_| |", @"|_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|" };
            foreach(string line in main)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("0. Exit the program");
            Console.WriteLine("1. Create a new random company");
            Console.WriteLine("2. Create a new company manually");
            if (comp != null)
            {
                Console.WriteLine("3. Print the company");
                Console.WriteLine("4. Hire an employee");
                if (comp.GetManagers() != null)
                {
                    Console.WriteLine("5. Print an employee");
                    Console.WriteLine("6. Fire an employee");
                    Console.WriteLine("7. Print the top paid employee");
                    Console.WriteLine("8. Print the employees that are at the bottom of the hierarchy");
                    Console.WriteLine("9. Print the average salary in the company");
                    Console.WriteLine("10. Change someone's salary");
                    Console.WriteLine();
                    Console.WriteLine("11. Make the CEO go crazy  < NEW !!! >");
                    Console.WriteLine("12. Create a malicious virus  < NEW !!! >");
                }
            }
            int answer = int.Parse(Console.ReadLine());
            Console.Clear();
            return answer;
        }
        static void Main1(string[] args)
        {
            Company comp = RandomComp(3, 3);
            Console.WriteLine(comp);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            

        }
        public static void Main(string[] args)
        {
            Company comp = null;
            int answer = ShowMenu(comp);
            while (answer != 0)
            {
                switch (answer)
                {
                    case -1:
                        comp = TestingOnly();
                        break;
                    case 1:
                        comp = CreateRandomCompany();
                        break;
                    case 2:
                        comp = CreateCompany();
                        break;
                    case 3:
                        PrintCompany(comp);
                        break;
                    case 4:
                        Hire(comp);
                        break;
                    case 5:
                        PrintEmployee(comp);
                        break;
                    case 6:
                        Fire(comp);
                        break;
                    case 7:
                        TopPaid(comp);
                        break;
                    case 8:
                        BottomEmployee(comp);
                        break;
                    case 9:
                        AvgPay(comp);
                        break;
                    case 10:
                        ChangeSalary(comp);
                        break;
                    case 11:
                        Craziness(comp);
                        break;
                    case 12:
                        Plague(comp);
                        break;
                }
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey();
                Console.WriteLine();
                answer = ShowMenu(comp);
            }
        }
    }
}
