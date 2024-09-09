using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    using System;
    public static class SRandom 
    {
        public static void Shuffle<T>(this T[] arr)
        {
            Random rng = new();
            int n = arr.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (arr[k], arr[n]) = (arr[n], arr[k]);
            }
        }

        public static void Shuffle(this List<int> list)
        {
            Random rng = new();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static bool PercentRandom(float rate)
        {
            rate = Mathf.Clamp01(rate);
            float value = UnityEngine.Random.Range(0f, 1f);
            if (value < rate) return true;
            else return false;
        }
        public static bool PercentRandom(float rate, Action action)
        {
            if (PercentRandom(rate))
            {
                action?.Invoke();
                return true;
            }
            return false;
        }
        public static int WheelRandom(List<float> rates)
        {
            float totalRate = 0f;
            for (int i = 0; i < rates.Count; i++)
            {
                if (rates[i] < 0) rates[i] = 0;
                totalRate += rates[i];
            }

            float value = UnityEngine.Random.Range(0f, 1f) * totalRate;
            float currentAnchor = 0;
            for (int i = 0; i < rates.Count; i++)
            {
                if (currentAnchor <= value && value < rates[i] + currentAnchor)
                {
                    return i;
                }
                currentAnchor += rates[i];
            }
            return 0;
        }

        public static int WheelRandom(float[] rates)
        {
            float totalRate = 0f;
            for (int i = 0; i < rates.Length; i++)
            {
                if (rates[i] < 0) rates[i] = 0;
                totalRate += rates[i];
            }

            float value = UnityEngine.Random.Range(0f, 1f) * totalRate;
            float currentAnchor = 0;
            for (int i = 0; i < rates.Length; i++)
            {
                if (currentAnchor <= value && value < rates[i] + currentAnchor)
                {
                    return i;
                }
                currentAnchor += rates[i];
            }
            return 0;

        }
    }
}