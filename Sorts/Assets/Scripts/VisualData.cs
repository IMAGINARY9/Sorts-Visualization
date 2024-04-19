using System.Collections;
using UnityEngine;

public class VisualData : MonoBehaviour
{
    public static float Delay { get; set; }
    public static Color IterateColor => Color.yellow;
    public static Color HitColor => Color.green;
    public static Color MissColor => Color.red;
    public static Color KnownColor => Color.blue;
    public static Color UnknownColor => Color.cyan;
    public static Color RememberColor => Color.magenta;

}
