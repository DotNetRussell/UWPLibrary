using BasecodeLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace BasecodeLibrary.Controls
{
    /// <summary>
    /// This is a list control that has filter capabilities built in.
    /// </summary>
    public class FilterableContentList : ControlContainer, IList
    {
        private string _FilterText;

        /// <summary>
        /// The text that is being filtered for
        /// </summary>
        public string FilterText
        {
            get { return _FilterText; }
            set
            {
                _FilterText = value;

                if (_FilterText.Length > 0)
                {
                    string[] words = _FilterText.Split(new String[] { " " },
                        StringSplitOptions.RemoveEmptyEntries);

                    FilteredItems.Clear();

                    foreach (FilterableContentListItem item in ContentItems)
                    {
                        bool addItem = true;

                        foreach (string word in words)
                        {
                            string title = item.ContentTitle ?? String.Empty;
                            string desc = item.ContentShortDescription ?? string.Empty;
                            if (title.ToLower().Contains(word.ToLower()) ||
                                desc.ToLower().Contains(word.ToLower()) ||
                                (item.DataObject is IFilterableItem && (item.DataObject as IFilterableItem).IsFilterMatch(word)))
                            {
                                continue;
                            }
                            else
                            {
                                addItem = false;
                                break;
                            }
                        }

                        if (addItem)
                        {
                            FilteredItems.Add(item);
                        }
                    }
                }

                OnPropertyChanged("FilteredItems");
            }
        }

        /// <summary>
        /// Items that have been filtered
        /// </summary>
        public ObservableCollection<FilterableContentListItem> FilteredItems
        {
            get;
            private set;
        }

        /// <summary>
        /// All of the available items to filter
        /// </summary>
        public ObservableCollection<FilterableContentListItem> ContentItems
        {
            get { return (ObservableCollection<FilterableContentListItem>)GetValue(ContentItemsProperty); }
            set { SetValue(ContentItemsProperty, value); }
        }

        public static readonly DependencyProperty ContentItemsProperty =
            DependencyProperty.Register("ContentItems",
                typeof(ObservableCollection<FilterableContentListItem>), typeof(FilterableContentList),
                new PropertyMetadata(null, OnContentChanged));

        /// <summary>
        /// The selected item
        /// </summary>
        public FilterableContentListItem SelectedContentItem
        {
            get { return (FilterableContentListItem)GetValue(SelectedContentItemProperty); }
            set { SetValue(SelectedContentItemProperty, value); }
        }

        /// <summary>
        /// Returns the selected item's data object
        /// </summary>
        public object SelectedContentObject
        {
            get { return SelectedContentItem ?? SelectedContentItem.DataObject; }
        }

        /// <summary>
        /// Returns the selected item's content title
        /// </summary>
        public string SelectedContentTitle
        {
            get { return SelectedContentItem != null ? SelectedContentItem.ContentTitle : String.Empty; }
        }

        /// <summary>
        /// Returns the selected item's content short description
        /// </summary>
        public string SelectedContentShortDescription
        {
            get { return SelectedContentItem != null ? SelectedContentItem.ContentShortDescription : String.Empty; }
        }

        /// <summary>
        /// Returns the selected item's content details
        /// </summary>
        public string SelectedContentDescription
        {
            get { return SelectedContentItem != null ? SelectedContentItem.Details : String.Empty; }
        }

        /// <summary>
        /// Returns the selected item's image URL
        /// </summary>
        public Uri SelectedContentImageURL
        {
            get { return SelectedContentItem != null ? SelectedContentItem.ImageURI : null; }
        }

        /// <summary>
        /// Returns the selected item's image dimensions  
        /// </summary>
        public Point SelectedContentImageDimensions
        {
            get { return SelectedContentItem != null ? SelectedContentItem.ImageDimensions : new Point(); }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the count of all items
        /// </summary>
        public int Count
        {
            get
            {
                return ContentItems.Count();
            }
        }

        /// <summary>
        /// Returns the count of the filtered items
        /// </summary>
        public int FilteredCount
        {
            get
            {
                return FilteredItems.Count();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Retrieve the data object from the filtered list at the passed in index
        /// </summary>
        /// <param name="index">The index of the object you wish to retreive</param>
        /// <returns>The data object of the item at the index passed in</returns>
        public object this[int index]
        {
            get
            {
                return FilteredItems[index].DataObject;
            }

            set
            {
                FilteredItems[index].DataObject = value;
            }
        }

        public static readonly DependencyProperty SelectedContentObjectProperty =
            DependencyProperty.Register("SelectedContentObject",
                typeof(object), typeof(FilterableContentList), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedContentItemProperty =
            DependencyProperty.Register("SelectedContentItem",
                typeof(FilterableContentListItem), typeof(FilterableContentList),
                new PropertyMetadata(new FilterableContentListItem(), OnSelectedItemChanged));

        /// <summary>
        /// Basic constructor
        /// </summary>
        public FilterableContentList()
        {
            DefaultStyleKey = typeof(FilterableContentList);
        }

        private static void OnContentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            FilterableContentList list = (FilterableContentList)obj;
            if (list.FilteredItems == null)
            {
                list.ContentItems.CollectionChanged += (s, a) =>
                {
                    if (a.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                    {
                        foreach (FilterableContentListItem item in a.NewItems)
                        {
                            list.FilteredItems.Add(item);
                        }
                    }
                    else if(a.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
                    {
                        list.FilteredItems.Clear();
                    }
                    list.OnPropertyChanged("FilteredItems");
                };
                if (list.ContentItems.Count != 0)
                {
                    list.FilteredItems = new ObservableCollection<FilterableContentListItem>(list.ContentItems);
                }
                else
                {
                    list.FilteredItems = new ObservableCollection<FilterableContentListItem>();
                }
            }
        }

        private static void OnSelectedItemChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            FilterableContentList list = (FilterableContentList)obj;
            if (list != null)
            {
                list.OnPropertyChanged("SelectedContentObject");
                list.OnPropertyChanged("SelectedContentTitle");
                list.OnPropertyChanged("SelectedCotnentShortDescription");
                list.OnPropertyChanged("SelectedContentDescription");
                list.OnPropertyChanged("SelectedContentImageURL");
                list.OnPropertyChanged("SelectedContentimageDimensions");
            }
        }

        /// <summary>
        /// Add a new item to the available filterable items
        /// </summary>
        /// <param name="ContentTitle">Title of the content item</param>
        /// <param name="shortDescription">Short description of the content item</param>
        /// <param name="description">Details of content item</param>
        /// <param name="DataObject">The data object being represented</param>
        /// <param name="imageUrl">Image URL</param>
        /// <param name="imageDimensions">Dimensions of the image</param>
        /// <returns>Returns total content items count</returns>
        public int Add(string ContentTitle, string shortDescription = "", string description = "",
            object DataObject = null, Uri imageUrl = null, Point imageDimensions = new Point())
        {
            FilterableContentListItem item = new FilterableContentListItem()
            {
                ContentTitle = ContentTitle,
                ContentShortDescription = shortDescription,
                Details = description,
                DataObject = DataObject,
                ImageURI = imageUrl,
                ImageDimensions = imageDimensions
            };

            if (ContentItems == null)
            {
                ContentItems = new ObservableCollection<FilterableContentListItem>();
                FilteredItems = new ObservableCollection<FilterableContentListItem>(ContentItems);
            }
            ContentItems.Add(item);

            return ContentItems.Count;
        }

        /// <summary>
        /// Clear the collection
        /// </summary>
        public void Clear()
        {
            if (ContentItems != null && FilteredItems != null)
            {
                ContentItems.Clear();
                FilteredItems.Clear();
            }
        }

        /// <summary>
        /// Check to see if the object passed in matches any of the data object
        /// </summary>
        /// <param name="value">Data object you wish to search for</param>
        /// <returns>Returns true if list contains a matching data object</returns>
        public bool Contains(object value)
        {
            bool containsItem = false;
            foreach (FilterableContentListItem item in ContentItems)
            {
                if (item.DataObject.Equals(value))
                {
                    containsItem = true;
                    break;
                }
            }           
            return containsItem;
        }

        /// <summary>
        /// Checks for the index of the data object passed in
        /// </summary>
        /// <param name="value">Data object being searched for</param>
        /// <returns>Returns the index of the item in the filtered list. If it doesn't exist it returns -1</returns>
        public int IndexOf(object value)
        {
            int index = -1;
            for (int x = 0; x < FilteredItems.Count; x++)
            {
                if (FilteredItems[x].DataObject.Equals(value))
                {
                    index = x;
                    break;
                }
            }
            return index;
        }


        /// <summary>
        /// Removes the data object from the filtered items
        /// </summary>
        /// <param name="value">Data object to be removed</param>
        public void Remove(object value)
        {
            bool wasRemoved = false;
            foreach (FilterableContentListItem item in FilteredItems.ToArray())
            {
                if (item.DataObject.Equals(value))
                {
                    FilteredItems.Remove(item);
                    wasRemoved = true;
                    break;
                }
            }
            if (!wasRemoved)
            {
                Debug.WriteLine("BasecodeLib warning: Cannot remove item. Doesn't exist in the collection.");
            }
        }

        /// <summary>
        /// Remove the element from the filtered items at the index passed in
        /// </summary>
        /// <param name="index">Index to be removed</param>
        public void RemoveAt(int index)
        {
            if (index <= FilteredItems.Count - 1)
            {
                FilteredItems.RemoveAt(index);
            }
            else
            {
                Debug.WriteLine("BasecodeLib warning: Cannot remove item at index " + index + ". Outside the bounds of the collection.");
            }
        }


        /// <summary>
        /// Get's an enumerator for all of the available items
        /// </summary>
        /// <returns>ContentItems enumerator</returns>
        public IEnumerator GetEnumerator()
        {
            return ContentItems.GetEnumerator();
        }

        /// <summary>
        /// Get's an enumerator for the filtered items
        /// </summary>
        /// <returns>FilteredItems enumerator</returns>
        public IEnumerator GetFilteredEnumerator()
        {
            return FilteredItems.GetEnumerator();
        }

        [Obsolete]
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public bool IsFixedSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
