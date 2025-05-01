using UnityEngine;

public class RandomWeight
{
    private int result;
    public int GetValue()
    {
        float randomVal = Random.value * 100.0f;

        result = (int)randomVal;

        return result;
    }
}
