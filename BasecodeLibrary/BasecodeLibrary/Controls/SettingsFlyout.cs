using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using static BasecodeLibrary.Enums.BasecodeEnums;

namespace BasecodeLibrary.Controls
{
    [ContentProperty(Name = "Items")]
    public class SettingsFlyout : Flyout
    {
        public List<SettingItem> Items
        {
            get { return (List<SettingItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(List<SettingItem>), typeof(SettingsFlyout), new PropertyMetadata(new List<SettingItem>()));

        //public List<Button> Buttons
        //{
        //    get { return (List<Button>)GetValue(ButtonsProperty); }
        //    set { SetValue(ButtonsProperty, value); }
        //}

        //public static readonly DependencyProperty ButtonsProperty =
        //    DependencyProperty.RegisterAttached("Buttons", typeof(List<Button>), typeof(SettingsFlyout), new PropertyMetadata(null));
        
        public SettingsFlyout()
        {
            this.Opening += GenerateSettingsMenu;
        }

        private void GenerateSettingsMenu(object sender, object e)
        {
            BuildSettingsMenu();
        }

        // I'm going to preface this with, this is ghetto as shit....
        // Unfortunetely I can't create a lookless control if I subclass flyout because DefaultStyleKey isn't available.
        // This means that if I created a flyout from scratch, I wouldn't be able to use it in Button.Flyout because we 
        // wouldn't be implementing IFlyout (Which is an internal interface... thanks MS)
        // So, the only alternative here is to manually generate the UI and jam it into the flyout control's content.
        private void BuildSettingsMenu()
        {
            if (Items != null)
            {
                StackPanel container = new StackPanel();
                container.Orientation = Orientation.Vertical;
                foreach (SettingItem item in Items)
                {
                    Grid innerContainer = new Grid();
                    innerContainer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(.5,GridUnitType.Star) });
                    innerContainer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(.5, GridUnitType.Star) });

                    TextBlock label = new TextBlock() { Text = item.Label };
                    label.Width = 200;
                    label.TextWrapping = TextWrapping.Wrap;
                    Grid.SetColumn(label, 0);

                    innerContainer.Children.Add(label);

                    switch (item.SettingType)
                    {
                        case (SettingsType._int):
                        case (SettingsType._double):
                        case (SettingsType._string):
                            TextBox input = new TextBox();
                            Binding dataBinding = new Binding();
                            dataBinding.Mode = BindingMode.TwoWay;
                            dataBinding.Path = new PropertyPath(item.BindingPath);
                            input.SetBinding(TextBox.TextProperty, dataBinding);
                            Grid.SetColumn(input, 1);
                            innerContainer.Children.Add(input);
                            break;
                        case (SettingsType._bool):
                            CheckBox checkBox = new CheckBox();
                            Binding checkboxBinding = new Binding();
                            checkboxBinding.Mode = BindingMode.TwoWay;
                            checkboxBinding.Path = new PropertyPath(item.BindingPath);
                            checkBox.SetBinding(CheckBox.IsCheckedProperty, checkboxBinding);
                            Grid.SetColumn(checkBox, 1);
                            innerContainer.Children.Add(checkBox);
                            break;
                        default:
                            TextBox defaultInput = new TextBox();
                            Binding defaultBinding = new Binding();
                            defaultBinding.Mode = BindingMode.TwoWay;
                            defaultBinding.Path = new PropertyPath(item.BindingPath);
                            defaultInput.SetBinding(TextBox.TextProperty, defaultBinding);
                            Grid.SetColumn(defaultInput, 1);
                            innerContainer.Children.Add(defaultInput);
                            break;
                    }
                    container.Children.Add(innerContainer);
                }

                //if(Buttons != null)
                //{
                //    StackPanel buttonsContainer = new StackPanel();
                //    foreach (Button button in Buttons)
                //    {
                //        buttonsContainer.Children.Add(button);
                //    }
                //    container.Children.Add(buttonsContainer);
                //}

                this.Content = container;
            }
        }
    }
}
