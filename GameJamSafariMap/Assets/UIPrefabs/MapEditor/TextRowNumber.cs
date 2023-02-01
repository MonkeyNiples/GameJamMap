    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextRowNumber : MonoBehaviour
{
    // Start is called before the first frame update
    public string m_MyText="";
    public string cows;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_MyText = $"Number of {cows}: {GetComponentInParent<Slider>().value}";
        GetComponent<TextMeshProUGUI>().SetText(m_MyText);

    }
}
