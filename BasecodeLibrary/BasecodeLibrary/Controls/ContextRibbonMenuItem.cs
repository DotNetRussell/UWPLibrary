using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BasecodeLibrary.Controls
{
    public class ContextRibbonMenuItem : ControlContainer
    {
        public Symbol ButtonIcon
        {
            get { return (Symbol)GetValue(ButtonIconProperty); }
            set { SetValue(ButtonIconProperty, value); }
        }

        public static readonly DependencyProperty ButtonIconProperty =
            DependencyProperty.Register("ButtonIcon", typeof(Symbol), typeof(ContextRibbonMenuItem), new PropertyMetadata(Symbol.Stop));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(ContextRibbonMenuItem), new PropertyMetadata(string.Empty));

        public string ButtonToolTip
        {
            get { return (string)GetValue(ButtonToolTipProperty); }
            set { SetValue(ButtonToolTipProperty, value); }
        }

        public static readonly DependencyProperty ButtonToolTipProperty =
            DependencyProperty.Register("ButtonToolTip", typeof(string), typeof(ContextRibbonMenuItem), new PropertyMetadata(string.Empty));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ContextRibbonMenuItem), new PropertyMetadata(null));

        public ContextRibbonMenuItem()
        {
            DefaultStyleKey = typeof(ContextRibbonMenuItem);
        }
    }
}
