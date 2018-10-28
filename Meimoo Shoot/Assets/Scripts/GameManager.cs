using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class GameManager : MonoSingleton<GameManager>
{
    public override void Init()
    {
        base.Init();
    }

    [SerializeField] bool _gameStarted = false;
    [SerializeField] bool _gameRunning = false;
    [SerializeField] int _score = 0;

    public bool GameStarted { get { return _gameStarted; }}
    public bool GameRunning { get { return _gameRunning; }}
    public int Score { get { return _score; }}

	// Use this for initialization
	void Start () 
    {
        UnityARSessionNativeInterface.ARAnchorAddedEvent += AnchorAdded;
        UnityARSessionNativeInterface.ARAnchorRemovedEvent += AnchorRemove;
	}
	
	public void EnemyHit()
    {
        _score++;
    }

    public void CitizentCapture()
    {
        SubtractFromScore(5);
    }

    void SubtractFromScore (int amount)
    {
        _score = Mathf.Max(-1, _score - amount);
    }

    void AnchorAdded(ARPlaneAnchor anchor)
    {
        _gameStarted = true;
        _gameRunning = true;
    }

    void AnchorRemove (ARPlaneAnchor anchor)
    {
        _gameRunning = false;
    }

}
