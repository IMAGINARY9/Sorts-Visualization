using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Sorts
{
    public static class BubbleSort
    {
        public static async Task Sort(List<ElementContainer> arr)
        {
            int size = arr.Count;
            for (int i = 0; i < size; i++)
            {
                ElementContainer ec = arr[i];
                ec.Select(VisualData.IterateColor);

                for (int j = size - 1; j > i; j--)
                {
                    if (arr[j].Value
                        < arr[j - 1].Value)
                    {
                        await BaseOperations.Swap(j, j - 1);
                    }
                    else
                        await BaseOperations.Select(j, VisualData.KnownColor);
                }

                ec.Deselect();

            }
        }
    }
}
