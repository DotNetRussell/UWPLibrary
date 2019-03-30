#UWPLibrary - BasecodeLibrary
UWP Controls that I've written and open sourced.

This library has a ton of useful UWP controls and utilities. Almost all of the controls are lookless, meaning if you don't like how they look then you can easily restyle them without losing functionality!


<h3>Controls</h3>

All of these controls support both desktop and mobile platforms naitively currently. 

<ul>
  <li><b>BaseCodePageContainer</b> - BaseCodePageContainer is used as a hook into the application to help support other BaseCodeLibrary Controls </li>
  <li><b>ControlContainer</b> - This class is the main BaseCodeLibrary control container. It enables it's contents to play nice with the rest of basecode library. It's not required but useful</li>
  <li><b>FeedbackPopup</b> - The FeedbackPopup provides an easy way to prompt the user for feedback. You can customize the title and content of the popup without restyling</li>
  <li><b>FilterableContentList</b> - This is a list control that has filter capabilities built in.</li>
  <li><b>FilterableContentListItem</b> - The root list item for FilterableContentList</li>
  <li><b>FilterableContentListPanel</b> - This expands on the FilterableContenList. It turns it into a panel that can be docked</li>
  <li><b>FilterableImageWrapGrid</b> - (<a target="_blank" href="http://i.imgur.com/q4K8IS3.mp4">demo here</a>) Turns the FilterableContentList into an image wrap grid that has filtering capabilities</li>
  <li><b>PopupBase</b> - This is the base popup control. This is a great starting point to create your own popups</li>
  <li><b>SettingsFlyout</b> - A flyout control specifically designed for the fast creation of bindable settings menus. </li>
  <li><b>SettingItem</b> - A settings element intended to be used inside the settings flyout menu. </li>
  <li><b>SettingItemSelector</b> - A settings element intended to be used inside the settings flyout menu that displays a combobox</li>
  <li><b>RateReminder</b> - (<a target="_blank" href="http://i.imgur.com/is0qNFa.mp4">demo here</a>) Prompts the user to review the application or email you. It has cusom title and content capabilties</li>
  <li><b>YouTubeVideoPlayer</b> - (<a target="_blank" href="http://i.imgur.com/EvHpw1a.mp4">demo here</a>) This UWP video player is made specifically to support youtube videos. It's current version supports full screen video</li> 
  <li><b>ContextRibbon</b> - This is a simple UWP Ribbon control. It will create  a horizontal row of ribbon items or ribbon menus</li>
  <li><b>ContextRibbonItem</b> - A simple context ribbon button. Able to set the tooltip, icon and text as well as the command binding</li>
  <li><b>ContextRibbonMenu</b> - A drop down of ContextRibbonMenuItem buttons</li>
  <li><b>ContextRibbonMenuItem</b> - The button that goes inside the ContextRibbonMenu</li>
</ul>


<h3>Utilities</h3>

<ul>
  <li><b>ApplicationServices</b>
      <ul>
        <li>Get the current device type - Mobile, Desktop, Phablet</li>
        <li>Add/Get/Contains item to application cache</li>
      </ul>
  <li><b>BasecodeRequestManager</b> - Runs async Http requests</li>
  <li><b>SaveManager</b> - Handles System File I/O for the application
      <ul>
      <li>Save/Get/Exists Object in storage</li>
      </ul>
  </li>
  <li><b>ViewModelBase</b> - A base class for viewmodels with INotifyPropertyChanged implemented</li>
  <li><b>ModelBase</b> - A base class for models with INotifyPropertyChanged implemented</li>
  <li><b>CommandHandler</b> - An ICommand implementation perfect for command bindings</li>
</ul>
