using UnityEngine;

public class SpawnRandom : MonoBehaviour
{

    int myrand;

    void Start()
    {
        myrand = Random.Range(1, 100);
        if (myrand > 30)
        {
            Debug.Log("not spawned");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("spawned");
        }
    }
}
