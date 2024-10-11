using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnScene : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        Debug.Log("PlayerController etkinle�tirildi.");
        CanvasManager.Instance.CanvasStatusChanged += HandleStatusChange;
    }
    private void Start()
    {
        HandleStatusChange(CanvasManager.Instance.currentCanvasStatus);
    }
    public void HandleStatusChange(CanvasStatus status)
    {
        switch (status) { case CanvasStatus.Play: gameObject.SetActive(true); break; default: gameObject.SetActive(false); break; }
    }
    private void OnDestroy()
    {
        Debug.Log("PlayerController devre d��� b�rak�ld�.");
        CanvasManager.Instance.CanvasStatusChanged -= HandleStatusChange;
    }
    private void Awake()
    {

    }
    private void OnDestroy()
    {
        Debug.Log("ChickenController etkinle�tirildi.");
        CanvasManager.Instance.CanvasStatusChanged += HandleStatusChange;

    }
    private void Start()
    {
        HandleStatusChange(CanvasStatus.Play);
    }
    public void HandleStatusChange(CanvasStatus status)
    {
        Debug.Log($"HandleStatusChange �a�r�ld�: {status}"); // Durum de�i�ikli�ini logla

        // E�er "Play" durumu ise, objeyi aktif et
        if (status == CanvasStatus.Play)
        {
            Debug.Log("ChickenController aktif edildi."); // Log ekle
            gameObject.SetActive(true);
        }
        else { gameObject.SetActive(false); }
    }

    private void OnDisable()
    {
        Debug.Log("ChickenController devre d��� b�rak�ld�.");
        CanvasManager.Instance.CanvasStatusChanged -= HandleStatusChange;
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
