import {
  AbstractControl,
  ValidationErrors,
  ValidatorFn
} from '@angular/forms';

export function passwordValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.value;

    if (!password) {
      return null;
    }

    const errors: ValidationErrors = {};

    if (!/[A-Z]/.test(password)) {
      errors['passwordUppercase'] = true;
    }

    if (!/[a-z]/.test(password)) {
      errors['passwordLowercase'] = true;
    }

    if (!/[0-9]/.test(password)) {
      errors['passwordNumber'] = true;
    }

    if (!/[^a-zA-Z0-9]/.test(password)) {
      errors['passwordSpecial'] = true;
    }

    return Object.keys(errors).length > 0 ? errors : null;
  };
}