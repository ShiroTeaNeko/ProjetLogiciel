using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
       

    }

    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
    }
}
