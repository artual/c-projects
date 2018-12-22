using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class Employee
    {
        private string name;
        private double id;
        private double salary;
        private Node<Employee> subordinates;
        private Company company;
        
        public Employee(string name, double id, double salary, Company company)
        {
            this.name = name;
            this.id = id;
            this.salary = salary;
            this.company = company;
        }
        public Employee(string name, double id, double salary, Node<Employee> subordinates, Company company)
        {
            this.name = name;
            this.id = id;
            this.salary = salary;
            this.subordinates = subordinates;
            this.company = company;
        }
        public override string ToString()
        {
            string answer = $"Name: {this.name}\nID: {this.id}\nSalary: {this.salary}\nCompany: {this.company.GetName()}";
            
            if (this.subordinates != null)
            {
                Node<Employee> p1 = this.subordinates;
                while (p1 != null)
                {
                    answer += "\n\n" + Tool.PadParagraph(p1.GetValue().ToString(), 6);

                    p1 = p1.GetNext();
                }
            }
            return answer;
        }
        public string ToStringWithoutSubs()
        {
            string answer = $"Name: {this.name}\nID: {this.id}\nSalary: {this.salary}\nCompany: {this.company.GetName()}";
            return answer;
        }

        public string GetName()
        {
            return this.name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public double GetID()
        {
            return this.id;
        }
        public void SetID(double id)
        {
            this.id = id;
        }
        public double GetSalary()
        {
            return this.salary;
        }
        public void SetSalary(double salary)
        {
            if (salary < 0)
            {
                throw new Exception($"Tried to have a salary smaller than 0 for {this.name}");
            }
            this.salary = salary;
        }
        public Node<Employee> GetSubordinates()
        {
            return this.subordinates;
        }
        public void SetSubordinates(Node<Employee> subordinates)
        {
            this.subordinates = subordinates;
        }
        public Company GetCompany()
        {
            return this.company;
        }
        public void SetCompany(Company comp)
        {
            this.company = comp;
        }

        public bool IsSubordinateOf(Employee emp1)
        {
            Node<Employee> p1 = emp1.GetSubordinates();
            while (p1 != null)
            {
                if (p1.GetValue() == this)
                {
                    return true;
                }
                p1 = p1.GetNext();
            }
            return false;
        }
        public void AddSubordinate(Node<Employee> subs)
        {
            if (this.subordinates == null)
            {
                this.subordinates = subs;
            }
            else
            {
                this.subordinates.GetLast().SetNext(subs);
            }
        }
        public Employee GetBoss1()
            // There is a sub function
        {
            Node<Employee> p2 = this.company.GetManagers();
            while (p2 != null)
            {
                if (ReturnBoss(p2.GetValue(), this) != null)
                {
                    return ReturnBoss(p2.GetValue(), this);
                }
                p2 = p2.GetNext();
            }

            return null; // tried to find unknown boss
            throw new Exception($"Tried to find unknown boss of {this.id}");

            Employee ReturnBoss(Employee current, Employee target)
            {
                if (target.IsSubordinateOf(current))
                {
                    return current;
                }

                Node<Employee> p1 = current.GetSubordinates();
                while (p1 != null)
                {
                    if (ReturnBoss(p1.GetValue(), target) != null)
                    {
                        return ReturnBoss(p1.GetValue(), target);
                    }
                    p1 = p1.GetNext();
                }
                return null;
            }
        }
        public Employee GetBoss()
        {
            Del<object, Employee> boss = delegate (object nothing, Employee emp1)
            {
                if (this.IsSubordinateOf(emp1))
                {
                    return emp1;
                }
                return null;
            };
            return this.company.ForEveryEmployee<object, Employee>(boss); // if returning null, tried to get unknown boss
        }
        public int BossCount()
        {
            int counter = 0;

            Employee emp1 = this.GetBoss();
            while (emp1 != null)
            {
                counter++;
                emp1 = emp1.GetBoss();
            }
            return counter;
        }
        public void RemoveSub(Employee unlucky)
        {
            if (unlucky == subordinates.GetValue())
            {
                subordinates = subordinates.GetNext();
            }
            else
            {
                Node<Employee> p1 = subordinates;
                while (p1.GetNext().GetValue() != unlucky)
                {
                    p1 = p1.GetNext();
                }
                p1.SetNext(p1.GetNext(2));
            }
        }
        public bool IsManager()
        {
            Node<Employee> managers = this.company.GetManagers();
            while (managers != null)
            {
                if (managers.GetValue() == this)
                {
                    return true;
                }
                managers = managers.GetNext();
            }
            return false;
        }
        public Node<Employee> GetNode()
        {
            Node<Employee> p1;
            if (IsManager())
            {
                p1 = company.GetManagers();
            }
            else
            {
                p1 = GetBoss().GetSubordinates();
            }
            while (p1 != null && p1.GetValue() != this)
            {
                p1 = p1.GetNext();
            }
            return p1;
        }
    }
}
