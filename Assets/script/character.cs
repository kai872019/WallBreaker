using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class character : MonoBehaviour
{

    private Vector2 _StartPositon;
    private bool _IsFly = false;
    private GameObject[] _Dotobjects = new GameObject[20];

    public float MaxPullDistance = 1;

    public float FlyFrce = 20;

    public GameObject Dotprefab;

    public float DotTimeInterval = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        _StartPositon = transform.position;


        for(int i=0;i<_Dotobjects.Length;i++)
        {
            _Dotobjects[i] = Instantiate(Dotprefab);

            _Dotobjects[i].transform.parent = transform;
            _Dotobjects[i].SetActive(false);
        }
    }
   
    private void OnMouseDrag()
    {
       
        
        if (_IsFly) return;
        Vector2 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(_StartPositon, Position) > MaxPullDistance)
        {
            Position = (Position - _StartPositon).normalized * MaxPullDistance + _StartPositon;
        }
           

        if (Position.x > _StartPositon.x)
            Position.x = _StartPositon.x;

        transform.position = Position;

        UpdateObjects();
    }

    private void OnMouseUp()
    {
        if (_IsFly) return;
       
        var Force = (_StartPositon - (Vector2)transform.position) * FlyFrce;

        var Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.isKinematic = false;
        Rigidbody2D.AddForce(Force, ForceMode2D.Impulse);

        Invoke(nameof(NextCharacter), 1);

        for (int i = 0; i < _Dotobjects.Length; i++)
        {
            _Dotobjects[i].SetActive(false);

        }

        _IsFly = true;
    }

    private void OnCollisonEnter2D(Collider collison)
    {
        
    }

    public void NextCharacter()
    {
        Destroy(gameObject, 5);
        Levelmanager.Instance.NextCharacter();
    }
    private void UpdateObjects()
    {
      
        var Force = (_StartPositon - (Vector2)transform.position) * FlyFrce;
        var CurrentTime = DotTimeInterval;
        for(int i = 0;i< _Dotobjects.Length; i++) 
        {
            _Dotobjects[i].SetActive(true);
            var Position = new Vector2();
            Position.x = (transform.position.x + Force.x * CurrentTime);
            Position.y = (transform.position.y + Force.y * CurrentTime) - (Physics2D.gravity.magnitude * CurrentTime * CurrentTime)/2;

            _Dotobjects[i].transform.position = Position;
            CurrentTime += DotTimeInterval;

            
        }
    }

}
