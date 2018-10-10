using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;

namespace Pokno.Infrastructure.Models
{
    public class ObservableCollectionManager<T>
    {
        public ObservableCollectionManager()
        {
            Collection = new ObservableCollection<T>();
        }

        public ObservableCollection<T> Collection { get; set; }
       
        public ObservableCollection<T> Refresh(ObservableCollection<T> collections)
        {
            ObservableCollection<T> newCollection = new ObservableCollection<T>();
            if (collections != null)
            {
                foreach (T collection in collections)
                {
                    newCollection.Add(collection);
                }
            }

            return newCollection;
        }



    }



}
