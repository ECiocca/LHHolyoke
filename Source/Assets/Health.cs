using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float StartHealth = 100f;
    public float HealSpeed = 2f;


    private void Update()
    {
        Death CurrentHealth = this.gameObject.GetComponent<Death>();
        if (CurrentHealth.CurrentHealth < 100)
        {
            if (CurrentHealth.HCooldown > 0) 
            {
                CurrentHealth.HCooldown -= Time.deltaTime;
            }
            else
            {
                CurrentHealth.CurrentHealth += Time.deltaTime * HealSpeed;
                CurrentHealth.CurrentHealth = Mathf.Clamp(CurrentHealth.CurrentHealth, 0, 100);
            }
            
        }

            }

    }
 

