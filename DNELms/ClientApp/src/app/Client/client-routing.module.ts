import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { LoginComponent } from 'src/api-authorization/login/login.component';
import { ForgotComponent } from 'src/app/Auth/forgot/forgot.component';
import { ProfileComponent } from 'src/app/Auth/profile/profile.component';
import { RegisterComponent } from 'src/app/Auth/register/register.component';
import { ResendEmailConfirmComponent } from 'src/app/Auth/resend-email-confirm/resend-email-confirm.component';
import { CategoriesComponent } from './Pages/categories/categories.component';
import { CourseComponent } from './Pages/course/course.component';
import { HomeComponent } from './Pages/home/home.component';
import { MyCoursesComponent } from './Pages/my-courses/my-courses.component';
import { MyMessagesComponent } from './Pages/my-messages/my-messages.component';
import { MyWishListComponent } from './Pages/my-wish-list/my-wish-list.component';
import { PurchaseHistoryComponent } from './Pages/purchase-history/purchase-history.component';

const routes: Routes = [{ path: "login", component: LoginComponent, canActivate: [AuthorizeGuard] },
{ path: "", component: HomeComponent },
{ path: "register", component: RegisterComponent },
{ path: "forgot", component: ForgotComponent },
{ path: "re-confirm", component: ResendEmailConfirmComponent },
{ path: "profile", component: ProfileComponent },
{ path: "course", component: CourseComponent },
{ path: "categories", component: CategoriesComponent },
{ path: "mycourses", component: MyCoursesComponent },
{ path: "mywishlist", component: MyWishListComponent },
{ path: "mymessages", component: MyMessagesComponent },
{ path: "purchasehistory", component: PurchaseHistoryComponent },];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
