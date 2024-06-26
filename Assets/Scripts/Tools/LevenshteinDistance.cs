using UnityEngine;

public class LevenshteinDistance : MonoBehaviour
{
    public static int Compute(string a, string b)
    {
        int n = a.Length;
        int m = b.Length;
        int[,] d = new int[n + 1, m + 1];

        if (n == 0)
            return m;

        if (m == 0)
            return n;

        for (int i = 0; i <= n; d[i, 0] = i++) ;
        for (int j = 0; j <= m; d[0, j] = j++) ;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int cost = (b[j - 1] == a[i - 1]) ? 0 : 1;

                d[i, j] = Mathf.Min(
                    d[i - 1, j] + 1,
                    d[i, j - 1] + 1,
                    d[i - 1, j - 1] + cost
                );
            }
        }

        return d[n, m];
    }
}