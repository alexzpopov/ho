using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

//public enum GamePlay { }
public class AnswerController : MonoBehaviour
{
    [Inject]
    void Create(AnswerSet answer, GameController gameContr)
    {
        GetComponent<SpriteRenderer>().sprite = answer.pic;
        transform.position = answer.pos;
        gameContr.addAnswer(gameObject);
    }

    public class AnswerFabrik : PlaceholderFactory<AnswerSet, GameController, AnswerController> 
        {

        }

}
