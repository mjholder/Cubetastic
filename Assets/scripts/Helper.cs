using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static int StringToInt(string input)
    {
        char[] inputChars = input.ToCharArray();
        int output = 0;

        for (int i = 0; i < inputChars.Length; i++)
        {
            if (inputChars[i] >= '0' && inputChars[i] <= '9')
            {
                int temp = (inputChars[i] - '0') * (int)Mathf.Pow(10, inputChars.Length - i - 1);
                output += temp;
            }
            else
            {
                Debug.LogError(input + " contains non-numerical characters");
                return 0;
            }
        }

        return output;
    }
}
