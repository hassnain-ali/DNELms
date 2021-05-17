import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from "@angular/material/snack-bar";

export class SnackBarHandler {
    constructor(private _snackBar: MatSnackBar) {

    }
    horizontalPosition: MatSnackBarHorizontalPosition = 'end';
    verticalPosition: MatSnackBarVerticalPosition = 'top';
    Show(message: string, duration: number = 2500): void {
        console.log(this._snackBar);
        this._snackBar.open(message, "", {
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
            duration: duration
        });
    }
}