using UnityEngine;

public class PJMove : MonoBehaviour {

    private float velocidade = 5.0F;
    public Rigidbody2D rb;
    Vector2 forçaPulo;
    bool podePular = true;
    int moedas = 0;

    void Start() {
        forçaPulo = new Vector2 (0.0f, 15.0f);
    }

    // Update is called once per frame
    void Update() {
        float mX = Input.GetAxisRaw ("Horizontal");
        rb.linearVelocityX = mX * velocidade;

        if (Input.GetKeyDown(KeyCode.Space) && podePular) {
            podePular = false;
            rb.AddForce(forçaPulo, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            podePular = true;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("Moeda")) {
            Destroy(other.gameObject);
            moedas++;
        }
    }
}