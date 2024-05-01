using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public int RotationSpeed = 100;
    private Transform itemTransform;
    // Start is called before the first frame update
    void Start()
    {
        //Grabbing GameObject’s Transform component and assign to itemTransform
        itemTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
