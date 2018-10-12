import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ProductService } from './service/product.service';
import { DashboardComponent } from './view/dashboard/dashboard.component';
import { SellerService } from './service/seller.service';
import { SalesService } from './service/sales.service';
import { FormProductComponent } from './view/forms/form-product/form-product.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    FormProductComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgbModule.forRoot()
  ],
  providers: [ProductService, SellerService, SalesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
