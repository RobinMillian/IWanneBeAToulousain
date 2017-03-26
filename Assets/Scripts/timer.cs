using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    private float time = 0f;
    public Vector4 pos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
    }

    /* void OnGUI()
     {
         int minutes = Mathf.FloorToInt(time / 60F);
         int seconds = Mathf.FloorToInt(time - minutes * 60);
         string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

         GUI.Label(new Rect(10, 10, 100, 20), niceTime);
         //GUI.Label(new Rect(), niceTime);
         Debug.Log("wut");
     }*/
    void OnGUI()
    {
        // Make a background box
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        GUIStyle style = GUI.skin.GetStyle("label");

        //Set the style font size to increase and decrease over time
        style.fontSize = 40;

        GUI.Label(new Rect(pos.x, pos.y, pos.z, pos.w), "Time: " + niceTime, style);

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
/*        if (GUI.Button(new Rect(20, 40, 80, 20), niceTime))
        {
            Application.LoadLevel(1);
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Level 2"))
        {
            Application.LoadLevel(2);
        } */
    }
}
