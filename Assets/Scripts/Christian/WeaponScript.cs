using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {


	public float fireRate=0;
	public float Damage=10;
	public float bulletSpeed = 1000.0f;
	public LayerMask whatToHit;
	public Rigidbody bulletPrefab;
	public float bulletSpawnrate=10;
	public int damagePerShot = 100;
	
	private float timeToFire=0;
	private float timeToSpawnBullet=0;
	private float camRayLength = 100f;          // The length of the ray from the camera into the scene.
	private int playAreaMask;
	private bool check;
	Transform firePoint;
	RaycastHit hit;
	Vector3 firePointPosition;
	Vector3 firePosition;

	public ParticleSystem particles;

	void Awake () {
		//Will search for childern, in this case will find the fire point of gun.
		// Create a layer mask for the floor layer.
		playAreaMask = LayerMask.GetMask ("PlayArea");
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError("Could not find firePoint! ");	
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Is this a single fire weapon, i.e. firerate=0
		if (fireRate == 0) 
		{
			Shoot();
		}
		else
		{
			if(Input.GetButton("Fire1")&&Time.time>timeToFire)
			{
				timeToFire=Time.time+1/fireRate;
				Shoot();
			}
		}
	}

	void Shoot(){
		if (Input.touchCount > 1) {
			// Create a ray from the mouse cursor on screen in the direction of the camera.
			Ray camRay = Camera.main.ScreenPointToRay (Input.GetTouch (1).position);
			
			// Create a RaycastHit variable to store information about what was hit by the ray.
			RaycastHit floorHit;
			
			// Perform the raycast and if it hits something on the play area layer...
			check=Physics.Raycast (camRay, out floorHit, camRayLength, playAreaMask);

			Ray ray;
			if (check) {
				ray=new Ray (firePoint.position, firePoint.forward);
				if (Time.time >= timeToSpawnBullet) {
					if (Physics.Raycast(camRay, out hit, 1000.0f))
					{
						//Debug.Log ("I HIT "+hit.collider.tag);
						Debug.DrawLine(this.transform.position,hit.point,Color.red,120);
						Effect ();
						if(hit.collider.tag.Equals("Enemy"))
						{
							EnemyHealth enemyHealth = hit.collider.GetComponent <EnemyHealth> ();
							if(enemyHealth != null)
							{
								enemyHealth.TakeDamage (damagePerShot, hit.point);
							}
						}
							//Debug.Log ("360 NOSCOPE YOLOSWAG");
						timeToSpawnBullet=Time.time +1/bulletSpawnrate;
					}
				}
			}


		}
	}

	void Effect(){

		//Instantiate (BulletTrailPrefab,firePoint.position,firePoint.rotation);
		Rigidbody bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as Rigidbody;
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
		GetComponent<AudioSource>().Play ();
		particles.Play ();
		Destroy (bullet.gameObject);
	}
}
