namespace BracketGenerate.InterfaceExample
{
    public class SoftwareEngeneer : IWorker
    {
        public string Name =>m_Name;
        private string m_Name;

        public decimal Salary => m_Salary;
        private decimal m_Salary;

        //Because Software engeneer is always active
        public bool Active => true;

        public SoftwareEngeneer(string _name,decimal _salary)
        {
            m_Name = _name;
            m_Salary = _salary;
        }

        public void ChangeActiveStatus(bool _status)
        {
            throw new System.Exception("Software Engeneer is always active");
        }

        public void DecreaseSalary(decimal _substractFromSalary)
        {
            m_Salary = Salary - _substractFromSalary / 2;
        }

        public void IncreaseSalary(decimal _addToSalary)
        {
            m_Salary = Salary + _addToSalary * 2;
        }
    }
}
