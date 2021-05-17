import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FileInput } from 'ngx-material-file-input';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { SnackBarHandler } from 'src/app/Common/SnackBarHandler';
import { ValidationMessages } from 'src/app/Common/Validations';
import { Category } from 'src/app/Models/Category';

@Component({
  selector: 'app-addcategory',
  templateUrl: './addcategory.component.html',
  styleUrls: ['./addcategory.component.css']
})
export class AddcategoryComponent implements OnInit {
  CategoryForm: FormGroup;
  IsSubmitting: boolean = false;
  snackBarHandler: SnackBarHandler;
  Categries: string[] = [
    'Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 'Delaware',
    'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky',
    'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi',
    'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico',
    'New York', 'North Carolina', 'North Dakota', 'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania',
    'Rhode Island', 'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
    'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'
  ];
  constructor(_snackBar: MatSnackBar, private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string,
    private authService: AuthorizeService) {
    this.snackBarHandler = new SnackBarHandler(_snackBar);
    this.CategoryForm = this.NewForm();
    // this.CategoryForm.controls.IsActive.setValue("true");
  }

  ngOnInit(): void {
  }
  SaveCategory(): void {
    if (this.CategoryForm.valid) {
      let category: Category = this.CategoryForm.value;
      this.IsSubmitting = true;
      console.log(this.baseUrl);
      this.authService.getAccessToken().subscribe(token => {
        let headers = new HttpHeaders();
        headers.set("Auhtorization", `Bearer ${token}`);
        this.http.post(this.baseUrl + "/api/CourseCategory", category, { headers: headers }).subscribe(function (result) {
          this.IsSubmitting = false;
          this.snackBarHandler.Show("Category Saved Successfully");
          this.CleaForm();
        });
      });
    } else {
      this.IsSubmitting = false;
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
      IsActive: new FormControl(true, []),
      SmallImage: new FormControl(FileInput, []),
      BannerImage: new FormControl(FileInput, [])
    });
  }
  CleaForm(): void {
    // this.CategoryForm.reset();
  }
}

