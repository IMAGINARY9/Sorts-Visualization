using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayHolder : MonoBehaviour
{
    private static List<ElementContainer> elements = new();
    public static List<ElementContainer> Elements { get => elements; set => elements = value; }

    public static int Size => Elements.Count;

    public void Add(GameObject elementGameObject, int initValue)
    {
        var elContaiter = elementGameObject.GetComponent<ElementContainer>();
        elContaiter.Init(initValue);
        Elements.Add(elContaiter);
    }
    public static void Remove(int i)
    {
        Destroy(Elements[i].gameObject);
        Elements.Remove(Elements[i]);
    }

    public static int GetElementIndex(ElementContainer element)
    {
        return Elements.IndexOf(element);
    }

    public static void Swap(int i, int j)
    {
        if (Elements == null) return;
        var tempPos = Elements[i].transform.position;
        Elements[i].transform.position = Elements[j].transform.position;
        Elements[j].transform.position = tempPos;
        var tempEl = elements[i];
        elements[i] = elements[j];
        elements[j] = tempEl;
    }

    public static void Clear()
    {
        for (int i = Elements.Count - 1; i >= 0; i--)
        {
            Remove(i);
        }
    }
    
}
