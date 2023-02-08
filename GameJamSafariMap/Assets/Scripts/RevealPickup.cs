using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RevealPickup : MonoBehaviour
{

    public GameObject Land;
    public GameObject Water;
    public GameObject TreeTile;
    public GameObject BreakingTile;

    public GameObject Reveal;
    public bool IsTriggered = false;
    public GameObject Goblin;
    public GameObject Sheep;
    public GameObject Player;

    public GameObject Map;

    public string mapSeed;

    public Vector2 Where;

    private int mapLength;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collission)
    {
        if ((collission.collider.gameObject.name == "Player" || collission.collider.gameObject.name == "Player(Clone)") && !IsTriggered)
        {
            IsTriggered = true;
            int columns = int.Parse(mapSeed[..1]); ;
            int output = 0;
            mapLength = 0;

            for (int i = 1; i < mapSeed.Length; i++)
            {
                bool succes = int.TryParse(mapSeed.Substring(i, 1), out output);
                if (!succes)
                {
                    generateMap(mapSeed[i], columns, ref i);
                }
                else
                {
                    for (int j = 1; j < output; j++)
                    {
                        generateMap(mapSeed[i + 1], columns, ref i);
                    }
                }

            }


            GameObject TreeGroup = GameObject.Find("TreeGroup");
            Destroy(TreeGroup,0);

            GameObject map = GameObject.Find("Map");
            if (map == null)
                map = GameObject.Find("Map(Clone)");
            Destroy(map);

            map = Instantiate(Map, transform);
            map.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }
    }
    void generateMap(char a, int columns, ref int i)
    {
        if (a.Equals('W'))
        {
            GenerateTile(Water, columns);
        }
        if (a.Equals('T'))
        {
            GenerateTile(TreeTile, columns);
        }
        if (a.Equals('R'))
        {
            

            int xLength = mapLength / columns;
            int zLength = mapLength % columns;
            Vector3 standardSize = new Vector3(2.5f, 0, 2.5f);
            mapLength++;
            GameObject newReveal = Instantiate(Reveal, transform.position + new Vector3((zLength+Where.x ) * standardSize.z, 0,(Where.y -xLength) * standardSize.x), Quaternion.Euler(Vector3.zero));

            RevealPickup TheScript = newReveal.GetComponent<RevealPickup>();

            i++;
            int xcoordinate;
            if (mapSeed.Substring(i, 1) == "-")
            {
                i++;
                xcoordinate = -int.Parse(mapSeed.Substring(i, 1));

            }
            else
            {
                xcoordinate = int.Parse(mapSeed.Substring(i, 1));
            }
            i++;
            int ycoordinate;
            if (mapSeed.Substring(i, 1) == "-")
            {
                i++;
                ycoordinate = -int.Parse(mapSeed.Substring(i, 1));

            }
            else
            {
                ycoordinate = int.Parse(mapSeed.Substring(i, 1));
            }
            i += 2;
            TheScript.Where = new Vector2(xcoordinate, ycoordinate);
            TheScript.IsTriggered = false;

            // R is READ, the where is read AND the ( is read
            string seed = "";
            int endAmount = 1;
            while (endAmount != 0)
            {
                seed += mapSeed[i];
                i++;
                if (mapSeed.Substring(i, 1) == "(")
                {
                    endAmount++;
                }

                if (mapSeed.Substring(i, 1) == ")")
                {
                    endAmount--;

                }
            }
            TheScript.mapSeed = seed;

            
        }
        if (a.Equals('L'))
        {
            GenerateTile(Land, columns);
        }
        if (a.Equals('P'))
        {
            GenerateEntity(Player, columns);
            GenerateTile(Land, columns);

        }
        if (a.Equals('S'))
        {
            GenerateEntity(Sheep, columns);
            GenerateTile(Land, columns);

        }
        if (a.Equals('G'))
        {
            GenerateEntity(Goblin, columns);
            GenerateTile(Land, columns);

        }
        if (a.Equals('B'))
        {
            GenerateTile(BreakingTile, columns);

        }

    }
    private void GenerateEntity(GameObject entity, int columns)
    {
        int xLength = mapLength / columns;
        int zLength = mapLength % columns;
        Vector3 standardSize = new Vector3(2.5f, 0, 2.5f);
        Instantiate(entity, transform.position + new Vector3((zLength+ 0.5f + Where.x) * standardSize.z, 10, (-xLength -0.5f + Where.y) * standardSize.x), transform.rotation);
    }

    private void GenerateTile(GameObject prefab, int columns)
    {
        int xLength = mapLength / columns;
        int zLength = mapLength % columns;
        Vector3 standardSize = new Vector3(2.5f, 0, 2.5f);
        mapLength++;
        Instantiate(prefab, transform.position + new Vector3((zLength + Where.x) * standardSize.z, 0, -((xLength-Where.y) * standardSize.x)), transform.rotation);

    }
}
