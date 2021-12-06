import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewbooksComponent } from './component/newbooks/newbooks.component';
import { StationaryComponent } from './component/stationary/stationary.component';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from './component/header/header.component';
import { CartComponent } from './component/cart/cart.component';
import { HomeComponent } from './component/home/home.component';
import { FooterComponent } from './component/footer/footer.component';
import { SignupComponent } from './signup/signup.component';
import { PaymentComponent } from './payment/payment.component';
import { BookComponent } from './component/book/book.component';

const routes: Routes = [ 
  { path:'', redirectTo: 'home', pathMatch:'full'},
  { path:'newbooks', component: NewbooksComponent},
 
  { path:'home', component: HomeComponent},
  { path:'stationary', component: StationaryComponent},
 
  { path:'cart', component:CartComponent},
  { path:'book', component:BookComponent},
  { path:'login', component:LoginComponent},
  { path:'signup', component:SignupComponent},
  { path:'payment', component:PaymentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
