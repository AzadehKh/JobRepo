/// <reference name="MicrosoftAjax.js"/>

Type.registerNamespace("JobRepo");

//create constructor
JobRepo.PasswordStrengthValidationComponent = function () {
    JobRepo.PasswordStrengthValidationComponent.initializeBase(this);
}

//define class
JobRepo.PasswordStrengthValidationComponent.prototype = {
    initialize: function () {
        //add custom initialization here
        JobRepo.PasswordStrengthValidationComponent.callBaseMethod(this, 'initialize');
    },

    CheckPasswordStrength: function (password) {
        var strPass = new String(password.toString());
        if (strPass.length < 6) {
            return "Weak";
        }
        else {
            if (strPass.length < 8) {
                return "Medium";
            }
            else {
                return "Strong";
            }
        }
    },

    dispose: function () {
        //add custom dispose actions here
        JobRepo.PasswordStrengthValidationComponent.callBaseMethod(this, 'dispose');
    }
}

//register class as a Sys.Component
JobRepo.PasswordStrengthValidationComponent.registerClass(
    'JobRepo.PasswordStrengthValidationComponent', Sys.Component);

//notify script loaded
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();