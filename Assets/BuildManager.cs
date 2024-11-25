using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;
        private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a déja un Build Manager dans la Scène !");
            return;
        }
        instance = this;
    }
    #endregion
    public GameObject standardTowerPrefab;
    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }


    // Start is called before the first frame update
    void Start()
    {
        towerToBuild = standardTowerPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
