using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{
    [Inject]
    ShowItem showitem;
    [Inject]
    GameController gameContr;
    [Inject]
    ShowItem showItem;
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    GameObject gameComplete;
    public Transform ItemGroup;
    [SerializeField]
    Text timer;
    public float levelTime = 30;
    private bool gamePlay = true;

    public void onMaskClick()
    {
        showitem.onShow();
        showItem.Mask.transform.position=gameContr.getFirstItem();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onNewGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void onGoMenu()
    {
        Application.LoadLevel(Application.loadedLevel-1);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (gamePlay)
        {
            levelTime -= Time.deltaTime;

            string minutes = Mathf.Floor(levelTime / 60).ToString("00");
            string seconds = (levelTime % 60).ToString("00");

            timer.text = string.Format("{0}:{1}", minutes, seconds);

            if (levelTime < 0)
            {
                GameOver();
            }
        }
    }
    private void GameOver()
    {
        gamePlay = false;
        gameOver.SetActive(true);
    }
    public void GameComplete()
    {
        gamePlay = false;
        gameComplete.SetActive(true);
    }

}
