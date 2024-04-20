using Assets.Scripts.Sorts;
using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private ArrayModifier arrayModifier;

    private async void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
            arrayModifier.ResetArray();

        if (Input.GetKeyDown(KeyCode.Return))
            arrayModifier.Iterate();

        if (Input.GetKeyDown(KeyCode.Backspace))
            arrayModifier.Swaps();

        if (Input.GetKeyDown(KeyCode.B))
            arrayModifier.StartBubbleSort();

        if (Input.GetKeyDown(KeyCode.S))
            arrayModifier.StartSelectionSort();

        if (Input.GetKeyDown(KeyCode.I))
            arrayModifier.StartInsertionSort();

        if (Input.GetKeyDown(KeyCode.P))
            QuickSort.Partition(ArrayHolder.Elements, 0, ArrayHolder.Elements.Count - 1);

        if (Input.GetKeyDown(KeyCode.Q))
            arrayModifier.StartQuickSort();

        if (Input.GetKeyDown(KeyCode.H))
            arrayModifier.StartHeapSort();

        if (Input.GetKeyDown(KeyCode.M))
            arrayModifier.StartMergeSort();

        if (Input.GetKeyDown(KeyCode.C))
            arrayModifier.StartBinarySearch();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
