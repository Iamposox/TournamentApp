namespace BracketGenerate.InterfaceExample
{
    public class OfficePlancton : IWorker
    {
        public string Name => m_Name;
        private string m_Name;

        public decimal Salary => m_Salary;
        private decimal m_Salary;

        public bool Active => m_Active;
        private bool m_Active;

        public OfficePlancton(string _name,decimal _salary, bool _active)
        {
            m_Active = _active;
            m_Name = _name;
            m_Salary = _salary;
        } 

        public void ChangeActiveStatus(bool _status)
        {
            if (!_status) DecreaseSalary(200m);
            m_Active = _status;
        }

        public void DecreaseSalary(decimal _substractFromSalary)
        {
            m_Salary =- _substractFromSalary;
        }

        public void IncreaseSalary(decimal _addToSalary)
        {
            m_Salary = +_addToSalary;
        }
    }
}
