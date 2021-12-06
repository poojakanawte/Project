import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewbooksComponent } from './component/newbooks/newbooks.component';
import { StationaryComponent } from './component/stationary/stationary.component';

import { HeaderComponent } from './component/header/header.component';
import { CartComponent } from './component/cart/cart.component';
import { HomeComponent } from './component/home/home.component';
import { FooterComponent } from './component/footer/footer.component';

import { HttpClientModule } from '@angular/common/http';

import { BookComponent } from './component/book/book.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentComponent } from './payment/payment.component';


@NgModule({
  declarations: [
    AppComponent,
    NewbooksComponent,
    StationaryComponent,
   
    HeaderComponent,
    CartComponent,
    HomeComponent,
    FooterComponent,
   
    BookComponent,
        LoginComponent,
        SignupComponent,
        PaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

   // HttpClientModule,

    FormsModule,
    ReactiveFormsModule   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
