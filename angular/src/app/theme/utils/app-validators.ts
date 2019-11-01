import { FormGroup, FormControl, ValidatorFn, AbstractControl } from '@angular/forms';
import { map } from 'rxjs/operators';

export function emailValidator(control: FormControl): { [key: string]: any } {
    var emailRegexp = /[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/;
    if (control.value && !emailRegexp.test(control.value)) {
        return { invalidEmail: true };
    }
}

export function phoneNumberValidator(control: FormControl): { [key: string]: any } {
    var phoneRegexp = /\D*([2-9]\d{2})(\D*)([2-9]\d{2})(\D*)(\d{4})\D*/;
    if (control.value && !phoneRegexp.test(control.value)) {
        return { invalidPhoneNumber: true };
    }
}
export function urlValidator(type: string): ValidatorFn {
    var facebookRegexp = /http(s)?:\/\/(www\.)?(facebook|fb)\.com\/[A-z0-9_\-\.]+\/?/;
    var twitterRegexp = /http(?:s)?:\/\/(?:www\.)?twitter\.com\/([a-zA-Z0-9_]+)/;
    var instagramRegexp = /https?:\/\/(www\.)?instagram\.com\/([A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\.(?!\.))){0,28}(?:[A-Za-z0-9_]))?)/;
    var linkedInRegexp =/http(?:s)?:\/\/(?:www\.)?linkedin\.com\/([a-zA-Z0-9_]+)/;
    var websiteRegexp = /^((https?|http):\/\/)?(www.)?[a-z0-9]+\.[a-z]+(\/[a-zA-Z0-9#]+\/?)*$/;

    return (control: AbstractControl): { [key: string]: boolean } | null => {
        switch (type) {
            case 'facebook':
                if (control.value && !facebookRegexp.test(control.value)) {
                    return { invalidUrl: true };
                }
                break;
            case 'twitter':
                if (control.value && !twitterRegexp.test(control.value)) {
                    return { invalidUrl: true };
                }
                break;
            case 'instagram':
                if (control.value && !instagramRegexp.test(control.value)) {
                    return { invalidUrl: true };
                }
                break;
            case 'linkedin':
                if (control.value && !linkedInRegexp.test(control.value)) {
                    return { invalidUrl: true };
                }
                break;
            case 'website':
                if (control.value && !websiteRegexp.test(control.value)) {
                    return { invalidUrl: true };
                }
                break;
        }
        return null;
    }
}
export function matchingPasswords(passwordKey: string, passwordConfirmationKey: string) {
    return (group: FormGroup) => {
        let password = group.controls[passwordKey];
        let passwordConfirmation = group.controls[passwordConfirmationKey];
        if (password.value !== passwordConfirmation.value) {
            return passwordConfirmation.setErrors({ mismatchedPasswords: true })
        }
    }
}