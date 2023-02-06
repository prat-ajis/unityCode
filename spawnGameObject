using UnityEngine;

public class spawnGameObject : MonoBehaviour
{
    //Game Object yang akan dispawn
    public GameObject[] fruitPrefab;
    //atur waktu spawn, dan acak munculnya
    public float secondSpawn = 0.5f, mixTrans, maxTrans;

    void Start()
    {
        StartCoroutine(fruitSpawn());
    }

    IEnumerator fruitSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(mixTrans, maxTrans);
            var position = new Vector3 (wanted, transform.position.y);
            GameObject gameObject = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
