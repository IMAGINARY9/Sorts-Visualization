using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Sorts
{
    class QuickSort
    {
        public static async Task<int> Partition(List<ElementContainer> arr, int begin, int end)
        {
            ElementContainer pivotEc = arr[end];
            pivotEc.Select(VisualData.RememberColor);

            int pivot = pivotEc.Value;

            ElementContainer qEc = arr[begin];
            qEc.Select(VisualData.IterateColor);

            int q = begin - 1;

            for (int i = begin; i <= end; i++)
            {
                await BaseOperations.Select(i, VisualData.UnknownColor);
                if (arr[i].Value < pivot)
                {
                    qEc.Deselect();

                    q++;
                    await BaseOperations.Swap(i, q);

                    qEc = arr[q];
                    qEc.Select(VisualData.IterateColor);
                }
                else
                    await BaseOperations.Select(i, VisualData.KnownColor);
            }

            await BaseOperations.Swap(q + 1, end);

            qEc.Deselect();
            pivotEc.Deselect();

            return q + 1;
        }

        public static async Task Sort(List<ElementContainer> arr, int begin, int end)
        {
            if (begin < end)
            {
                int q = await Partition(arr, begin, end);

                await Sort(arr, begin, q - 1);
                await Sort(arr, q + 1, end);
            }
        }
    }
}
