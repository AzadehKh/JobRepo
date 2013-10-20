function searchFailed(ajaxcontext) {

    var response = ajaxcontext.get_response();
    var element = ajaxcontext.get_updateTarget();
    element.innerHTML = "An error has occured , please try again" ;
    
}