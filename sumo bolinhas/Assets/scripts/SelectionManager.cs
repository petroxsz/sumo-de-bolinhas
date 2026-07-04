using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    public Image player1Image;
    public Image player2Image;

    public TMP_Text player1Name;
    public TMP_Text player2Name;

    private BolinhaData[] bolinhas;

    private int p1Index = 0;
    private int p2Index = 1;

    private bool p1Confirmed = false;
    private bool p2Confirmed = false;

    private SelectionInputActions inputActions;

    private void Awake()
    {
        inputActions = new SelectionInputActions();
    }

    private void Start()
    {
        bolinhas = Resources.LoadAll<BolinhaData>("Bolinhas");
        AtualizarUI();
    }

    private void OnEnable()
    {
        inputActions.Selection.Enable();

        inputActions.Selection.P1Next.performed += ctx => NextP1();
        inputActions.Selection.P1Previous.performed += ctx => PrevP1();
        inputActions.Selection.P2Next.performed += ctx => NextP2();
        inputActions.Selection.P2Previous.performed += ctx => PrevP2();

        inputActions.Selection.P1Confirm.performed += ctx => ConfirmP1();
        inputActions.Selection.P2Confirm.performed += ctx => ConfirmP2();
    }

    private void OnDisable()
    {
        inputActions.Selection.Disable();
    }

    void NextP1() { if (!p1Confirmed) { p1Index = (p1Index + 1) % bolinhas.Length; AtualizarUI(); } }
    void PrevP1() { if (!p1Confirmed) { p1Index--; if (p1Index < 0) p1Index = bolinhas.Length - 1; AtualizarUI(); } }

    void NextP2() { if (!p2Confirmed) { p2Index = (p2Index + 1) % bolinhas.Length; AtualizarUI(); } }
    void PrevP2() { if (!p2Confirmed) { p2Index--; if (p2Index < 0) p2Index = bolinhas.Length - 1; AtualizarUI(); } }

    void ConfirmP1()
    {
        if (p1Confirmed) return;

        p1Confirmed = true;
        GameManager.Instance.player1.bolinhaEscolhida = bolinhas[p1Index];

        VerificarStart();
    }

    void ConfirmP2()
    {
        if (p2Confirmed) return;

        p2Confirmed = true;
        GameManager.Instance.player2.bolinhaEscolhida = bolinhas[p2Index];

        VerificarStart();
    }

    void VerificarStart()
    {
        if (p1Confirmed && p2Confirmed)
        {
            SceneManager.LoadScene("GameplayScene");
        }
    }

    void AtualizarUI()
    {
        player1Image.sprite = bolinhas[p1Index].sprite;
        player2Image.sprite = bolinhas[p2Index].sprite;

        player1Name.text = bolinhas[p1Index].nome;
        player2Name.text = bolinhas[p2Index].nome;
    }
}