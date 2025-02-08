using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Script : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    private Rigidbody rg;
    public UnityEngine.UI.Text zaman, can, durum;
    public float Hiz = 1.8f;
    float zamansayaci = 90;
    int cansayaci = 25;
    bool oyundevam = true;
    bool oyuntamam = false;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { if (oyundevam && !oyuntamam)
        {
            zamansayaci -= Time.deltaTime;
            zaman.text = (int)zamansayaci + "";
        }
        else if(!oyuntamam)
        {
            durum.text = "oyun tamamlanamadý.";
            btn.gameObject.SetActive(true);
        }

            if (zamansayaci < 0)
                oyundevam = false;
        
    }
    private void FixedUpdate()
    {
        if (oyundevam&& !oyuntamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * Hiz);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        if (objIsmi.Equals("bitis"))
        {
            //print("oyun tamamlandý.");
            oyuntamam= true;
            durum.text = "oyun tamamlandý";
            btn.gameObject.SetActive(true);
        }
        else if (!objIsmi.Equals("labzemin") && !objIsmi.Equals("diszemin")) 
        {
            cansayaci -= 1;
            can.text = cansayaci+"";
            if(cansayaci==0)
                oyundevam= false;
        }
    } 
}
            
