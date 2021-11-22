using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplePenNote
{
    /// <summary>
    /// NoteControl.xaml 的交互逻辑
    /// </summary>
    public partial class NoteControl : UserControl
    {

        public event EventHandler<EventArgs> RightButtonPressed;
        public event EventHandler<EventArgs> SizeAvailable;
        private bool _stylusIn = false;
        public bool IsStylusIn
        {
            get {
                return _stylusIn;
            }
            set { 
                _stylusIn = value;
            }
        }

        public NoteControl()
        {
            InitializeComponent();
            this.InkCanvas = canv;
           
        }

        public InkCanvas InkCanvas { get; private set; }
        public InkCanvasEditingMode EditingMode { get; internal set; } = InkCanvasEditingMode.Ink;
        public InkCanvasEditingMode EditingModeInverted { get; internal set; } = InkCanvasEditingMode.EraseByStroke;

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            canv.EditingMode = InkCanvasEditingMode.None;
            canv.EditingModeInverted = InkCanvasEditingMode.None;
        }


        InkCanvasEditingMode prevMode = InkCanvasEditingMode.Ink;
        private void canv_TouchDown(object sender, TouchEventArgs e)
        {
            prevMode = canv.EditingMode;
            e.Handled = true;
            canv.EditingMode = InkCanvasEditingMode.None;
            canv.EditingModeInverted = InkCanvasEditingMode.None;
        }

        private void canv_TouchMove(object sender, TouchEventArgs e)
        {
            e.Handled= true;
            canv.EditingMode = InkCanvasEditingMode.None;
            canv.EditingModeInverted = InkCanvasEditingMode.None;
        }

        private void canv_TouchUp(object sender, TouchEventArgs e)
        {
            canv.EditingMode = prevMode;
            e.Handled = true;
            canv.EditingMode = InkCanvasEditingMode.None;
            canv.EditingModeInverted = InkCanvasEditingMode.None;
        }

        private void canv_StylusEnter(object sender, StylusEventArgs e)
        {

        }

        private void canv_StylusLeave(object sender, StylusEventArgs e)
        {
            IsStylusIn = false;
        }

        private void canv_StylusOutOfRange(object sender, StylusEventArgs e)
        {
            if(canv.ActiveEditingMode == InkCanvasEditingMode.Select)
            {
                return;
            }
            canv.EditingMode = InkCanvasEditingMode.None;
            canv.EditingModeInverted = InkCanvasEditingMode.None;
            IsStylusIn = false;
        }

        private void canv_StylusInRange(object sender, StylusEventArgs e)
        {

            canv.EditingMode = EditingMode;
            canv.EditingModeInverted = EditingModeInverted;
            
        }

        private void canv_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {

        }

        Guid STYLUS_BUTTON_RIGHT = Guid.Parse("f0720328-663b-418f-85a6-9531ae3ecdfa");

        private void canv_StylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            
        }

        private void canv_StylusButtonUp(object sender, StylusButtonEventArgs e)
        {
            if (e.StylusButton.Guid == STYLUS_BUTTON_RIGHT)
            {
                e.Handled = true;
                RightButtonPressed?.Invoke(this, EventArgs.Empty);
            }
        }

        private void canv_StylusDown(object sender, StylusDownEventArgs e)
        {
            IsStylusIn = true;
        }

        private void canv_StylusUp(object sender, StylusEventArgs e)
        {
            IsStylusIn = false;
        }

        public bool StrokesChanged()
        {
            return strokesChanged;
        }
        private bool strokesChanged = false;
        private void canv_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            strokesChanged = true;
        }

        internal void ClearStrokeChanged()
        {
            strokesChanged = false;
        }

        internal void NotifyStrokesChanged()
        {
            strokesChanged = true;
        }

        private void canv_StrokeErased(object sender, RoutedEventArgs e)
        {
            strokesChanged = true;
        }

        private void canv_SelectionMoved(object sender, EventArgs e)
        {
            strokesChanged = true;
        }

        private void canv_SelectionResized(object sender, EventArgs e)
        {
            strokesChanged = true;
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SizeAvailable?.Invoke(this, e);
        }
    }
}
