using System;

namespace BracketGenerate.InterfaceExample
{
    public class CEO : IWorker
    {
        public string Name => m_Name;
        private string m_Name;

        //"Non of your fucking business" 
        //Will show less then actually is :D
        public decimal Salary => m_Salary/50;
        private decimal m_Salary = 1000000m;

        //"I am always active biatch, i am CEO (actually I am on vacation, but you shoulndt care)";
        public bool Active => false;
        private bool m_Active;
        public CEO(string _name) 
        {
            m_Name = Name;
        }

        public void ChangeActiveStatus(bool _status)
        {
            m_Active = _status;
        }

        public void IncreaseSalary(decimal _addToSalary)
        {
            m_Salary = _addToSalary * 30;
        }

        public void DecreaseSalary(decimal _substractFromSalary)
        {
            //("I will rather fire you, then decrease my Salary");
        }
    }
}
