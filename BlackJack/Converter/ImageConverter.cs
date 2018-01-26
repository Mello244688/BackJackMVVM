using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BlackJack.Converter
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string pack = "pack://application:,,,/Images/PlayingCards/";

            if (value.GetType().Name == typeof(List<>).Name)
            {
                List<BitmapImage> images = new List<BitmapImage>();
                
                foreach (var item in (IList)value)
                {
                    try
                    {
                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.UriSource = new Uri(pack + item);
                        img.EndInit();
                        images.Add(img);
                    }
                    catch (Exception)
                    {
                        return DependencyProperty.UnsetValue;
                    }
                }
                return images;
            }

            try
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(pack + value);
                img.EndInit();
                return img;
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
