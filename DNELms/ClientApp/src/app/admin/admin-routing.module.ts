import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddcoursesComponent } from './pages/courses/addcourses/addcourses.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AddbannerComponent } from './pages/banners/addbanner/addbanner.component';
import { BannerlistComponent } from './pages/banners/bannerlist/bannerlist.component';
import { AddcategoryComponent } from './pages/categories/addcategory/addcategory.component';
import { CategorieslistComponent } from './pages/categories/categorieslist/categorieslist.component';
import { AddassignmentComponent } from './pages/courses/addassignment/addassignment.component';
import { AddcourselevelComponent } from './pages/courses/addcourselevel/addcourselevel.component';
import { AddcoursetypesComponent } from './pages/courses/addcoursetypes/addcoursetypes.component';
import { AssignmentslistComponent } from './pages/courses/assignmentslist/assignmentslist.component';
import { CourselevellistComponent } from './pages/courses/courselevellist/courselevellist.component';
import { CourselistComponent } from './pages/courses/courselist/courselist.component';
import { ListcoursetypesComponent } from './pages/courses/listcoursetypes/listcoursetypes.component';
import { AddquizComponent } from './pages/courses/addquiz/addquiz.component';
import { QuizlistComponent } from './pages/courses/quizlist/quizlist.component';
import { AddlanguagesComponent } from './pages/languages/addlanguages/addlanguages.component';
import { LanguageslistComponent } from './pages/languages/languageslist/languageslist.component';
import { AddcityComponent } from './pages/world/addcity/addcity.component';
import { AddcountryComponent } from './pages/world/addcountry/addcountry.component';
import { AddstatesComponent } from './pages/world/addstates/addstates.component';
import { CitieslistComponent } from './pages/world/citieslist/citieslist.component';
import { CountrieslistComponent } from './pages/world/countrieslist/countrieslist.component';
import { StateslistComponent } from './pages/world/stateslist/stateslist.component';
import { RawsqlComponent } from './pages/rawsql/rawsql.component';

const routes: Routes = [
  { path: "", component: DashboardComponent, },
  { path: "add-course", component: AddcoursesComponent },
  { path: "add-banner", component: AddbannerComponent },
  { path: "banner-list", component: BannerlistComponent },
  { path: "add-category", component: AddcategoryComponent },
  { path: "add-category/:id", component: AddcategoryComponent },
  { path: "category-list", component: CategorieslistComponent },
  { path: "add-assignment", component: AddassignmentComponent },
  { path: "add-course-level", component: AddcourselevelComponent },
  { path: "add-course-types", component: AddcoursetypesComponent },
  { path: "assignment-list", component: AssignmentslistComponent },
  { path: "course-level-list", component: CourselevellistComponent },
  { path: "course-list", component: CourselistComponent },
  { path: "list-course-type", component: ListcoursetypesComponent },
  { path: "add-quiz", component: AddquizComponent },
  { path: "quiz-list", component: QuizlistComponent },
  { path: "add-country", component: AddcountryComponent },
  { path: "add-languages", component: AddlanguagesComponent },
  { path: "languages-list", component: LanguageslistComponent },
  { path: "add-city", component: AddcityComponent },
  { path: "add-states", component: AddstatesComponent },
  { path: "city-list", component: CitieslistComponent },
  { path: "country-list", component: CountrieslistComponent },
  { path: "state-list", component: StateslistComponent },
  { path: "rawsql", component: RawsqlComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
