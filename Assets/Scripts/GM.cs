using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM instance = null;

    [SerializeField]
    GameObject levelCanvas;

    [SerializeField]
    Vector2[] spawnPos;
    //[SerializeField]
    //bool flip = false;

    //bool inLevel = false;


    [SerializeField]
    public GameObject[] player;
    public string[] playerSelect;
    private int selectedPlayers = 0;
    private LoadSceneOnClick levelLoader;
    //private Animator charDisplay;
    //[SerializeField]
    //CameraController cam;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        Setup();
    }

    void Setup()
    {
        levelLoader = GameObject.FindObjectOfType<LoadSceneOnClick>();
        if (GameObject.FindGameObjectWithTag("Level") == true)
        {
            for (int i = 0; i < player.Length; i++)
            {
                player[i] = (GameObject)Resources.Load(playerSelect[i], typeof(GameObject));
                player[i] = Instantiate(player[i], spawnPos[i], player[i].transform.rotation) as GameObject;
                player[i].name = "Player " + (i + 1);
                //cam.m_Targets[i] = player[i].transform;
            }
            levelCanvas.SetActive(true);
        }
        else if (GameObject.Find("CharSelect") == true)
        {
            levelCanvas.SetActive(false);
            //charDisplay = GameObject.Find("CharacterDisplay1").GetComponent<Animator>();
            //charDisplay.SetBool("flip", flip);
        }

    }
    // Use this for initialization
    void Start ()
    {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectCharacter()
    {
        selectedPlayers++;
        if (selectedPlayers >= 2)
        {
            //Debug.Log("Begin Game");
            levelLoader.LoadByIndex(2);
        }
    }

    IEnumerator Begin(int beginTimer)
    {
        yield return new WaitForSeconds(beginTimer);

    }
}
