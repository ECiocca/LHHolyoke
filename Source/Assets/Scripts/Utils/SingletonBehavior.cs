using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif

/// <summary>
/// By extending this instead of Mono Behavior, a class is treated as a singleton and created when first refferenced.
/// If the reference is not defined the project is searched for the behavior and attached if necessary.
/// </summary>
/// <typeparam name="T">The type of the singletop Behavior</typeparam>

public abstract class SingletonBehavior<T> : MonoBehaviour
    where T : SingletonBehavior<T>, new()
{

	//check if we have an instance of the singleton (have we been spawned?)
	public static bool HasInstance()
	{
		return _instance != null;
	}

    private static T _instance;
    public static T Instance
    {
        get
        {
            #region debug
            //#if UNITY_EDITOR
            //            var st = new StackTrace();
            //            for (var i = 0; i < st.FrameCount; ++i)
            //            {
            //                var method = st.GetFrame(i).GetMethod().Name;
            //                switch (method)
            //                {
            //                    case "OnEnable":
            //                    case "Awake":
            //                    case "OnDestroy":
            //                    case "OnDisable":
            //                        var reflectedType = st.GetFrame(i).GetMethod().ReflectedType;
            //                        if (reflectedType != null)
            //                        {
            //                            var log = "EventManager instance offending caller: " + reflectedType.Name +
            //                                      "." + method + "()";
            //                            Debug.LogWarning(log);
            //                        }
            //                        break;
            //                }
            //            }
            //#endif
            #endregion

            string typeName = typeof(T).ToString();

            if (_instance == null)
            {
                T[] foundObjects = Resources.FindObjectsOfTypeAll<T>();
                if( foundObjects.Length > 0)
                {
#if UNITY_EDITOR
                    for ( int i = 0; i < foundObjects.Length; i++ )
                    {
                        if (!EditorUtility.IsPersistent(foundObjects[i]))
                        {
                            _instance = foundObjects[i];
                        }
                    }
#else
                    _instance = foundObjects[0];
#endif
                }
                if (_instance == null)
                {
                    GameObject gob = new GameObject(typeName);
                    _instance = gob.AddComponent<T>();
                }
            }
            if (_instance == null)
            {
                Debug.LogError(typeName + "._instance is null!.");
            }
            return _instance;
        }
    }

    //  This will check if we have an instance (that is not being destroyed) but will not create one.
    public static bool HaveInstance()
    {
        if (_instance != null)
            return true;

        //Will find inactive objects
        return Resources.FindObjectsOfTypeAll<T>().Length != 0;
    }

    public virtual void Reset()
    {
        _instance = null;
    }

}
