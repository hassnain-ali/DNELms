import { HttpClient, HttpEventType, HttpHandler, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { FileInput } from 'ngx-material-file-input';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Convert } from 'src/app/Common/Convert';
import { RequestHandler } from 'src/app/Common/RequestHandler';
import { SnackBarHandler } from 'src/app/Common/SnackBarHandler';
import { ValidationMessages } from 'src/app/Common/Validations';
import { Category, CategoryVM } from 'src/app/Models/Category';

@Component({
  selector: 'app-addcategory',
  templateUrl: './addcategory.component.html',
  styleUrls: ['./addcategory.component.css']
})
export class AddcategoryComponent implements OnInit {
  CategoryForm: FormGroup;
  IsBusy: boolean = false;
  snackBarHandler: SnackBarHandler;
  progress: number
  Categries: any[] = [];
  constructor(_snackBar: MatSnackBar, private http: HttpClient, router: Router) {
    this.snackBarHandler = new SnackBarHandler(_snackBar);
    this.CategoryForm = this.NewForm();
    this.CategoryForm.controls.IsActive.setValue("true");
  }

  ngOnInit(): void {
    this.IsBusy = true;
    this.http.get('/api/CourseCategory/GetDDL/0').subscribe((s: any) => {
      console.log(s);
      this.Categries = s.Data.$values;
      this.IsBusy = false;
    });
  }
  SaveCategory(): void {
    if (this.CategoryForm.valid) {
      var formData = Convert.toFormData(this.CategoryForm.value);
      let BannerImage = Convert.toFile(this.CategoryForm.value.BannerImageFile);
      let SmallImage = Convert.toFile(this.CategoryForm.value.SmallImageFile);
      this.IsBusy = true;
      if (BannerImage != null) {
        formData.append("BannerImageFile", BannerImage);
      }
      if (SmallImage != null) {
        formData.append("SmallImageFile", SmallImage);
      }
      this.http.post('api/CourseCategory', formData, { reportProgress: true }).subscribe((event: any) => {
        console.log(event);
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
          console.log(this.progress);
        } else if (event instanceof HttpResponse) {
          console.log(event);
        }
        if (event.Success == true) {
          this.CleaForm();
        }
        this.IsBusy = false;
      }, (error) => {
        console.log(error);
      });
    } else {
      this.IsBusy = false;
    }
  }
  GetRequiredMessage(prop: FormControl): string {
    return ValidationMessages(prop);
  }
  NewForm(): FormGroup {
    return new FormGroup({
      Id: new FormControl(0, []),
      Name: new FormControl('', [Validators.required, Validators.minLength(3)]),
      ParentId: new FormControl(0, []),
      IsActive: new FormControl('', [Validators.required]),
      SmallImageFile: new FormControl('', []),
      BannerImageFile: new FormControl('', [])
    });
  }
  CleaForm(): void {
    this.CategoryForm.reset();
  }
}

