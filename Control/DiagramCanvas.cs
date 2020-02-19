using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tournaments.WPF.Model;

namespace Tournaments.WPF.Control
{
    public class DiagramCanvas : Canvas
    {
        public CanvasField GridLayout
        {
            get { return (CanvasField)GetValue(GridLayoutProperty); }
            set 
            { 
                SetValue(GridLayoutProperty, value);
                GenerateField();
            }
        }

        public static readonly DependencyProperty GridLayoutProperty =
            DependencyProperty.Register(
                "GridLayout", 
                typeof(CanvasField), 
                typeof(DiagramCanvas), 
                new PropertyMetadata(null, GridLayoutPropertyChanged));


        private static void GridLayoutPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DiagramCanvas target = (DiagramCanvas)d;
            target.GridLayoutPropertyChanged(target.GridLayout);
        }
        private void GridLayoutPropertyChanged(CanvasField date)
        {
            GridLayout = date;
        }

        private void GenerateField()
        {
            if (GridLayout is null) return;
            Cell cell = GridLayout.Field[0, 0];
            for (int x = 0; x < GridLayout.Field.GetLength(0); x++)
            {
                for (int y = 0; y < GridLayout.Field.GetLength(1); y++)
                {
                    var temp = new Border();
                    temp.Width= cell.Width;
                    temp.Height=cell.Height;
                    temp.BorderThickness =new Thickness(1);
                    temp.BorderBrush = Brushes.Gray;
                    SetTop(temp, (cell.Height * y )+10);
                    SetLeft(temp, (cell.Width * x) + 10);
                    Children.Add(temp);
                }
            }
            Width = GridLayout.Field.GetLength(0) * 300 + 50;
            Height = GridLayout.Field.GetLength(1) * 50 + 50;
        }
    }
}
