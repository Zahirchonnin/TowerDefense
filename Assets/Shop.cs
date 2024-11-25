using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
     // Start is called before the first frame update
    void Start()
    {
       buildManager = BuildManager.instance; 
    }
/*
    // Update is called once per frame
    void Update()
    {
        
    } */
    // public void PurchaseArrowTower()
    // {
    //     Debug.Log("Archer Preparé");
    //     buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    // }
    //     public void PurchaseCanonTower()
    // {
    //     Debug.Log("Archer Preparé");
    //     buildManager.SetTowerToBuild(buildManager.canonTowerPrefab);
    // }
    //         public void PurchaseMageTower()
    // {
    //     Debug.Log("Archer Preparé");
    //     buildManager.SetTowerToBuild(buildManager.mageTowerPrefab);
    // }
}
