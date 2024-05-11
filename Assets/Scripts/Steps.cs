using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Steps : MonoBehaviour
{
    public GameObject[] passos; // Array de GameObjects representando cada passo
    private int passoAtual = 1; // Índice do passo atual


    void Start()
    {


    }

    public void AvancarPasso()
    {
        passoAtual++;

        if (passoAtual == 2)
        {
            step_02();
        }
        else if (passoAtual == 3)
        {
            step_03();
        }
        else if (passoAtual == 4)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }


    public void step_02()
    {
        GameObject botaoDesligar = FindGameObjectsAll("input_button_08_01");
        GameObject step_2_text = FindGameObjectsAll("step_2_text");
        Outline OLbotaoDesligar = botaoDesligar.GetComponent<Outline>();
        OLbotaoDesligar.enabled = true;
        Animator botaoDesligarAnimator = botaoDesligar.GetComponent<Animator>();
        botaoDesligarAnimator.SetBool("Runing", true);
        step_2_text.SetActive(true);
        StartCoroutine(ScaleUp(step_2_text));
    }
    public void step_03()
    {
        GameObject botaoDesligar = FindGameObjectsAll("input_button_08_01");
        GameObject chaveSeletora = FindGameObjectsAll("input_point_11");
        GameObject baseChaveSeletora = FindGameObjectsAll("input_11");
        GameObject step_2_text = FindGameObjectsAll("step_2_text");
        GameObject step_3_text = FindGameObjectsAll("step_3_text");
        Outline OLbotaoDesligar = botaoDesligar.GetComponent<Outline>();
        OLbotaoDesligar.enabled = false;
        Animator botaoDesligarAnimator = botaoDesligar.GetComponent<Animator>();
        botaoDesligarAnimator.SetBool("Runing", false);
        step_2_text.SetActive(false);
        step_3_text.SetActive(true);
        StartCoroutine(ScaleUp(step_3_text));
        Animator chaveSeletoraAnimator = baseChaveSeletora.GetComponent<Animator>();
        chaveSeletoraAnimator.SetBool("Runing", true);
        Outline OLchaveSeletora = baseChaveSeletora.GetComponent<Outline>();
        OLchaveSeletora.enabled = true;

    }



    private IEnumerator ScaleUp(GameObject obj)
    {
        float duration = 0.5f; // Duração da animação
        float timer = 0f;
        Vector3 initialScale = obj.transform.localScale;

        while (timer < duration)
        {
            float scale = Mathf.Lerp(0f, 1f, timer / duration); // Interpola a escala
            obj.transform.localScale = initialScale * scale;
            timer += Time.deltaTime;
            yield return null;
        }
        obj.transform.localScale = initialScale;
    }

    void Update()
    {
        // Código de atualização
    }

    public static GameObject FindGameObjectsAll(string name) => Resources.FindObjectsOfTypeAll<GameObject>().First(x => x.name == name);
}
