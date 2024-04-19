using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class BinarySearch
    {
        public static async Task<bool> Find(List<ElementContainer> arr, int key)
        {
            int first = 0;
            int last = arr.Count - 1;

            while (first <= last)
            {
                int middle = (first + last) / 2;

                var t1 = BaseOperations.Select(first, VisualData.IterateColor, VisualData.Delay * 5);
                var t2 = BaseOperations.Select(last, VisualData.IterateColor, VisualData.Delay * 5);
                var t3 = BaseOperations.Select(middle, VisualData.RememberColor, VisualData.Delay * 5);

                await Task.WhenAll(t1, t2, t3);

                if (arr[middle].Value == key)
                {
                    await BaseOperations.Select(middle, VisualData.HitColor, VisualData.Delay * 5);
                    return true;
                }
                else if (first == last)
                {
                    await BaseOperations.Select(first, VisualData.MissColor, VisualData.Delay * 5);
                    return false;
                }
                else if (arr[middle].Value > key)
                {
                    last = middle - 1;
                }
                else
                {
                    first = middle + 1;
                }
            }

            return false;
        }
    }
}
