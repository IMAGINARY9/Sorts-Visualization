using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Sorts
{
    class HeapSort
    {
        private static async Task MaxHeapify(List<ElementContainer> arr, int size, int i)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int largest = i;

            ElementContainer iEc = arr[i];
            iEc.Select(VisualData.IterateColor);

            if (left < size
                && arr[left].Value
                > arr[largest].Value)
            {
                await BaseOperations.Select(left, VisualData.UnknownColor);
                largest = left;
            }

            if (right < size
                && arr[right].Value
                > arr[largest].Value)
            {
                await BaseOperations.Select(left, VisualData.KnownColor);
                largest = right;
            }

            iEc.Deselect();

            if (largest != i)
            {
                await BaseOperations.Swap(i, largest);
                await MaxHeapify(arr, size, largest);
            }

        }

        private static async Task BuildMaxHeapify(List<ElementContainer> arr)
        {
            for (int i = arr.Count / 2 - 1; i >= 0; i--)
                await MaxHeapify(arr, arr.Count, i);
        }

        public static async Task Sort(List<ElementContainer> arr)
        {
            int size = arr.Count;
            await BuildMaxHeapify(arr);
            for (int i = size - 1; i > 0; i--)
            {
                await BaseOperations.Swap(i, 0);
                await MaxHeapify(arr, i, 0);
            }
        }
    }
}
