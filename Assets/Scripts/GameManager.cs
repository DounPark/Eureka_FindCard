using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Card firstCard;
    public Card secondCard;
    public Text timeTxt;
    public GameObject endTxt;
    public GameObject endBtn;
    public bool finished = false;
    AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clipa;
    
    public int cardCount = 0;
    float time = 0.0f;
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

        void Update()
    {
        if (finished)
        {
            return;
        }

        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 30.0f)
        {
            endTxt.SetActive(true);
            time = 30.0f;
            
            finished = true;
        }

        if (time >20.0f)
        {
            audioSource.PlayOneShot(clipa);
        }
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                finished = true;
                //Time.timeScale = 0.0f;
                endTxt.SetActive(true);
                endBtn.SetActive(true);
                
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
