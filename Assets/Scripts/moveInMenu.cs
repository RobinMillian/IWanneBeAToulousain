using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class moveInMenu : MonoBehaviour {

    public GameObject cursor;
    public string[] scenePaths;
    public Transform[] levelsPoints;
    public AudioClip[] audioStation;
    private AudioSource source;
    public int _currentIndex = 0;
    private bool canMove = true;
    private float currentTime = 0.4f;
    private float goLetsGo = 5f;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        Transform startPoint = levelsPoints[_currentIndex];
        cursor.transform.localPosition = new Vector3(startPoint.position.x, startPoint.position.y, startPoint.position.z);
        gameObject.transform.position = new Vector3(startPoint.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update() {
        if (goLetsGo == 5f)
        {
            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0 && canMove)
            {
                source.Stop();
                _currentIndex += 1;
                if (_currentIndex == levelsPoints.Length)
                    _currentIndex = levelsPoints.Length - 1;
                playSounds(audioStation[_currentIndex]);
                centerMainCameraOn(levelsPoints[_currentIndex]);
                setCursor(levelsPoints[_currentIndex], cursor);
                cursor.SetActive(false);
                canMove = false;
            }
            else if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0 && canMove)
            {
                source.Stop();
                _currentIndex -= 1;
                if (_currentIndex < 0)
                    _currentIndex = 0;
                playSounds(audioStation[_currentIndex]);
                setCursor(levelsPoints[_currentIndex], cursor);

                cursor.SetActive(false);
                canMove = false;
            }
        }
        if (Input.GetButtonDown("Submit") || goLetsGo != 5f)
        {
            if (goLetsGo == 5f)
                SceneManager.LoadScene("SceneLoader", LoadSceneMode.Additive);
            goLetsGo -= Time.deltaTime;
            if (goLetsGo < 0)
                SceneManager.LoadScene(scenePaths[_currentIndex], LoadSceneMode.Single);
        }
        if (goLetsGo == 5)
        {
            centerMainCameraOn(levelsPoints[_currentIndex]);
            currentTime -= Time.deltaTime;
            if (canMove == false && currentTime < 0)
            {
                currentTime = 0.4f;
                canMove = true;
            }
        }
    }

    void playSounds(AudioClip pist)
    {
       
        source.PlayOneShot(pist, 0.7F);
    }

    void centerMainCameraOn(Transform point)
    {
        float encadrment = 2f;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(point.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Time.deltaTime * 14f);
        if (point.position.x >= gameObject.transform.position.x - encadrment && point.position.x <= gameObject.transform.position.x + encadrment)
        {
            cursor.SetActive(true);
        }
        else
            canMove = false;
    }
    void setCursor(Transform startPoint, GameObject cursor)
    {
        cursor.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, startPoint.position.z);
    }
}
