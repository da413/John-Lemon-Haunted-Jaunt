using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    public ParticleSystem JohnParticles;
    public bool canAttack = true;
    public AudioSource activateSound;
    public AudioSource deactivateSound;

    bool attacked;
    

    void Update()
    {
       
        if (Input.GetKeyDown("space") && canAttack)
        {
            JohnParticles.Play();
            activateSound.Play();
            attacked = true;
            canAttack = false;
        }  
        
    }

    public void Activate()
    {
        activateSound.Play();
        attacked = true;
        JohnParticles.Play();
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
        if (other.transform.CompareTag("Enemy") && attacked)
        {
            //Debug.Log("Sure");
            other.gameObject.SetActive(false);
            attacked = false;
            JohnParticles.Stop();
            deactivateSound.Play();
        }
          
     }
    
}

//When we press space, the particle system bursts
//When gargoyles or ghosts enter the trigger while pressing space, they are destroyed