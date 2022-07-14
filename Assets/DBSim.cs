using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBSim : IDataBase
{
    private Dictionary<string, string> DB;
    public DBSim() {
        DB = new Dictionary<string, string>();
        DB.Add("Admin","1423");
    }
    public bool isRegistered(string nickname, string password) {
        if (DB.TryGetValue(nickname, out string DBPass)) {
            if(DBPass == password) {
                return true;
            }
        }
        return false;
    }
}
