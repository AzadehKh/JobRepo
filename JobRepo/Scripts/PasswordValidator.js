
function ValidatePassword(source, arguments) {

    var data = arguments.Value.split('');

    //start by setting false
    arguments.IsValid = false;

    //check length
    if(data.length < 6 || data.length > 10) return;
    
    var hasuppercase = false; var haslowercase = false; var hasnumber = false;

    for (var c in data) {
        if (data[c] >= 'A' && data[c] <= 'Z') {
            hasuppercase = true;
        } else if (data[c] >= 'a' && data[c] <= 'z') {
            haslowercase = true;
        } else if (data[c] >= '0' && data[c] <= '9') {
            hasnumber = true;
        }
        if (hasuppercase && haslowercase && hasnumber) {
                arguments.IsValid = true;
                break;
        }
    }
}