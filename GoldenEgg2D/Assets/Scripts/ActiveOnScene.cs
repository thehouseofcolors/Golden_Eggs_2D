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
        Debug.Log("PlayerController etkinleþtirildi.");
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
        Debug.Log("PlayerController devre dýþý býrakýldý.");
        CanvasManager.Instance.CanvasStatusChanged -= HandleStatusChange;
    }
    private void Awake()
    {

    }
    private void OnDestroy()
    {
        Debug.Log("ChickenController etkinleþtirildi.");
        CanvasManager.Instance.CanvasStatusChanged += HandleStatusChange;

    }
    private void Start()
    {
        HandleStatusChange(CanvasStatus.Play);
    }
    public void HandleStatusChange(CanvasStatus status)
    {
        Debug.Log($"HandleStatusChange çaðrýldý: {status}"); // Durum deðiþikliðini logla

        // Eðer "Play" durumu ise, objeyi aktif et
        if (status == CanvasStatus.Play)
        {
            Debug.Log("ChickenController aktif edildi."); // Log ekle
            gameObject.SetActive(true);
        }
        else { gameObject.SetActive(false); }
    }

    private void OnDisable()
    {
        Debug.Log("ChickenController devre dýþý býrakýldý.");
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
