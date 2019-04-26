using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : FireProjectile {

	public override void Start () {
        
       
    }
	
	// Update is called once per frame
	public override void Update()
    {
        position = transform.position;
        base.Update();

    }

}
