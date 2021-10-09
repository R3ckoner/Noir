using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public bool gun1 = true;
    public bool gun2 = false;
    public bool gun3 = false;
    public float reloadTime = 1f;
    public int selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
       
        SelectWeapon();
        

    }
    
    
     void OnCollisionEnter (Collision col) 
 {
          if (col.gameObject.CompareTag("pistol"))
          {
              gun1 = true;
              
 
          }  
          if (col.gameObject.CompareTag("smg"))
          {
              gun2 = true;
              
 
          }  
          if (col.gameObject.CompareTag("ar"))
          {
              gun3 = true;
              
 
          }  
 }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

       
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
            
        }
        
            
        
    }

   

    
}
