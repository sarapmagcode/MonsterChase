using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] _characters;

    // Public properties
    private int _charIndex; // Backing field
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    /// <summary>
    /// Singleton pattern
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Make sure only one copy of this is in the game
        }
    }
}
