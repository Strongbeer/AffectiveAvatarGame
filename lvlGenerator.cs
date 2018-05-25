using System.Collections.Generic;
using UnityEngine;

public class lvlGenerator : MonoBehaviour {

    public string seed;
    public bool useRandomSeed;

    public int quantity = 10;
    public int minLenght = 3;
    public int maxLenght = 5;
    public int minHeight = 0;
    public int maxHeight = 5;

    [Range(0,1)]
    public float Complexity = 0.5F;

    public GameObject platformTile;
    public GameObject platformGround;
    public GameObject player;

    [Tooltip("The size must be lower than 'Quantity'.")]
    public List<GameObject> addonObjects;
    public List<GameObject> addonObjects2;
    public List<GameObject> addonObjects3;
    public List<GameObject> addonObjects4;
    public List<GameObject> addonObjects5;


    private System.Random pseudoRandom;

    private List<Platform> platforms = new List<Platform>();

    private GameObject levelGo;

    public CharacterSelection characterSelection;

    // Use this for initialization
    void Start () {
        //Platform p = new Platform(1,5,2,true);
        generateLvL();
        characterSelection.ToggleEndMenu();

    }

    public void generateLvL ()
    {
        // random generator initiation
        InitRandomObject();
        // beginning of platforms - where
        CreateDefaultPlatforms();
        //
        SetIsDanger();
        //
        SetAddonObjects();
        SetAddonObjects2();
        SetAddonObjects3();
        SetAddonObjects4();
        SetAddonObjects5();
        //
        BuildLvl();

    }

    public void BuildLvl()
    {
        if (levelGo != null)
            Destroy(levelGo);
        levelGo = new GameObject("Level");
        // create platform
        PlacePlatforms();
        // create player
        PlacePlayer();
    }

    void PlacePlatforms()
    {
        foreach(Platform current in platforms)
        {
            for (int i = current.startIndex; i < current.startIndex + current.lenght; i++)
            {
                Vector3 pos = new Vector3(i, current.height, 0);
                if(!(i == current.startIndex + current.lenght - 1 && current.isDanger))
                {
                    GameObject curTile = Instantiate(platformTile, pos, Quaternion.identity);
                    curTile.transform.parent = levelGo.transform;

                    if (i == current.startIndex)
                        AddColider(ref curTile, current);
                }
            }

            PlaceAddon(current);
            PlaceGroundTiles(current);
        }
    }

    void PlaceAddon(Platform current)
    {
        if (current.addon != null)
        {
            Vector3 addonPos = new Vector3(current.startIndex + 1, current.height + 2, 0);

            GameObject curAddon = Instantiate(current.addon, addonPos, Quaternion.identity);
            curAddon.transform.parent = levelGo.transform;
        }
    }

    void AddColider(ref GameObject go, Platform current)
    {
        BoxCollider2D coll = go.AddComponent<BoxCollider2D>();

        Vector2 size;
        size.x = current.lenght - (current.isDanger ? 1:0);
        size.y = current.isDanger ? 1 : current.height + 5;

        coll.size = size;

        Vector2 offset;

        offset.x = size.x/2 - 0.5F;
        offset.y = current.isDanger ? 0 : -size.y / 2 + 0.5F;

        coll.offset = offset;

    }

    void PlacePlayer()
    {
        Vector3 playerPos = new Vector3(0, platforms[0].height + 1, 0);
        player.transform.position = playerPos;
    }

    void PlaceGroundTiles(Platform current)
    {
        Vector3 tilePos = new Vector3(0, 0, 0);

        if (!current.isDanger)
        {
            for (int i = current.startIndex; i < current.startIndex + current.lenght; i++)
            {
                for (int c = current.height -1; c > -5; c--)
                {
                    tilePos.x = i;
                    tilePos.y = c;

                    GameObject curTile = Instantiate(platformGround, tilePos, Quaternion.identity);
                    curTile.transform.parent = levelGo.transform;
                }
            }
        }
    }

    void InitRandomObject()
    {
        if (useRandomSeed)
            seed = Time.time.ToString();

        pseudoRandom = new System.Random(seed.GetHashCode());
    }

    void CreateDefaultPlatforms()
    {
        int currentStartIndex = 0; // start position of first plarform
        platforms.Clear();

        int height = getRandomNumber(minHeight, maxHeight +1);

        for (int i = 0; i < quantity; i++)
        {
            int heightDirection = getRandomNumber(0, 3);
            switch (heightDirection)
            {
                case 0:
                    height --;
                    break;
                case 2:
                    height ++;
                    break;
            }

            height = Mathf.Max(height, minHeight);
            height = Mathf.Min(height, maxHeight);

            Platform current = new Platform(currentStartIndex, getRandomNumber(minLenght, maxLenght + 1), height, false);
            platforms.Add(current);
            currentStartIndex += current.lenght;
        }

    }

    void SetIsDanger()
    {
        List<int> indices = GetRandomNumbers(0, quantity, Mathf.RoundToInt(Complexity * quantity));

        foreach(int current in indices)
        {
            platforms[current].isDanger = true;
            //Debug.Log(current);
        }
    }

    void SetAddonObjects()
    {
        //                                   min,  max,       return value
        List<int> indices = GetRandomNumbers(1, quantity, addonObjects.Count);
        int counter = 0;
        foreach (int current in indices)
        {
            platforms[current].addon = addonObjects[counter];
            //Debug.Log(current);
            counter++;
        }
    }

    void SetAddonObjects2()
    {
        //                                   min,  max,       return value
        List<int> indices2 = GetRandomNumbers(1, quantity, addonObjects2.Count);
        int counter = 0;
        foreach (int current in indices2)
        {
            platforms[current].addon = addonObjects2[counter];
            //Debug.Log(current);
            counter++;
        }
    }

    void SetAddonObjects3()
    {
        //                                   min,  max,       return value
        List<int> indices3 = GetRandomNumbers(1, quantity, addonObjects3.Count);
        int counter = 0;
        foreach (int current in indices3)
        {
            platforms[current].addon = addonObjects3[counter];
            //Debug.Log(current);
            counter++;
        }
    }

    void SetAddonObjects4()
    {
        //                                   min,  max,       return value
        List<int> indices4 = GetRandomNumbers(1, quantity, addonObjects4.Count);
        int counter = 0;
        foreach (int current in indices4)
        {
            platforms[current].addon = addonObjects4[counter];
            //Debug.Log(current);
            counter++;
        }
    }

    void SetAddonObjects5()
    {
        //                                   min,  max,       return value
        List<int> indices5 = GetRandomNumbers(1, quantity, addonObjects5.Count);
        int counter = 0;
        foreach (int current in indices5)
        {
            platforms[current].addon = addonObjects5[counter];
            //Debug.Log(current);
            counter++;
        }
    }

    List<int> GetRandomNumbers(int min, int max, int quantity)
    {
        List<int> result = new List<int>();
        List<int> buffer = new List<int>();

        for (int i = min; i < max; i++)
        {
            buffer.Add(i);
        }

        for (int i = 0; i < quantity; i++)
        {
            int temp = getRandomNumber(0, buffer.Count);
            result.Add(buffer[temp]);
            buffer.RemoveAt(temp);
        }

        return result;
    }

    int getRandomNumber (int min, int max)
    {
        return pseudoRandom.Next(min, max);
    }
}
