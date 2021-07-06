using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPoints : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(HideMe());
    }

    
    IEnumerator HideMe()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        //Destroy(gameObject, 2);
    }
}
