using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public static class BaseOperations
{
    public async static Task Select(ElementContainer element, Color color, float time)
    {
        element.Select(color);
        await Task.Delay((int)(time * 1000));
        element.Deselect();
    }
    public static async Task Select(int i, Color color, float time)
    {
        await Select(ArrayHolder.Elements[i], color, time);
    }
    public static async Task Select(int i, Color color)
    {
        await Select(ArrayHolder.Elements[i], color, VisualData.Delay);
    }
    public static async Task Select(int i)
    {
        await Select(i, VisualData.IterateColor);
    }

    public static async Task Swap(int i, int j, float time)
    {
        var t1 = Select(i, VisualData.HitColor, time);
        var t2 = Select(j, VisualData.MissColor, time);
        await Task.WhenAll(t1, t2);

        ArrayHolder.Swap(i, j);

        t1 = Select(i, VisualData.MissColor, time);
        t2 = Select(j, VisualData.HitColor, time);
        await Task.WhenAll(t1, t2);
    }

    public static async Task Swap(int i, int j)
    {
        await Swap(i, j, VisualData.Delay);
    }
}
