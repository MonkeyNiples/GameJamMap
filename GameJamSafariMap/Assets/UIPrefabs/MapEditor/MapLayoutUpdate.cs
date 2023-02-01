using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapLayoutUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseContainer;

    void Start()
    {
        GameObject ColumnSlider = GameObject.Find("ColumnSlider");
        GameObject RowSlider = GameObject.Find("RowSlider");

        for (int i = 0; i < (int)RowSlider.GetComponent<Slider>().value; i++)
        {
            for(var j = 0; j < (int)ColumnSlider.GetComponent<Slider>().value; j++)
            {
                GameObject BaseContainer = Instantiate(baseContainer);
                BaseContainer.transform.SetParent(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject slider = GameObject.Find("ColumnSlider");
        int columns = (int)slider.GetComponent<Slider>().value;
        GameObject RowSlider = GameObject.Find("RowSlider");
        int rows  = (int)RowSlider.GetComponent<Slider>().value;

        GetComponent<GridLayoutGroup>().constraintCount = columns;
        int currentBlocks = transform.childCount;
        int shouldBeBlocks = columns * rows;

        if (currentBlocks != shouldBeBlocks)
        {
            if(currentBlocks< shouldBeBlocks)
            {
                for(int i = currentBlocks; i < shouldBeBlocks; i++)
                {
                    GameObject BaseContainer = Instantiate(baseContainer);
                    BaseContainer.transform.SetParent(transform);
                }
            }
            else
            {
                for (int i= currentBlocks-1;i>shouldBeBlocks-1;i--)
                {
                    GameObject.Destroy(transform.GetChild(i).gameObject);
                }
               
            }


        }

    }
}
