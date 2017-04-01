using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform target;
    public float padding;
    public bool camFollowUp;

	public void Start()
	{
	}

	public void Update()
	{
        if (!camFollowUp)
            transform.Translate(target.position.x - transform.position.x, 0, 0);
        else
            transform.Translate(target.position.x - transform.position.x, transform.position.y + padding - transform.position.y, 0);
	}
}
