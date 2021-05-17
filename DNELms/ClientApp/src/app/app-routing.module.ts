import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Admin_Routes } from '../app/Routes/admin-routes'
import { Client_Routes } from './Routes/client-routes';
import { ClientDefaultComponent } from './Client/client-default/client-default.component';
import { AdminComponent } from './admin/admin/admin.component';
import { NotFoundComponent } from './Errors/not-found/not-found.component';
import { UnauthorizedComponent } from './Errors/unauthorized/unauthorized.component';

const routes: Routes = [
  { path: "", component: ClientDefaultComponent, children: Client_Routes },

  { path: 'admin', component: AdminComponent, children: Admin_Routes },
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '/404', pathMatch: 'full' },
  { path: 'unauthorized', component: UnauthorizedComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
