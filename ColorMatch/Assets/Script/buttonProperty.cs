using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class buttonProperty : MonoBehaviour
{
    // Have an action that passes the color of this button
    public Action<Color, GameObject> OnButtonPress;
    public bool correct = false;
    [SerializeField] buttonListener buttonListener;

    // a Colorvaribale to store the color it is set to

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pressed()
    {
        //GetComponent<Image>().dopunch
        if (buttonListener.duringGame)
        {
            transform.DOPunchScale(new Vector3(1, 1, 1) * 0.1f, 0.6f, 10, 1);
            OnButtonPress?.Invoke(GetComponent<Image>().color, gameObject);
        }
        // invoke our action and send our color

        //if (correct)
        //{
        //    Debug.Log("correct!");
        //    gameManager.correct();
        //}
        //else
        //{
        //    Debug.Log("nah!");
        //    gameManager.incorrect();
        //}





        //int a = 100;
        //Slider s = new Slider();
       
        
        //DOTween.To(() => s.value, x => s.value = x, 10, 5).SetEase(Ease.InQuart).SetLoops(2).OnComplete(()=> {
        //    a = 5;
        //});




    }




}
