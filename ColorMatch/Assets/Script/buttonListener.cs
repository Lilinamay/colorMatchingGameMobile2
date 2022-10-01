using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class buttonListener : MonoBehaviour
{
    public static Action<int > OnButtonSet;
    int i = 0;
    public List< GameObject> buttonlist= new List<GameObject>();
    Color correctColor;
    Color incorrectColor;
    [SerializeField] GameObject correctImage;
    [SerializeField] GameObject InCorrectImage;
    gameManager gameManager;
    int x;
    public float Timer = -5;  //code timer
    public float maxTimer = 5;
    public bool duringGame = true;
    public string playText;
    
    // Color variable for incorrect color
    // Color variable for correct color

    void OnEnable()
    {

        // find a way to listen to button presses
        
        foreach (GameObject g in buttonlist)
        {
            g.GetComponent<buttonProperty>().OnButtonPress += checkColor;
         }
        OnButtonSet += addList;

    }

    private void OnDisable()
    {
        OnButtonSet -= addList;
        foreach (GameObject g in buttonlist)
        {
            g.GetComponent<buttonProperty>().OnButtonPress -= checkColor;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<gameManager>();
        duringGame = false;
        disableButtons();
        playText = "play";
    }

    private void Update()
    {
        if (duringGame)
        {
            if (Timer >= 0)
            {
                Timer -= Time.deltaTime;
            }
            if (Timer < 0)
            {
                //endGame
                //StartCoroutine(resetGame());
                duringGame = false;
                playText = "replay";
                //disableButtons();
                Timer = -5;
            }
        }

    }

    //create afunction that passes along info to whoever is incharge of the score

    void checkColor(Color c,GameObject gameObject)
    {
        correctImage.SetActive(true);
        correctImage.transform.position = buttonlist[x].transform.position;

        if (c == correctColor)
        {
            gameManager.correct();
            StartCoroutine(resetLevel());
        }
        else
        {
            gameManager.incorrect();
            duringGame = false;
            InCorrectImage.SetActive(true);
            InCorrectImage.transform.DOShakePosition(1,50);
            InCorrectImage.transform.position = gameObject.transform.position;
            playText = "replay";
            //disableButtons();
            //StartCoroutine(resetGame());        //restart game
        }
        

    }

    public void resetGameButton()
    {
        if (!duringGame)
        {
            StartCoroutine(resetGame());
            //playText = "play";
        }
        else
        {
            disableButtons();
            duringGame = false;
            playText = "play";
            Timer = -5;
            
        }
    }

    void disableButtons()
    {
        foreach (GameObject g in buttonlist)
        {
            g.SetActive(false);
        }
    }

    void ableButtons()
    {
        foreach (GameObject g in buttonlist)
        {
            g.SetActive(true);
        }
    }

    IEnumerator resetGame()
    {
        yield return new WaitForSeconds(0.2f);
        ableButtons();
        gameManager.score = 0;
        InCorrectImage.SetActive(false);
        correctImage.SetActive(false);
        addList(buttonlist.Count);
        Timer = maxTimer;
        duringGame = true;
        playText = "quit";
    }

    IEnumerator resetLevel()
    {
        duringGame = false;
        yield return new WaitForSeconds(0.5f);
        duringGame = true;
        addList(buttonlist.Count);
        InCorrectImage.SetActive(false);
        correctImage.SetActive(false);
        Timer = maxTimer;
    }

    void addList(int num)
    {
        float r = UnityEngine.Random.Range(0.00f, 1.00f);
        float g = UnityEngine.Random.Range(0.00f, 1.00f);
        float b = UnityEngine.Random.Range(0.00f, 1.00f);

        float r2 = UnityEngine.Random.Range(0.00f, 1.00f);
        float g2 = UnityEngine.Random.Range(0.00f, 1.00f);
        float b2 = UnityEngine.Random.Range(0.00f, 1.00f);
        //buttonlist.Add(gameobject);
        //Debug.Log(i);
        //i++;
        correctColor = new Color(r2, g2, b2);
        incorrectColor = new Color(r, g, b);
        x = UnityEngine.Random.Range(0, num);
        //Debug.Log(x);
        for (int i = 0; i < buttonlist.Count; i++)
        {
            if (i == x)
            {
                //Debug.Log("different!");
                buttonlist[i].GetComponent<Image>().color = correctColor;
                //buttonlist[i].GetComponent<buttonProperty>().correct = true;
            }
            else
            {
                //Debug.Log("same");
                buttonlist[i].GetComponent<Image>().color = incorrectColor;
                //buttonlist[i].GetComponent<buttonProperty>().correct = false;
            }
        }


    }
}
