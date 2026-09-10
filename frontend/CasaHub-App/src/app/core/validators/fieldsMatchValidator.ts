import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function fieldsMatchValidator(
  field: string,
  confirmationField: string
): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.get(field)?.value;
    const confirmationValue = control.get(confirmationField)?.value;

    if (!value || !confirmationValue) {
      return null;
    }

    return value === confirmationValue
      ? null
      : { fieldsMismatch: true };
  };
}