using System.Windows;
using System.Windows.Controls;

namespace RedditRSS
{
    /* 
     * Source: https://thomasfreudenberg.com/archive/2010/08/01/binding-webbrowser-content-in-wpf/ 
     * Defining a new attached property 'Body' for the WebBrowser control so that it is possible to pass HTML string through a data binding.
     * This is needed to display the RedditRSS.Models.Feeditem.Content property because WebBrowser has no built-in property for its content.
     */
    public class WebBrowserHelper
    {
        public static readonly DependencyProperty BodyProperty =
            DependencyProperty.RegisterAttached("Body", typeof(string), typeof(WebBrowserHelper), new PropertyMetadata(OnBodyChanged));

        public static string GetBody(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(BodyProperty);
        }

        public static void SetBody(DependencyObject dependencyObject, string body)
        {
            dependencyObject.SetValue(BodyProperty, body);
        }

        private static void OnBodyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser WebView = (WebBrowser)d;
            if (WebView is not null)
            {
                if ((string)e.NewValue is not null)
                {
                    WebView.NavigateToString((string)e.NewValue);

                }
                else
                {
                    WebView.NavigateToString("<p></p>");

                }
            }
        }
    }

}
