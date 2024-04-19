using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayGenerator : MonoBehaviour
{
    [SerializeField]
    private float offset;
    [SerializeField]
    private int initSize;

    [SerializeField]
    private ArrayHolder arrayHolder;
    [SerializeField]
    private GameObject arrayElement;

    public static int Size { get; set; }

    private void Start()
    {
        Size = initSize;
        Generate();
    }

    private void CameraSetup(int n)
    {
        Camera.main.orthographicSize = n + n / 2;
        Camera.main.transform.position = new Vector3(0, -n / 5, -10);
    }
    public void Generate()
    {
        int n = (int)(Size * offset);
        CameraSetup(n);

        float pos = arrayElement.transform.localScale.x * (Size - 1) * -1;
        for (int i = 0; i < Size; i++)
        {
            var elementGameObject = Instantiate(arrayElement.gameObject, new Vector3(pos, 0, 0), Quaternion.identity, arrayHolder.transform);
            arrayHolder.Add(elementGameObject, Random.Range(1, n + 1));
            pos += arrayElement.transform.localScale.x * 2;
        }
    }
    
}
