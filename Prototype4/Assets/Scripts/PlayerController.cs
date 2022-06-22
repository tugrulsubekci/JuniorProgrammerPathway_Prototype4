using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;

    public bool hasPowerup;
    public bool hasPowerup2;
    private float powerupStrength = 10.0f;
    public GameObject powerupIndicator;
    public GameObject powerup2Indicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        powerup2Indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(speed * verticalInput * focalPoint.transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(nameof(PowerupCountdownRoutine));
            powerupIndicator.SetActive(true);
        }
        if(other.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(nameof(Powerup2CountdownRoutine));
            powerup2Indicator.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
    IEnumerator Powerup2CountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup2 = false;
        powerup2Indicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>(); 
            Vector3 awayFromPlayer = collision.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
