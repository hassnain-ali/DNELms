import { HttpClient, HttpEventType } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Convert } from 'src/app/Common/Convert';
import { SnackBarHandler } from 'src/app/Common/SnackBarHandler';
import { ValidationMessages } from 'src/app/Common/Validations';

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
  constructor(_snackBar: MatSnackBar,
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute) {
    this.snackBarHandler = new SnackBarHandler(_snackBar);
    this.CategoryForm = this.NewForm();
    this.CategoryForm.controls.IsActive.setValue("true");
  }

  ngOnInit(): void {
    this.IsBusy = true;
    this.route.params.subscribe(s => {
      this.SetById(s["id"]);
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
      this.http.post('api/CourseCategory', formData, { reportProgress: true, observe: 'events' }).subscribe((event: any) => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event.type === HttpEventType.Response) {
          console.log(event);
          if (event.body.Success == true) {
            this.CleaForm();
            this.snackBarHandler.Show('Category Saved Successfully.');
            this.IsBusy = false;
            this.router.navigateByUrl('/admin/add-category');
          }
        }
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
    let pId = this.CategoryForm.controls.ParentId.value;
    this.CategoryForm.reset();
    this.CategoryForm.controls.IsActive.setValue("true");
    this.CategoryForm.controls.Id.setValue(0);
    this.CategoryForm.controls.ParentId.setValue(pId);
  }
  SetById(id: number) {
    this.IsBusy = true;
    if (!isNaN(id) && id > 0) {
      this.http.get('/api/CourseCategory/' + id).subscribe((s: any) => {
        let data = s.Data;
        this.PreBind(data.Id);
        this.CategoryForm.controls.Id.setValue(data.Id);
        this.CategoryForm.controls.Name.setValue(data.Name);
        this.CategoryForm.controls.IsActive.setValue((<string>data.IsActive).toString());
        this.CategoryForm.controls.ParentId.setValue((<number>data.ParentId).toString());
      });
    } else {
      this.PreBind(0);
    }
  }
  PreBind(id: number) {
    this.http.get('/api/CourseCategory/GetDDL/' + id).subscribe((s: any) => {
      this.Categries = s.Data.$values;
      this.IsBusy = false;
    });
  }
}

