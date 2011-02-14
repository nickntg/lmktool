//
// This script is called several times, once for each key to be updated.
// The LMK tool sets the following parameters:
//
//  * helper: an instance of the JintHelper class.
//  * key: an instance of the ThalesKey class with info on key to be updated.
//
// This script must execute the update statement against the database to
// update the value of the key. In this example, a Postilion database is updated.
//
var sqlStmt = "UPDATE Crypto_Dea1_Keys SET val_under_ksk='";
sqlStmt = sqlStmt + key.TranslatedValue;
sqlStmt = sqlStmt + "' WHERE name='";
sqlStmt = sqlStmt + key.KeyName;
sqlStmt = sqlStmt + "'";

helper.ExecuteUpdate(sqlStmt);