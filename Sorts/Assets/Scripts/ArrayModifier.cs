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


    private async void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
            ResetArray();   

        if (Input.GetKeyDown(KeyCode.Return))
            Iterate();

        if (Input.GetKeyDown(KeyCode.Backspace))
            Swaps();

        if (Input.GetKeyDown(KeyCode.B))
            StartBubbleSort();

        if (Input.GetKeyDown(KeyCode.S))
            StartSelectionSort();

        if (Input.GetKeyDown(KeyCode.I))
            StartInsertionSort();

        if (Input.GetKeyDown(KeyCode.P))
            QuickSort.Partition(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count - 1);

        if (Input.GetKeyDown(KeyCode.Q))
            StartQuickSort();

        if (Input.GetKeyDown(KeyCode.H))
            StartHeapSort();

        if (Input.GetKeyDown(KeyCode.M))
            StartMergeSort();

        if (Input.GetKeyDown(KeyCode.C))
            StartBinarySearch();

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (locked) return;
            locked = true;

            var t1 = QuickSort.Sort(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count / 2);
            var t2 = QuickSort.Sort(ArrayHolder.Elements, ArrayHolder.Elements.Count / 2 + 1, ArrayHolder.Elements.Count - 1);
            await Task.WhenAll(t1, t2);
            MergeSort.Merge(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count / 2, ArrayHolder.Elements.Count - 1);

            locked = false;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (locked) return;
            locked = true;

            var t1 = QuickSort.Sort(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count / 4);
            var t2 = QuickSort.Sort(ArrayHolder.Elements, ArrayHolder.Elements.Count / 4 + 1, ArrayHolder.Elements.Count / 2);

            var t3 = QuickSort.Sort(ArrayHolder.Elements, ArrayHolder.Elements.Count / 2 + 1, ArrayHolder.Elements.Count - ArrayHolder.Elements.Count / 4);
            var t4 = QuickSort.Sort(ArrayHolder.Elements, ArrayHolder.Elements.Count - ArrayHolder.Elements.Count / 4 + 1, ArrayHolder.Elements.Count - 1);

            await Task.WhenAll(t1, t2, t3, t4);

            await MergeSort.Merge(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count / 4, ArrayHolder.Elements.Count / 2);
            await MergeSort.Merge(ArrayHolder.Elements, ArrayHolder.Elements.Count / 2 + 1, ArrayHolder.Elements.Count - ArrayHolder.Elements.Count / 4, ArrayHolder.Elements.Count - 1);

            MergeSort.Merge(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count / 2, ArrayHolder.Elements.Count - 1);

            locked = false;
        }

        
    }

}
