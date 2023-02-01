using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCommunication : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider mainSlider;

    //Invoked when a submit button is clicked.
    public int SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        return (int)mainSlider.value;
    }
}
