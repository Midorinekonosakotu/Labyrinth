using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // =========================
    // ■ シングルトン
    // =========================
    public static GameState Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // =========================
    // ■ ゲーム状態
    // =========================
    public enum State
    {
        Title,
        Playing,
        Result
    }

    public State CurrentState { get; private set; }

    // =========================
    // ■ プレイヤー状態
    // =========================
    public bool HasKey { get; private set; } = false;

    public int HintCount { get; private set; } = 0;
    public int MaxHintCount = 3;

    // =========================
    // ■ イベント
    // =========================
    public event Action OnKeyChanged;
    public event Action OnHintChanged;
    public event Action<State> OnStateChanged;

    // =========================
    // ■ 初期化
    // =========================
    public void InitGame()
    {
        HasKey = false;
        HintCount = 0;
        SetState(State.Playing);

        OnKeyChanged?.Invoke();
        OnHintChanged?.Invoke();
    }

    // =========================
    // ■ 状態変更
    // =========================
    public void SetState(State newState)
    {
        CurrentState = newState;
        OnStateChanged?.Invoke(CurrentState);
    }

    // =========================
    // ■ 鍵取得
    // =========================
    public void GetKey()
    {
        HasKey = true;
        OnKeyChanged?.Invoke();
    }

    // =========================
    // ■ 鍵使用
    // =========================
    public bool TryUseKey()
    {
        if (!HasKey) return false;

        HasKey = false;
        OnKeyChanged?.Invoke();
        return true;
    }

    // =========================
    // ■ ヒント使用
    // =========================
    public bool TryUseHint()
    {
        if (HintCount >= MaxHintCount) return false;

        HintCount++;
        OnHintChanged?.Invoke();
        return true;
    }

    // =========================
    // ■ クリア
    // =========================
    public void ClearGame()
    {
        SetState(State.Result);
    }
}