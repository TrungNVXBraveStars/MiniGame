using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenRandomNum : MonoBehaviour
{
    private int[] GenerateRandomNumbers(int count, int minValue, int maxValue)
    {
        int[] numbers = new int[count];

        for (int i = 0; i < count; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(minValue, maxValue + 1);
            }
            while (System.Array.IndexOf(numbers, randomNumber) != -1);

            numbers[i] = randomNumber;
        }

        return numbers;
    }
}
