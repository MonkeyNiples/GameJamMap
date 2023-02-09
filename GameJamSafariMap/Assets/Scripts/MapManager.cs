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
    public GameObject UIBreakingTilePrefab;


    public GameObject UISheepPrefab;
    public GameObject UIGoblinPrefab;

    public GameObject Tree;



    private List<GameObject> Map;

    void Start()
    {
        Invoke("StartDelayed", 0.001f);
        
    }

    private void StartDelayed()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        List<GameObject> Map = new List<GameObject>();
        GameObject Base = GameObject.Find("Base");
        Vector3 BasePosition = Base.transform.position;

        GameObject[] RealLandArray = GameObject.FindGameObjectsWithTag("T_Land");
        foreach (GameObject RealLand in RealLandArray)
        {
            GameObject UILand = Instantiate(UILandPrefab, transform.position, transform.rotation);
            UILand.transform.position = RealLand.transform.position - BasePosition;
            UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
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
        GameObject[] RealBreakArray = GameObject.FindGameObjectsWithTag("T_BreakingLand");
        foreach (GameObject RealBreak in RealBreakArray)
        {
            GameObject UILand = Instantiate(UIBreakingTilePrefab, transform.position, transform.rotation);
            UILand.transform.position = RealBreak.transform.position - BasePosition;
            UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
            UILand.transform.SetParent(transform, false);
        }

        GameObject UIPlayer = Instantiate(UIPlayerPrefab, transform.position, transform.rotation);
        UIPlayer.transform.position = GetPlayerLocation();
        UIPlayer.transform.SetParent(transform, false);

        GameObject UISheep = Instantiate(UISheepPrefab, transform.position, transform.rotation);
        UISheep.transform.position = GetAnimalLocation();
        UISheep.transform.SetParent(transform, false);

         GetGoblinLocation();



        GameObject TreeGroup = new GameObject("TreeGroup");

        GameObject[] AllLands = RealLandArray.Concat(RealWaterArray.Concat(RealRevealArray.Concat(RealBreakArray.Concat(RealTreeArray)).ToArray().ToArray()).ToArray()).ToArray();
        AllLands=PutLands(-1, 0, AllLands, BasePosition);
        AllLands = PutLands(1, 0, AllLands, BasePosition);
        AllLands = PutLands(0, -1, AllLands, BasePosition);
        AllLands = PutLands(-1, 0, AllLands, BasePosition);
        AllLands = PutLands(1, 0, AllLands, BasePosition);
        AllLands = PutLands(0, -1, AllLands, BasePosition);


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
                GameObject tree = Instantiate(Tree, Land.transform.position - new Vector3(0, 2, 2.5f), transform.rotation);
                tree.transform.SetParent(TreeGroup.transform);
                GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
                UILand.transform.position = tree.transform.position - BasePosition;
                UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
                UILand.transform.SetParent(transform, false);
            }
        }
    }

    private GameObject[] PutLands(int v1, int v2, GameObject[] allLands, Vector3 basePosition)
    {
        GameObject TreeGroup = GameObject.Find("TreeGroup");
        List<GameObject> TheseTrees = new List<GameObject>();
        if (v1 != 0)
        {
            for (int i = 0; i < allLands.Length; i++)
            {
                GameObject Land = allLands[i];
                bool hasMore = false;
                for (int j = 0; j < allLands.Length; j++)
                {
                    GameObject CompareLand = allLands[j];
                    if (Land.transform.position.x*v1 > CompareLand.transform.position.x*v1)
                    {
                        hasMore = true;
                        break;
                    }
                }

                if (!hasMore)
                {
                    GameObject tree = Instantiate(Tree, Land.transform.position - new Vector3(2.5f*v1, 0, 0), transform.rotation);
                    tree.transform.SetParent(TreeGroup.transform);
                    GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
                    UILand.transform.position = tree.transform.position - basePosition;
                    UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
                    UILand.transform.SetParent(transform, false);
                    TheseTrees.Add(tree);
                }
            }
        }
        else
        {
            for (int i = 0; i < allLands.Length; i++)
            {
                GameObject Land = allLands[i];
                bool hasMore = false;
                for (int j = 0; j < allLands.Length; j++)
                {
                    GameObject CompareLand = allLands[j];
                    if (Land.transform.position.z * v2 > CompareLand.transform.position.z*v2)
                    {
                        hasMore = true;
                        break;
                    }
                }

                if (!hasMore)
                {
                    GameObject tree = Instantiate(Tree, Land.transform.position - new Vector3(0, 0, 2.5f*v2), transform.rotation);
                    tree.transform.SetParent(TreeGroup.transform);
                    GameObject UILand = Instantiate(UITreePrefab, transform.position, transform.rotation);
                    UILand.transform.position = tree.transform.position - basePosition;
                    UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40);
                    UILand.transform.SetParent(transform, false);
                    TheseTrees.Add(tree);
                }
            }
        }
        return allLands = allLands.Concat(TheseTrees.ToArray()).ToArray();
    }

    private void GetGoblinLocation()
    {
        GameObject Base = GameObject.Find("Base");
        Vector3 BasePosition = Base.transform.position;

        GameObject OldUIGoblin;
        GameObject[] OldGoblinUIArray = GameObject.FindGameObjectsWithTag("T_UIGoblin");
        for(int i = OldGoblinUIArray.Length-1; i > -1; i--)
        {
            OldUIGoblin = OldGoblinUIArray[i];
            GameObject.Destroy(OldUIGoblin);
        }

            GameObject[] RealGoblinArray = GameObject.FindGameObjectsWithTag("T_Enemy");
        foreach (GameObject RealGoblin in RealGoblinArray)
        {
            GameObject UILand = Instantiate(UIGoblinPrefab, transform.position, transform.rotation);
            UILand.transform.position = RealGoblin.transform.position - BasePosition;
            UILand.transform.position = new Vector3(UILand.transform.position.x * 40, UILand.transform.position.z * 40) + new Vector3(-50, 45); 
            UILand.transform.SetParent(transform, false);
        }
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
            return returnVector + new Vector3(-50, 45) ;
        }
        return new Vector3(2000, 2000);

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
        return returnVector + new Vector3(-25, 45);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Player");
        if (Player == null)
            Player = GameObject.Find("Player(Clone)");
        if (Player.GetComponent<PlayerManager>() != null)
        {
            PlayerManager TheScript = Player.GetComponent<PlayerManager>();
            if (TheScript.UsingMap)
            {
                GameObject UIPlayerReal = GameObject.Find("UI_Player(Clone)");
                UIPlayerReal.transform.localPosition = GetPlayerLocation();

                GameObject UISheep = GameObject.Find("UI_Sheep(Clone)");
                UISheep.transform.localPosition = GetAnimalLocation();

               GetGoblinLocation();
    

                transform.localPosition = new Vector3(0, 0, 0);

            }
            else
            {
                transform.localPosition = new Vector3(2000, 0, 0);

            }
        }
    }
}
