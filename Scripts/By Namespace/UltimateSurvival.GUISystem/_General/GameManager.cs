using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public KeyCode jump { get; set; }
    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode run { get; set; }
    public KeyCode attack { get; set; }
    public KeyCode crouch { get; set; }
    public KeyCode reload { get; set; }
    public KeyCode interact { get; set; }
    public KeyCode openInven { get; set; }
    public KeyCode closeInven { get; set; }
    public KeyCode esc { get; set; }

    void Awake()
    {
        //Singleton pattern
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        /*Assign each keycode when the game starts.
		 * Loads data from PlayerPrefs so if a user quits the game, 
		 * their bindings are loaded next time. Default values
		 * are assigned to each Keycode via the second parameter
		 * of the GetString() function
		 */
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        run = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("run", "Left Shift"));
        attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attack", "Mouse 0"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouch", "C"));
        reload = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("reload", "R"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interact", "E"));
        openInven = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("openInven", "Tab"));
        closeInven = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("closeInven", "Tab"));
        esc = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("esc", "Escape"));


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
