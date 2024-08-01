using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void OnDevinBooker ()
    {
        SceneManager.LoadScene("Booker");
    }

    public void OnLebronJames ()
    {
        SceneManager.LoadScene("Lebron");
    }

    public void OnKevinDurant ()
    {
        SceneManager.LoadScene("Durant");
    }
}
