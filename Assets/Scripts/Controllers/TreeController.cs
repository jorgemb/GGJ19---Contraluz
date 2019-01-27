using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float TimeToWait = 2.0f;
    public GameObject woodPrefab;

    private bool startDestroy = false;

    public void CutTree()
    {
        startDestroy = true;
    }

    public void Update()
    {
        if (startDestroy)
        {
            if(TimeToWait > 0.0f)
            {
                TimeToWait -= Time.deltaTime;
                return;
            }

            int woodToCreate = Mathf.FloorToInt(Random.Range(2.0f, 6.0f));
            for (int i = 0; i != woodToCreate; i++)
            {
                GameObject newWood = Instantiate(woodPrefab);
                Vector3 newPosition = transform.position;
                newPosition.y += Random.Range(2.0f, 5.0f);
                newWood.transform.position = newPosition;
            }


            Destroy(gameObject);
        }
    }
}
