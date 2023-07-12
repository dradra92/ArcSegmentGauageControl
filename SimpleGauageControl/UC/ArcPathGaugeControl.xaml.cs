using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

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
        private double? strokeThickness;

        /// <summary>
        /// x축 방향, Y축 방향 반지름
        /// </summary>
        private Point? radious;

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

            DrawGaugae();
        }

        private void DrawGaugae()
        {

        }

        public void StorkeThickness(double value)
        {
            this.strokeThickness = value;
        }

        public void Radious(int xRadious, int yRadious)
        {
            this.radious = new Point(xRadious, yRadious);
        }

        public void ProgressBrushColor (Brush color)
        {
            progressBrushColor = color;
        }

        public void BackgroundColor(Brush color)
        {
            backgroundColor = color;
        }

        public void NoneProgressBrushColor(Brush color) { 
            noneProgressBrushColor = color;
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
        }

        public void ProgressValue(double value)
        {
            if (value < 0.0)  this.progressValue = 0.0;
            else if (value > 100.0)  this.progressValue = 100.0;
            else  this.progressValue = value;
            
            ProgressText.Text = value + "%";

            DrawGaugae();
        }
    }
}
