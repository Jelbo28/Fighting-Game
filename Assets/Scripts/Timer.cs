using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    bool knockout = false;

    public float startingTime;

    public float initialCountdown = 4;

    public float LastLoss;

    private Text myText;

    public GameObject GameOverScreenFader;

    public GameObject RoundOverScreenFader;

    public PlayerController player;

    private IEnumerator coroutine;

    public Text GameOverText;

    public Text RoundOverText;

    public float Rounds;

    [SerializeField]
    Image[] KO;

    private bool start;


    void Start()
    {

        start = true;
        myText = GetComponent<Text>();
        //StartCoroutine("MyMethod");
        Update();
    }

    void Update()
    {
        if (knockout)
        {
            StartCoroutine("MyMethod");
        }
        Countdown();
    }

    void Countdown()
    {
        if (start)

        {
            myText.fontSize = 35;
            initialCountdown -= Time.deltaTime;
            myText.text = "" + Mathf.Round(initialCountdown);
            if (initialCountdown <= 1)
            {
                myText.text = "FIGHT";
                if (initialCountdown <= 0)
                {
                    myText.fontSize = 20;
                    start = false;
                }
            }
        }
        else
        {
            startingTime -= Time.deltaTime;

            myText.text = "TIME REMAINING \n" + Mathf.Round(startingTime);

            if (startingTime <= 0)
            {
                myText.enabled = false;
                startingTime = 0;
                RoundOverText.enabled = true;
                RoundOverScreenFader.SetActive(true);
                //GameOverScreenFader.SetActive(true);
                player.gameObject.SetActive(false);
            }

            /*  else (startingTime <=0 && Rounds >=3)
              {
                  myText.enabled = false;
                  startingTime = 0;
                  GameOverText.enabled = true;
                  GameOverScreenFader.SetActive(true);
                  player.gameObject.SetActive(false);
              }
              */
        }


    }

    IEnumerator MyMethod()
    {
        //Debug.Log("Before waiting 3 seconds");
        for (int i = 0; i < KO.Length; i++)
        {
            KO[i].enabled = true;
            yield return new WaitForSeconds(1);
        }
    }

}
