//----------------------------------------------------------------------
// じゃんけんメイン
//----------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//----------------------------------------------------------------------
// じゃんけんの種類
//----------------------------------------------------------------------
public enum JANKEN_TYPE
{
	GU,
	TYOKI,
	PA,
	MAX
};

//----------------------------------------------------------------------
// メインクラス
//----------------------------------------------------------------------
public class JankenMain : MonoBehaviour
{
	[SerializeField]Button[]			m_janken_btn;
	[SerializeField]Image[]				m_janken_hands;
	[SerializeField]Image				m_enemy_hand;
	
	const string JANKEN_URL = "https://www.yahoo.co.jp/";
	
	//----------------------------------------------------------------------
	// スタート
	//----------------------------------------------------------------------
	void Start()
	{
		m_janken_btn[ (int)JANKEN_TYPE.GU    ].onClick.AddListener( OnClickJankenGU );
		m_janken_btn[ (int)JANKEN_TYPE.TYOKI ].onClick.AddListener( OnClickJankenTYOKI );
		m_janken_btn[ (int)JANKEN_TYPE.PA    ].onClick.AddListener( OnClickJankenPA );
	}
	
	//----------------------------------------------------------------------
	// アップデート
	//----------------------------------------------------------------------
	void Update()
	{
		
	}
	
	//----------------------------------------------------------------------
	// グーボタンを押したとき
	//----------------------------------------------------------------------
	void OnClickJankenGU()
	{
		Debug.Log("GU");
		
		StartCoroutine( ConnectJanken( JANKEN_URL, JANKEN_TYPE.GU ) );
	}
	//----------------------------------------------------------------------
	// チョキボタンを押したとき
	//----------------------------------------------------------------------
	void OnClickJankenTYOKI()
	{
		Debug.Log("TYOKI");

		StartCoroutine( ConnectJanken( JANKEN_URL, JANKEN_TYPE.TYOKI ) );
	}
	//----------------------------------------------------------------------
	// パーボタンを押したとき
	//----------------------------------------------------------------------
	void OnClickJankenPA()
	{
		Debug.Log("PA");

		StartCoroutine( ConnectJanken( JANKEN_URL, JANKEN_TYPE.PA ) );
	}
	
	//----------------------------------------------------------------------
	// 通信
	//----------------------------------------------------------------------
	IEnumerator ConnectJanken( string url, JANKEN_TYPE my_type )
	{
		WWW www = new WWW( url );
		
		yield return www;
		
		Debug.Log( www.bytes.Length.ToString() );
		
		JANKEN_TYPE enemy_type = (JANKEN_TYPE)( www.bytes.Length % (int)JANKEN_TYPE.MAX );
		
		Result( enemy_type );
	}
	
	//----------------------------------------------------------------------
	// 敵の手
	//----------------------------------------------------------------------
	void Result( JANKEN_TYPE enemy_type )
	{
		m_enemy_hand.sprite = m_janken_hands[ (int)enemy_type ].sprite;
	}
}
