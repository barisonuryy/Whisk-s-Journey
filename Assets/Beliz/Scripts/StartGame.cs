using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private bool buttonPressed = false;
    public Button playButton;
    public AudioSource source;
    public AudioClip buttonClick;

    public Button muteButton;
    public Button unmuteButton;

    public Button descripButton;

    public GameObject descriptionPanel;
    public Button backButton;
    void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(StartTheGame);

        Button mute_btn = muteButton.GetComponent<Button>();
        mute_btn.onClick.AddListener(MuteSound);

        Button unmute_btn = unmuteButton.GetComponent<Button>();
        unmute_btn.onClick.AddListener(UnmuteSound);

        Button descr_btn = descripButton.GetComponent<Button>();
        descr_btn.onClick.AddListener(ShowDescription);

        Button b_btn = backButton.GetComponent<Button>();
        b_btn.onClick.AddListener(GoBack);
        
    }

    public void StartTheGame(){
        buttonPressed = true;
        int currentSceneIndex  = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void PlayButtonClickSound()
    {
        if (buttonClick != null)
        {
            source.clip = buttonClick;
            source.Play();
        }
        else
        {
            Debug.Log("AudioSource component is not assigned");
        }
    }

    public void MuteSound(){

        AudioListener.volume = 0f;
        muteButton.interactable = false;
        muteButton.gameObject.SetActive(false);
        unmuteButton.interactable = true;
        unmuteButton.gameObject.SetActive(true);
       
    }

    public void UnmuteSound(){
        AudioListener.volume = 1f;
        unmuteButton.interactable = false;
        unmuteButton.gameObject.SetActive(false);
        muteButton.interactable = true;
        muteButton.gameObject.SetActive(true);

    }

    public void ShowDescription(){
        descriptionPanel.SetActive(true);
    }

    public void GoBack(){
        descriptionPanel.SetActive(false);
    }


    

    

}
