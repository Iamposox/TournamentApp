using System;
using System.ComponentModel;
using System.Linq;
using TournamentBracketGenerator.Model;
using System.Threading.Tasks;

namespace Tournaments.WPF.Model
{
    public class CanvasField : Abstract.BaseViewModel
    {
        public Cell[,] Field { get; set; } 

        public CanvasField(int _xElements, int _yElements)
        {
            Field = new Cell[_xElements, _yElements];
            for (int x = 0; x < Field.GetLength(0); x++)
            {
                for (int y = 0; y < Field.GetLength(1); y++)
                {
                    Field[x, y] = new Cell();
                }
            }
        }
    }

    public class Cell : Abstract.BaseViewModel
    {
        public double Height { get; set; } = 50;
        public double Width { get; set; } = 300;
    }

    /// <summary>
    /// Should be moved to domain layer and replayed with a Participant_Wrapper class
    /// </summary>
    public class Participant_Wrapper : Abstract.BaseViewModel
    {
        public Participant_Wrapper(Participant _participant,int _id)
        {
            Model = _participant;
            Possition_X = 20;
            Possition_Y = (_id * 100);
        }

        public Participant_Wrapper(Participant _participant, int _x, int _y)
        {
            Model = _participant;
            Possition_X = _x;
            Possition_Y = _y;
        }

        public int Possition_X { get; set; }
        public int Possition_Y { get; set; }

        /// <summary>
        /// For addictional control, having ID is making some operation easier
        /// </summary>
        public Guid Guid { get; set; }
        public Participant Model { get; set; }


        public string Patronymic 
        { 
            get =>Model.Patronymic; 
            set
            {
                Model.Patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public string Name 
        { 
            get => Model.Name; 
            set
            {
                Model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string LastName 
        { 
            get=>Model.LastName;
            set
            {
                Model.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        
        
        public string FullName { get; set; }
        public int ID { get; set; }
        public short Weight { get; set; }

    }
}
