using UnityEngine;
using static Utilities;

public class BulletBehavour : MonoBehaviour
{

    private Vector3 _direction;

    private Team _team;

    private float speed = 10f;

    public void SetDirection(Vector3 direction) {

        _direction = direction;
    }

    public void SetTeam(Team team)
    {
        _team = team;
    }

    // Update is called once per frame
    void Update()
    {

        if (_direction != null)
        {
            transform.Translate(_direction * speed * Time.deltaTime);

        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "drone" && other.GetComponent<Drone>().Team != _team)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("stage")) {
            Destroy(gameObject);
        }
    }

}
