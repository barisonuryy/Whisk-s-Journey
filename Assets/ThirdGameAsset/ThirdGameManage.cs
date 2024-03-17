using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdGameManage : MonoBehaviour
{
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private GameObject[] healths;
    [SerializeField] private TextMeshProUGUI textScore;
    private int score;
    private bool canPress;
    private int rand,tempRand;
    private float tempTime;
    private int health;
    private bool isTrueButton;
    public bool isPassedThree;
    private bool isCreated;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        CreateArrow();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress)
        {
            CheckCorrect();
        }

        if (score >= 10)
        {
            textScore.SetText("SKOR: "+score+"     Hedef Tamamlandı!");
            isPassedThree = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            
        }
      
    }

    void CreateArrow()
    {
        tempRand = rand;
        int changer = Random.Range(0, 2);
        rand = Random.Range(0, arrows.Length);
        if (rand == tempRand)
        {
            if (rand == 0)
            {
                rand++;
            }
            else if (rand == arrows.Length - 1)
            {
                rand--;
            }
            else
            {
                if (changer == 0)
                {
                    rand--;
                }
                else
                {
                    rand++;
                }
            }
        }
        tempTime = Time.time;
        canPress = true;
        isTrueButton = false;
    }

    void CheckCorrect()
    {
        
        arrows[rand].transform.GetChild(0).gameObject.SetActive(true);
        string value=  arrows[rand].gameObject.name;


        if (Time.time - tempTime < 3)
        {
            if (value.Equals("UpArrows")&&Input.GetKey(KeyCode.W))
            {
               
                score++;
               textScore.SetText("SKOR: "+score);
                isTrueButton = true;
                  
            }
          

            if (value.Equals("DownArrows")&&Input.GetKey(KeyCode.S))
            {
               
         
                score++;
                textScore.SetText("SKOR: "+score);
                isTrueButton = true;
               

               
            }
            if (value.Equals("RightArrows")&& Input.GetKey(KeyCode.D))
            {
               
                score++;
                textScore.SetText("SKOR: "+score);
                isTrueButton = true;
            }
            if(value.Equals("LeftArrows")&& Input.GetKey(KeyCode.A))
            {
        
                
                score++;
                textScore.SetText("SKOR: "+score);
                isTrueButton = true;
             
            
            }
            if (Input.anyKey)
            {
                canPress = false;
                if (!isTrueButton)
                {
                    health--;
                    healths[health].SetActive(false);
                }
            }
        }
        else
        {
            canPress = false;
        }
       
         
 
              if(!canPress)
              {
                  Invoke(nameof(TurnOffArrow),0.5f);
                  
              }

     
    }

    void TurnOffArrow()
    {
   
        arrows[rand].transform.GetChild(0).gameObject.SetActive(false);
        if(health>0)
        CreateArrow();
        else
        {
            //SceneManager.LoadScene()
        }
    }
    
}
