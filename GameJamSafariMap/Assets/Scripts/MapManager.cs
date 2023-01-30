using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UILandPrefab;
    public GameObject UIWaterPrefab;
    public GameObject UIPlayerPrefab;
    public GameObject UIRevealPrefab;
    public GameObject UITreePrefab;

    public GameObject UISheepPrefab;
    public GameObject UIGoblinPrefab;

    public GameObject Tree;



    private List<GameObject> Map;

    void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        List<GameObject> Map = new List<GameObject>();
        GameObject Base = GameObject.Find("Base");
        Vector3 BasePosition = Base.transform.position;

        GameObject[] RealLandArray = GameObject.FindGameObjectsWithTag("T_Land");
        foreach(GameObject RealLand in RealLandArray)
        {
            GameObject UILand = Instantiate(UILandPrefab, transform.position , transform.rotation);
            UILand.transform.position = RealLand.transform.position - BasePosition;
            UILand.transform.position = new Vector3(UILand.transform.position.x*40, UILand.transform.position.z * 40);
            UILand.transform.SetParent(transform, false);
        }

        GameObject[] RealWaterArray = GameObject.FindGameObjectsWithTag("T_ObstacleLand");
        foreach (GameObject RealWater in RealWaterArray)
        {
            GameObject UILand = Instantiate(UIWaterPrefab, transform.position, transform.rotation);
            UILand.transform.position = RealWater.transform.position - BasePosition;
            UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
            UILand.transform.SetParent(transform, false);   
        }
        GameObject[] RealTreeArray = GameObject.FindGameObjectsWithTag("T_ObstacleLand2");
        foreach (GameObject RealTree in RealTreeArray)
        {
            GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
            UILand.transform.position = RealTree.transform.position - BasePosition;
            UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
            UILand.transform.SetParent(transform, false);
        }
        GameObject[] RealRevealArray = GameObject.FindGameObjectsWithTag("T_Reveal");
        foreach (GameObject RealReveal in RealRevealArray)
        {
            GameObject UILand = Instantiate(UIRevealPrefab, transform.position, transform.rotation);
            UILand.transform.position = RealReveal.transform.position - BasePosition;
            UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
            UILand.transform.SetParent(transform, false);
        }

        GameObject UIPlayer = Instantiate(UIPlayerPrefab, transform.position, transform.rotation);
        UIPlayer.transform.position = GetPlayerLocation(); 
        UIPlayer.transform.SetParent(transform, false);

        GameObject UISheep = Instantiate(UISheepPrefab, transform.position, transform.rotation);
        UISheep.transform.position = GetAnimalLocation();
        UISheep.transform.SetParent(transform, false);

        GameObject UIGoblin = Instantiate(UIGoblinPrefab, transform.position, transform.rotation);
        UIGoblin.transform.position = GetGoblinLocation();
        UIGoblin.transform.SetParent(transform, false);



        GameObject TreeGroup = new GameObject("TreeGroup");

        GameObject[] AllLands =  RealLandArray.Concat(RealWaterArray.Concat(RealRevealArray.Concat(RealTreeArray).ToArray()).ToArray()).ToArray();
        for(int i = 0; i < AllLands.Length; i++)
        {
            GameObject Land = AllLands[i];
            bool hasMore=false;
            for(int j = 0; j < AllLands.Length; j++)
            {
                GameObject CompareLand = AllLands[j];
                if (Land.transform.position.x > CompareLand.transform.position.x)
                {
                    hasMore = true;
                    break;
                }
            }
            
            if (!hasMore)
            {
                GameObject tree = Instantiate(Tree, Land.transform.position - new Vector3(2.5f,0,0), transform.rotation);
                tree.transform.SetParent(TreeGroup.transform);
                GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
                UILand.transform.position = tree.transform.position - BasePosition;
                UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
                UILand.transform.SetParent(transform, false);
            }
        }
        for (int i = 0; i < AllLands.Length; i++)
        {
            GameObject Land = AllLands[i];
            bool hasMore = false;
            for (int j = 0; j < AllLands.Length; j++)
            {
                GameObject CompareLand = AllLands[j];
                if (Land.transform.position.x < CompareLand.transform.position.x)
                {
                    hasMore = true;
                    break;
                }
            }
            if (!hasMore)
            {
                GameObject tree = Instantiate(Tree, Land.transform.position - new Vector3(-2.5f, 0, 0), transform.rotation);
                tree.transform.SetParent(TreeGroup.transform);
                GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
                UILand.transform.position = tree.transform.position - BasePosition;
                UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
                UILand.transform.SetParent(transform, false);

            }
        }
        for (int i = 0; i < AllLands.Length; i++)
        {
            GameObject Land = AllLands[i];
            bool hasMore = false;
            for (int j = 0; j < AllLands.Length; j++)
            {
                GameObject CompareLand = AllLands[j];
                if (Land.transform.position.z > CompareLand.transform.position.z)
                {
                    hasMore = true;
                    break;
                }
            }
            if (!hasMore)
            {
                GameObject tree = Instantiate(Tree, Land.transform.position - new Vector3(0, 0, 2.5f), transform.rotation);
                tree.transform.SetParent(TreeGroup.transform);
                GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
                UILand.transform.position = tree.transform.position - BasePosition;
                UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
                UILand.transform.SetParent(transform, false);
            }
        }
        for (int i = 0; i < AllLands.Length; i++)
        {
            GameObject Land = AllLands[i];
            bool hasMore = false;
            for (int j = 0; j < AllLands.Length; j++)
            {
                GameObject CompareLand = AllLands[j];
                if (Land.transform.position.z < CompareLand.transform.position.z)
                {
                    hasMore = true;
                    break;
                }
            }
            if (!hasMore)
            {
                GameObject tree = Instantiate(Tree, Land.transform.position - new Vector3(0, 0, -2.5f), transform.rotation);
                tree.transform.SetParent(TreeGroup.transform);
                GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
                UILand.transform.position = tree.transform.position - BasePosition;
                UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
                UILand.transform.SetParent(transform, false);
            }
        }
    }
    private Vector3 GetGoblinLocation()
    {
        GameObject Base = GameObject.Find("Base");
        Vector3 BasePosition = Base.transform.position;
        GameObject RealGoblin = GameObject.Find("Goblin");
        if (RealGoblin == null)
            RealGoblin = GameObject.Find("Goblin Variant(Clone)");
        if (RealGoblin != null)
        {
            Vector3 returnVector = RealGoblin.transform.position - BasePosition;
            returnVector = new Vector3(returnVector.x * 40, returnVector.z * 40, 0);
            return returnVector + new Vector3(-25,25);
        }
        return Vector3.zero;
    }

    private Vector3 GetAnimalLocation()
    {
        GameObject Base = GameObject.Find("Base");
        Vector3 BasePosition = Base.transform.position;
        GameObject RealSheep = GameObject.Find("Sheep");
        if(RealSheep==null)
            RealSheep= GameObject.Find("Sheep Variant(Clone)");
        if (RealSheep != null)
        {
            Vector3 returnVector = RealSheep.transform.position - BasePosition;
            returnVector = new Vector3(returnVector.x * 40, returnVector.z * 40, 0);
            return returnVector + new Vector3(-25,25) ;
        }
        return Vector3.zero;
    }

    private Vector3 GetPlayerLocation()
    {
        GameObject Base = GameObject.Find("Base");
        Vector3 BasePosition = Base.transform.position;
        GameObject RealPlayer = GameObject.Find("Player");
        if (RealPlayer == null)
            RealPlayer = GameObject.Find("Player(Clone)");
        Vector3 returnVector = RealPlayer.transform.position-BasePosition;
        returnVector = new Vector3(returnVector.x * 40, returnVector.z * 40, 0);
        return returnVector + new Vector3(-25, 25);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Player");
        if(Player.GetComponent<PlayerManager>() != null)
        {
            PlayerManager TheScript = Player.GetComponent<PlayerManager>();
            if (TheScript.UsingMap)
            {
                GameObject UIPlayerReal = GameObject.Find("UI_Player(Clone)");
                UIPlayerReal.transform.localPosition = GetPlayerLocation();

                GameObject UISheep = GameObject.Find("UI_Sheep(Clone)");
                UISheep.transform.localPosition = GetAnimalLocation();

                GameObject UIGoblin = GameObject.Find("UI_Goblin(Clone)");
                UIGoblin.transform.localPosition = GetGoblinLocation();
    

                transform.localPosition = new Vector3(0, 0, 0);

            }
            else
            {
                transform.localPosition = new Vector3(2000, 0, 0);

            }
        }
    }
}
