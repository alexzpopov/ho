using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenu : MonoBehaviour
{
 public void onStart()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
