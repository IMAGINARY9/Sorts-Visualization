using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Sorts
{
    public static class MergeSort
    {
        public static async Task Merge(List<ElementContainer> arr, int begin, int middle, int end)
        {
            int i = begin;
            int j = middle + 1;
            List<ElementContainer> X = new();

            while (i <= middle && j <= end)
            {
                var t1 = BaseOperations.Select(i, VisualData.KnownColor);
                var t2 = BaseOperations.Select(j, VisualData.UnknownColor);

                await Task.WhenAll(t1, t2);

                if (arr[i].Value < arr[j].Value)
                {
                    await BaseOperations.Select(i, VisualData.HitColor);
                    X.Add(arr[i]);
                    i++;
                }
                else
                {
                    await BaseOperations.Select(j, VisualData.HitColor);
                    X.Add(arr[j]);
                    j++;
                }
            }

            while (i <= middle)
            {
                X.Add(arr[i]);
                i++;
            }
            while (j <= end)
            {
                X.Add(arr[j]);
                j++;
            }

            int l = 0;
            for (int k = begin; k <= end; k++)
            {
                var index = ArrayHolder.GetElementIndex(X[l++]);
                await BaseOperations.Swap(k, index);
            }
        }

        public static async Task Sort(List<ElementContainer> arr, int begin, int end)
        {
            if (begin < end)
            {
                var t1 = BaseOperations.Select(begin, VisualData.IterateColor);
                var t2 = BaseOperations.Select(end, VisualData.IterateColor);

                int middle = (begin + end) / 2;

                var t3 = BaseOperations.Select(middle, VisualData.RememberColor);

                await Task.WhenAll(t1, t2, t3);

                await Sort(arr, begin, middle);
                await Sort(arr, middle + 1, end);

                await Merge(arr, begin, middle, end);
            }
        }
    }
}
