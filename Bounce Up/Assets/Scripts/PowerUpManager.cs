using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public GameObject itemGFX;

    public BoxCollider bc;

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.tag;

        if (otherTag == "Player")
        {
            if (itemGFX.activeSelf)
            {
                itemGFX.SetActive(false);
            }

            bc.enabled = false;

            StartCoroutine(enableObject());
        }
    }

    IEnumerator enableObject()
    {
        yield return new WaitForSeconds(60);

        if (!itemGFX.activeSelf)
        {
            itemGFX.SetActive(true);
        }

        bc.enabled = true;
    }
}
