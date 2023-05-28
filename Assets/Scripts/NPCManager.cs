using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance;

    [SerializeField] GameObject npcPrefab;
    [SerializeField] float spawningFreqency;
    [SerializeField] int maxNPC;

    float timer;
    int npcs;

    private void Awake()
    {
        Instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (npcs >= 50)
            return;


        if (timer >= spawningFreqency)
        {
            Vector3 randomDirection = Player.Instance.transform.position + Random.insideUnitSphere * 100f;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 100f, 1);

            Instantiate(npcPrefab, hit.position, Quaternion.identity);
            timer = 0f;
            npcs++;
        }
    }

    public void DecreaseCounter()
    {
        npcs--;
    }

}
