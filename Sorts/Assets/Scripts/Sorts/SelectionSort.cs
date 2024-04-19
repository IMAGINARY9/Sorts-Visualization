using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Sorts
{
    public static class SelectionSort
    {
        public static async Task Sort(List<ElementContainer> arr)
        {
            int size = arr.Count;
            for (int i = 0; i < size - 1; i++)
            {
                ElementContainer ec = arr[i];
                ec.Select(VisualData.IterateColor);

                int smallest = i;
                ElementContainer ecSmallest = arr[smallest];

                for (int j = i + 1; j < size; j++)
                {
                    await BaseOperations.Select(j, VisualData.UnknownColor);
                    if (arr[j].Value
                        < arr[smallest].Value)
                    {
                        if (smallest != i)
                            ecSmallest.Deselect();
                        smallest = j;
                        ecSmallest = arr[smallest];
                        ecSmallest.Select(VisualData.HitColor);
                    }
                }

                await BaseOperations.Swap(i, smallest);
                ecSmallest.Deselect();
                ec.Deselect();
            }
        }
    }
}
