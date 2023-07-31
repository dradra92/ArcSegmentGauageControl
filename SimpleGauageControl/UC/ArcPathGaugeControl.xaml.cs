using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace SimpleGauageControl.UC
{
    /// <summary>
    /// SimpleGaugeControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ArcPathGaugeControl : UserControl
    {
        /// <summary>
        /// 두께
        /// </summary>
        private double strokeThickness = 40.0;

        /// <summary>
        /// x축 방향, Y축 방향 반지름
        /// </summary>
        private Size? radious;

        /// <summary>
        /// 진행률을 표시하는 방향의 color
        /// </summary>
        private Brush? progressBrushColor;

        /// <summary>
        /// 컨트롤 배경 색
        /// </summary>
        private Brush? backgroundColor;

        /// <summary>
        /// Progress에서 비어 있는 부분의 color
        /// </summary>
        private Brush? noneProgressBrushColor;

        /// <summary>
        /// Gauge 표시 삼각형 Color
        /// </summary>
        private Brush? gaugeNeedleColor;

        /// <summary>
        /// Gauge 표시 삼각형 너비
        /// </summary>
        private int gaugeNeedleWidth;

        /// <summary>
        /// Gauge 표시 삼각형 높이
        /// </summary>
        private int gaugeNeedleHeight;

        private double progressStartPointX;

        private double progressStartPointY;

        private double progressEndPointX;

        private double progressEndPointY;

        /// <summary>
        /// 진행률
        /// </summary>
        private double progressValue = 0.0;

        /// <summary>
        /// 
        /// </summary>
        public ArcPathGaugeControl()
        {
            InitializeComponent();

            SetInitValue();

            //DrawGaugae();
        }


        private void SetInitValue()
        {
            


        }

        private void DrawGaugae()
        {
            CalculatePoint();

            ProgressArcSegment.Point   = new Point(progressEndPointX, progressEndPointY);
            EmptyPathFigure.StartPoint = new Point(progressEndPointX, progressEndPointY);
        }

        private void CalculatePoint()
        {
            progressStartPointX = ProgressPathFigure.StartPoint.X;
            progressStartPointY = ProgressPathFigure.StartPoint.Y;

            progressEndPointX = ProgressArcSegment.Point.X;
            progressEndPointY = ProgressArcSegment.Point.Y;

            double xRadius = ProgressArcSegment.Size.Width;
            double yRadius = ProgressArcSegment.Size.Height;

            // Calulate radian
            double rad = progressValue * Math.PI / 100;


            // Progress En Point Calculate;
            progressEndPointX = progressStartPointX + xRadius - (xRadius * Math.Cos(rad));
            progressEndPointY = progressStartPointY - (yRadius * Math.Sin(rad));
        }

        public void StorkeThickness(double value)
        {
            this.strokeThickness = value;

            ProgressPath.StrokeThickness = value;
            EmptyPath.StrokeThickness = value;

        }

        public void Radious(double xRadious, double yRadious)
        {
            this.radious = new Size(xRadious, yRadious);

            ProgressArcSegment.Size = (Size)radious;
            EmptyArcSegment.Size = (Size)radious;
        }

        public void ProgressBrushColor (Brush color)
        {
            progressBrushColor = color;

            ProgressPath.Stroke = color;
        }

        public void BackgroundColor(Brush color)
        {
            backgroundColor = color;

            LocalControl.Background = color;
        }

        public void NoneProgressBrushColor(Brush color) { 
            noneProgressBrushColor = color;

            EmptyPath.Stroke = color;
        }

        public void GaugeNeedleWidth(int w)
        {
            this.gaugeNeedleWidth = w;
        }

        public void GaugeNeedleHeight(int h)
        {
            this.gaugeNeedleHeight = h;
        }

        public void GaugeNeedleColor (Brush color)
        {
            this.gaugeNeedleColor = color;

            NeedlePath.Stroke = color;
        }

        public void ProgressValue(double value)
        {
            if (value < 0.0)  this.progressValue = 0.0;
            else if (value > 100.0)  this.progressValue = 100.0;
            else  this.progressValue = value;
            
            ProgressText.Text = value + "%";
        }

        private void Progress_Text_Changed(object sender, TextChangedEventArgs e)
        {
            DrawGaugae();
        }
    }
}
