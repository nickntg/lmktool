//
// This script returns an SQL connection string to the database
// which holds the HSM keys encrypted under the old LMK storage.
// The connection string is formated as per ADO.Net rules.
//
return "data source=192.168.1.66;initial catalog=realtime;persist security info=False;user id=sa;password=password";