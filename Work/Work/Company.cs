using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class Company
    {
        public R ForEveryEmployee<T, R>(Del<T, R> foo, T par = default(T))
            // there is a sub function
        {
            // T - Parameter Class
            // R - returning class
            // foo - The custom function

            R result;
            Node<Employee> p2 = this.managers;
            while (p2 != null)
            {
                result = EverySub(p2.GetValue());
                if (!object.Equals(result, default(R)))
                {
                    return result;
                }
                p2 = p2.GetNext();
            }
            return default(R);

            R EverySub(Employee current)
            {
                result = foo(par, current);
                if (!object.Equals(result, default(R)))
                {
                    return result;
                }
                Node<Employee> p1 = current.GetSubordinates();
                while (p1 != null)
                {
                    result = EverySub(p1.GetValue());
                    if (!object.Equals(result, default(R)))
                    {
                        return result;
                    }
                    p1 = p1.GetNext();
                }
                return default(R);
            }
        }
        public void ForEveryEmployee(Del foo)
            // there is a sub function
        {
            // foo - the custom function

            Node<Employee> p2 = this.managers;
            while (p2 != null)
            {
                EverySub(p2.GetValue());
                p2 = p2.GetNext();
            }

            void EverySub(Employee current)
            {
                foo(current);
                Node<Employee> p1 = current.GetSubordinates();
                while (p1 != null)
                {
                    EverySub(p1.GetValue());
                    p1 = p1.GetNext();
                }
            }
        }
        public static Random rand = new Random();

        private string name;
        private double worth;
        private Node<Employee> managers;

        public Company(string name, double worth, Node<Employee> managers)
        {
            this.name = name;
            this.worth = worth;
            this.managers = managers;
        }
        public override string ToString()
        {
            string answer = $"Name: {this.name}\nWorth: {this.worth}\nManagers:";

            Node<Employee> p1 = this.managers;
            while (p1 != null)
            {
                answer += "\n\n" + p1.GetValue().ToString();
                p1 = p1.GetNext();
            }
            return answer;
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public double GetWorth()
        {
            return this.worth;
        }
        public void SetWorth(double worth)
        {
            this.worth = worth;
        }
        public Node<Employee> GetManagers()
        {
            return this.managers;
        }
        public void SetManagers(Node<Employee> managers)
        {
            this.managers = managers;
        }

        private double NextID = 0;
        public double GetNextID()
        {
            return this.NextID;
        }
        public double GenerateID()
        {
            NextID++;
            return NextID - 1;
        }

        public Employee FindEmployee(double id)
            // There is a sub function
        {
            Node<Employee> p2 = this.GetManagers();
            while (p2 != null)
            {
                if (FarSubordinate(p2.GetValue()) != null)
                {
                    return FarSubordinate(p2.GetValue());
                }
                p2 = p2.GetNext();
            }
            return null;

            Employee FarSubordinate(Employee current)
            {
                if (current.GetID() == id)
                {
                    return current;
                }
                Node<Employee> p1 = current.GetSubordinates();
                Employee emp1;
                while (p1 != null)
                {
                    emp1 = FarSubordinate(p1.GetValue());
                    if (emp1 != null)
                    {
                        return emp1;
                    }
                    p1 = p1.GetNext();
                }
                return null;
            }
        }
        public Node<Employee> FindEmployee(string name)
        {
            Node<Employee> rights = new Node<Employee>(null), p1 = rights;
            Del<object, object> addNames = delegate (object nothing, Employee emp1)
            {
                if (emp1.GetName() == name)
                {
                    p1.SetNext(new Node<Employee>(emp1));
                    p1 = p1.GetNext();
                }
                return null;
            };
            ForEveryEmployee<object, object>(addNames);
            return rights.GetNext();
        }
        public void SwitchBetween1(Employee emp1, Employee emp2)
            // There is a sub function
            // this is not functioning
        {
            Node<Employee> tempSubordinate;
            Node<Employee> tempNode;

            if (emp1.BossCount() <= emp2.BossCount())
            {
                tempSubordinate = emp2.GetSubordinates();
                tempNode = FindNode(emp2);

                emp2.SetSubordinates(null);
                FindNode(emp2).SetValue(null);

                FindNode(emp1).SetValue(emp2);
                emp2.SetSubordinates(emp1.GetSubordinates());

                emp1.SetSubordinates(tempSubordinate);
                tempNode.SetValue(emp1);
            }
            else
            {
                tempSubordinate = emp1.GetSubordinates();
                tempNode = FindNode(emp1);

                emp1.SetSubordinates(null);
                FindNode(emp1).SetValue(null);

                FindNode(emp2).SetValue(emp1);
                emp1.SetSubordinates(emp2.GetSubordinates());

                tempNode.SetValue(emp2);
                emp2.SetSubordinates(tempSubordinate);
            }

            Node<Employee> FindNode(Employee emp3)
            {
                Node<Employee> p1;
                if (emp3.IsManager())
                {
                    p1 = this.managers;
                }
                else
                {
                    p1 = emp3.GetBoss().GetSubordinates();
                }
                while (p1 != null)
                {
                    if (p1.GetValue() == emp3)
                    {
                        return p1;
                    }
                    p1 = p1.GetNext();
                }
                throw new Exception("Couldn't find the node");
            }
        }
        public void SwitchBetween(Employee emp1, Employee emp2)
        {
            Node<Employee> temp1 = emp1.GetNode(), temp2 = emp2.GetNode(), tempSub1 = emp1.GetSubordinates(), tempSub2 = emp2.GetSubordinates();
            emp1.SetSubordinates(null);
            emp2.SetSubordinates(null);
            temp1.SetValue(emp2);
            temp2.SetValue(emp1);
            emp1.SetSubordinates(tempSub2);
            emp2.SetSubordinates(tempSub1);
        }
        public int EmployeeCount()
            // There is a sub function
        {
            int counter = 0;
            Node<Employee> p2 = this.managers;
            while (p2 != null)
            {
                EmployeeCounter(p2.GetValue());
                p2 = p2.GetNext();
            }
            return counter;

            void EmployeeCounter(Employee current)
            {
                counter++;
                if (current.GetSubordinates() != null)
                {
                    Node<Employee> p1 = current.GetSubordinates();
                    while (p1 != null)
                    {
                        EmployeeCounter(p1.GetValue());
                        p1 = p1.GetNext();
                    }
                }
            }
        }
        public Node<Employee> GetLowestEmployees()
        {
            Node<Employee> lowestEmp = null;
            int maxNumOfBosses = -1;
            Del<object, object> updLowest = delegate (object nothing, Employee emp1)
            {
                int bosss = emp1.BossCount();

                if (bosss == maxNumOfBosses)
                {
                    lowestEmp.GetLast().SetNext(new Node<Employee>(emp1));
                    return null;
                }
                if (bosss > maxNumOfBosses)
                {
                    maxNumOfBosses = bosss;
                    lowestEmp = new Node<Employee>(emp1);
                }
                return null;
            };
            ForEveryEmployee<object, object>(updLowest);
            return lowestEmp;
        }
        public Employee GetRandomEmployee()
        {
            int i = rand.Next(EmployeeCount());
            Del<object, Employee> RandomEmp = delegate (object nothing, Employee emp1)
            {
                if (i == 0)
                {
                    return emp1;
                }
                i--;
                return null;
            };
            return ForEveryEmployee<object, Employee>(RandomEmp);
        }
        public void Beswitching()
        {
            Employee emp1, emp2;
            for (int i = EmployeeCount(); i > 0; i--)
            {
                emp1 = GetRandomEmployee();
                emp2 = GetRandomEmployee();
                if (emp1 != emp2)
                {
                    SwitchBetween(emp1, emp2);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
