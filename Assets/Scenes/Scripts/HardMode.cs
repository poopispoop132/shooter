using UnityEngine;
using UnityEngine.UI;

public class HardMode : MonoBehaviour
{
    public Toggle Hard;
    public float HardEnemy;
    public float HardFast;
    
    public float onHard = 0.7f;
    public float offHard = 1f;
    
    public float onFast = 1.7f;
    public float offFast = 2.5f;

    public EnemySpawner spawnerPrefab;
    private EnemySpawner spawnerInstance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hard.onValueChanged.AddListener(OnToggleChanged);
        spawnerInstance = Instantiate(spawnerPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }
void OnToggleChanged(bool isOn)
{
    Debug.Log(isOn);
        if (isOn)
        {
            spawnerInstance.spawnInterval = onHard;
            spawnerInstance.fastSpawnInterval = onFast;
        }

    else
    {
        spawnerInstance.spawnInterval = offHard;
        spawnerInstance.fastSpawnInterval = offFast;
    }
}
}