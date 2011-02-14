//
// This script is called once to read keys to be migrated from the old
// LMKs to the new LMKs. The LMK tool sets the following parameters:
//
//  * helper: an instance of the JintHelper class.
//
// This script should read the keys from the database and also select
// which keys should be migrated. In this example, KEKs are selected from
// a Postilion database and the key type is set according to the key domain.
//

// Clear keys.
helper.ClearKeys();

// Get all keys.
helper.ExecuteSelect("SELECT * FROM Crypto_Dea1_Keys");

// Loop in keys.
var i;
for (i=0; i<helper.RecCount(); i++) {
    var keyName;
    var keyValue;
    var keyType;
    var keySubType;

    // Get key information.
    keyName = helper.Item("name", i);
    keyValue = helper.Item("val_under_ksk", i);
    keyType = helper.Item("key_type", i);
    keySubType = helper.Item("key_sub_type", i);

    // Filter out everything except KEKs.
    if (keyType == "0")
      // Choose key type (DOMAIN KEKs are ZMKs, TERMINAL KEKs are TMKs).
      if (keySubType == "0")
        helper.AddKey (keyName, "U" + keyValue, "000");
      else
        helper.AddKey (keyName, "U" + keyValue, "002");
}