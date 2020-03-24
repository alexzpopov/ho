using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;



[Serializable]
public class ItemSet
{

    //    public int index;
    public string caption;
    public Sprite pic;
}

[Serializable]
public class AnswerSet
{

    //  public int index;
    public Vector3 pos;
    public Sprite pic;
}

[CreateAssetMenu(fileName = "GameSettings", menuName = "Installers/GameSettings")]
    public class GameSettings : ScriptableObjectInstaller<GameSettings>
    {
    public LevelSet[] level;
    public GameObject item;
    public GameObject Answer;
    public GameObject Fx;
    public Color BGcolor;
    //public AudioHandler.Settings AudioHandler;




    [Serializable]
        public class LevelSet
        {

            public int time;
            public List<ItemSet> Items=new List<ItemSet>();
            public List<AnswerSet> Answers = new List<AnswerSet>();
            
    }

        public override void InstallBindings()
        {
        }

    }


