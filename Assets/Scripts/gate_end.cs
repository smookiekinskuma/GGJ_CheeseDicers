using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate_end : MonoBehaviour
{
    public UIScript UIUpdate;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        UIUpdate.Credits();
    }
}
