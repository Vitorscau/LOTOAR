using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private static PrefabManager _instance;

    public static PrefabManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject prefabManagerObject = new GameObject("PrefabManager");
                _instance = prefabManagerObject.AddComponent<PrefabManager>();
            }
            return _instance;
        }
    }

    private GameObject prefabToInstantiate;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPrefabToInstantiate(GameObject prefab)
    {
        prefabToInstantiate = prefab;
    }

    public GameObject GetPrefabToInstantiate()
    {
        return prefabToInstantiate;
    }
}
