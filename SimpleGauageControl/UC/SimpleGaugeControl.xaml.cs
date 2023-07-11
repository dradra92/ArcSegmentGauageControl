using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace SimpleGauageControl.UC
{
    /// <summary>
    /// SimpleGaugeControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SimpleGaugeControl : UserControl
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
        /// 진행률
        /// </summary>
        public double progressValue = 0.0;

        /// <summary>
        /// 
        /// </summary>
        public SimpleGaugeControl()
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
    }
}
