using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float padding;
    public bool camFollowUp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!camFollowUp)
        transform.Translate(target.position.x - transform.position.x, 0, 0);
        else
         transform.Translate(target.position.x - transform.position.x, target.position.y + padding - transform.position.y, 0);
    }
}
