using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal_pickup : MonoBehaviour
{
    public UIScript UIUpdate;
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        UIUpdate.CrystalGrab(this.gameObject.name);
    }
}
