using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public float Width=500f;

    public Death A;

    // Update is called once per frame
    void Update () {
        float myhealth = Mathf.Clamp(A.CurrentHealth, 0, 100);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((myhealth / 100.0F)*Width,108);

        Image mycolor = GetComponent<Image>();
        if (mycolor != null)
        {
            float currentcolor = myhealth / 100.0f;
            mycolor.color = new Color(1-currentcolor,currentcolor,0);
        }


    
	}
}
