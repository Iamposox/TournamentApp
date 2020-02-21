using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.InterfaceExample
{
    public interface IWorker
    {
        string Name { get; }
        decimal Salary { get; }
        bool Active { get; }
        void ChangeActiveStatus(bool _status);
        void IncreaseSalary(decimal _addToSalary);
        void DecreaseSalary(decimal _substractFromSalary);
    }
}
