import { FormControl } from "@angular/forms";

export function ValidationMessages(prop: FormControl): string {
    if (prop.touched) {
        if (prop.invalid && prop.hasError('required')) {
            return "The Value is Required";
        }
        else if (prop.invalid && prop.hasError('minlength')) {
            return prop.errors?.minlength?.requiredLength + " Min length";
        }
        else if (prop.invalid && prop.hasError('maxlength')) {
            return prop.errors?.maxlength?.requiredLength + " Max length";
        }
        else if (prop.invalid && prop.hasError('email')) {
            return "Not a valid Email";
        }
        else if (prop.invalid && prop.hasError('requiredtrue')) {
            return "Need to select true value";
        }
    }
    return "";
}