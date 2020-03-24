using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class ItemController : MonoBehaviour
{
    public bool active=true;
    [Inject]
    void Create(ItemSet item,Transform trans, GameController gameContr)
    {
        transform.SetParent(trans, false);
        GetComponent<Image>().sprite = item.pic;
        transform.GetChild(1).GetComponent<Text>().text = item.caption;
        gameContr.addItem(gameObject);
    }

    public class ItemFabrik : PlaceholderFactory<ItemSet, Transform, GameController,  ItemController>
    {
        
    }
}
