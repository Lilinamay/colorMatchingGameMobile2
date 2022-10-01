using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    int num = 4;
    public bool check = false;
    public int score = 0;
    [SerializeField] TMP_Text scoreT;
    [SerializeField] TMP_Text timerT;
    [SerializeField] Image TimerI;
    [SerializeField] TMP_Text play;
    public int timerText;
    // Start is called before the first frame update
    void Start()
    {
        buttonListener.OnButtonSet?.Invoke(num);
        //Camera.main.transform.DOShakePosition(3);
        play.text = "play";

    }

    // Update is called once per frame
    void Update()
    {
        scoreT.text = "Score: " + score;
        timerText = (int)GetComponent<buttonListener>().Timer;
        if (timerText +1 > -1 )
        {
            timerT.text = timerText+1 + "";
        }
        if (timerText < -4)
        {
            timerT.text = "";
            score = 0;
        }
        //timerT.text = (int)GetComponent<buttonListener>().Timer+1 + "";
        play.text = GetComponent<buttonListener>().playText;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonListener.OnButtonSet?.Invoke(num);
        }
        TimerI.fillAmount = GetComponent<buttonListener>().Timer / GetComponent<buttonListener>().maxTimer;
    }

    public void correct()
    {
        score++;

    }

    public void incorrect()
    {

    }

    //public void playbuttonText()
    //{
    //    if(play.text == "play")
    //    {
    //        play.text = GetComponent<buttonListener>().playText();
    //    }

    //}
}
