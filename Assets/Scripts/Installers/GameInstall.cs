using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class GameInstall : MonoInstaller
    {
        [Inject]
        GameSettings gs;

        public override void InstallBindings()
        {
        //  InstallSignals();
        // Container.BindFactory<StartEnd, FxController, FxController.FxFabrik>().FromComponentInNewPrefab(gs.Fx);
        Container.BindFactory<Vector3,Vector3, Fx, Fx.FxFabrik>().FromComponentInNewPrefab(gs.Fx);
        Container.BindFactory<ItemSet,Transform,GameController, ItemController, ItemController.ItemFabrik>().FromComponentInNewPrefab(gs.item);

        Container.BindFactory<AnswerSet,GameController, AnswerController, AnswerController.AnswerFabrik>().FromComponentInNewPrefab(gs.Answer);



        
    }
      //  void InstallSignals()
    //   {
            //  SignalBusInstaller.Install(Container);
            //   Container.DeclareSignal<GamePause>();
    //    }

    }
    public class GamePause
    {
    }

