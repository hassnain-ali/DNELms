import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientRoutingModule } from './client-routing.module';
import { ClientDefaultComponent } from './client-default/client-default.component';
import { FooterComponent } from './Layout/footer/footer.component';
import { LayoutComponent } from './Layout/layout/layout.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { HomeComponent } from './Pages/home/home.component';
import { CartComponent } from './Pages/cart/cart.component';
import { MatProgressBarModule } from '@angular/material/progress-bar';

@NgModule({
  declarations: [
    ClientDefaultComponent,
    LayoutComponent,
    FooterComponent,
    HomeComponent,
    CartComponent,
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    SlickCarouselModule,
    MatProgressBarModule
  ]
})
export class ClientModule { }
