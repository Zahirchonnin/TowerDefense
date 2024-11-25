
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public Color hoverColor;
    private Color baseColor;
    private Renderer crend;

    private GameObject tower;



    // Start is called before the first frame update
     void Start()
    {
       crend= GetComponent<Renderer>();
       baseColor = crend.material.color;
    }
/*
    // Update is called once per frame
    void Update()
    {
        
    } */
    private void OnMouseDown()
    {
        if(tower != null)
        {
            Debug.Log("Impossible de construir");
        }

        //Construir une tourelle.
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
       tower = Instantiate(towerToBuild, transform.position, Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                // Instantiate(towerToBuild, transform.position, transform.rotation);
        
    }
    private void OnMouseEnter()
    {
        crend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        crend.material.color = baseColor;
    }
}
