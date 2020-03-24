using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Fx : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isActive;

    [Inject]
    void Create(Vector3 _startPos, Vector3 _endPos)
    {

        startPos = _startPos; endPos = _endPos;
        startPos.z = -1; endPos.z = -1;
        this.transform.position = startPos;
        isActive = true;

    }
    private void Update()
    {
        if (isActive)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, 0.05f);
            Debug.Log(Vector3.Distance(transform.position, endPos));
            if (Vector3.Distance(transform.position, endPos) < 0.1f)
            {
                isActive = false;
                Destroy(this.gameObject);
            }

        }
    }
    public class FxFabrik : PlaceholderFactory<Vector3, Vector3, Fx>
    {

    }
}