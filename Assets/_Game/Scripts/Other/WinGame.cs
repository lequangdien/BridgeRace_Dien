using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstranName.Player))
        {
            UIManager.Instance.WinGame();
          
        }
        if (other.CompareTag(ConstranName.Bot))
        {
            UIManager.Instance.LoseGame();
        }
    }
}
