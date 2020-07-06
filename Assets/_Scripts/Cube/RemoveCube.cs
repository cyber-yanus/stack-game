using System.Collections;
using UnityEngine;

public class RemoveCube : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("TimeToDie");
    }


    IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
