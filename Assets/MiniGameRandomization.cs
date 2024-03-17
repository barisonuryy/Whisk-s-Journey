using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class MiniGameRandomization : MonoBehaviour
{
    // Start is called before the first frame update
    public const int gridRows = 2;
    public const int gridColls = 4;
    public const float offSetX = 30f;
    public const float offSetY =25f;
    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3};
        numbers = ShuffleArray(numbers);
        for (int i = 0; i < gridColls; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card=Instantiate(originalCard) as MainCard;
                }

                int index = j * gridColls + i;
                int id = numbers[index];
                card.ChangeSprite(id,images[id]);
                float posX = (offSetX * i) + startPos.x;
                float posY = (offSetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int temp = newArray[i];
            int rand = Random.Range(i, newArray.Length);
            newArray[i] = newArray[rand];
            newArray[rand] = temp;
        }

        return newArray;
    }

    private MainCard _firstCard;
    private MainCard _secondCard;
    private int tryCount = 3;
    [SerializeField] private GameObject[] healthBar;
   
    public bool canReveal
    {
        get
        {
            return _secondCard == null;
        }
    }

    public void cardRevealed(MainCard card)
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        }
        else
        {
            _secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstCard.id != _secondCard.id)
        {
            tryCount--;
            healthBar[tryCount].SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _firstCard.Unreveal();
            _secondCard.Unreveal();
        }

        _firstCard = null;
        _secondCard = null;
    }
}
