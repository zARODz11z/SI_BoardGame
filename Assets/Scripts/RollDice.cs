using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RollDice : MonoBehaviour
   
{
    public Texture Side1, Side2, Side3, Side4, Side5, Side6;
    private Texture[] DiceArray;
    public int timeWait;
    public GameObject questionToDisplay;


    // Start is called before the first frame update
    void Start()
    {
        DiceArray = new Texture[6] { Side1, Side2, Side3, Side4, Side5, Side6 };
        
        //animator = this.gameObject.GetComponentInChildren<Animator>();
    }
    public void RollDie()
    {               
                       
                    
        int index = Random.Range(0, 6);
        Texture ImgToShow = DiceArray[index];
        GameObject.FindWithTag("DiceImage").GetComponent<RawImage>().texture = ImgToShow;
        ChangeQuestion.displayNewQuestion();
        Debug.Log("Dice rolled");
    }
   
   
}
