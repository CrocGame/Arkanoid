using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private Blocks _blocks;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _size;


    private void Start()
    {
        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 0; j < _size.y; j++)
            {
                var block =Instantiate(_blocks, transform.position+new Vector3(_offset.x+i,0,_offset.y+j), Quaternion.identity);
            }
        }
    }

}
