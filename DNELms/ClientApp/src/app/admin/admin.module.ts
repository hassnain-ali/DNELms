import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminHeaderComponent } from './layout/header/header.component';
import { AdminFooterComponent } from './layout/footer/admin-footer.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AddcoursesComponent } from './pages/courses/addcourses/addcourses.component';
import { AddbannerComponent } from './pages/banners/addbanner/addbanner.component';
import { BannerlistComponent } from './pages/banners/bannerlist/bannerlist.component';
import { AddcategoryComponent } from './pages/categories/addcategory/addcategory.component';
import { CategorieslistComponent } from './pages/categories/categorieslist/categorieslist.component';
import { AddassignmentComponent } from './pages/courses/addassignment/addassignment.component';
import { AddcourselevelComponent } from './pages/courses/addcourselevel/addcourselevel.component';
import { AddcoursetypesComponent } from './pages/courses/addcoursetypes/addcoursetypes.component';
import { AssignmentslistComponent } from './pages/courses/assignmentslist/assignmentslist.component';
import { CourselevellistComponent } from './pages/courses/courselevellist/courselevellist.component';
import { ListcoursetypesComponent } from './pages/courses/listcoursetypes/listcoursetypes.component';
import { AddlanguagesComponent } from './pages/languages/addlanguages/addlanguages.component';
import { LanguageslistComponent } from './pages/languages/languageslist/languageslist.component';
import { AddcityComponent } from './pages/world/addcity/addcity.component';
import { AddcountryComponent } from './pages/world/addcountry/addcountry.component';
import { AddstatesComponent } from './pages/world/addstates/addstates.component';
import { CitieslistComponent } from './pages/world/citieslist/citieslist.component';
import { CountrieslistComponent } from './pages/world/countrieslist/countrieslist.component';
import { StateslistComponent } from './pages/world/stateslist/stateslist.component';
import { AdminComponent } from './admin/admin.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonToggleModule } from '@angular/material/button-toggle';

import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatPaginatorModule } from '@angular/material/paginator';
import { OverlayModule } from '@angular/cdk/overlay';
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';

import { PerfectScrollbarConfigInterface, PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { CourselistComponent } from './pages/courses/courselist/courselist.component';
import { AddquizComponent } from './pages/courses/addquiz/addquiz.component';
import { QuizlistComponent } from './pages/courses/quizlist/quizlist.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SnackBarHandler } from '../Common/SnackBarHandler';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { FileInputConfig, MaterialFileInputModule, NGX_MAT_FILE_INPUT_CONFIG } from 'ngx-material-file-input';
import { MatSortModule } from '@angular/material/sort';
import { RawsqlComponent } from './pages/rawsql/rawsql.component';
import { PagedEntityService } from './PagedEntityService';
import { HttpClient } from '@angular/common/http';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  wheelSpeed: 2,
  wheelPropagation: true,
  minScrollbarLength: 20
};
const config: FileInputConfig = {
  sizeUnit: 'Octet'
};
@NgModule({
  declarations: [
    AdminComponent,
    AdminHeaderComponent,
    AdminFooterComponent,
    DashboardComponent,
    AddcoursesComponent,
    CourselistComponent,
    AddquizComponent,
    QuizlistComponent,
    AddbannerComponent,
    BannerlistComponent,
    StateslistComponent,
    CountrieslistComponent,
    CitieslistComponent,
    AddstatesComponent,
    AddcountryComponent,
    AddcityComponent,
    LanguageslistComponent,
    AddlanguagesComponent,
    ListcoursetypesComponent,
    CourselevellistComponent,
    AddcategoryComponent,
    CategorieslistComponent,
    AddassignmentComponent,
    AddcourselevelComponent,
    AddcoursetypesComponent,
    AssignmentslistComponent,
    RawsqlComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRoutingModule,
    MatSidenavModule,
    MatToolbarModule,
    MatDividerModule,
    MatIconModule,
    MatButtonModule,
    MatExpansionModule,
    PerfectScrollbarModule,
    OverlayModule,
    MatMenuModule,
    MatTooltipModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MaterialFileInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatStepperModule,
    MatSlideToggleModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonToggleModule,
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    },
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { floatLabel: 'auto' } },
    { provide: NGX_MAT_FILE_INPUT_CONFIG, useValue: config },
    { provide: PagedEntityService, deps: [HttpClient] }
  ],

})
export class AdminModule { }
