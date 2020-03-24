using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class GameController : MonoBehaviour
{

    [Inject]
    GameSettings gs;
    [Inject]
    UIController uiContr;
    [Inject]
    ItemController.ItemFabrik itemFabrik;
    [Inject]
    AnswerController.AnswerFabrik answerFabrik;
    [Inject]
    Fx.FxFabrik fxFabrik;

    [SerializeField]
    int score;
    [SerializeField]
    const float delta = 0.8f;


    List<GameObject> AnswPos = new List<GameObject>();
    List<GameObject> ItemPos = new List<GameObject>();

    // Start is called before the first frame update
    public void addItem(GameObject item)
    {
        ItemPos.Add(item);
    }
    public void addAnswer(GameObject item)
    {
        AnswPos.Add(item);
    }
    
    public Vector3 getFirstItem()
    {
        foreach (var item in AnswPos)
        {
            if (item.activeSelf)
            {
                return item.transform.position;
            }  
        }
        return new Vector3(0, 0, 0);
    }

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        int _level=PlayerPrefs.GetInt("level", 0);
        CreateItem(gs.level[_level].Items);
        CreateAnswer(gs.level[_level].Answers);
    }
    void CreateItem(List<ItemSet> items)
    {
        foreach (var item in items)
        {
            itemFabrik.Create(item, transform,this);
        }
    }
    void CreateAnswer(List<AnswerSet> items)
    {
        foreach (var item in items)
        {
            answerFabrik.Create(item,this);
        }
    }
    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))// && touch
        {
           // Debug.Log(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 pos = ray.GetPoint(0); pos.z = 0;
            if (Physics.Raycast(ray))
            {
                foreach (var item in AnswPos)
                {
                    //visible and distance <delta
                    if ((item.activeSelf) && (Vector3.Distance(item.transform.position, pos) < delta))
                    {
                        item.SetActive(false);
                        GameObject _itemPos = ItemPos[AnswPos.IndexOf(item)];
                        _itemPos.GetComponent<ItemController>().active = false;
                        _itemPos.transform.GetChild(0).GetComponent<Image>().enabled = true;
                        //_itemPos.transform.position
                        fxFabrik.Create(item.transform.position, Camera.main.ScreenToWorldPoint(_itemPos.transform.position));
                        score++;
                        PlayerPrefs.SetInt("score", score);
                        break;
                    }
                }
                int itemLeft = ItemPos.Count;
                foreach (var item in ItemPos)
                {
                    if (!item.GetComponent<ItemController>().active)
                        itemLeft--;
                }
                if (itemLeft == 0)
                {
                    uiContr.GameComplete();
                }
                    //Debug.Log(pos + " " + Vector3.Distance(debugPos.position, pos));
            }
            else
            {
                score--;
                PlayerPrefs.SetInt("score", score);
            }
            //need 0.8f
            // Instantiate(particle, transform.position, transform.rotation);
        }
    }
}
