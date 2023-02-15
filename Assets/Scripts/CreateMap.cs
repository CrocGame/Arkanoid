using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private Blocks _blocks;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _size;

    [SerializeField] private Buffs[] _buffs;
    private int sumValueBuffs;

    public GameObject CanvasDamage;

    private void Start()
    {
        foreach (var buff in _buffs)
        {
            sumValueBuffs+=buff.ValueChance;
        }
        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 0; j < _size.y; j++)
            {
                var block =Instantiate(_blocks, transform.position+new Vector3(_offset.x+i,0,_offset.y+j), Quaternion.identity);
                block.CanvasDamage = CanvasDamage;
                block.OnDestroy += CreateBuffs;
            }
        }
    }

    private void CreateBuffs(Blocks blocks)
    {
        float chanse = Random.Range(0f, 1f);
        if (chanse<0.1f)
        {
            int position = Random.Range(0, sumValueBuffs);
            int sum = 0;
            foreach (var buff in _buffs)
            {
                if (position <= sum)
                {
                    Instantiate(buff, blocks.transform.position, buff.transform.rotation);
                    break;
                }
                else
                {
                    sum += buff.ValueChance;
                }
            }
            blocks.OnDestroy -= CreateBuffs;
        }
        
    }
}
