using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Hero;
    Transform trans;
  
    // Start is called before the first frame update
    void Start()
    {
      trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       trans.position = new Vector3(Hero.position.x, 0,-10);
     }
}
