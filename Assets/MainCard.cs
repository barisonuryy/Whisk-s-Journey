using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    private bool canTurn;
    [SerializeField] private MiniGameRandomization randomization;
    [SerializeField] private GameObject Card_Back;
    void Start()
    {
        canTurn = false;
    }

    public void OnMouseDown()
    {
        if (Card_Back.activeSelf&&randomization.canReveal)
        {
            Card_Back.SetActive(false);
            randomization.cardRevealed(this);
            
        }
    }

    private int _id;

    public int id
    {
        get
        {
            return _id;
        }
    }

    public void ChangeSprite(int id,Sprite image)
    {
        _id =id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Unreveal()
    {
        Card_Back.SetActive(true);

    }
}
