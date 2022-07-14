using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authorization : MonoBehaviour {

    [SerializeField]private AuthorizationUI authorizationUI;

    public void Authorize() {
        if (GameManager.instance.DB.isRegistered(authorizationUI.nickname.text, authorizationUI.password.text)) {
            GameManager.instance.ChangeScene(GameManager.instance.launcherSceneNumber);
        }
        else {
            Debug.LogError("Неверный логин или пароль");
        }
    }
}
