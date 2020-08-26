using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;
    public GameObject platform;
    public GameObject diamonds;
    Vector3 lastPosition;
    float size;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

       
    }

    public void startPlatformSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {

        int rand = Random.Range(0, 7);
        if (rand < 4)
        {
            SpawnX();
        } else if (rand > 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 position = lastPosition;
        Vector3 diamPosition = new Vector3(position.x, position.y + 1, position.z);
        position.x += size;
        lastPosition = position;
        Instantiate(platform, position, Quaternion.identity);//instantiate funkcija sluzi za kreiranje objekata, prvi parametar je koji objekat, drugi pozicija
        // i treci rotacija ja navodim da uzima trenutno rotiranje
        int rand = Random.Range(0, 4);
        if (rand < 1 )
        {
            Instantiate(diamonds, diamPosition, diamonds.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 position = lastPosition;
        Vector3 diamPosition = new Vector3(position.x, position.y + 1, position.z);
        position.z += size;
        lastPosition = position;
        Instantiate(platform, position, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds, diamPosition, diamonds.transform.rotation);
        }
    }
}
