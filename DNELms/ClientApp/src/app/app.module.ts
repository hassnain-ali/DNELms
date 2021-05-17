import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './Auth/login/login.component';
import { RegisterComponent } from './Auth/register/register.component';
import { ForgotComponent } from './Auth/forgot/forgot.component';
import { ResendEmailConfirmComponent } from './Auth/resend-email-confirm/resend-email-confirm.component';
import { ProfileComponent } from './Auth/profile/profile.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';

import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { UnauthorizedComponent } from './Errors/unauthorized/unauthorized.component';
import { NotFoundComponent } from './Errors/not-found/not-found.component';
import { OverlayModule } from '@angular/cdk/overlay';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForgotComponent,
    ResendEmailConfirmComponent,
    ProfileComponent,
    UnauthorizedComponent,
    NotFoundComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    OverlayModule,
    MatMenuModule,
    MatTooltipModule,
    MatSnackBarModule,
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
