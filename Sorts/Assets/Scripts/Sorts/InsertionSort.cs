using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Sorts
{ 
    public static class InsertionSort
    {
        public static async Task Sort(List<ElementContainer> arr)
        {
            int size = arr.Count;
            for (int i = 1; i < size; i++)
            {
                ElementContainer ec = arr[i];
                ec.Select(VisualData.IterateColor);

                var j = i;
                while (j > 0 && arr[j].Value
                                < arr[j - 1].Value)
                {
                    await BaseOperations.Swap(j, j - 1);
                    j--;

                    ec.Deselect();
                    ec = arr[i];
                    ec.Select(VisualData.IterateColor);
                }

                await BaseOperations.Select(j, VisualData.KnownColor);

                ec.Deselect();
            }
        }
    }
}
