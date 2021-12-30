using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static int FindIndex<T>(this ObservableCollection<T> collection, Func<T, bool> predicate)
        {
            for(int i = 0; i < collection.Count; i++)
            {
                if (predicate(collection[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
