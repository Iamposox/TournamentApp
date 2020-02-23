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
}
