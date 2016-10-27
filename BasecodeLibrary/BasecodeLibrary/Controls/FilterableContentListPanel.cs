using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BasecodeLibrary.Controls
{
    public class FilterableContentListPanel : FilterableContentList
    {
        /// <summary>
        /// Set the list collapsed 
        /// </summary>
        public bool IsCollapsed { get; private set; }

        #region Template Parts

        private Grid partListGrid { get; set; }
        private TextBox partFilterTextBox { get; set; }
        private ListBox partFilteredListBox { get; set; }
        private Button partExpanderButton { get; set; }

        #endregion

        public FilterableContentListPanel()
        {
            DefaultStyleKey = typeof(FilterableContentListPanel);
        }

        protected override void OnApplyTemplate()
        {
            partListGrid = GetTemplateChild("PART_ListGrid") as Grid;
            partExpanderButton = GetTemplateChild("PART_ExpanderButton") as Button;
            partFilterTextBox = GetTemplateChild("PART_FilterTextBox") as TextBox;
            partFilteredListBox = GetTemplateChild("PART_FilteredListBox") as ListBox;

            if (partExpanderButton != null &&
              partListGrid != null &&
              partFilterTextBox != null &&
              partFilteredListBox != null)
            {
                partExpanderButton.Click += (s, a) =>
                {
                    if (!IsCollapsed)
                    {
                        partFilteredListBox.Visibility = Visibility.Collapsed;
                        partFilterTextBox.Visibility = Visibility.Collapsed;
                        partListGrid.Width = 40;
                        IsCollapsed = true;
                    }
                    else
                    {
                        partListGrid.Width = 300;
                        partFilteredListBox.Visibility = Visibility.Visible;
                        partFilterTextBox.Visibility = Visibility.Visible;
                        IsCollapsed = false;
                    }
                };
            }

            base.OnApplyTemplate();
        }
    }
}
