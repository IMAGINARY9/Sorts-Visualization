using Assets.Scripts;
using Assets.Scripts.Sorts;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ArrayModifier : MonoBehaviour
{
    public static int SearchValue { get; set; }

    [SerializeField]
    private ArrayGenerator arraySetup;

    private bool locked = false;

    public async Task Iterate()
    {
        if (locked) return;
        locked = true;

        for (int i = 0; i < ArrayHolder.Size; i++)
        {
            await BaseOperations.Select(i);
        }

        locked = false;
    }

    public async Task Swaps()
    {
        if (locked) return;
        locked = true;

        for (int i = 0; i < ArrayHolder.Size - 1; i++)
        {
            await BaseOperations.Swap(i, i + 1);
        }

        locked = false;
    }

    public void ResetArray()
    {
        ArrayHolder.Clear();
        arraySetup.Generate();
        locked = false;
    }

    public async void StartBubbleSort()
    {
        if (locked) return;
        locked = true;

        await BubbleSort.Sort(ArrayHolder.Elements);

        locked = false;
    }
    public async void StartSelectionSort()
    {
        if (locked) return;
        locked = true;

        await SelectionSort.Sort(ArrayHolder.Elements);

        locked = false;
    }
    public async void StartInsertionSort()
    {
        if (locked) return;
        locked = true;

        await InsertionSort.Sort(ArrayHolder.Elements);

        locked = false;
    }

    public async void StartQuickSort()
    {
        if (locked) return;
        locked = true;

        await QuickSort.Sort(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count - 1);

        locked = false;
    }

    public async void StartHeapSort()
    {
        if (locked) return;
        locked = true;

        await HeapSort.Sort(ArrayHolder.Elements);

        locked = false;
    }

    public async void StartMergeSort()
    {
        if (locked) return;
        locked = true;

        await MergeSort.Sort(ArrayHolder.Elements, 0, ArrayHolder.Size - 1);

        locked = false;
    }

    public async void StartBinarySearch()
    {
        if (locked) return;
        locked = true;

        await BinarySearch.Find(ArrayHolder.Elements, SearchValue);

        locked = false;
    }
        
    
}
