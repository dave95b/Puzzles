using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "SpriteList", menuName = "Game data/IntValue")]
public class IntValue : ScriptableValue<int>
{
    public static implicit operator int(IntValue intValue) => intValue.Value;

    public static IntValue operator ++(IntValue intValue)
    {
        intValue.Value++;
        return intValue;
    }

    public static IntValue operator --(IntValue intValue)
    {
        intValue.Value--;
        return intValue;
    }

    public static IntValue operator +(IntValue intValue, int i)
    {
        intValue.Value += i;
        return intValue;
    }

    public static IntValue operator -(IntValue intValue, int i)
    {
        intValue.Value -= i;
        return intValue;
    }

    public static IntValue operator *(IntValue intValue, int i)
    {
        intValue.Value *= i;
        return intValue;
    }

    public static IntValue operator /(IntValue intValue, int i)
    {
        intValue.Value /= i;
        return intValue;
    }
}