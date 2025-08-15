using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace MauiBrownianMotion.Views.Controls
{
    public class BrownianMotionDrawable : IDrawable
    {
        #region Props
        public IList<double[]> SimulationResults { get; set; } = new List<double[]>();
        public Color[] LineColors { get; set; } = new Color[] { Colors.Red, Colors.Green, Colors.Blue, Colors.Orange, Colors.Purple };
        #endregion

        #region Methods
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (SimulationResults == null || !SimulationResults.Any())
                return;

            // Desenha os eixos
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 1;
            canvas.DrawLine(40, dirtyRect.Height - 40, dirtyRect.Width - 10, dirtyRect.Height - 40); // Eixo X
            canvas.DrawLine(40, 10, 40, dirtyRect.Height - 40); // Eixo Y

            double maxPrice = SimulationResults.Max(s => s.Max());
            double minPrice = SimulationResults.Min(s => s.Min());

            DrawReferenceLines(canvas, dirtyRect, maxPrice, minPrice);

            // Desenhar cada simulação
            for (int i = 0; i < SimulationResults.Count; i++)
            {
                var results = SimulationResults[i];
                var color = LineColors[i % LineColors.Length];

                canvas.StrokeColor = LineColors[i % LineColors.Length];
                canvas.StrokeSize = 2;

                var points = new PointF[results.Length];

                for (int j = 0; j < results.Length; j++)
                {
                    float x = 40 + (j * (dirtyRect.Width - 50) / (results.Length - 1));
                    float y = (float)(dirtyRect.Height - 40 
                        - ((results[j] - minPrice) / (maxPrice - minPrice)) * (dirtyRect.Height - 50)); 
                    points[j] = new PointF(x, y);
                }

                // Cria PathF a partir dos pontos
                var path = new PathF();
                if (points.Length > 0)
                {
                    path.MoveTo(points[0].X, points[0].Y);
                    for (int j = 1; j < points.Length; j++)
                    {
                        path.LineTo(points[j].X, points[j].Y);
                    }
                    canvas.DrawPath(path);
                }
            }
        }

        private void DrawReferenceLines(ICanvas canvas, RectF dirtyRect, double maxPrice, double minPrice)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
