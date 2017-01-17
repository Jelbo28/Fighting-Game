using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    bool knockout = false;

    public float startingTime;

    public float initialCountdown = 3;

    public float LastLoss;

    private Text myText;

    public GameObject GameOverScreenFader;

    public GameObject RoundOverScreenFader;

    private IEnumerator coroutine;

    public Text GameOverText;

    public Text RoundOverText;

    public float Rounds;

    [SerializeField]
    Image[] KO;

    [SerializeField]
    PlayerController[] player;

    private float delay = 3;
    private bool start = false;

    int i = 3;

    void Start()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i] = GameObject.Find("Player " + (i + 1)).GetComponent<PlayerController>();
            player[i].enabled = false;
        }

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
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            if (start)
            {
                myText.fontSize = 45;
                initialCountdown -= Time.deltaTime;

                if (Mathf.Round(initialCountdown) > i && initialCountdown >= 1)
                {
                    myText.transform.localScale = new Vector3(myText.transform.localScale.x - (0.5f * Time.deltaTime), myText.transform.localScale.y - (0.5f * Time.deltaTime), 1);
                }
                else
                {
                    i--;
                    myText.transform.localScale = Vector3.one;
                }
                myText.text = "" + Mathf.Round(initialCountdown);
                if (initialCountdown <= 1)
                {
                    myText.text = "FIGHT";
                    for (int i = 0; i < player.Length; i++)
                    {
                        player[i].enabled = true;
                    }
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
                    //player.gameObject.SetActive(false);
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
        else
        {
            myText.text = " ";
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
