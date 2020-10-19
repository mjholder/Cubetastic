using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMapping;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMap in colorMapping)
        {
            if (colorMap.color.Equals(pixelColor))
            {
                Vector3 pos = new Vector3(x, 1, y);
                Instantiate(colorMap.prefab, pos, Quaternion.identity);
            }
        }
    }
}
