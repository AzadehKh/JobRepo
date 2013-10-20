/// <reference name="MicrosoftAjax.js"/>

Type.registerNamespace("JobRepo");

//create constructor
JobRepo.UserNameTextbox = function (element) {
    JobRepo.UserNameTextbox.initializeBase(this, [element]);

    this._minLen = null;
}

//define class
JobRepo.UserNameTextbox.prototype = {

    //initialize the UI control
    initialize: function () {
        JobRepo.UserNameTextbox.callBaseMethod(this, 'initialize');

        this._onKeyupHandler = Function.createDelegate(this, this._onKeyup);
        $addHandlers(this.get_element(), { 'keyup': this._onKeyup }, this);



    },

    dispose: function () {
        $clearHandlers(this.get_element());
        JobRepo.UserNameTextbox.callBaseMethod(this, 'dispose');
    },

    //define key press event
    _onKeyup: function (e) {

        //get data text    
        var pass = this.get_element().value;
        this.IsValidData(pass);

    },

    //define properties
    get_minLen: function () {
        return this._minLen;
    },
    set_minLen: function (value) {
        this._minLen = value;
    },



    //define events

    // Create add and remove accessors fot the validated event.
    add_validated: function (handler) {
        this.get_events().addHandler("validated", handler);
    },
    remove_validated: function (handler) {
        this.get_events().removeHandler("validated", handler);
    },

    // Create a function to raise the validated event.
    raisevalidated: function (isvalid) {
        var h = this.get_events().getHandler('validated');
        if (h) h(this, new JobRepo.ValidatedEventArgs(isvalid));
    },

    // Create add and remove accessors for the validating event.
    add_validating: function (handler) {
        this.get_events().addHandler("validating", handler);
    },
    remove_validating: function (handler) {
        this.get_events().removeHandler("validating", handler);
    },

    // Create a function to raise the validating event.
    raisevalidating: function () {
        var h = this.get_events().getHandler('validating');
        if (h) h(this);
    },


    // define extra methods

    IsValidData: function (input) {
        var strInput = new String(input.toString());

        this.raisevalidating();


        if (strInput.length < this.get_minLen) {
            this.raisevalidated(false);
            return;
        }

        // We need to get help from closures to get access to parent 
        //class (this) within callback method(success funtion)
        var $t = this;
        //we can use either var $t = $(this); or var $t = this;
        //but If we use the former , we will need to use $t[0] to get access to its methods, properties and etc
        // for example : $t[0].raisevalidated(true);



        ///////////////////////////////////////////////
        // $t.trigger('validated', [true]);
        // $t.trigger("validating");


        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            url: "Services/UserNameValidationService.asmx/IsValidUserName",
            data: "{'username': '" + strInput + "'}",
            success: function (data) {

                // this.raiseEvent() doesn't work here 
                //as we don't have access to the parent class here directly so we need to use $t
                //debugger;
                // $t.trigger('raisevalidated', true);
                $t.raisevalidated(data.d);


            },
            error: function () {
                alert("Error calling the web service.");
            }
        });
    }
}

//register class as a Sys.Control
JobRepo.UserNameTextbox.registerClass('JobRepo.UserNameTextbox', Sys.UI.Control);

///////////////////////////////////Event Arguments Class//////////////////////////////////////////////

JobRepo.ValidatedEventArgs = function (isvalid) {

    if (arguments.length !== 1) throw Error.parameterCount();

    JobRepo.ValidatedEventArgs.initializeBase(this);

    this._isvalid = isvalid;

}


JobRepo.ValidatedEventArgs.prototype =

{

    get_isvalid: function () {
        return this._isvalid;
    }
};

JobRepo.ValidatedEventArgs.registerClass('JobRepo.ValidatedEventArgs', Sys.EventArgs);  


////////////////////////////////////////////////////////////////////////////////


//notify loaded
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();